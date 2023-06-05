#pragma once
#include "Game.h"
#include "Room.h"

class GameManager
{
public:

	GameManager(IDatabase* database);

	Game createGame(Room);
	void deleteGame(int gameId);

private:

	static unsigned int m_idGenerator;
	std::vector<Game> m_games;
	IDatabase* m_database;
};
