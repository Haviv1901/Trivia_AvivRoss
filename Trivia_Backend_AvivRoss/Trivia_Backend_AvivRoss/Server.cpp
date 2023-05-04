#include "Server.h"
#include "Helper.h"

#include <iostream>
#include <string>
#include <thread>


// dtor ctor
Server::Server()
{

	m_communicator = Communicator();

}
Server::~Server()
{
	
}

void Server::run()
{


	// start listening
	m_communicator.bindAndListen();

	// create new thread for handling message
	//std::thread tr(&Communicator::message handler, m_communicator);
	//tr.detach();


	while (true)
	{
		// the main thread is only accepting clients 
		// and add then to the list of handlers
		debugPrint("accepting client...");
		m_communicator.handleNewClient();
	}
}