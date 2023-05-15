#include "LoginRequestHandler.h"
#include "Helper.h"
#include "Consts.h"
#include "JsonRequestPacketDeserializer.h"
#include "JsonResponsePacketSerializer.h"
#include "MenuRequestHandler.h"


LoginRequestHandler::LoginRequestHandler()
{
}

bool LoginRequestHandler::isRequestRelevant(RequestInfo req) const
{
	if(req.id == LOGIN_CODE || req.id == SIGN_UP_CODE)
	{
		return true;
	}
	return false;
}
RequestResult LoginRequestHandler::handleRequest(RequestInfo req) const
{
	RequestResult res;
	res.newHandler = nullptr;

	try
	{
		if (!isRequestRelevant(req))
		{
			ErrorResponse errorRes;
			errorRes.messagge = Helper::stringToBuffer("Please send a Login code (1) or a Sign up code. (2)");
			res.respones = JsonResponsePacketSerializer::serializeResponse(errorRes);
		}
		else if (req.id == LOGIN_CODE)
		{
			LoginRequest loginReq = JsonRequestPacketDeserializer::deserializeLoginRequest(req.buffer);
			Helper::debugPrint("login msg recv, passwod: " + loginReq.password + " username: " + loginReq.username);
			if(!m_handlerFactory.getLoginManager().login(loginReq.username, loginReq.password)) // login user
			{
				throw std::exception("Error logging in.");
			}
			LoginResponse loginRes;
			Helper::debugPrint("login succesfully.");
			res.respones = JsonResponsePacketSerializer::serializeResponse(loginRes);
			res.newHandler = new MenuRequestHandler();

		}
		else if (req.id == SIGN_UP_CODE)
		{
			SignupRequest signupReq = JsonRequestPacketDeserializer::deserializeSignupRequest(req.buffer);
			SignupResponse signupRes;
			Helper::debugPrint("signup msg recv, passwod: " + signupReq.password + " username: " + signupReq.username + " email: " + signupReq.email);
			signupRes.status = 1;
			res.respones = JsonResponsePacketSerializer::serializeResponse(signupRes);
		}
	}
	catch(std::exception e)
	{
		ErrorResponse errorRes;
		Helper::debugPrint(e.what());
		errorRes.messagge = Helper::stringToBuffer(e.what());
		res.respones = JsonResponsePacketSerializer::serializeResponse(errorRes);
	}
	catch(...)
	{
		ErrorResponse errorRes;
		errorRes.messagge = Helper::stringToBuffer("Could not parse message. pls send it in the correct format.");
		res.respones = JsonResponsePacketSerializer::serializeResponse(errorRes);
	}
	return res;
}