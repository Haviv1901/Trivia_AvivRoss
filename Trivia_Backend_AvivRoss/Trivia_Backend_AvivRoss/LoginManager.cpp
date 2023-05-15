#include "LoginManager.h"
#include "Consts.h"
#include <vector>
#include <regex>

const char emailRegEx[] = "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$";

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
bool LoginManager::signup(const string& email, const string&  username, const string& pass)
{
	if (!regex_match(email, std::regex(EMAIL_REGEX)))
	{
		throw std::exception("invalid email. ->  **@**.**  ");
	}
	if (!regex_match(pass, std::regex(PASSWORD_REGEX)))
	{
		throw std::exception("Password must be 8 chars long, atleast 1 big char, 1 small char, 1 number, and one of these chars: ! @ # $ % ^ & *");
	}
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
bool LoginManager::login(const string& username, const string& password)
{
	if (!m_database->doesUserExist(username))
	{
		return false;
	}
	if(!m_database->doesPasswordMatch(password, username))
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
bool LoginManager::logout(const string& username)
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