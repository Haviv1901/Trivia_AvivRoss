#pragma once
#include <WinSock2.h>
#include <string>
#include "Consts.h"


class Helper
{

public:
	// misc
	static void debugPrint(std::string msg);
	static void notImplemented();

	// communication functions
	static void sendData(const SOCKET sc, const Buffer message);
	static int getMessageTypeCode(const SOCKET sc);
	static int getLengthFromSocket(const SOCKET sc);
	static std::string getDataFromSocket(const SOCKET sc, const int bytesNum);
	static Buffer getDataFromSocketBuffer(const SOCKET sc, const int bytesNum);

	// data types convertors
	static Buffer stringToBuffer(std::string str);
	static std::string bufferToString(Buffer buffer);
	static std::string bufferToString(Buffer buffer, int start, int end);

private:
	static Buffer getPartFromSocket(const SOCKET sc, const int bytesNum, const int flags);
};


