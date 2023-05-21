#pragma once
#include <vector>

#include "IDatabase.h"

class StatisticsManager
{
public:

	StatisticsManager(IDatabase* database);

	std::vector<Statistics> getHighScore();
	Statistics getUserStatistics(string username);

private:
	IDatabase* m_database;
};

