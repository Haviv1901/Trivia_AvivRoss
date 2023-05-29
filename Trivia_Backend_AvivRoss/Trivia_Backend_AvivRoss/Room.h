#pragma once
#include <string>
#include <vector>

#include "LoggedUser.h"

using std::string;

struct RoomData
{
	unsigned int id;
	string name;
	unsigned int maxPlayers;
	unsigned int numOfQuestionsInGame;
	unsigned int timePerQuestion;
	unsigned int isActive;
} typedef RoomData;

class Room
{

public:
	Room(LoggedUser creator, RoomData roomData);

	void addUser(LoggedUser user);
	void removeUser(LoggedUser user);
	std::vector<string> getAllUsers() const;
	RoomData getData() const;

private:
	//RoomData m_metadat; ????? what is that name
	RoomData m_roomData;
	std::vector<LoggedUser> m_users;
};

