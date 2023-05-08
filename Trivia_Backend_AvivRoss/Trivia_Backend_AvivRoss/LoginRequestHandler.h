#pragma once
#include <string>

#include "IRequestHandler.h"



class LoginRequestHandler : public IRequestHandler
{
public:

	LoginRequestHandler();

	bool isRequestRelevant(RequestInfo req) override;
	RequestInfo handleRequest(RequestInfo req) override;
};

