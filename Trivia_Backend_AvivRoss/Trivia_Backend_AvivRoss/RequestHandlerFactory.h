#pragma once
#include "LoginManager.h"
#include "LoginRequestHandler.h"

class RequestHandlerFactory
{
public:

	RequestHandlerFactory();

	LoginRequestHandler* creaateLoginRequestHandler();
	LoginManager& getLoginManager();
};

