#pragma once
#include <WinSock2.h>


void debugPrint(std::string msg);
void sendData(const SOCKET sc, const std::string message);
//std::string getPartFromSocket(const SOCKET sc, const int bytesNum, const int flags);