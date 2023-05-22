#pragma once
#include "IRequestHandler.h"
#include "LoggedUser.h"
#include "RoomManager.h"
#include "StatisticsManager.h"
#include "LoginRequestHandler.h"

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

	// not in uml
	RequestResult error(RequestInfo req, string errorMessage);

private:
	LoggedUser m_user;
	RoomManager& m_roomManager;
	StatisticsManager& m_statisticsManager;
	RequestHandlerFactory& m_handlerFactory;
	static unsigned int m_idGenerator;

};

