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
	int id; // int ???
	time_t receivalTime; // time_t is ctime's object
	Buffer buffer;
} typedef RequestInfo;



struct RequestResult
{
	Buffer respones;
	IRequestHandler* newHandler;
} typedef RequestResult;

class IRequestHandler // virtual "" "" = 0;
{
	virtual bool isRequestRelevant(RequestInfo req) const = 0;
	virtual RequestResult handleRequest(RequestInfo req) const = 0;
};