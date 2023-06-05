#include "GameManager.h"
#include "Game.h"

unsigned int GameManager::m_idGenerator = 0;

GameManager::GameManager(IDatabase* database)
	: m_database(database)
{
	
}

Game GameManager::createGame(Room room)
{
	std::list<Question> questionsList = m_database->getQuestions(10);
	std::vector<Question> questions = std::vector<Question>(questionsList.begin(), questionsList.end());

	std::map<string, GameData> players;

	for (auto player : room.getAllUsers())
	{
		GameData data;
		data.currentQuestion = questions[0];
	}

	Game temp(questions, m_idGenerator++, players);
	m_games.push_back(temp);
	return temp;
}

void GameManager::deleteGame(int gameId)
{
	auto iter = std::find_if(m_games.begin(), m_games.end(), [gameId](Game& game) { return game.getGameId() == gameId; });

	m_games.erase(iter);

}