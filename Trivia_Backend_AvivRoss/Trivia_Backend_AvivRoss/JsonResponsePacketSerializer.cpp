#include "JsonResponsePacketSerializer.h"
#include "Helper.h"
#include "nlohmann/json.hpp"

using json = nlohmann::json;
json parseToJson(Buffer buffer);

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
	string strData = "{";
	// {roomN: ID, RoomN:Id, ... RoomN:ID}
	for (int i = 0; i < response.rooms.size(); i++) 
	{
		strData += "\"" + response.rooms[i].name + "\":";
		strData += to_string(response.rooms[i].id) + ",";
	}
	if (response.rooms.size() > 0)
	{
		strData.pop_back();
	}
	strData += "}";
	Buffer data = Helper::stringToBuffer(strData);

	return createResponse(GET_ROOMS_CODE, data);
}

Buffer JsonResponsePacketSerializer::serializeResponse(GetPlayersInRoomResponse response)
{
	string strData = "{\"PlayersInRoom\":\"";
	// list of players, like such : {PlayersInRoom: “user1, user2, ... userN”}
	for (int i = 0; i < response.players.size(); i++)
	{
		strData += response.players[i] + ", ";
	}
	strData.pop_back();
	strData.pop_back();
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
	string strData = "{";

	for (int i = 0; i < response.statistics.size(); i++)
	{
		strData += "\"" + response.statistics[i].username + "\":";
		strData += to_string(response.statistics[i].playerScore) + ",";
	}
	if (response.statistics.size() > 0)
	{
		strData.pop_back();
	}

	strData += "}";
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
	strData += std::to_string(response.statistics.playerScore) + "}";

	Buffer data = Helper::stringToBuffer(strData);
	return createResponse(GET_PERSONAL_STATS_CODE, data);
}


Buffer JsonResponsePacketSerializer::serializeResponse(CloseRoomResponse response)
{
	json res;
	res["status"] = response.status;

	return createResponse(CLOSE_OR_LEAVE_ROOM_CODE, Helper::stringToBuffer(res.dump()));
}
Buffer JsonResponsePacketSerializer::serializeResponse(StartGameResponse response)
{
	json res;
	res["status"] = response.status;

	return createResponse(START_GAME_CODE, Helper::stringToBuffer(res.dump()));
}
Buffer JsonResponsePacketSerializer::serializeResponse(GetRoomStateResponse response)
{
	json res;
	res["status"] = response.status;
	res["hasGameBegun"] = response.hasGameBegun;
	res["Players"] = response.players;
	res["Question Count"] = response.questionCount;
	res["Answer Timeout"] = response.answerTimeout;

	return createResponse(GET_ROOMS_CODE, Helper::stringToBuffer(res.dump()));
}
Buffer JsonResponsePacketSerializer::serializeResponse(LeaveRoomResponse response)
{
	json res;
	res["status"] = response.status;

	return createResponse(CLOSE_OR_LEAVE_ROOM_CODE, Helper::stringToBuffer(res.dump()));
}

//v4

Buffer JsonResponsePacketSerializer::serializeResponse(SubmitAnswerResponse response)
{
	json res;
	res["status"] = response.status;
	res["correctAnswerId"] = response.correctAnswerId;

	return createResponse(SUBMIT_ANSWER_CODE, Helper::stringToBuffer(res.dump()));
}
Buffer JsonResponsePacketSerializer::serializeResponse(GetGameResultsResponse response)
{
	json res;
	res["status"] = response.status;
	for (auto user : response.results)
	{
		json j;
		j["correctAnswerCount"] = user.correctAnswerCount;
		j["wrongAnswerCount"] = user.wrongAnswerCount;
		j["averageAnswerTime"] = user.averageAnswerTime;
		j["Score"] = user.score;
		res[user.username] = j;
	}

	return createResponse(GET_GAME_RESULT_CODE, Helper::stringToBuffer(res.dump()));
}
Buffer JsonResponsePacketSerializer::serializeResponse(GetQuestionResponse response)
{
	json res;
	res["status"] = response.status;
	res["Question"] = response.question;

	res["0"] = response.answers[0];
	res["1"] = response.answers[1];
	res["2"] = response.answers[2];
	res["3"] = response.answers[3];


	return createResponse(GET_QUESTION_CODE, Helper::stringToBuffer(res.dump()));
}
Buffer JsonResponsePacketSerializer::serializeResponse(LeaveGameResponse response)
{
	json res;
	res["status"] = response.status;

	return createResponse(LEAVE_GAME_CODE, Helper::stringToBuffer(res.dump()));
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


