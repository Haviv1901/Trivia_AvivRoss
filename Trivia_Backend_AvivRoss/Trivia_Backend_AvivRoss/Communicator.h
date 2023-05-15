#pragma once
#include <map>
#include <WinSock2.h>
#include "LoginRequestHandler.h"

#if defined(_WIN32)
#define GETSOCKETERRNO() (WSAGetLastError())
#else
#define GETSOCKETERRNO() (errno)
#endif



class Communicator
{
public:

	Communicator(RequestHandlerFactory& handlerFactory);
	~Communicator();

	void startHandleRequests();

	void bindAndListen();
	void handleNewClient();

	void clientHandler(SOCKET client_socket);

private:
	SOCKET m_serverSocket;
	std::map<SOCKET, IRequestHandler*> m_clients;
	RequestHandlerFactory& m_handlerFactory;
};

