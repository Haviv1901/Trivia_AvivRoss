#pragma once
#include <vector>

#include "IDatabase.h"

class StatisticsManager
{
public:

	StatisticsManager(IDatabase* database);

	std::vector<string> getHighScore();
	std::vector<string> getUserStatistics(string username);

private:
	IDatabase* m_database;
};

