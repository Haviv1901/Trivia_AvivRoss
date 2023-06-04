#include "RoomAdminRequestHandler.h"
#include "Consts.h"
#include "JsonResponsePacketSerializer.h"


RoomAdminRequestHandler::RoomAdminRequestHandler(Room room, LoggedUser user, RoomManager& roomManager, RequestHandlerFactory& reqHandlerFac)
	: m_room(room), m_user(user), m_roomManager(roomManager), m_handlerFactory(reqHandlerFac)
{
}

bool RoomAdminRequestHandler::isRequestRelevant(RequestInfo req)
{
	if (req.id == CLOSE_OR_LEAVE_ROOM_CODE || req.id == START_GAME_CODE || req.id == GET_ROOM_STATE_CODE)
	{
		return true;
	}
	return false;
}
RequestResult RoomAdminRequestHandler::handleRequest(RequestInfo req)
{
	if (!isRequestRelevant(req))
	{
		return error(req, "Invalid Code.");
	}

	switch (req.id)
	{
	case(CLOSE_OR_LEAVE_ROOM_CODE):
		return closeRoom(req);
		break;
	case(START_GAME_CODE):
		return startGame(req);
		break;
	case(GET_ROOM_STATE_CODE):
		return getRoomState(req);
		break;
	}
}

RequestResult RoomAdminRequestHandler::closeRoom(RequestInfo)
{
	RequestResult res;
	CloseRoomResponse closeRoomRes;

	m_room = m_roomManager.getRoom(m_room.getData().id);

	m_roomManager.deleteRoom(m_room.getData().id);
	closeRoomRes.status = 1;
	res.newHandler = m_handlerFactory.createMenuRequestHandler(m_user);
	res.respones = JsonResponsePacketSerializer::serializeResponse(closeRoomRes);

	return res;
}
RequestResult RoomAdminRequestHandler::startGame(RequestInfo)
{
	RequestResult res;
	StartGameResponse startGameRes;

	m_roomManager.getRoom(m_room.getData().id).getData().isActive = 1;
	startGameRes.status = 1;
	res.newHandler = this;
	res.respones = JsonResponsePacketSerializer::serializeResponse(startGameRes);

	return res;
}
RequestResult RoomAdminRequestHandler::getRoomState(RequestInfo)
{
	RequestResult res;
	GetRoomStateResponse getRoomRes;

	m_room = m_roomManager.getRoom(m_room.getData().id);

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
RequestResult RoomAdminRequestHandler::error(RequestInfo req, string errorMessage)
{
	RequestResult res;
	ErrorResponse errorRes;
	errorRes.messagge = Helper::stringToBuffer(errorMessage);
	res.respones = JsonResponsePacketSerializer::serializeResponse(errorRes);
	res.newHandler = this;
	return res;
}