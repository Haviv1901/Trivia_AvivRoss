#pragma once
#include <map>

#include "IDatabase.h"
#include "LoggedUser.h"

struct GameData
{
	Question currentQuestion;
	unsigned int correctQuestion;
	unsigned int wrongQuestion;
	float averageAnswerTime;
};

class Game
{
public:

	Game(std::vector<Question> questions, unsigned int gameId);

	Question getQuestionForUser(LoggedUser user);
	void submitAnswer(LoggedUser user, unsigned int answerId);
	void removePlayer(LoggedUser user);

private:

	std::vector<Question> m_questions;
	std::map<LoggedUser, GameData> m_players;
	unsigned int m_gameId;

};

