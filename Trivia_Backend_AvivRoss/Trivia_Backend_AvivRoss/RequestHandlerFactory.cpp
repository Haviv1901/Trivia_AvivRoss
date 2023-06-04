#include "RequestHandlerFactory.h"


RequestHandlerFactory::RequestHandlerFactory(IDatabase* database) : m_loginManager(database), m_database(database), m_statisticsManager(database)
{
}


LoginRequestHandler* RequestHandlerFactory::createLoginRequestHandler()
{
	return new LoginRequestHandler(*this);
}

MenuRequestHandler* RequestHandlerFactory::createMenuRequestHandler(LoggedUser user)
{
	return new MenuRequestHandler(user, m_roomManager, m_statisticsManager, *this);
}

LoginManager& RequestHandlerFactory::getLoginManager()
{
	return m_loginManager;
}

StatisticsManager& RequestHandlerFactory::getStatisticsManager()
{
	return m_statisticsManager;
}

RoomManager& RequestHandlerFactory::getRoomManager()
{
	return m_roomManager;
}

RoomAdminRequestHandler* RequestHandlerFactory::createAdminRequestHandler(Room room, LoggedUser user)
{
	return new RoomAdminRequestHandler(room, user, m_roomManager, *this);
}
RoomMemberRequestHandler* RequestHandlerFactory::createMemberRequestHandler(Room room, LoggedUser user)
{
	return new RoomMemberRequestHandler(room, user, m_roomManager, *this);
}