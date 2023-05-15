#include "MenuRequestHandler.h"


MenuRequestHandler::MenuRequestHandler()
{
	
}

bool MenuRequestHandler::isRequestRelevant(RequestInfo req) const
{
	return true;
}
RequestResult MenuRequestHandler::handleRequest(RequestInfo req) const
{
	RequestResult res;
	return res;
}