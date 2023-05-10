#include "LoginRequestHandler.h"
#include "Helper.h"
#include "Consts.h"
#include "JsonRequestPacketDeserializer.h"
#include "JsonResponsePacketSerializer.h"

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

	if(!isRequestRelevant(req))
	{
		throw std::exception("invalid request, pls send login or signup request");
	}

	RequestResult res;
	res.newHandler = nullptr;

	if (req.id == LOGIN_CODE)
	{
		LoginRequest loginReq = JsonRequestPacketDeserializer::deserializeLoginRequest(req.buffer);
		LoginResponse loginRes;
		Helper::debugPrint("login msg recv, passwod: " + loginReq.password + " username: " + loginReq.username);
		loginRes.status = 1;
		res.respones = JsonResponsePacketSerializer::serializeResponse(loginRes);
	}
	else if (req.id == SIGN_UP_CODE)
	{
		SignupRequest signupReq = JsonRequestPacketDeserializer::deserializeSignupRequest(req.buffer);
		SignupResponse signupRes;
		Helper::debugPrint("signup msg recv, passwod: " + signupReq.password + " username: " + signupReq.username + " email: " + signupReq.email);
		signupRes.status = 1;
		res.respones = JsonResponsePacketSerializer::serializeResponse(signupRes);
	}
	return res;
}