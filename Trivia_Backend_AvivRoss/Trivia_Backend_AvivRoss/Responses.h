#pragma once
#include <string>
#include <vector>
#include "Consts.h"

using std::string;
using std::vector;

struct ErrorResponse
{
	Buffer messagge;
} typedef ErrorResponse;

struct LoginResponse
{
	unsigned int status;
} typedef LoginResponse;

struct SignupResponse
{
	unsigned int status;
} typedef SignupResponse;

struct LogoutResponse
{
	unsigned int status;
} typedef LogoutResponse;

struct GetRoomsResponse
{
	unsigned int status;
	//vector<RoomData> rooms
} typedef GetRoomsResponse;

struct GetHighScoreResponse
{
	unsigned int status;
	std::vector<std::string> statistics;
} typedef GetHighScoreResponse;

struct GetPersonalStatsResponse
{
	unsigned int status;
	vector<string> statistics;
} typedef GetPersonalStatsResponse;