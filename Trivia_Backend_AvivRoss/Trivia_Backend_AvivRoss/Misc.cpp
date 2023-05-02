#include <iostream>
#include <string>
#include "Consts.h"

using std::string;
using std::cout;


void debugPrint(string msg)
{
	HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
	if (DEBUG_MODE)
	{
		SetConsoleTextAttribute(hConsole, 12);
		cout << "Debug msg:" << msg << '\n';
		SetConsoleTextAttribute(hConsole, 15);
	}
}