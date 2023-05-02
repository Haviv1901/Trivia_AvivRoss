#include "Communicator.h"
#include "Consts.h"
#include "Helper.cpp"
#include <numeric>
#include <exception>
#include <iostream>
#include <string>


Communicator::Communicator()
{
	// create socket handle
	m_serverSocket = ::socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	if (m_serverSocket == INVALID_SOCKET)
		throw std::exception(__FUNCTION__ " - socket");
}

Communicator::~Communicator()
{
	// close socket handle
	try
	{
		::closesocket(m_serverSocket);
	}
	catch (...) {}
}

void Communicator::startHandleRequests()
{
	bindAndListen();

	// create new thread for handling message
	/*std::thread tr(&MagshMessageServer::handleReceivedMessages, this);
	tr.detach();*/

	while (true)
	{
		// the main thread is only accepting clients 
		// and add then to the list of handlers
		debugPrint("accepting client...");
		handleNewClient();
	}

}

/**
 * \brief function will bind a port and will start listinig for requests.
 */
void Communicator::bindAndListen()
{
	// create socket
	m_serverSocket = ::socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	if (m_serverSocket == INVALID_SOCKET)
		throw std::exception(__FUNCTION__ " - socket");


	// do stuff that open the socket idk
	struct sockaddr_in sa = { 0 };
	sa.sin_port = htons(PORT);
	sa.sin_family = AF_INET;
	sa.sin_addr.s_addr = IFACE;
	// again stepping out to the global namespace
	if (::bind(m_serverSocket, (struct sockaddr*)&sa, sizeof(sa)) == SOCKET_ERROR)
		throw std::exception(__FUNCTION__ " - bind");
	debugPrint("binded");

	if (::listen(m_serverSocket, SOMAXCONN) == SOCKET_ERROR)
		throw std::exception(__FUNCTION__ " - listen");
	debugPrint("listening...");

}
void Communicator::handleNewClient()
{
	SOCKET client_socket = accept(m_serverSocket, NULL, NULL);
	if (client_socket == INVALID_SOCKET)
		throw std::exception(__FUNCTION__);

	m_clients.insert({ client_socket,  new LoginRequestHandler });

	debugPrint("Client accepted !");
	// create new thread for client	and detach from it
	std::thread tr(&Communicator::clientHandler, this, client_socket);
	tr.detach();

}


void Communicator::clientHandler(SOCKET client_socket)
{
	try
	{
		sendData(client_socket, "Hello");
		while(true)
		{
			
		} // stay ideal
	}
	catch (const std::exception& e)
	{
		std::cout << "Exception was catch in function clientHandler. socket=" << client_socket << ", what=" << e.what() << std::endl;
	}
	closesocket(client_socket);
}