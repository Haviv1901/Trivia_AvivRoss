#pragma once
#include <map>
#include <WinSock2.h>
#include "IRequestHandler.h"
#include <deque>
#include <queue>
#include <mutex>
#include <condition_variable>
#include <WinSock2.h>



class Communicator
{
public:

	Communicator();
	~Communicator();

	void startHandleRequests();

	void bindAndListen();
	void handleNewClient();

private:
	SOCKET m_serverSocket;
	std::map<SOCKET, IRequestHandler*>;
};

