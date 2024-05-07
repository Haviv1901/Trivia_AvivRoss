#pragma once
#include <string>
#include "Consts.h"
#include "Responses.h"

using std::string;




class JsonResponsePacketSerializer
{
public:
	static Buffer serializeResponse(ErrorResponse response);
	static Buffer serializeResponse(LoginResponse response);
	static Buffer serializeResponse(SignupResponse response);

	//v2
	static Buffer serializeResponse(LogoutResponse response);
	static Buffer serializeResponse(GetRoomsResponse response);
	static Buffer serializeResponse(GetPlayersInRoomResponse response);
	static Buffer serializeResponse(JoinRoomResponse response);
	static Buffer serializeResponse(CreateRoomResponse response);
	static Buffer serializeResponse(GetHighScoreResponse response);
	static Buffer serializeResponse(GetPersonalStatsResponse response);

	//v3
	static Buffer serializeResponse(CloseRoomResponse response);
	static Buffer serializeResponse(StartGameResponse response);
	static Buffer serializeResponse(GetRoomStateResponse response);
	static Buffer serializeResponse(LeaveRoomResponse response);

	//v4
	static Buffer serializeResponse(SubmitAnswerResponse response);
	static Buffer serializeResponse(GetGameResultsResponse response);
	static Buffer serializeResponse(GetQuestionResponse response);
	static Buffer serializeResponse(LeaveGameResponse response);

	//v4.1

};

