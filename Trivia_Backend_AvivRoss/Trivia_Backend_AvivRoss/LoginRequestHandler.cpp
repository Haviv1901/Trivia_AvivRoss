#include "LoginRequestHandler.h"
#include "Helper.h"
#include "Consts.h"

LoginRequestHandler::LoginRequestHandler()
{
	
}

bool LoginRequestHandler::isRequestRelevant(RequestInfo req)
{
	int code = req.buffer[0]; // first byte is the code.
	if(code == LOGIN_CODE || code == SIGN_UP_CODE)
	{
		return true;
	}
	return false;
}
RequestInfo LoginRequestHandler::handleRequest(RequestInfo req)
{
	int msg_length = ((static_cast<uint32_t>(req.buffer[1]) << 24)
	| (static_cast<uint32_t>(req.buffer[2]) << 16)
	| (static_cast<uint32_t>(req.buffer[3]) << 8)
	| (static_cast<uint32_t>(req.buffer[4]))); // converting 4 bytes of msg length to int
	string msg = "";
	int i = 0;
	for (i = 5; i < msg_length; i++)
	{
		msg += req.buffer[i] + "";
	}

	// then continue to do stuf ??? idk TODO: contiue this function
	return req;
}