#include "MenuRequestHandler.h"

#include "Helper.h"
#include "JsonRequestPacketDeserializer.h"
#include "JsonResponsePacketSerializer.h"
#include "Responses.h"

unsigned int MenuRequestHandler::m_idGenerator = 1;

MenuRequestHandler::MenuRequestHandler(LoggedUser user, RoomManager& roomManager, StatisticsManager& statsManager, RequestHandlerFactory& reqHandlerFac)
	: m_user(user), m_roomManager(roomManager), m_statisticsManager(statsManager), m_handlerFactory(reqHandlerFac)
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

	try
	{
		if (!isRequestRelevant(req))
		{
			throw std::exception("Invalid Code.");
		}

		switch (req.id)
		{
		case(SIGNOUT_CODE):
			res = signout(req);
			break;
		case(GET_ROOMS_CODE):
			res = getRooms(req);
			break;
		case(GET_PLAYERS_IN_ROOM_CODE):
			res = getPlayersInRoom(req);
			break;
		case(GET_PERSONAL_STATS_CODE):
			res = getPersonalStats(req);
			break;
		case(GET_HIGH_SCORE_CODE):
			res = getHighScore(req);
			break;
		case(JOIN_ROOM_CODE):
			res = joinRoom(req);
			break;
		case(CREATE_ROOM_CODE):
			res = createRoom(req);
			break;

		default:
			throw std::exception("Error accored, please try again.");
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



RequestResult MenuRequestHandler::signout(RequestInfo req)
{
	RequestResult res;

	if(!m_handlerFactory.getLoginManager().logout(m_user.getUsername()))
	{
		throw std::exception("Logout failed.");
	}

	LogoutResponse logoutRes;
	logoutRes.status = 1;

	res.respones = JsonResponsePacketSerializer::serializeResponse(logoutRes);
	res.newHandler = m_handlerFactory.createLoginRequestHandler();
	return res;
}
RequestResult MenuRequestHandler::getRooms(RequestInfo req)
{
	RequestResult res;
	GetRoomsResponse response;

	vector<Room> rooms = m_handlerFactory.getRoomManager().getRooms();

	for (Room room : rooms)
	{
		response.rooms.push_back(room.getData());
	}
	
	response.status = 1;

	res.respones = JsonResponsePacketSerializer::serializeResponse(response);
	res.newHandler = m_handlerFactory.createMenuRequestHandler(m_user); // return user to login menu
	return res;
}
RequestResult MenuRequestHandler::getPlayersInRoom(RequestInfo req)
{
	RequestResult res;
	GetPlayersInRoomRequest request = JsonRequestPacketDeserializer::deserializeGetPlayersRequest(req.buffer);
	GetPlayersInRoomResponse response;

	response.players = m_roomManager.getRoom(request.roomId).getAllUsers();

	res.respones = JsonResponsePacketSerializer::serializeResponse(response);
	res.newHandler = m_handlerFactory.createMenuRequestHandler(m_user); 
	return res;
}
RequestResult MenuRequestHandler::getPersonalStats(RequestInfo req)
{
	RequestResult res;
	GetPersonalStatsResponse response;

	response.statistics = m_statisticsManager.getUserStatistics(m_user.getUsername());
	response.status = 1;

	res.respones = JsonResponsePacketSerializer::serializeResponse(response);
	res.newHandler = m_handlerFactory.createMenuRequestHandler(m_user);
	return res;
}
RequestResult MenuRequestHandler::getHighScore(RequestInfo req)
{
	RequestResult res;
	GetHighScoreResponse response;

	response.statistics = m_handlerFactory.getStatisticsManager().getHighScore();

	res.respones = JsonResponsePacketSerializer::serializeResponse(response);
	res.newHandler = m_handlerFactory.createMenuRequestHandler(m_user);
	return res;
}
RequestResult MenuRequestHandler::joinRoom(RequestInfo req)
{
	RequestResult res;
	JoinRoomRequest request = JsonRequestPacketDeserializer::deserializeJoinRoomRequest(req.buffer);
	JoinRoomResponse response;

	m_handlerFactory.getRoomManager().getRoom(request.roomId).addUser(m_user);

	response.status = 1;
	res.respones = JsonResponsePacketSerializer::serializeResponse(response);
	res.newHandler = m_handlerFactory.createMenuRequestHandler(m_user);
	return res;
}
RequestResult MenuRequestHandler::createRoom(RequestInfo req)
{
	RequestResult res;
	CreateRoomRequest request = JsonRequestPacketDeserializer::deserializeCreateRoomRequest(req.buffer);
	CreateRoomResponse response;
	unsigned int roomId = ++m_idGenerator;
	m_roomManager.createRoom(m_user, RoomData{ roomId , request.roomName, request.maxUsers, request.questionCount, request.answerTimeout, 1 });

	response.roomId = roomId;
	res.respones = JsonResponsePacketSerializer::serializeResponse(response);
	res.newHandler = m_handlerFactory.createMenuRequestHandler(m_user);
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
