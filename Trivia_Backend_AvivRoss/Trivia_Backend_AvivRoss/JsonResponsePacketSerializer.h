#pragma once
#include <string>
#include "Consts.h"

using std::string;

struct ErrorResponse
{
	string messagge;
} typedef ErrorResponse;

struct LoginResponse
{
	unsigned int status;
} typedef LoginResponse;

struct SignupResponse
{
	unsigned int status;
} typedef SignupResponse;

class JsonResponsePacketSerializer
{
	static Buffer serializeResponse(ErrorResponse response);
	static Buffer serializeResponse(LoginResponse response);
	static Buffer serializeResponse(SignupResponse response);
};
