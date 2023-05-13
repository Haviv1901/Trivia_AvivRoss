#include "SqliteDatabase.h"
#include "sqlite3.h"
#include <io.h>
#include <iostream>
#include <string>
#include <windows.h>
#include <list>
#include <map>
#include <ostream>
#include "Consts.h"
#include "Helper.h"

using std::list;
using std::string;
using std::endl;
using std::cout;
using std::map;
using std::to_string;

void sqlRunQuery(string sqlStatement, sqlite3* db);
void sqlRunQuery(string sqlStatement, sqlite3* db, int(*callback)(void*, int, char**, char**));
void createTables(sqlite3* db);

int callbackUsers(void* data, int argc, char** argv, char** azColName);

struct user
{
	string email;
	string username;
	string pass;
} typedef user;

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
	sqlite3_close(_db);
	_db = nullptr;
}
int SqliteDatabase::doesUserExist(string userName)
{
	std::vector<user> users;
	sqlRunQuery("SELECT * FROM USERS WHERE NAME=" + userName, callbackUsers, (void*)&users);
	if(users.size() == 0)
	{
		return false;
	}
	return true;
}
int SqliteDatabase::doesPasswordMatch(string pass, string pass2)
{
	
}
int SqliteDatabase::addNewUser(string username, string pass, string email)
{
	
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
	string sqlStatement = "CREATE TABLE USERS (ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,"
		" NAME TEXT NOT NULL,"
		" EMAIL TEXT NOT NULL,"
		" PASSWORD TEXT NOT NULL); ";
	sqlRunQuery(sqlStatement);
}

int callbackUsers(void* data, int argc, char** argv, char** azColName)
{
	int id;
	// id name
	string name;

	if(data != nullptr)
	{
		throw std::exception("null data was given.");
	}



	for (int i = 0; i < argc; i++)
	{
		if (string(azColName[i]) == "ID")
		{
			id = atoi(argv[i]);
		}
		else if (string(azColName[i]) == "NAME")
		{
			name = argv[i];
			User user(id, name);
			usersList.push_back(user);
		}

	}

	return 0;
}