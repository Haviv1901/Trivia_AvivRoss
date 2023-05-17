#include "MenuRequestHandler.h"


MenuRequestHandler::MenuRequestHandler(LoggedUser user, RoomManager roomManager, StatisticsManager statsManager, RequestHandlerFactory reqHandlerFac)
	: m_handlerFactory(reqHandlerFac), m_user(user), m_roomManager(roomManager), m_statisticsManager(statsManager)
{
	
}

bool MenuRequestHandler::isRequestRelevant(RequestInfo req)
{
	if(req.id == MENU_CODE)
	return true;
}
RequestResult MenuRequestHandler::handleRequest(RequestInfo req)
{
	RequestResult res;
	return res;
}



RequestResult signout(RequestInfo req);
RequestResult getRooms(RequestInfo req);
RequestResult getPlayersInRoom(RequestInfo req);
RequestResult getPersonalStats(RequestInfo req);
RequestResult getHighScore(RequestInfo req);
RequestResult joinRoom(RequestInfo req);
RequestResult createRoom(RequestInfo req);