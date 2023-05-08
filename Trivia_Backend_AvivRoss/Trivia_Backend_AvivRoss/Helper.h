#pragma once
#include <WinSock2.h>
#include <string>


void debugPrint(std::string msg);
void notImplemented();

void sendData(const SOCKET sc, const std::string message);
std::string getPartFromSocket(const SOCKET sc, const int bytesNum, const int flags);

Buffer stringToBuffer(std::string str);
std::string bufferToString(Buffer buffer);
std::string bufferToString(Buffer buffer, int start, int end);
