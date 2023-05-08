#pragma once
#include <string>

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
	static string serializeResponse(ErrorResponse);
	static string serializeResponse(LoginResponse);
	static string serializeResponse(SignupResponse);
};

