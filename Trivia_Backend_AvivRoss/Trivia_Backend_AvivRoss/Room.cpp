#include "Room.h"

// ctor
// create room and insert the creator to he list.
Room::Room(LoggedUser creator, RoomData roomData) : m_roomData(roomData)
{
	m_users.push_back(creator);
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
	for (auto it = m_users.begin(); it != m_users.end(); ++it)
	{
		if (it->getUsername() == user.getUsername())
		{
			m_users.erase(it);
			break;
		}
	}
}

/**
 * \brief return all names of users in room
 * \return vector with all the names as strings.
 */
std::vector<string> Room::getAllUsers() const
{
	std::vector<string> names;
	for (auto name : m_users)
	{
		names.push_back(name.getUsername());
	}
	return names;
}

RoomData Room::getData() const
{
	return m_roomData;
}