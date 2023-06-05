#include "RoomMemberRequestHandler.h"

#include "JsonResponsePacketSerializer.h"


RoomMemberRequestHandler::RoomMemberRequestHandler(Room room, LoggedUser user, RoomManager& roomManager, RequestHandlerFactory& reqHandlerFac) :
	m_room(room), m_user(user), m_roomManager(roomManager), m_handlerFactory(reqHandlerFac)
{}

bool RoomMemberRequestHandler::isRequestRelevant(RequestInfo req)
{
	if (req.id == CLOSE_OR_LEAVE_ROOM_CODE || req.id == GET_ROOM_STATE_CODE)
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

	try
	{
		switch (req.id)
		{
		case(CLOSE_OR_LEAVE_ROOM_CODE):
			return leaveRoom(req);
			break;
		case(GET_ROOM_STATE_CODE):
			return getRoomState(req);
			break;
		}
	}
	catch (...)
	{
		return error(req, "Room Closed", m_handlerFactory.createMenuRequestHandler(m_user));
	}

}

RequestResult RoomMemberRequestHandler::leaveRoom(RequestInfo)
{
	RequestResult res;
	LeaveRoomResponse leaveRes;


	m_roomManager.getRoom(m_room.getData().id).removeUser(m_user);
	leaveRes.status = 1;
	res.newHandler = m_handlerFactory.createMenuRequestHandler(m_user);
	res.respones = JsonResponsePacketSerializer::serializeResponse(leaveRes);

	return res;
}
RequestResult RoomMemberRequestHandler::getRoomState(RequestInfo req)
{
	RequestResult res;
	GetRoomStateResponse getRoomRes;

	try
	{
		m_room = m_roomManager.getRoom(m_room.getData().id);

		RoomData roomData = m_room.getData();

		getRoomRes.status = 1;
		getRoomRes.players = m_room.getAllUsers();
		getRoomRes.hasGameBegun = roomData.isActive;
		getRoomRes.questionCount = roomData.numOfQuestionsInGame;
		getRoomRes.answerTimeout = roomData.timePerQuestion;

		if (roomData.isActive) // if game started, set handler to game handler
		{
			res.newHandler = m_handlerFactory.createGameRequestHandler(m_room, m_user);
		}
		else
		{
			res.newHandler = this;
		}

		res.respones = JsonResponsePacketSerializer::serializeResponse(getRoomRes);
	}
	catch (const std::exception&)
	{
		return error(req, "Room Closed", m_handlerFactory.createMenuRequestHandler(m_user));
	}


	return res;
}



/**
 * \brief error accored, return to communicator an error result.
 * \param req
 * \param errorMessage
 * \return
 */
RequestResult RoomMemberRequestHandler::error(RequestInfo req, string errorMessage, IRequestHandler* newHandler)
{
	RequestResult res;
	ErrorResponse errorRes;
	errorRes.messagge = Helper::stringToBuffer(errorMessage);
	res.respones = JsonResponsePacketSerializer::serializeResponse(errorRes);
	if (newHandler == nullptr)
	{
		res.newHandler = this;
	}
	else
	{
		res.newHandler = newHandler;
	}
	return res;
}