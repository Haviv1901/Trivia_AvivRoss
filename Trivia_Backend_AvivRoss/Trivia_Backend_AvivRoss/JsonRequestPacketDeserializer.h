#pragma once
#include <string>
#include "IRequestHandler.h"

using std::string;



class JsonRequestPacketDeserializer
{
public:
	static LoginRequest deserializeLoginRequest(string& Buffer);
	static SignupRequest deserializeSignupRequest(string& Buffer);
};

