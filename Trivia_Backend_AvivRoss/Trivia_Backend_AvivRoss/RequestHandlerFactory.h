#pragma once
#include "LoginManager.h"
#include "LoginRequestHandler.h"
#include "MenuRequestHandler.h"
#include "RoomManager.h"

class LoginRequestHandler;
class MenueRequestHandler;

class RequestHandlerFactory
{
public:

	RequestHandlerFactory(IDatabase* database);
	LoginRequestHandler* createLoginRequestHandler();
	MenuRequestHandler* createMenuRequestHandler();
	LoginManager& getLoginManager();

	//StatisticsManager& getStaticsManager() const;
	RoomManager& getRoomManager();

private:
	LoginManager m_loginManager;
	IDatabase* m_database;

	RoomManager m_roomManager;
	//StatisticsManager m_statisticsManager;
};

