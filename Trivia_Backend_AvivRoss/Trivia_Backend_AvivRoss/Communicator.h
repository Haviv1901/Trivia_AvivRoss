#pragma once
#include <map>
#include <WinSock2.h>
#include "LoginRequestHandler.h"



class Communicator
{
public:

	Communicator();
	~Communicator();

	void startHandleRequests();

	void bindAndListen();
	void handleNewClient();

	void clientHandler(SOCKET client_socket);

private:
	SOCKET m_serverSocket;
	std::map<SOCKET, IRequestHandler*> m_clients;
};

