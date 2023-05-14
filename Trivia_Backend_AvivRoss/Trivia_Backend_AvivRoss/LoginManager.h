#pragma once
#include <string>
#include <vector>

#include "IDatabase.h"
#include "LoggedUser.h"

using std::string;

class LoginManager
{
public:
	LoginManager();
	bool signup(string mail, string username, string pass);
	bool login(string username, string passowrd);
	bool logout(string username);

private:
	std::vector<LoggedUser> m_loggedUsers;
	IDatabase* m_database;
};

