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

void StatisticsManager::addGameResult(string username, int correctAnswers, int totalAnswers, float averageAnswerTime)
{
	m_database->addGameResult(username, correctAnswers, totalAnswers, averageAnswerTime);
}