#pragma once
#include <ctime>
#include <vector>
#include <string>

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
	std::vector<char> buffer;
} typedef RequestInfo;



struct RequestResult
{
	std::string respones; // buffer ?
	IRequestHandler* newHandler;
} typedef RequestResult;

class IRequestHandler // virtual "" "" = 0;
{
	virtual bool isRequestRelevant(RequestInfo req) = 0;
	virtual RequestInfo handleRequest(RequestInfo req) = 0;
};