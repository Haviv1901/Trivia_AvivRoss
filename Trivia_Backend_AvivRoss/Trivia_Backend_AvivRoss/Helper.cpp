#include <iostream>
#include <string>

#include "Consts.h"
#include "Helper.h"


using std::string;
using std::cout;


void Helper::debugPrint(string msg)
{
	HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
	if (DEBUG_MODE)
	{
		SetConsoleTextAttribute(hConsole, 10);
		cout << "Debug message: ";
		SetConsoleTextAttribute(hConsole, 15);
		cout << msg << '\n';
	}
}

/**
 * \brief send string over the socket
 * \param sc 
 * \param message 
 */
void Helper::sendData(const SOCKET sc, const Buffer message)
{
	debugPrint("sending: " + bufferToString(message));

	if (send(sc, bufferToString(message).c_str(), message.size(), 0) == INVALID_SOCKET)
	{
		throw std::exception("Error while sending message to client");
	}
}

/**
 * \brief recieves string from socket
 * \param sc socket
 * \param bytesNum num of chars to recv
 * \param flags usually = 0
 * \return string
 */
Buffer Helper::getPartFromSocket(const SOCKET sc, const int bytesNum, const int flags)
{
	if (bytesNum == 0)
	{
		return Buffer();
	}

	char* data = new char[bytesNum + 1];
	int res = recv(sc, data, bytesNum, 0);
	if (res == INVALID_SOCKET)
	{
		std::string s = "Error while recieving from socket: ";
		s += std::to_string(sc);
		throw std::exception(s.c_str());
	}
	data[bytesNum] = 0;
	Buffer v(data, data + bytesNum);
	delete[] data;
	return v;
}

void Helper::notImplemented()
{
	throw std::exception("Not implemented yet.");
}


Buffer Helper::stringToBuffer(string str)
{
	return Buffer(str.begin(), str.end());

}

string Helper::bufferToString(Buffer buffer)
{
	return string(buffer.begin(), buffer.end());
}

//string Helper::bufferToString(Buffer buffer, int start, int end)
//{
//	return string(buffer.at(start), buffer.at(end));
//}

// recieves the type code of the message from socket (3 bytes)
// and returns the code. if no message found in the socket returns 0 (which means the client disconnected)
int Helper::getMessageTypeCode(const SOCKET sc)
{
	Buffer buff = getPartFromSocket(sc, 1, 0);
	if(buff.empty())
	{
		return 0;
	}
	std::string msg = bufferToString(buff);

	int res = std::atoi(msg.c_str());
	return  res;
}

int Helper::getLengthFromSocket(const SOCKET sc)
{
	Buffer buffer = getPartFromSocket(sc, 4, 0);

	return int((unsigned char)(buffer[0]) << 24 |
		(unsigned char)(buffer[1]) << 16 |
		(unsigned char)(buffer[2]) << 8 |
		(unsigned char)(buffer[3]));
}

std::string Helper::getDataFromSocket(const SOCKET sc, const int bytesNum)
{
	return bufferToString(getPartFromSocket(sc, bytesNum, 0));
}

Buffer Helper::getDataFromSocketBuffer(const SOCKET sc, const int bytesNum)
{
	return getPartFromSocket(sc, bytesNum, 0);
}