#include "RoomMemberRequestHandler.h"

#include "JsonResponsePacketSerializer.h"


RoomMemberRequestHandler::RoomMemberRequestHandler(Room room, LoggedUser user, RoomManager& roomManager, RequestHandlerFactory& reqHandlerFac) :
	m_room(room), m_user(user), m_roomManager(roomManager), m_handlerFactory(reqHandlerFac)
{}

bool RoomMemberRequestHandler::isRequestRelevant(RequestInfo req)
{
	if (req.id == LEAVE_ROOM_CODE || req.id == GET_ROOM_STATE_CODE)
	{
		return true;
	}
	return false;
}
RequestResult RoomMemberRequestHandler::handleRequest(RequestInfo req)
{
	if (!isRequestRelevant(req))
	{
		return error(req, "Invalid Code.");
	}

	switch (req.id)
	{
	case(LEAVE_ROOM_CODE):
		return leaveRoom(req);
		break;
	case(GET_ROOM_STATE_CODE):
		return getRoomState(req);
		break;
	}

}

RequestResult RoomMemberRequestHandler::leaveRoom(RequestInfo)
{
	RequestResult res;
	LeaveRoomResponse leaveRes;
	
	m_room.removeUser(m_user);
	leaveRes.status = 1;
	res.newHandler = m_handlerFactory.createMenuRequestHandler(m_user);
	res.respones = JsonResponsePacketSerializer::serializeResponse(leaveRes);

	return res;
}
RequestResult RoomMemberRequestHandler::getRoomState(RequestInfo)
{
	RequestResult res;
	GetRoomStateResponse getRoomRes;

	RoomData roomData = m_room.getData();

	getRoomRes.status = 1;
	getRoomRes.players = m_room.getAllUsers();
	getRoomRes.hasGameBegun = roomData.isActive;
	getRoomRes.questionCount = roomData.numOfQuestionsInGame;
	getRoomRes.answerTimeout = roomData.timePerQuestion;

	res.newHandler = this;
	res.respones = JsonResponsePacketSerializer::serializeResponse(getRoomRes);

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
	res.newHandler = this;
	return res;
}