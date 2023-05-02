#pragma once
#include "Communicator.h"
class Server
{

public:

	// dtor ctor
	Server();
	~Server();

	void run();

private:
	Communicator m_communicator;
};

