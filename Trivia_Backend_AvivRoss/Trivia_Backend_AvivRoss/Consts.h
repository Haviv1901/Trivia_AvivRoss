#pragma once
#include <vector>

#define DB_PATH "TriviaDB.sqlite"

static const unsigned short PORT = 6969; // port to bind
static const unsigned int IFACE = 0;

typedef unsigned char byte;
typedef std::vector<byte> Buffer;

#define DEBUG_MODE true // on or off debug prints

enum {ERROR_CODE=0, LOGIN_CODE=1, SIGN_UP_CODE=2, MENU=3};

