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
	std::string str;
//	std::thread tr(&Communicator::startHandleRequests, this);
//	tr.detach();

	
	while (str != "Exit")
	{
		std::cin >> str;
	}
}