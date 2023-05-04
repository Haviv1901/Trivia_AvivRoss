#include <iostream>
#include <thread>
#include "Helper.h"

#include "Server.h"
#include "WSAInitializer.h"

int main()
{
	std::string str;
	try
	{
		debugPrint("Starting...");
		WSAInitializer wsa_init;
		Server server = Server();
		server.run();
	}
	catch (const std::exception& e)
	{
		std::cout << "Exception was thrown in function: " << e.what() << std::endl;
		debugPrint("Last error was " + std::to_string(GETSOCKETERRNO()));
	}
	catch (...)
	{
		std::cout << "Unknown exception in main !" << std::endl;
		debugPrint("Last error was " + std::to_string(GETSOCKETERRNO()));
	}

	

	while(str != "Exit")
	{
		std::cin >> str;
	}

	exit(EXIT_SUCCESS);


}
