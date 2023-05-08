#include "JsonResponsePacketSerializer.h"
#include "Helper.h"


Buffer JsonResponsePacketSerializer::serializeResponse(ErrorResponse response)
{
	return stringToBuffer("{message:\"" + response.messagge + "\"}");
}
Buffer JsonResponsePacketSerializer::serializeResponse(LoginResponse response)
{
	return stringToBuffer("status: " + std::to_string(response.status) + "}");
}
Buffer JsonResponsePacketSerializer::serializeResponse(SignupResponse response)
{
	return stringToBuffer("status: " + std::to_string(response.status) + "}");
}