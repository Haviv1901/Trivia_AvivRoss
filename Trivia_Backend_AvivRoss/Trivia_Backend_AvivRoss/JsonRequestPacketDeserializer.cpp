#include "JsonRequestPacketDeserializer.h"




LoginRequest JsonRequestPacketDeserializer::deserializeLoginRequest(Buffer buffer)
{
	if(int(buffer[0]) != LOGIN_CODE)
	{
		throw std::exception("Error in function JsonRequestPacketDeserializer::deserializeLoginRequest, not a login request.");
	}

	LoginRequest res;
	string pass;
}
SignupRequest JsonRequestPacketDeserializer::deserializeSignupRequest(Buffer buffer)
{
	
}