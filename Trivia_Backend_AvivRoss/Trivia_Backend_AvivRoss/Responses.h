#pragma once
#include <string>
#include <vector>
#include "Consts.h"
#include "helper.h"
#include "Room.h"

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


//v2
struct LogoutResponse
{
	unsigned int status;
} typedef LogoutResponse;

struct GetRoomsResponse
{
	unsigned int status;
	vector<RoomData> rooms;
} typedef GetRoomsResponse;

struct GetPlayersInRoomResponse
{
	vector<string> players;
} typedef GetPlayersInRoomResponse;

struct GetHighScoreResponse
{
	//unsigned int status;
	vector<Statistics> statistics;
} typedef GetHighScoreResponse;

struct GetPersonalStatsResponse
{
	unsigned int status;
	Statistics statistics;
} typedef GetPersonalStatsResponse;

struct JoinRoomResponse
{
	unsigned int status;
} typedef JoinRoomResponse;

struct CreateRoomResponse
{
	unsigned int roomId;
} typedef CreateRoomResponse;


struct CloseRoomResponse
{
	unsigned int status;
} typedef CloseRoomResponse;


struct StartGameResponse
{
	unsigned int status;
} typedef StartGameResponse;

struct GetRoomStateResponse
{
	unsigned int status;
	bool hasGameBegun;
	vector<string> players;
	unsigned int questionCount;
	unsigned int answerTimeout;
} typedef GetRoomStateResponse;

struct LeaveRoomResponse
{
	unsigned int status;
} typedef LeaveRoomResponse;

struct LeaveGameResponse
{
	unsigned int status;
} typedef LeaveGameResponse;

struct GetQuestionResponse
{
	unsigned int status;
	string question;
	string rightAnswer;
	vector<string> wrongAnswers;
	//std::map<unsigned int, string> answers; // answer id (1-4), answer
} typedef GetQuestionResponse;

struct SubmitAnswerResponse
{
	unsigned int status;
} typedef SubmitAnswerResponse;

struct PlayerResults
{
	string username;
	unsigned int correctAnswerCount;
	unsigned int wrongAnswerCount;
	unsigned int averageAnswerTime;
	unsigned int score;
} typedef PlayerResults;

struct GetGameResultsResponse
{
	unsigned int status;
	vector<PlayerResults> results;
} typedef GetGameResultsResponse;

