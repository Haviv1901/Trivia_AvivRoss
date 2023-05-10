#include "LoginRequestHandler.h"
#include "Helper.h"
#include "Consts.h"

LoginRequestHandler::LoginRequestHandler()
{
	
}

bool LoginRequestHandler::isRequestRelevant(RequestInfo req)
{
	if(req.id == LOGIN_CODE || req.id == SIGN_UP_CODE)
	{
		return true;
	}
	return false;
}
RequestResult LoginRequestHandler::handleRequest(RequestInfo req)
{
	
	RequestResult res;
	res.newHandler = nullptr;
	res.respones = req.buffer;


	return res;
}