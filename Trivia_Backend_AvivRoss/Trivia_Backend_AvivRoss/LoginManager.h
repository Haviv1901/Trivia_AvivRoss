#pragma once
#include <string>
#include <vector>

#include "IDatabase.h"
#include "LoggedUser.h"

using std::string;

class LoginManager
{
public:
	LoginManager(IDatabase* database);
	bool signup(string email, string username, string pass);
	bool login(string username, string passowrd);
	bool logout(string username);

private:
	std::vector<LoggedUser> m_loggedUsers;
	IDatabase* m_database;
};

