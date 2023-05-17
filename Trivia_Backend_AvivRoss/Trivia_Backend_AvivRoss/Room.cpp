#include "Room.h"

// ctor
Room::Room(RoomData roomData) : m_roomData(roomData)
{
}

/**
 * \brief add user to room
 * \param user 
 */
void Room::addUser(LoggedUser user)
{
	m_users.push_back(user);
}

/**
 * \brief remove user from room
 * \param user 
 */
void Room::removeUser(LoggedUser user)
{
	m_users.erase(std::remove(m_users.begin(), m_users.end(), user), m_users.end());
}

/**
 * \brief return all names of users in room
 * \return vector with all the names as strings.
 */
std::vector<string> Room::getAllUsers()
{
	std::vector<string> names;
	for (auto name : m_users)
	{
		names.push_back(name.getUsername());
	}
	return names;
}