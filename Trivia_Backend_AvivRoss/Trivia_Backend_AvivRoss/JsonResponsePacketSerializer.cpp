#include "JsonResponsePacketSerializer.h"
#include "Helper.h"


Buffer JsonResponsePacketSerializer::serializeResponse(ErrorResponse response)
{
	Buffer data = Helper::stringToBuffer("{message:\"" + Helper::bufferToString(response.messagge) + "\"}");
	int length = data.size();
	Buffer res;
	res.push_back((unsigned char)(ERROR_CODE + '0')); // insert code

	res.push_back((length >> 24) & 0xFF); // inserting 4 bytes of length
	res.push_back((length >> 16) & 0xFF);
	res.push_back((length >> 8) & 0xFF);
	res.push_back(length & 0xFF);

	res.insert(res.end(), data.begin(), data.end()); // connecting headers with data

	return res;
}
Buffer JsonResponsePacketSerializer::serializeResponse(LoginResponse response)
{
	Buffer data = Helper::stringToBuffer("{status: " + std::to_string(response.status) + "}");
	int length = data.size();
	Buffer res;
	res.push_back((unsigned char)(LOGIN_CODE + '0')); // insert code

	res.push_back((length >> 24) & 0xFF); // inserting 4 bytes of length
	res.push_back((length >> 16) & 0xFF);
	res.push_back((length >> 8) & 0xFF);
	res.push_back(length & 0xFF);

	res.insert(res.end(), data.begin(), data.end()); // connecting headers with data

	return res;
}
Buffer JsonResponsePacketSerializer::serializeResponse(SignupResponse response)
{
	Buffer data = Helper::stringToBuffer("{status: " + std::to_string(response.status) + "}");
	int length = data.size();
	Buffer res;
	res.push_back((unsigned char)(SIGN_UP_CODE + '0')); // insert code

	res.push_back((length >> 24) & 0xFF); // inserting 4 bytes of length
	res.push_back((length >> 16) & 0xFF);
	res.push_back((length >> 8) & 0xFF);
	res.push_back(length & 0xFF);

	res.insert(res.end(), data.begin(), data.end()); // connecting headers with data

	return res;
}