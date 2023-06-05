#pragma comment(lib, "urlmon.lib")
#include "SqliteDatabase.h"
#include "sqlite3.h"
#include <io.h>
#include <iostream>
#include <string>
#include <ostream>
#include "Consts.h"
#include "Helper.h"
#include "nlohmann/json.hpp"
#include <urlmon.h>
#include <algorithm>
#include <random>
#include <sstream>


using std::vector;
using std::string;
using std::list;
using std::endl;
using std::cout;
using std::to_string;

void sqlRunQuery(string sqlStatement, sqlite3* db);
void sqlRunQuery(string sqlStatement, sqlite3* db, int(*callback)(void*, int, char**, char**));
void createTables(sqlite3* db);

string getQuestionsFromWeb();

int callbackUsers(void* data, int argc, char** argv, char** azColName);
int callbackQuestions(void* data, int argc, char** argv, char** azColName);
int callbackStatistics(void* data, int argc, char** argv, char** azColName);

SqliteDatabase::SqliteDatabase()
{
	open();
}

SqliteDatabase::~SqliteDatabase()
{
	close();
}

/**
 * \brief opens data base
 * \return 
 */
bool SqliteDatabase::open()
{
	int file_exist = _access(DB_PATH, 0);
	int res = sqlite3_open(DB_PATH, &_db);
	if (res != SQLITE_OK)
	{
		_db = nullptr;
		throw std::exception("error opening data base");
		return false;
	}
	if (file_exist != 0)
	{
		// file did not exist before - create tables
		createTables();
	}
	return true;
}

/**
 * \brief close data base
 * \return 
 */
bool SqliteDatabase::close()
{
	if(sqlite3_close(_db) == SQLITE_OK)
	{
		_db = nullptr;
		return true;
	}
	return false;
}

/**
 * \brief checks if user exist
 * \param userName 
 * \return return 0 if doesnt exist - 1 if user do exist
 */
int SqliteDatabase::doesUserExist(string userName)
{
	std::vector<user> users;
	getUsers(&users, userName);
	if(users.size() == 0)
	{
		return 0;
	}
	return 1;
}

/**
 * \brief checks if a password is matching the username
 * \param pass 
 * \param username 
 * \return 
 */
int SqliteDatabase::doesPasswordMatch(string pass, string username)
{
	std::vector<user> users;
	getUsers(&users, username);

	if (users.size() == 0)
	{
		return 0;
	}

	for(auto iter : users)
	{
		if(iter.pass == pass)
		{
			return 1;
		}
	}

	return 0;
}

/**
 * \brief add new user to the data base
 * \param username 
 * \param pass 
 * \param email 
 * \return 0 if failed, 1 if succeded
 */
int SqliteDatabase::addNewUser(string username, string pass, string email)
{
	if(doesUserExist(username))
	{
		return 0;
	}
	try
	{
		sqlRunQuery("INSERT INTO USERS VALUES('" + username + "', '" + email + "', '" + pass + "');");
		sqlRunQuery("INSERT INTO STATISTICS VALUES('" + username + "', 0, 0, 0, 0); ");
	}
	catch(std::exception e)
	{
		return 0;
	}
	return 1;

}


/**
 * \brief function will run an sql query and prints the result and error message if needed
 * \param sqlStatement
 * \param db
 * \param errMessage
 */
void SqliteDatabase::sqlRunQuery(string sqlStatement, int(*callback)(void*, int, char**, char**), void* data) const
{
	char* errMessage;
	HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
	int res;
	if (DEBUG_MODE)
	{
		cout << "running: " << sqlStatement;
	}
	try
	{
		if (callback != nullptr)
			res = sqlite3_exec(_db, sqlStatement.c_str(), callback, data, &errMessage);
		else
			res = sqlite3_exec(_db, sqlStatement.c_str(), nullptr, nullptr, &errMessage);
	}
	catch (std::exception e)
	{
		Helper::debugPrint("An error was cought in function: " + string(__FUNCTION__) + " for: " + e.what());
	}
	if (res != SQLITE_OK && DEBUG_MODE)
	{
		SetConsoleTextAttribute(hConsole, 12);
		cout << " - could not run query: " << errMessage << endl;
		SetConsoleTextAttribute(hConsole, 15);
		throw std::exception("could not run query");
	}
	else if (DEBUG_MODE)
	{
		SetConsoleTextAttribute(hConsole, 10);
		cout << " - succeded." << endl;
		SetConsoleTextAttribute(hConsole, 15);
	}
}
/**
 * \brief will call the same function with nullptr as the calback function
 * \param sqlStatement
 */
void SqliteDatabase::sqlRunQuery(string sqlStatement) const
{
	sqlRunQuery(sqlStatement, nullptr);
}

/**
 * \brief will call the same function with nullptr as the callback's arg
 * \param sqlStatement
 * \param db
 */
void SqliteDatabase::sqlRunQuery(string sqlStatement, int(*callback)(void*, int, char**, char**)) const
{
	sqlRunQuery(sqlStatement, callback, nullptr);
}


/**
 * \brief creates the tables
 */
void SqliteDatabase::createTables() const
{
	string questions;
	string sqlStatement = "CREATE TABLE USERS (NAME TEXT PRIMARY KEY NOT NULL,"
		" EMAIL TEXT NOT NULL,"
		" PASSWORD TEXT NOT NULL); ";
	sqlRunQuery(sqlStatement);

	sqlStatement = "CREATE TABLE QUESTIONS (QUESTION TEXT PRIMARY KEY NOT NULL," 
		" CORR_ANSWER TEXT NOT NULL,"
		" WRONG_ANSWER1 TEXT NOT NULL,"
		" WRONG_ANSWER2 TEXT NOT NULL,"
		" WRONG_ANSWER3 TEXT NOT NULL); ";
	sqlRunQuery(sqlStatement);

	sqlStatement = "CREATE TABLE STATISTICS (USERNAME TEXT PRIMARY KEY NOT NULL,"
		" AVG_ANSWER_TIME FLOAT NOT NULL,"
		" TOTAL_CORRECT_ANSWERS INT NOT NULL,"
		" TOTAL_ANSWERS INT NOT NULL,"
		" TOTAL_GAMES INT NOT NULL); ";
	sqlRunQuery(sqlStatement);

	

	try // get questions from server
	{
		questions = getQuestionsFromWeb();
	}
	catch (const std::exception& e)
	{
		throw std::exception("could not get questions from server");
	}

	Helper::debugPrint("parsing to json: " + questions);
	nlohmann::json jsonQuestions = nlohmann::json::parse(questions); // creating the json object
	Helper::debugPrint("parsed successfully");

	if (jsonQuestions["response_code"] != 0)
	{
		throw std::exception("could not get questions from server");
	}
	
	string question, correctAnswer, wrongAnswer1, wrongAnswer2, wrongAnswer3;
	for (int i = 0; i < 10; i++)
	{
		for (auto it = jsonQuestions["results"][i].begin(); it != jsonQuestions["results"][i].end(); ++it)
		{
			if (it.key() == "question")
			{
				question = it.value();
			}
			else if (it.key() == "correct_answer")
			{
				correctAnswer = it.value();
			}
			else if (it.key() == "incorrect_answers")
			{
				wrongAnswer1 = it.value()[0];
				wrongAnswer2 = it.value()[1];
				wrongAnswer3 = it.value()[2];
			}
			//question = (*it)["question"].get<string>();
			//correctAnswer = (*it)["correct_answer"].get<string>();
			//wrongAnswer1 = (*it)["incorrect_answers"][0].get<string>();
			//wrongAnswer2 = (*it)["incorrect_answers"][1].get<string>();
			//wrongAnswer3 = (*it)["incorrect_answers"][2].get<string>();
			
		}
		sqlStatement = "INSERT INTO QUESTIONS VALUES('" + question + "', '" + correctAnswer + "', '" + wrongAnswer1 + "', '" + wrongAnswer2 + "', '" + wrongAnswer3 + "'); ";
		sqlRunQuery(sqlStatement);
	}

	
}

/**
 * \brief function to get all users in database and return them in a structre type data
 * \param usersList 
 * \param prefix 
 */
void SqliteDatabase::getUsers(std::vector<user>* usersList, string prefix)
{
	if(prefix == "")
	{
		sqlRunQuery("SELECT * FROM USERS", callbackUsers, (void*)usersList);
	}
	else
	{
		sqlRunQuery("SELECT * FROM USERS WHERE NAME='" + prefix + "'", callbackUsers, (void*)usersList);
	}
}

void SqliteDatabase::getQuestions(std::list<Question>* questionsList, string prefix)
{
	sqlRunQuery("SELECT * FROM QUESTIONS", callbackQuestions, (void*)questionsList);
}


std::list<Question> SqliteDatabase::getQuestion(int num)
{
	std::list<Question> res;
	getQuestions(&res);

	auto end = std::next(res.begin(), num);

	return std::list<Question>(res.begin(), end);

}

float SqliteDatabase::getPlayerAverageAnswerTime(string username)
{
	vector<Statistics> stats;

	getStatistics(&stats, username);

	if (stats.size() == 1)
	{
		return stats[0].avgAnswerTime;
	}

	throw std::exception("2 usernames found. ERORR ?? HOW??? WTF????? NOT SUPPOSED TO HAPPEND");

}
int SqliteDatabase::getNumOfCorrectAnswers(string username)
{
	vector<Statistics> stats;

	getStatistics(&stats, username);

	if (stats.size() == 1)
	{
		return stats[0].numOfCorrectAnswers;
	}

	throw std::exception("2 usernames found. ERORR ?? HOW??? WTF????? NOT SUPPOSED TO HAPPEND");

}


int SqliteDatabase::getNumOfTotalAnswers(string username)
{
	vector<Statistics> stats;

	getStatistics(&stats, username);

	if (stats.size() == 1)
	{
		return stats[0].numOfTotalAnswers;
	}

	throw std::exception("2 usernames found. ERORR ?? HOW??? WTF????? NOT SUPPOSED TO HAPPEND");
}


int SqliteDatabase::getNumOfPlayerGames(string username)
{
	vector<Statistics> stats;

	getStatistics(&stats, username);

	if (stats.size() == 1)
	{
		return stats[0].numOfPlayerGames;
	}

	throw std::exception("2 usernames found. ERORR ?? HOW??? WTF????? NOT SUPPOSED TO HAPPEND");
}


float SqliteDatabase::getPlayerScore(string username)
{
	vector<Statistics> stats;

	getStatistics(&stats, username);

	if (stats.size() == 1)
	{
		return stats[0].playerScore;
	}

	throw std::exception("2 usernames found. ERORR ?? HOW??? WTF????? NOT SUPPOSED TO HAPPEND");
}

std::vector<Statistics> SqliteDatabase::getHighScores()
{
	int i = 0;
	int max = 5;
	vector<Statistics> stats;

	getStatistics(&stats);

	std::sort(stats.begin(), stats.end(), [](Statistics a, Statistics b) { return a.playerScore > b.playerScore; });

	vector<Statistics> res;
	stats.size() > 5 ? max = 5 : max = stats.size();

	for (i = 0; i < max; i++)
	{
		res.push_back(stats[i]);
	}

	return res;
}

Statistics SqliteDatabase::getStats(string username)
{
	vector<Statistics> stats;

	getStatistics(&stats, username);

	

	if (stats.size() == 1)
	{
		Statistics s;
		s.avgAnswerTime = stats[0].avgAnswerTime;
		s.numOfCorrectAnswers = stats[0].numOfCorrectAnswers;
		s.numOfPlayerGames = stats[0].numOfPlayerGames;
		s.numOfTotalAnswers = stats[0].numOfTotalAnswers;
		s.playerScore = stats[0].playerScore;
		s.username = username;

		return s;
	}

	throw std::exception("2 usernames found. ERORR ?? HOW??? WTF????? NOT SUPPOSED TO HAPPEND");
}

void SqliteDatabase::getStatistics(std::vector<Statistics>* usersList, string username)
{
	if (username == "")
	{
		sqlRunQuery("SELECT * FROM STATISTICS", callbackStatistics, (void*)usersList);
	}
	else
	{
		sqlRunQuery("SELECT * FROM STATISTICS WHERE USERNAME='" + username + "'", callbackStatistics, (void*)usersList);
	}
}

/**
 * \brief callback - for Questions
 * \param data
 * \param argc
 * \param argv
 * \param azColName
 * \return
 */
int callbackStatistics(void* data, int argc, char** argv, char** azColName)
{
	// id name
	string username, avgAnswerTime, totalCorrectAnswers, totalAnswers, totalGames;

	if (data == nullptr)
	{
		throw std::exception("null data was given.");
	}

	vector<Statistics>* questionsList = (vector<Statistics>*)data;

	for (int i = 0; i < argc; i++)
	{
		if (string(azColName[i]) == "USERNAME")
		{
			username = argv[i];
		}
		if (string(azColName[i]) == "AVG_ANSWER_TIME")
		{
			avgAnswerTime = argv[i];
		}
		if (string(azColName[i]) == "TOTAL_CORRECT_ANSWERS")
		{
			totalCorrectAnswers = argv[i];
		}
		if (string(azColName[i]) == "TOTAL_ANSWERS")
		{
			totalAnswers = argv[i];
		}
		if (string(azColName[i]) == "TOTAL_GAMES")
		{
			totalGames = argv[i];
		}

	}
	Statistics temp;
	temp.username = username;
	temp.avgAnswerTime = std::stof(avgAnswerTime);
	temp.numOfCorrectAnswers = std::stoi(totalCorrectAnswers);
	temp.numOfTotalAnswers = std::stoi(totalAnswers);
	temp.numOfPlayerGames = std::stoi(totalGames);

	if(temp.numOfCorrectAnswers == 0)
	{
		temp.playerScore = 0;
	}
	else
	{
		temp.playerScore = ((float)temp.numOfCorrectAnswers / temp.numOfTotalAnswers) * (float)100;
	}

	questionsList->push_back(temp);
	return 0;
}

/**
 * \brief callback - for Questions
 * \param data
 * \param argc
 * \param argv
 * \param azColName
 * \return
 */
int callbackQuestions(void* data, int argc, char** argv, char** azColName)
{
	// id name
	string question, currAnswer, wrongAnswer1, wrongAnswer2, wrongAnswer3;

	if (data == nullptr)
	{
		throw std::exception("null data was given.");
	}

	list<Question>* questionsList = (list<Question>*)data;

	for (int i = 0; i < argc; i++)
	{
		if (string(azColName[i]) == "QUESTION")
		{
			question = argv[i];
		}
		if (string(azColName[i]) == "CURR_ANSWER")
		{
			currAnswer = argv[i];
		}
		if (string(azColName[i]) == "WRONG_ANSWER1")
		{
			wrongAnswer1 = argv[i];
		}
		if (string(azColName[i]) == "WRONG_ANSWER2")
		{
			wrongAnswer2 = argv[i];
		}
		if (string(azColName[i]) == "WRONG_ANSWER3")
		{
			wrongAnswer3 = argv[i];
		}

	}
	vector<string> answers;
	answers.push_back(currAnswer);
	answers.push_back(wrongAnswer1);
	answers.push_back(wrongAnswer2);
	answers.push_back(wrongAnswer3);

	auto rng = std::default_random_engine{}; // shuffle the answers
	std::shuffle(std::begin(answers), std::end(answers), rng);


	std::vector<string>::iterator itr = std::find(answers.begin(), answers.end(), currAnswer); // find the correct answer index
	int correctAnswerIndex = std::distance(answers.begin(), itr);

	questionsList->push_back(Question(question, answers, correctAnswerIndex));
	return 0;
}

/**
 * \brief callback - for users
 * \param data 
 * \param argc 
 * \param argv 
 * \param azColName 
 * \return 
 */
int callbackUsers(void* data, int argc, char** argv, char** azColName)
{
	// id name
	string name, email, pass;

	if(data == nullptr)
	{
		throw std::exception("null data was given.");
	}

	vector<user>* usersList = (vector<user>*)data;

	for (int i = 0; i < argc; i++)
	{
		if (string(azColName[i]) == "NAME")
		{
			name = argv[i];
		}
		if (string(azColName[i]) == "EMAIL")
		{
			email = argv[i];
		}
		if (string(azColName[i]) == "PASSWORD")
		{
			pass = argv[i];
		}

	}
	user temp;
	temp.email = email;
	temp.pass = pass;
	temp.username = pass;
	usersList->push_back(temp);
	return 0;
}

string getQuestionsFromWeb()
{
	IStream* stream;
	//Also works with https URL's - unsure about the extent of SSL support though.
	HRESULT result = URLOpenBlockingStream(0, API_ADDRESS, &stream, 0, 0);
	if (result != 0)
	{
		return "{}";
	}
	char buffer[100];
	unsigned long bytesRead;
	std::stringstream ss;
	stream->Read(buffer, 100, &bytesRead);
	while (bytesRead > 0U)
	{
		ss.write(buffer, (long long)bytesRead);
		stream->Read(buffer, 100, &bytesRead);
	}
	stream->Release();
	return ss.str();
}