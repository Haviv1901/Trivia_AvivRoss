#pragma once
#include "IRequestHandler.h"
class MenuRequestHandler : public IRequestHandler
{
public:

	MenuRequestHandler();

	bool isRequestRelevant(RequestInfo req) override;
	RequestResult handleRequest(RequestInfo req) override;

};

