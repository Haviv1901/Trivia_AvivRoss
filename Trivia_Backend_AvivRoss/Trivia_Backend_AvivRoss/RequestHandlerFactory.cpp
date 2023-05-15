#include "RequestHandlerFactory.h"


RequestHandlerFactory::RequestHandlerFactory(IDatabase* database) : m_loginManager(database), m_database(database)
{
}


LoginRequestHandler* RequestHandlerFactory::createLoginRequestHandler()
{
	
}
LoginManager& RequestHandlerFactory::getLoginManager()
{
	return m_loginManager;
}