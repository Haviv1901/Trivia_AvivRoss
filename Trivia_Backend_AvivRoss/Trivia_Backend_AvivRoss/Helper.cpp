#include <iostream>
#include <string>

#include "Consts.h"
#include "Helper.h"


using std::string;
using std::cout;


void debugPrint(string msg)
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
void sendData(const SOCKET sc, const std::string message)
{
	const char* data = message.c_str();

	if (send(sc, data, message.size(), 0) == INVALID_SOCKET)
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
std::string getPartFromSocket(const SOCKET sc, const int bytesNum, const int flags)
{
	if (bytesNum == 0)
	{
		return "";
	}

	char* data = new char[bytesNum + 1];
	int res = recv(sc, data, bytesNum, flags);
	if (res == INVALID_SOCKET)
	{
		std::string s = "Error while recieving from socket: ";
		s += std::to_string(sc);
		throw std::exception(s.c_str());
	}
	data[bytesNum] = 0;
	std::string received(data);
	delete[] data;
	return received;
}

void notImplemented()
{
	throw std::exception("Not implemented yet.");
}