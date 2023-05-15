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
	bool signup(const string& email, const string& username, const string& pass);
	bool login(const string& username, const string& password);
	bool logout(const string& username);

private:
	std::vector<LoggedUser> m_loggedUsers;
	IDatabase* m_database;
};

