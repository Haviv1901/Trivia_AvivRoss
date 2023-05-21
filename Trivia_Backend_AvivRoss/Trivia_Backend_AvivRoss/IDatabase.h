#pragma once
#include <string>
#include <list>

using std::string;

struct Question
{
	string question;
	std::vector<string> answers; // first answer is the correct one
};

struct Statistics
{
	string username;
	float avgAnswerTime;
	int numOfCorrectAnswers;
	int numOfTotalAnswers;
	int numOfPlayerGames;
	float playerScore;
} typedef Statistics;

class IDatabase
{
public:


	virtual bool open() = 0;
	virtual bool close() = 0;
	virtual int doesUserExist(string userName) = 0;
	virtual int doesPasswordMatch(string pass, string username) = 0;
	virtual int addNewUser(string username, string pass, string email) = 0;

	// stats
	virtual std::list<Question> getQuestion(int num) = 0;
	virtual float getPlayerAverageAnswerTime(string username) = 0;
	virtual int getNumOfCorrectAnswers(string username) = 0;
	virtual int getNumOfTotalAnswers(string username) = 0;
	virtual int getNumOfPlayerGames(string username) = 0;
	virtual float getPlayerScore(string username) = 0;
	virtual std::vector<Statistics> getHighScores() = 0;

	// not in uml
	virtual Statistics getStats(string username) = 0;

};
