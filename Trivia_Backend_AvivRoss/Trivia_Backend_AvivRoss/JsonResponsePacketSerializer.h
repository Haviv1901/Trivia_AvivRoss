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
};

