#include "StatisticsManager.h"




StatisticsManager::StatisticsManager(IDatabase* database) : m_database(database)
{
}

std::vector<string> StatisticsManager::getHighScore()
{
	return m_database->getHighScores();
}
std::vector<string> StatisticsManager::getUserStatistics(string username)
{
	std::vector<string> stats;

	stats.push_back("Average Answer Time: " + std::to_string(m_database->getPlayerAverageAnswerTime(username)));
	stats.push_back("Number Of Correct Answers: " + std::to_string(m_database->getNumOfCorrectAnswers(username)));
	stats.push_back("Number Of Total Answers: " + std::to_string(m_database->getNumOfTotalAnswers(username)));
	stats.push_back("Number Of Player Games: " + std::to_string(m_database->getNumOfPlayerGames(username)));
	stats.push_back("Player Score: " + std::to_string(m_database->getPlayerScore(username)));
	
	return stats;
}