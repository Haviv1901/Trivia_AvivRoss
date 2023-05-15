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

private:

	void sqlRunQuery(string sqlStatement, int(*callback)(void*, int, char**, char**), void* data) const;
	void sqlRunQuery(string sqlStatement, int(*callback)(void*, int, char**, char**)) const;
	void sqlRunQuery(string sqlStatement) const;
	void getUsers(std::vector<user>* usersList, string prefix = "");
	void createTables() const;

	sqlite3* _db;
};

