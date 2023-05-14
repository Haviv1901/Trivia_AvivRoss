#pragma once
#include "Communicator.h"
#include "IDatabase.h"
class Server
{

public:

	// dtor ctor
	Server();
	~Server();

	void run();

private:
	Communicator m_communicator;
	IDatabase* m_database;
	RequestHandlerFactory m_handlerFactory;
};

