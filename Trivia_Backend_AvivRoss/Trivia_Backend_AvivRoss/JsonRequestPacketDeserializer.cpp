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
	string json = bufferToString(buffer, 4, buffer.size() - 1);

}
SignupRequest JsonRequestPacketDeserializer::deserializeSignupRequest(Buffer buffer)
{
	
}