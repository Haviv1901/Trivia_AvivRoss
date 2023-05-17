#pragma once
#include <map>

#include "Room.h"

class RoomManager
{
public:
	RoomManager();

	void createRoom(LoggedUser creator, RoomData data);
	void deleteRoom(int roomId);
	unsigned int getRoomState(int roomId) const;
	std::vector<Room> getRooms();
	Room& getRoom(int roomId);

private:
	std::map<unsigned int, Room> m_rooms; // room id, room handle
};

