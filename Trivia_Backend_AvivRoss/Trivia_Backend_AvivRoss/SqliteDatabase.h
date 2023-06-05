#pragma once
#include <vector>

#include "IDatabase.h"
#include "sqlite3.h"


struct user
{
	string email;
	string username;
	string pass;
} typedef user;

class SqliteDatabase :
    public IDatabase
{

public:

    SqliteDatabase();
	~SqliteDatabase();

	bool open() override;
	bool close() override;
	int doesUserExist(string userName) override;
	int doesPasswordMatch(string pass, string username) override;
	int addNewUser(string username, string pass, string email) override;

	std::list<Question> getQuestions(int num) override;
	float getPlayerAverageAnswerTime(string username) override;
	int getNumOfCorrectAnswers(string username) override;
	int getNumOfTotalAnswers(string username) override;
	int getNumOfPlayerGames(string username) override;
	float getPlayerScore(string username) override;
	std::vector<Statistics> getHighScores() override;

	// not in uml
	Statistics getStats(string username) override;

private:

	void sqlRunQuery(string sqlStatement, int(*callback)(void*, int, char**, char**), void* data) const;
	void sqlRunQuery(string sqlStatement, int(*callback)(void*, int, char**, char**)) const;
	void sqlRunQuery(string sqlStatement) const;
	void getStatistics(std::vector<Statistics>* usersList, string username = "");
	void getUsers(std::vector<user>* usersList, string prefix = "");
	void getQuestionsFromDB(std::list<Question>* questionsList, string prefix = "");
	void createTables() const;

	sqlite3* _db;
};

