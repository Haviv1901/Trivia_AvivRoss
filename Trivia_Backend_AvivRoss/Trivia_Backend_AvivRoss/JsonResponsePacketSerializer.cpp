#include "JsonResponsePacketSerializer.h"
#include "Helper.h"

using std::to_string;
using std::string;

Buffer createResponse(unsigned char code, Buffer data);

Buffer JsonResponsePacketSerializer::serializeResponse(ErrorResponse response)
{
	Buffer data = Helper::stringToBuffer("{\"message\":\"" + Helper::bufferToString(response.messagge) + "\"}");
	return createResponse(ERROR_CODE, data);
}

Buffer JsonResponsePacketSerializer::serializeResponse(LoginResponse response)
{
	Buffer data = Helper::stringToBuffer("{\"status\": " + std::to_string(response.status) + "}");
	return createResponse(LOGIN_CODE, data);
}

Buffer JsonResponsePacketSerializer::serializeResponse(SignupResponse response)
{
	Buffer data = Helper::stringToBuffer("{\"status\": " + std::to_string(response.status) + "}");
	return createResponse(SIGN_UP_CODE, data);
}

Buffer JsonResponsePacketSerializer::serializeResponse(LogoutResponse response)
{
	Buffer data = Helper::stringToBuffer("{\"status\": " + std::to_string(response.status) + "}");
	return createResponse(SIGNOUT_CODE, data);
}

Buffer JsonResponsePacketSerializer::serializeResponse(GetRoomsResponse response)
{
	string strData = "{\"Rooms\":\"";
	// list of rooms, like such : {Rooms: “room1, room2, ... roomN”}
	for (int i = 0; i < response.rooms.size(); i++) 
	{
		strData += response.rooms[i].name + ",";
	}
	strData += "\"}";
	Buffer data = Helper::stringToBuffer(strData);

	return createResponse(GET_ROOMS_CODE, data);
}

Buffer JsonResponsePacketSerializer::serializeResponse(GetPlayersInRoomResponse response)
{
	string strData = "{\"PlayersInRoom\":\"";
	// list of players, like such : {PlayersInRoom: “user1, user2, ... userN”}
	for (int i = 0; i < response.players.size(); i++)
	{
		strData += response.players[i] + ",";
	}
	strData += "\"}";
	Buffer data = Helper::stringToBuffer(strData);

	return createResponse(GET_PLAYERS_IN_ROOM_CODE, data);
}

Buffer JsonResponsePacketSerializer::serializeResponse(JoinRoomResponse response)
{
	Buffer data = Helper::stringToBuffer("{\"status\": " + std::to_string(response.status) + "}");
	return createResponse(JOIN_ROOM_CODE, data);
}

Buffer JsonResponsePacketSerializer::serializeResponse(CreateRoomResponse response)
{
	Buffer data = Helper::stringToBuffer("{\"Room Id\": " + std::to_string(response.roomId) + "}");
	return createResponse(CREATE_ROOM_CODE, data);
}

Buffer JsonResponsePacketSerializer::serializeResponse(GetHighScoreResponse response)
{
	string strData = "{\"HighScores\": {";
	// top 5 high scores, usernames and score. {HighScores: {user1: 5, user2: 4, user3: 3, user4: 2, user5: 1} }
	for (int i = 0; i < 5; i++)
	{
		strData += response.statistics[i].username + ": ";
		strData += to_string(response.statistics[i].playerScore) + ", ";
	}
	strData += "}}";
	Buffer data = Helper::stringToBuffer(strData);
	return createResponse(GET_HIGH_SCORE_CODE, data);
}

Buffer JsonResponsePacketSerializer::serializeResponse(GetPersonalStatsResponse response)
{
	// players full statistics, for example: {Average Answer Time: 5, Correct Answers: 5, Total Answers: 10, Total Games: 2, Total Score: 10}
	string strData = "{\"Average Answer Time\":";
	strData += std::to_string(response.statistics.avgAnswerTime) + ",";
	strData += "\"Correct Answers\":";
	strData += std::to_string(response.statistics.numOfCorrectAnswers) + ",";
	strData += "\"Total Answers\":";
	strData += std::to_string(response.statistics.numOfTotalAnswers) + ",";
	strData += "\"Total Games\":";
	strData += std::to_string(response.statistics.numOfPlayerGames) + ",";
	strData += "\"Total Score\":";
	strData += std::to_string(response.statistics.playerScore) + ",";
	strData += "\"}";

	Buffer data = Helper::stringToBuffer(strData);
	return createResponse(GET_PERSONAL_STATS_CODE, data);
}

/**
 * \brief function will generate a response packet with the given code and data, adding headers to the data.
 * \param code code of the msg
 * \param data data of the msg
 * \return Buffer to send straight to client, with headers and data
 */
Buffer createResponse(unsigned char code, Buffer data)
{
	int length = data.size();
	Buffer res;
	res.push_back(code); // insert code

	res.push_back((length >> 24) & 0xFF); // inserting 4 bytes of length
	res.push_back((length >> 16) & 0xFF);
	res.push_back((length >> 8) & 0xFF);
	res.push_back(length & 0xFF);

	res.insert(res.end(), data.begin(), data.end()); // connecting headers with data

	return res;
}