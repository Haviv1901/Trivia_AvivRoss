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
};

