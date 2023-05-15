#pragma once
#include <string>

using std::string;

class IDatabase
{
public:

	virtual ~IDatabase();

	virtual bool open() = 0;
	virtual bool close() = 0;
	virtual int doesUserExist(string userName) = 0;
	virtual int doesPasswordMatch(string pass, string username) = 0;
	virtual int addNewUser(string username, string pass, string email) = 0;
};
