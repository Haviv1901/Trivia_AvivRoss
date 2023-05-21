#pragma once
#include <string>
#include "IRequestHandler.h"
#include "Consts.h"

using std::string;



class JsonRequestPacketDeserializer
{
public:
	static LoginRequest deserializeLoginRequest(Buffer buffer);
	static SignupRequest deserializeSignupRequest(Buffer buffer);

	//v2
	static GetPlayersInRoomRequest deserializeGetPlayersRequest(Buffer buffer);
	static JoinRoomRequest deserializeJoinRoomRequest(Buffer buffer);
	static CreateRoomRequest deserializeCreateRoomRequest(Buffer buffer);
};

