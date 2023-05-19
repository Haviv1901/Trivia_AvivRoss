#pragma once
#include <string>
#include <list>

using std::string;

struct Question
{
	string question;
	std::vector<string> answers;
};

class IDatabase
{
public:


	virtual bool open() = 0;
	virtual bool close() = 0;
	virtual int doesUserExist(string userName) = 0;
	virtual int doesPasswordMatch(string pass, string username) = 0;
	virtual int addNewUser(string username, string pass, string email) = 0;

	virtual std::list<Question> getQuestion(int num) = 0;
};
