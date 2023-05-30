#pragma once
#include <vector>

#define DB_PATH "TriviaDB.sqlite"
#define EMAIL_REGEX "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$"
#define PASSWORD_REGEX "^^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8}$"
#define DEBUG_MODE true // on or off debug prints
#define API_ADDRESS L"https://opentdb.com/api.php?amount=10&category=15&type=multiple"

static const unsigned short PORT = 6969; // port to bind
static const unsigned int IFACE = 0;

typedef unsigned char byte;
typedef std::vector<byte> Buffer;

enum {
	ERROR_CODE = 0, LOGIN_CODE = 10, SIGN_UP_CODE = 12, // login codes 1X

	MENU_CODE = 20, SIGNOUT_CODE = 21, GET_ROOMS_CODE = 22, GET_PLAYERS_IN_ROOM_CODE = 23,  // menu codes 2X
	GET_PERSONAL_STATS_CODE = 24, GET_HIGH_SCORE_CODE = 25, JOIN_ROOM_CODE = 26, CREATE_ROOM_CODE = 27, LAST_MENU_CODE,

	CLOSE_OR_LEAVE_ROOM_CODE = 30, START_GAME_CODE, GET_ROOM_STATE_CODE, LAST_ROOM_CODE // room codes 3X
};

