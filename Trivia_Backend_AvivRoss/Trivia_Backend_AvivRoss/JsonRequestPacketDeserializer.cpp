#include "JsonRequestPacketDeserializer.h"

#include "Helper.h"
#include "nlohmann/json.hpp"

using json = nlohmann::json;
json parseToJson(Buffer buffer);

LoginRequest JsonRequestPacketDeserializer::deserializeLoginRequest(Buffer buffer)
{

	LoginRequest res;
	json json = parseToJson(buffer);

	res.password = json["password"];
	res.username = json["username"];

	return res;

}

SignupRequest JsonRequestPacketDeserializer::deserializeSignupRequest(Buffer buffer)
{
	SignupRequest res;
	json json = parseToJson(buffer);

	res.password = json["password"];
	res.username = json["username"];
	res.email = json["email"];

	return res;

}

GetPlayersInRoomRequest JsonRequestPacketDeserializer::deserializeGetPlayersRequest(Buffer buffer)
{
	GetPlayersInRoomRequest res;
	json json = parseToJson(buffer);

	res.roomId = json["roomId"];

	return res;
}
JoinRoomRequest JsonRequestPacketDeserializer::deserializeJoinRoomRequest(Buffer buffer)
{
	JoinRoomRequest res;
	json json = parseToJson(buffer);

	res.roomId = json["roomId"];

	return res;
}
CreateRoomRequest JsonRequestPacketDeserializer::deserializeCreateRoomRequest(Buffer buffer)
{
	CreateRoomRequest res;
	json json = parseToJson(buffer);

	res.answerTimeout = json["Answer Time Out"];
	res.maxUsers = json["Max Users"];
	res.questionCount = json["Question Count"];
	res.roomName = json["Room Name"];

	return res;
}



json parseToJson(Buffer buffer)
{
	json json;
	string parseMe = Helper::bufferToString(buffer);
	Helper::debugPrint("parsing to json: " + parseMe);
	try
	{
		json = json::parse(parseMe); // creating the json object
	}
	catch (...)
	{
		throw std::exception("Could not parse message. pls send it in the correct format.");
	}

	return json;
}