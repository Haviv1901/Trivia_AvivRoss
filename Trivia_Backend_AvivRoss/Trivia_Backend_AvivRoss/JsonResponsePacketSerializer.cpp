#include "JsonResponsePacketSerializer.h"
#include "Helper.h"


Buffer JsonResponsePacketSerializer::serializeResponse(ErrorResponse response)
{
	return Helper::stringToBuffer("{message:\"" + Helper::bufferToString(response.messagge )+ "\"}");
}
Buffer JsonResponsePacketSerializer::serializeResponse(LoginResponse response)
{
	return Helper::stringToBuffer("{status: " + std::to_string(response.status) + "}");
}
Buffer JsonResponsePacketSerializer::serializeResponse(SignupResponse response)
{
	return Helper::stringToBuffer("{status: " + std::to_string(response.status) + "}");
}