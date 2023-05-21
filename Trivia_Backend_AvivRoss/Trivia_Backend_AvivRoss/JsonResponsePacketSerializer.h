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

};

