#include "Communicator.h"
#include "Consts.h"
#include <numeric>
#include <exception>
#include <iostream>
#include <mutex>
#include <string>
#include <thread>
#include <ctime>
#include "Helper.h"


using std::string;
using std::cout;
using std::mutex;

std::mutex mtx;

//void debugPrint(string msg);
//void sendData(const SOCKET sc, const std::string message);


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

	if(m_clients.size() > 0) // clearing the allocated memory in the map.
	{
		for (auto pair : m_clients)
		{
			delete pair.second;
		}
	}

}

void Communicator::startHandleRequests()
{
	bindAndListen();

	// create new thread for handling message 
	/*std::thread tr(&MagshMessageServer::handleReceivedMessages, this);
	tr.detach();*/

	while (true)
	{
		// this thread is only accepting clients 
		// and add then to the list of handlers
		Helper::debugPrint("accepting client...");
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
	Helper::debugPrint("binded");

	if (::listen(m_serverSocket, SOMAXCONN) == SOCKET_ERROR)
		throw std::exception(__FUNCTION__ " - listen");
	Helper::debugPrint("listening...");

}
void Communicator::handleNewClient()
{
	SOCKET client_socket = accept(m_serverSocket, NULL, NULL);
	if (client_socket == INVALID_SOCKET)
		throw std::exception(__FUNCTION__);

	mtx.lock();
	m_clients.insert({ client_socket,  new LoginRequestHandler });
	mtx.unlock();

	Helper::debugPrint("Client accepted !");
	// create new thread for client	and detach from it
	std::thread tr(&Communicator::clientHandler, this, client_socket);
	tr.detach();

}


void Communicator::clientHandler(SOCKET client_socket)
{

	try
	{
		while (true)
		{
			int i = 0;
			int code, length;

			code = Helper::getMessageTypeCode(client_socket);
			length = Helper::getLengthFromSocket(client_socket);
			Buffer data = Helper::getDataFromSocketBuffer(client_socket, length);

			RequestInfo msg;
			msg.buffer = data;
			msg.id = code;
			msg.receivalTime = time(nullptr);



		}
	}
	catch (const std::exception& e)
	{
		std::cout << "Exception was catch in function clientHandler. socket=" << client_socket << ", what=" << e.what() << std::endl;
	}
	closesocket(client_socket);
}



