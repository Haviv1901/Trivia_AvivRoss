#include "JsonRequestPacketDeserializer.h"

#include "Helper.h"
#include "nlohmann/json.hpp"

using json = nlohmann::json;

LoginRequest JsonRequestPacketDeserializer::deserializeLoginRequest(Buffer buffer)
{
	if(int(buffer[0]) != LOGIN_CODE)
	{
		throw std::exception("Error in function JsonRequestPacketDeserializer::deserializeLoginRequest, not a login request.");
	}

	LoginRequest res;
	json json = json::parse(bufferToString(buffer, 4, buffer.size() - 1)); // creating the json object

	res.password = json["password"];
	res.username = json["username"];

	return res;

}
SignupRequest JsonRequestPacketDeserializer::deserializeSignupRequest(Buffer buffer)
{
	if (int(buffer[0]) != SIGN_UP_CODE)
	{
		throw std::exception("Error in function JsonRequestPacketDeserializer::deserializeLoginRequest, not a login request.");
	}

	SignupRequest res;
	json json = json::parse(bufferToString(buffer, 4, buffer.size() - 1)); // creating the json object

	res.password = json["password"];
	res.username = json["username"];
	res.email = json["email"];

	return res;

}