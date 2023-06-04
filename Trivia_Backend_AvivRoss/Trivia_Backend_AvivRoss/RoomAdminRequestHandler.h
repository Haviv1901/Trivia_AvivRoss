#pragma once
#include "IRequestHandler.h"
#include "RequestHandlerFactory.h"
#include "Room.h"
#include "RoomManager.h"

class RoomAdminRequestHandler :
    public IRequestHandler
{

public:

	RoomAdminRequestHandler(Room room, LoggedUser user, RoomManager& roomManager, RequestHandlerFactory& reqHandlerFac);

	bool isRequestRelevant(RequestInfo req) override;
	RequestResult handleRequest(RequestInfo req) override;

	RequestResult closeRoom(RequestInfo);
	RequestResult startGame(RequestInfo);
	RequestResult getRoomState(RequestInfo);

	RequestResult error(RequestInfo req, string errorMessage);

private:
	Room m_room;
	LoggedUser m_user;
	RoomManager& m_roomManager;
	RequestHandlerFactory& m_handlerFactory;

};

