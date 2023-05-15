#include "LoginManager.h"
#include <vector>

LoginManager::LoginManager(IDatabase* database)
{
	m_database = database;
}

/**
 * \brief sign up and login a new user
 * \param email 
 * \param username 
 * \param pass 
 * \return 
 */
bool LoginManager::signup(string email, string username, string pass)
{
	if(m_database->doesUserExist(username))
	{
		return false;
	}
	if(m_database->addNewUser(username, pass, email))
	{
		m_loggedUsers.push_back(LoggedUser(username));
		return true;
	}
	return false;
}

/**
 * \brief login a new user
 * \param username 
 * \param passowrd 
 * \return 
 */
bool LoginManager::login(string username, string passowrd)
{
	if (m_database->doesUserExist(username))
	{
		return false;
	}
	if(!m_database->doesPasswordMatch(passowrd, username))
	{
		return false;
	}
	

	m_loggedUsers.push_back(LoggedUser(username));

	return true;
}

/**
 * \brief logout a user
 * \param username 
 * \return 
 */
bool LoginManager::logout(string username)
{
	for(auto iter = m_loggedUsers.begin() ; iter != m_loggedUsers.end() ; iter++)
	{
		if(iter->getUsername() == username)
		{
			iter = m_loggedUsers.erase(iter);
			return true;
		}
	}
	return false;
}