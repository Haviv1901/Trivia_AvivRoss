#include "MenuRequestHandler.h"

#include "Helper.h"
#include "JsonResponsePacketSerializer.h"
#include "Responses.h"


MenuRequestHandler::MenuRequestHandler(LoggedUser user, RoomManager roomManager, StatisticsManager statsManager, RequestHandlerFactory reqHandlerFac)
	: m_handlerFactory(reqHandlerFac), m_user(user), m_roomManager(roomManager), m_statisticsManager(statsManager)
{
	
}

bool MenuRequestHandler::isRequestRelevant(RequestInfo req)
{
	if (req.id >= MENU_CODE && req.id < LAST_MENU_CODE)
	{
		return true;
	}
	return false;
}
RequestResult MenuRequestHandler::handleRequest(RequestInfo req)
{
	RequestResult res;
	res.newHandler = nullptr;

	try
	{
		if (!isRequestRelevant(req))
		{
			throw std::exception("Invalid Code.");
		}

		switch (req.id)
		{
		case(SIGNOUT_CODE):
			//res = signout(req);
			break;
		}


	}
	catch (std::exception e)
	{
		Helper::debugPrint(e.what());
		res = error(req, e.what());
	}
	catch (...)
	{
		res = error(req, "Could not parse message. pls send it in the correct format.");
	}
	return res;
}




/**
 * \brief error accored, return to communicator an error result.
 * \param req
 * \param errorMessage
 * \return
 */
RequestResult MenuRequestHandler::error(RequestInfo req, string errorMessage)
{
	RequestResult res;
	ErrorResponse errorRes;
	errorRes.messagge = Helper::stringToBuffer(errorMessage);
	res.respones = JsonResponsePacketSerializer::serializeResponse(errorRes);
	res.newHandler = nullptr;
	return res;
}