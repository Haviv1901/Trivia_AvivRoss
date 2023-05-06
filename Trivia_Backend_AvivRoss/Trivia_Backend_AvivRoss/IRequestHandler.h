#pragma once
#include <ctime>
#include <vector>

struct
{
	int id; // int ???
	time_t receivalTime; // time_t is ctime's object
	std::vector<BYTE> buffer;
} typedef RequestInfo;

class IRequestHandler // virtual "" "" = 0;
{
	virtual bool isRequestRelevant(RequestInfo) = 0;
	virtual RequestInfo handleRequest(RequestInfo) = 0;
};