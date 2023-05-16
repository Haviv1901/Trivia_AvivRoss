#include "Server.h"
#include "Helper.h"
#include "SqliteDataBase.h"

#include <iostream>
#include <string>
#include <thread>


// dtor ctor
Server::Server() : m_database(new SqliteDatabase()), m_handlerFactory(m_database), m_communicator(m_handlerFactory)
{
}

Server::~Server()
{
	
}

void Server::run()
{

	std::string str;
	std::thread tr(&Communicator::startHandleRequests, this->m_communicator); // server thread
	tr.detach();

	
	while (str != "Exit")
	{
		std::cin >> str;
	}
}