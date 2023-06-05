#pragma once
#include "GameManager.h"
#include "LoginManager.h"
#include "LoginRequestHandler.h"
#include "MenuRequestHandler.h"
#include "RoomManager.h"
#include "RoomMemberRequestHandler.h"
#include "RoomAdminRequestHandler.h"
#include "GameRequestHandler.h"

class LoginRequestHandler;
class MenuRequestHandler;
class RoomMemberRequestHandler;
class RoomAdminRequestHandler;
class GameRequestHandler;

class RequestHandlerFactory
{
public:

	RequestHandlerFactory(IDatabase* database);
	LoginRequestHandler* createLoginRequestHandler();
	MenuRequestHandler* createMenuRequestHandler(LoggedUser user);
	RoomAdminRequestHandler* createAdminRequestHandler(Room room, LoggedUser user);
	RoomMemberRequestHandler* createMemberRequestHandler(Room room, LoggedUser user);
	LoginManager& getLoginManager();

	StatisticsManager& getStatisticsManager();
	RoomManager& getRoomManager();

	GameRequestHandler* createGameRequestHandler(Room room, LoggedUser user);
	GameManager& getGameManager();

private:
	LoginManager m_loginManager;
	IDatabase* m_database;
	RoomManager m_roomManager;
	StatisticsManager m_statisticsManager;
	GameManager m_gameManager;
};

