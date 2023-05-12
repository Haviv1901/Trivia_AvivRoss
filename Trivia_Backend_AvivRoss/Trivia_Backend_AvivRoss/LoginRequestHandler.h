#pragma once
#include <string>

#include "IRequestHandler.h"



class LoginRequestHandler : public IRequestHandler
{
public:

	LoginRequestHandler();

	bool isRequestRelevant(RequestInfo req) override;
	RequestResult handleRequest(RequestInfo req) override;
};

