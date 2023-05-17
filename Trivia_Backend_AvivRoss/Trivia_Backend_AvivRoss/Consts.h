#pragma once
#include <vector>

#define DB_PATH "TriviaDB.sqlite"
#define EMAIL_REGEX "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$"
#define PASSWORD_REGEX "^^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8}$"
#define DEBUG_MODE true // on or off debug prints

static const unsigned short PORT = 6969; // port to bind
static const unsigned int IFACE = 0;

typedef unsigned char byte;
typedef std::vector<byte> Buffer;

enum {ERROR_CODE=0, LOGIN_CODE=1, SIGN_UP_CODE=2, MENU_CODE =3};

