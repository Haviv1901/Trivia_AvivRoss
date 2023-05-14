#include "SqliteDatabase.h"
#include "sqlite3.h"
#include <io.h>
#include <iostream>
#include <string>
#include <ostream>
#include "Consts.h"
#include "Helper.h"

using std::vector;
using std::string;
using std::endl;
using std::cout;
using std::to_string;

void sqlRunQuery(string sqlStatement, sqlite3* db);
void sqlRunQuery(string sqlStatement, sqlite3* db, int(*callback)(void*, int, char**, char**));
void createTables(sqlite3* db);

int callbackUsers(void* data, int argc, char** argv, char** azColName);


bool SqliteDatabase::open()
{
	int file_exist = _access(DB_PATH, 0);
	int res = sqlite3_open(DB_PATH, &_db);
	if (res != SQLITE_OK)
	{
		_db = nullptr;
		std::cout << "Failed to open DB" << std::endl;
		return false;
	}
	if (file_exist != 0)
	{
		// file did not exist before - create tables
		createTables();
	}
	return true;
}
bool SqliteDatabase::close()
{
	if(sqlite3_close(_db) == SQLITE_OK)
	{
		_db = nullptr;
		return true;
	}
	return false;
}
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
int SqliteDatabase::addNewUser(string username, string pass, string email)
{
	try
	{
		sqlRunQuery("INSERT INTO USERS VALUES(" + username + ", '" + email + ", ' " + pass + "');");
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
			res = sqlite3_exec(_db, sqlStatement.c_str(), callback, nullptr, &errMessage);
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
 * \param db
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



void SqliteDatabase::createTables() const
{
	string sqlStatement = "CREATE TABLE USERS (NAME TEXT PRIMARY KEY NOT NULL,"
		" EMAIL TEXT NOT NULL,"
		" PASSWORD TEXT NOT NULL); ";
	sqlRunQuery(sqlStatement);
}

void SqliteDatabase::getUsers(std::vector<user>* usersList, string prefix)
{
	if(prefix == "")
	{
		sqlRunQuery("SELECT * FROM USERS", callbackUsers, (void*)usersList);
	}
	else
	{
		sqlRunQuery("SELECT * FROM USERS WHERE NAME=" + prefix, callbackUsers, (void*)usersList);
	}
}


int callbackUsers(void* data, int argc, char** argv, char** azColName)
{
	// id name
	string name, email, pass;

	if(data != nullptr)
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