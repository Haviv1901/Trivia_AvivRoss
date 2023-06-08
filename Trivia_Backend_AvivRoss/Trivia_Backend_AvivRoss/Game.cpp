#include "Game.h"


Game::Game(std::vector<Question> questions, unsigned int gameId, std::map<string, GameData> players)
	: m_questions(questions), m_gameId(gameId), m_players(players)
{
	
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
	m_players[user.getUsername()].averageAnswerTime = (m_players[user.getUsername()].averageAnswerTime + timeTookToAnswer) / 2;
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
	m_players.erase(user.getUsername());
}

unsigned int Game::getGameId()
{
	return m_gameId;
}

std::map<string, GameData> Game::getPlayers()
{
	return m_players;
}