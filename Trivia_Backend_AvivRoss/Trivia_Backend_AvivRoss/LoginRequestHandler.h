#pragma once
#include <string>

#include "IRequestHandler.h"
#include "RequestHandlerFactory.h"

class RequestHandlerFactory;

class LoginRequestHandler : public IRequestHandler
{
public:

	LoginRequestHandler(RequestHandlerFactory& handlerFactory);

	bool isRequestRelevant(RequestInfo req) override;
	RequestResult handleRequest(RequestInfo req) override;
	RequestResult login(RequestInfo req);
	RequestResult signup(RequestInfo req);

	// not in uml
	RequestResult error(RequestInfo req, string errorMessage);

private:
	RequestHandlerFactory& m_handlerFactory;
};

