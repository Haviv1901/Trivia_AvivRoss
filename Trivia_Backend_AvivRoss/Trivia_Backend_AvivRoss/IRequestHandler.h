#pragma once
#include <ctime>
#include <vector>
#include <string>

#include "Consts.h"

using std::string;

class IRequestHandler;

struct LoginRequest
{
	string username;
	string password;
} typedef LoginRequest;

struct SignupRequest
{
	string username;
	string password;
	string email;
} typedef SignupRequest;

struct RequestInfo
{
	int id;
	time_t receivalTime; // time_t is ctime's object
	Buffer buffer;
} typedef RequestInfo;



struct RequestResult
{
	Buffer respones;
	IRequestHandler* newHandler;
} typedef RequestResult;

struct GetPlayersInRoomRequest
{
	unsigned int roomId;
} typedef GetPlayersInRoomRequest;

struct JoinRoomRequest
{
	unsigned int roomId;
} typedef JoinRoomRequest;

struct CreateRoomRequest
{
	string roomName;
	unsigned int maxUsers;
	unsigned int questionCount;
	unsigned int answerTimeout;
} typedef CreateRoomRequest;



class IRequestHandler // virtual "" "" = 0;
{
public:
	virtual bool isRequestRelevant(RequestInfo req) = 0;
	virtual RequestResult handleRequest(RequestInfo req) = 0;
};