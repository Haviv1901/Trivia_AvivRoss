#include "LoginRequestHandler.h"
#include "Helper.h"
#include "Consts.h"
#include "JsonRequestPacketDeserializer.h"
#include "JsonResponsePacketSerializer.h"
#include "MenuRequestHandler.h"


LoginRequestHandler::LoginRequestHandler(RequestHandlerFactory& handlerFactory) : m_handlerFactory(handlerFactory)
{
}

/**
 * \brief checks if the request is a login or a register
 * \param req 
 * \return 
 */
bool LoginRequestHandler::isRequestRelevant(RequestInfo req) 
{
	if(req.id == LOGIN_CODE || req.id == SIGN_UP_CODE)
	{
		return true;
	}
	return false;
}

/**
 * \brief handle the login / signup request
 * \param req 
 * \return 
 */
RequestResult LoginRequestHandler::handleRequest(RequestInfo req) 
{
	RequestResult res;
	res.newHandler = nullptr;

	try
	{
		if (!isRequestRelevant(req))
		{
			res = error(req, "Please send a Login code (1) or a Sign up code. (2)");
		}
		else if (req.id == LOGIN_CODE)
		{
			res = login(req);
		}
		else if (req.id == SIGN_UP_CODE)
		{
			res = signup(req);
		}
	}
	catch(std::exception e)
	{
		Helper::debugPrint(e.what());
		res = error(req, e.what());
	}
	catch(...)
	{
		res = error(req, "Could not parse message. pls send it in the correct format.");
	}
	return res;
}

/**
 * \brief login user
 * \param req 
 * \return 
 */
RequestResult LoginRequestHandler::login(RequestInfo req)
{
	RequestResult res;
	LoginRequest loginReq = JsonRequestPacketDeserializer::deserializeLoginRequest(req.buffer);
	if (!m_handlerFactory.getLoginManager().login(loginReq.username, loginReq.password)) // login user
	{
		throw std::exception("Username or password do not match.");
	}
	Helper::debugPrint("login succesfully.");
	LoginResponse loginRes;
	loginRes.status = 1;
	res.respones = JsonResponsePacketSerializer::serializeResponse(loginRes);
	res.newHandler = m_handlerFactory.createMenuRequestHandler(LoggedUser{ loginReq.username });
	return res;
}

/**
 * \brief sign in user
 * \param req
 * \return
 */
RequestResult LoginRequestHandler::signup(RequestInfo req)
{
	RequestResult res;
	SignupRequest signupReq = JsonRequestPacketDeserializer::deserializeSignupRequest(req.buffer);
	if (!m_handlerFactory.getLoginManager().signup(signupReq.email, signupReq.username, signupReq.password)) // sign-up user
	{
		throw std::exception("Error signing in.");
	}
	SignupResponse signupRes;
	signupRes.status = 1;
	res.respones = JsonResponsePacketSerializer::serializeResponse(signupRes);
	res.newHandler = m_handlerFactory.createMenuRequestHandler(LoggedUser{ signupReq.username });
	return res;
}

/**
 * \brief error accored, return to communicator an error result.
 * \param req
 * \param errorMessage 
 * \return 
 */
RequestResult LoginRequestHandler::error(RequestInfo req, string errorMessage)
{
	RequestResult res;
	ErrorResponse errorRes;
	errorRes.messagge = Helper::stringToBuffer(errorMessage);
	res.respones = JsonResponsePacketSerializer::serializeResponse(errorRes);
	res.newHandler = nullptr;
	return res;
}