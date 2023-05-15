#pragma once
#include <string>

#include "IRequestHandler.h"
#include "RequestHandlerFactory.h"


class LoginRequestHandler : public IRequestHandler
{
public:

	LoginRequestHandler();

	bool isRequestRelevant(RequestInfo req) const override;
	RequestResult handleRequest(RequestInfo req) const override;
	RequestResult login(RequestInfo req);
	RequestResult signup(RequestInfo req);

private:
	RequestHandlerFactory& m_handlerFactory;
};

