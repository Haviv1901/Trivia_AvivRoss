#include "StatisticsManager.h"




StatisticsManager::StatisticsManager(IDatabase* database) : m_database(database)
{
}

std::vector<Statistics> StatisticsManager::getHighScore()
{
	return m_database->getHighScores();
}
Statistics StatisticsManager::getUserStatistics(string username)
{
	return m_database->getStats(username);
}