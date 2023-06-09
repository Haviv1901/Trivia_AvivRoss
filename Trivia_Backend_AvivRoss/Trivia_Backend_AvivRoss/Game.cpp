#include "Game.h"
#include <mutex>

std::mutex playersMutex;

Game::Game(std::vector<Question> questions, unsigned int gameId, std::map<string, GameData> players)
	: m_questions(questions), m_players(players), m_gameId(gameId)
{
	for(auto player : m_players)
	{
		m_playerReady[player.first] = false;
	}
}

Question Game::getQuestionForUser(LoggedUser user)
{
	return m_players[user.getUsername()].currentQuestion;
}


void Game::submitAnswer(LoggedUser user, unsigned int answerId, double timeTookToAnswer)
{
	if (m_players[user.getUsername()].currentQuestion.getCorrectAnswerId() == answerId)
	{
		m_players[user.getUsername()].numOfCorrectAnswers++;
	}
	else
	{
		m_players[user.getUsername()].numOfWrongAnswers++;
	}
	m_players[user.getUsername()].averageAnswerTime = ((float)m_players[user.getUsername()].averageAnswerTime + timeTookToAnswer) / (float)2;
	int questionNum = m_players[user.getUsername()].numOfWrongAnswers + m_players[user.getUsername()].numOfCorrectAnswers;
	try
	{
		m_players[user.getUsername()].currentQuestion = m_questions[questionNum];
	}
	catch (...)
	{
		m_players[user.getUsername()].currentQuestion = m_questions[questionNum-1];
	}
	
}
void Game::removePlayer(LoggedUser user)
{
	playersMutex.lock();
	m_playerReady.erase(user.getUsername());
	//m_players.erase(user.getUsername());
	playersMutex.unlock();
}

unsigned int Game::getGameId()
{
	return m_gameId;
}

std::map<string, GameData> Game::getPlayers()
{
	return m_players;
}

std::map<string, bool>& Game::getPlayerReady()
{
	return m_playerReady;
}