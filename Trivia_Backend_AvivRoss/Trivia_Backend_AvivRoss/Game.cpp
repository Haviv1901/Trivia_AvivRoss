#include "Game.h"


Game::Game(std::vector<Question> questions, unsigned int gameId)
	: m_questions(questions), m_gameId(gameId)
{
}

Question Game::getQuestionForUser(LoggedUser user)
{
	
}
void Game::submitAnswer(LoggedUser user, unsigned int answerId);
void Game::removePlayer(LoggedUser user);