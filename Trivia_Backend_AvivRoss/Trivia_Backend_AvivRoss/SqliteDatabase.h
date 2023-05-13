#pragma once
#include "IDatabase.h"
#include "sqlite3.h"

class SqliteDatabase :
    public IDatabase
{

public:

    SqliteDatabase();

	bool open() override;
	bool close() override;
	int doesUserExist(string userName) override;
	int doesPasswordMatch(string pass, string pass2) override;
	int addNewUser(string username, string pass, string email) override;

private:

	void sqlRunQuery(string sqlStatement, int(*callback)(void*, int, char**, char**), void* data) const;
	void sqlRunQuery(string sqlStatement, int(*callback)(void*, int, char**, char**)) const;
	void sqlRunQuery(string sqlStatement) const;
	void createTables() const;

	sqlite3* _db;
};

