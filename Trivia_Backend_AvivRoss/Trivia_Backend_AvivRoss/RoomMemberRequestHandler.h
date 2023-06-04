#pragma once
#include "IRequestHandler.h"
#include "RequestHandlerFactory.h"
#include "Room.h"
#include "RoomManager.h"

class RequestHandlerFactory;

class RoomMemberRequestHandler :
    public IRequestHandler
{

public:

	RoomMemberRequestHandler(Room room, LoggedUser user, RoomManager& roomManager, RequestHandlerFactory& reqHandlerFac);

	bool isRequestRelevant(RequestInfo req) override;
	RequestResult handleRequest(RequestInfo req) override;

	RequestResult leaveRoom(RequestInfo);
	RequestResult getRoomState(RequestInfo);

	// not in uml
	RequestResult error(RequestInfo req, string errorMessage, IRequestHandler* newHandler = nullptr);


private:
	Room m_room;
	LoggedUser m_user;
	RoomManager& m_roomManager;
	RequestHandlerFactory& m_handlerFactory;

};

