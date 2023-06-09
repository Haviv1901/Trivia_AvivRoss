#include "RoomManager.h"

#include <algorithm>
#include <iterator>


RoomManager::RoomManager()
{
}

/**
 * \brief create room
 * \param creator 
 * \param data 
 */
void RoomManager::createRoom(LoggedUser creator, RoomData data)
{
	m_rooms.insert({ data.id, Room(creator, data) });
}

/**
 * \brief remove room.
 * \param roomId 
 */
void RoomManager::deleteRoom(int roomId)
{
	auto it = m_rooms.find(roomId);
	if (it != m_rooms.end())
	 {
		m_rooms.erase(it);
	}
}
unsigned int RoomManager::getRoomState(int roomId)
{
	auto it = m_rooms.find(roomId);
	return it->second.getData().id;
}
std::vector<Room> RoomManager::getRooms()
{
	std::vector<Room> res;
	for (auto it = m_rooms.begin(); it != m_rooms.end(); ++it) {

		if (!it->second.getData().isActive) // dont show rooms which have allready started the game.
		{
			res.push_back(it->second);
		}
		
	}
	return res;
}
Room& RoomManager::getRoom(int roomId)
{
	return m_rooms.at(roomId);
}