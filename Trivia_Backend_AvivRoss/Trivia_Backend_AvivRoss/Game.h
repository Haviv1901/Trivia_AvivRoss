#pragma once
#include <map>

#include "IDatabase.h"
#include "LoggedUser.h"

struct GameData
{
	Question currentQuestion;
	unsigned int questioNum;
	unsigned int numOfCorrectAnswers;
	unsigned int numOfWrongAnswers;
	float averageAnswerTime;

	GameData() : currentQuestion(Question()), numOfCorrectAnswers(0), numOfWrongAnswers(0), questioNum(0), averageAnswerTime(0)
	{
	}

	GameData(Question que) : currentQuestion(que), numOfCorrectAnswers(0), numOfWrongAnswers(0), questioNum(0), averageAnswerTime(0)
	{
	}
};



class Game
{
public:

	Game(std::vector<Question> questions, unsigned int gameId, std::map<string, GameData> players);

	Question getQuestionForUser(LoggedUser user);
	void submitAnswer(LoggedUser user, unsigned int answerId, double timeTookToAnswer);
	void removePlayer(LoggedUser user);

	unsigned int getGameId();
	std::map<string, GameData> getPlayers();

private:

	std::vector<Question> m_questions;
	std::map<string, GameData> m_players;
	unsigned int m_gameId;

};