#include "GameRequestHandler.h"

#include "JsonRequestPacketDeserializer.h"
#include "JsonResponsePacketSerializer.h"
#include "Responses.h"


GameRequestHandler::GameRequestHandler(Game& game, LoggedUser& user, GameManager& gameManager, RequestHandlerFactory& handlerFactory)
	: m_game(game), m_user(user), m_gameManager(gameManager), m_handlerFactory(handlerFactory)
{
	//m_game = game;
	//m_user = user;
	//m_gameManager = gameManager;
	//m_handlerFactory = handlerFactory;
}

bool GameRequestHandler::isRequestRelevant(RequestInfo req)
{
	if (req.id < GAME_CODES || req.id > LAST_GAME_CODE)
	{
		return false;
	}
	return true;
}
RequestResult GameRequestHandler::handleRequest(RequestInfo req)
{
	RequestResult res;

	try
	{
		if (!isRequestRelevant(req))
		{
			throw std::exception("Invalid Code.");
		}

		switch (req.id)
		{
		case(LEAVE_GAME_CODE):
			res = leaveGame(req);
			break;
		case(GET_QUESTION_CODE):
			res = getQuestion(req);
			break;
		case(SUBMIT_ANSWER_CODE):
			res = submitAnswer(req);
			break;
		case(GET_GAME_RESULT_CODE):
			res = getGameResult(req);
			break;

		default:
			throw std::exception("Error accored, please try again.");
		}
	}
	catch (std::exception e)
	{
		Helper::debugPrint(e.what());
		res = error(req, e.what());
	}
	catch (...)
	{
		res = error(req, "Could not parse message. pls send it in the correct format.");
	}
	return res;
}

RequestResult GameRequestHandler::getQuestion(RequestInfo req)
{
	RequestResult res;

	GetQuestionResponse getQuestionRes;
	
	getQuestionRes.status = 1;

	//m_game = m_gameManager.getGameByUser(m_user.getUsername());

	Question temp = m_game.getQuestionForUser(m_user.getUsername());

	getQuestionRes.question = temp.getQuestion(); // insertr question

	getQuestionRes.answers.insert({ 0 , temp.getPossibleAnswers()[0] });
	getQuestionRes.answers.insert({ 1 , temp.getPossibleAnswers()[1] });
	getQuestionRes.answers.insert({ 2 , temp.getPossibleAnswers()[2] });
	getQuestionRes.answers.insert({ 3 , temp.getPossibleAnswers()[3] });
	

	res.respones = JsonResponsePacketSerializer::serializeResponse(getQuestionRes);
	res.newHandler = this;
	m_startTime = clock();
	return res;
}
RequestResult GameRequestHandler::submitAnswer(RequestInfo req) 
{
	RequestResult res;
	double timeTookToAnswer = (clock() - m_startTime) / (double)CLOCKS_PER_SEC;

	SubmitAnswerRequest submingAnswerReq = JsonRequestPacketDeserializer::deserializeSubmitAnswerRequest(req.buffer);
	SubmitAnswerResponse submitAnswerRes;

	submitAnswerRes.correctAnswerId = m_game.getQuestionForUser(m_user.getUsername()).getCorrectAnswerId();
	m_game.submitAnswer(m_user.getUsername(), submingAnswerReq.answerId, timeTookToAnswer); // add here function recv also the time it took to answer



	submitAnswerRes.status = 1;
	
	res.respones = JsonResponsePacketSerializer::serializeResponse(submitAnswerRes);
	res.newHandler = this;
	return res;
	
}
RequestResult GameRequestHandler::getGameResult(RequestInfo req)
{

	std::map<string, GameData> tempPlayers = m_game.getPlayers(); // putting it all in variables so its human readable. (kinda)
	string playerName = m_user.getUsername();
	int totalAswers = tempPlayers[playerName].numOfCorrectAnswers + tempPlayers[playerName].numOfWrongAnswers;
	m_handlerFactory.getStatisticsManager().addGameResult(playerName, tempPlayers[playerName].numOfCorrectAnswers, totalAswers, tempPlayers[playerName].averageAnswerTime);
	// updating db with the game results.

	m_game.getPlayerReady()[m_user.getUsername()] = true;

	bool flag = true;
	Helper::debugPrint("waiting for all players to finish the quiz");
	while (flag) // wait for all players to finish the quiz before sending the results.
	{
		flag = false;
		for (auto user : m_game.getPlayerReady())
		{
			if (!user.second) // if a player is not ready yet
			{
				flag = true; // continue waiting
			}
		}
	}
	Helper::debugPrint("all players finished the quiz - extracting data");

	RequestResult res;
	GetGameResultsResponse getGameResultsRes;

	for (auto iter : m_game.getPlayers()) // extracting the data from the game to the response.
	{
		PlayerResults res;
		res.username = iter.first;
		res.correctAnswerCount = iter.second.numOfCorrectAnswers;
		res.wrongAnswerCount = iter.second.numOfWrongAnswers;
		res.averageAnswerTime = iter.second.averageAnswerTime;

		if (iter.second.numOfCorrectAnswers + iter.second.numOfWrongAnswers == 0)
		{
			res.score = 0;
		}
		else
		{
			res.score = ((float)iter.second.numOfCorrectAnswers / iter.second.numOfCorrectAnswers + iter.second.numOfWrongAnswers) * (float)100;
		}

		getGameResultsRes.results.push_back(res);
	}

	m_game.getPlayerReady()[m_user.getUsername()] = false; // reset the player ready status to false.
	// now check that all other threads are also reset to false to indicate they all extracted data from db
	// and now we can close the room and delete it from the map.
	Helper::debugPrint("waiting for all players to finish extracting data");
	while (flag) 
	{
		flag = false;
		for (auto user : m_game.getPlayerReady())
		{
			if (user.second) // if a player is not ready yet
			{
				flag = true; // continue waiting
			}
		}
	}
	Helper::debugPrint("all players finished extracting data - now leaving the game");
	res.respones = JsonResponsePacketSerializer::serializeResponse(getGameResultsRes);
	res.newHandler = leaveGame(req).newHandler;
	return res;
}


RequestResult GameRequestHandler::leaveGame(RequestInfo req)
{
	RequestResult res;

	LeaveGameResponse leaveGameRes;

	leaveGameRes.status = 1;

	if (m_game.getPlayers().size() == 1) // if the player is the last one in the room
	{
		m_game.removePlayer(m_user.getUsername());
		m_gameManager.deleteGame(m_game.getGameId());
		Helper::debugPrint(m_user.getUsername() + " - left and closed the game");
	}
	else
	{
		m_game.removePlayer(m_user.getUsername());
		Helper::debugPrint(m_user.getUsername() + " - left the game");
	}
	

	res.respones = JsonResponsePacketSerializer::serializeResponse(leaveGameRes);
	res.newHandler = m_handlerFactory.createMenuRequestHandler(m_user);
	return res;
}


/**
 * \brief error accored, return to communicator an error result.
 * \param req
 * \param errorMessage
 * \return
 */
RequestResult GameRequestHandler::error(RequestInfo req, string errorMessage)
{
	RequestResult res;
	ErrorResponse errorRes;
	errorRes.messagge = Helper::stringToBuffer(errorMessage);
	res.respones = JsonResponsePacketSerializer::serializeResponse(errorRes);
	res.newHandler = this;
	return res;
}