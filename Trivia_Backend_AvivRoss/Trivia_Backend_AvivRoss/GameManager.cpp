#include "GameManager.h"
#include "Game.h"

unsigned int GameManager::m_idGenerator = 0;

GameManager::GameManager(IDatabase* database)
	: m_database(database)
{
	
}



Game& GameManager::createGame(Room room)
{
	std::list<Question> questionsList = m_database->getQuestions(10);
	std::vector<Question> questions = std::vector<Question>(questionsList.begin(), questionsList.end());

	std::map<string, GameData> players; // username -> GameData

	for (auto player : room.getAllUsers())
	{
		GameData data;
		data.currentQuestion = questions[0];
		data.averageAnswerTime = 0;
		data.numOfCorrectAnswers = 0;
		data.numOfWrongAnswers = 0;
		players.insert({ player, data });
	}

	
	m_games.push_back(Game(questions, ++m_idGenerator, players));
	return m_games.back();
}

void GameManager::deleteGame(int gameId)
{
	auto iter = std::find_if(m_games.begin(), m_games.end(), [gameId](Game& game) { return game.getGameId() == gameId; });

	m_games.erase(iter);

}

Game& GameManager::getGameByUser(string user, Room room)
{


	for (auto& element : m_games)
	{
		if (element.getPlayers().count(user) > 0)
		{
			return element;
		}
	} // if the user is in some game retuirn that game, if not create new game with the room

	return createGame(room);
}



