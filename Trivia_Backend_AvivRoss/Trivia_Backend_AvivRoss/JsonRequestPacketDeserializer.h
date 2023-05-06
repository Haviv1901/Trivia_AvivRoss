#pragma once

#include <string>

using std::string;

struct
{
	string username;
	string password;
} typedef LoginRequest;

struct
{
	string username;
	string password;
	string email;
} typedef SignupRequest;

class JsonRequestPacketDeserializer
{
public:
	static LoginRequest deserializeLoginRequest(string Buffer&);
	static SignupRequest deserializeSignupRequest(string Buffer&);
};

