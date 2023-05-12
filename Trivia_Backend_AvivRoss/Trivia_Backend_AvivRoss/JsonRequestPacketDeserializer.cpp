#include "JsonRequestPacketDeserializer.h"

#include "Helper.h"
#include "nlohmann/json.hpp"

using json = nlohmann::json;

LoginRequest JsonRequestPacketDeserializer::deserializeLoginRequest(Buffer buffer)
{

	LoginRequest res;
	string parseMe = Helper::bufferToString(buffer);
	Helper::debugPrint("parsing to json: " + parseMe);
	json json = json::parse(parseMe); // creating the json object

	res.password = json["password"];
	res.username = json["username"];

	return res;

}
SignupRequest JsonRequestPacketDeserializer::deserializeSignupRequest(Buffer buffer)
{

	SignupRequest res;
	string parseMe = Helper::bufferToString(buffer);
	Helper::debugPrint("parsing to json: " + parseMe);
	json json = json::parse(parseMe); // creating the json object

	res.password = json["password"];
	res.username = json["username"];
	res.email = json["email"];

	return res;

}