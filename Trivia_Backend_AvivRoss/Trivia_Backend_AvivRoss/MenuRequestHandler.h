#pragma once
#include "IRequestHandler.h"
#include "LoggedUser.h"
#include "RequestHandlerFactory.h"
#include "RoomManager.h"
#include "StatisticsManager.h"

class RequestHandlerFactory;

class MenuRequestHandler : public IRequestHandler
{
public:

	MenuRequestHandler(LoggedUser user, RoomManager roomManager, StatisticsManager statsManager, RequestHandlerFactory reqHandlerFac);

	bool isRequestRelevant(RequestInfo req) override;
	RequestResult handleRequest(RequestInfo req) override;

	RequestResult signout(RequestInfo req);
	RequestResult getRooms(RequestInfo req);
	RequestResult getPlayersInRoom(RequestInfo req);
	RequestResult getPersonalStats(RequestInfo req);
	RequestResult getHighScore(RequestInfo req);
	RequestResult joinRoom(RequestInfo req);
	RequestResult createRoom(RequestInfo req);

private:
	LoggedUser m_user;
	RoomManager& m_roomManager;
	StatisticsManager& m_statisticsManager;
	RequestHandlerFactory& m_handlerFactory;

};

