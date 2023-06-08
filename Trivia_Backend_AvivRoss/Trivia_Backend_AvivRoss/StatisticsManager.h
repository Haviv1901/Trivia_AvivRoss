#pragma once
#include <vector>

#include "IDatabase.h"

class StatisticsManager
{
public:

	StatisticsManager(IDatabase* database);

	std::vector<Statistics> getHighScore();
	Statistics getUserStatistics(string username);

	void addGameResult(string username, int correctAnswers, int totalAnswers, float averageAnswerTime);

private:
	IDatabase* m_database;
};

