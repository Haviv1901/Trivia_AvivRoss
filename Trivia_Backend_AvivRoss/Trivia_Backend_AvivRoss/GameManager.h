#pragma once
#include "Game.h"
#include "Room.h"
#include "IDatabase.h"


class GameManager
{
public:

	GameManager(IDatabase* database);

	Game& createGame(Room);
	void deleteGame(int gameId);
	Game& getGameByUser(string user, Room room);

private:

	static unsigned int m_idGenerator;
	std::vector<Game> m_games;
	IDatabase* m_database;
};

