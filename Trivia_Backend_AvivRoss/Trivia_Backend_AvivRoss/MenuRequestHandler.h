#pragma once
#include "IRequestHandler.h"
class MenuRequestHandler : public IRequestHandler
{
public:

	MenuRequestHandler();

	bool isRequestRelevant(RequestInfo req) const override;
	RequestResult handleRequest(RequestInfo req) const override;

};

