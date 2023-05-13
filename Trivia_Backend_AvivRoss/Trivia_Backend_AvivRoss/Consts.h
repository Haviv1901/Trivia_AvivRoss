#pragma once
#include <vector>

#define DB_PATH "TriviaDB.sqlite"

static const unsigned short PORT = 6969; // port to bind
static const unsigned int IFACE = 0;

typedef unsigned char byte;
typedef std::vector<byte> Buffer;

#define DEBUG_MODE true // on or off debug prints
#define LOGIN_CODE 1
#define SIGN_UP_CODE 2

