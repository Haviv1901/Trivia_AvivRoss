#include "GameRequestHandler.h"

#include "JsonRequestPacketDeserializer.h"
#include "JsonResponsePacketSerializer.h"
#include "Responses.h"


GameRequestHandler::GameRequestHandler(Game game, LoggedUser user, GameManager& gameManager, RequestHandlerFactory& handlerFactory)
	: m_game(game), m_user(user), m_gameManager(gameManager), m_handlerFactory(handlerFactory)
{
	
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
	
	m_game.submitAnswer(m_user.getUsername(), submingAnswerReq.answerId); // add here function recv also the time it took to answer


	submitAnswerRes.status = 1;
	submitAnswerRes.correctAnswerId = m_game.getQuestionForUser(m_user.getUsername()).getCorrectAnswerId();
	res.respones = JsonResponsePacketSerializer::serializeResponse(submitAnswerRes);
	res.newHandler = this;
	return res;
	
}
RequestResult GameRequestHandler::getGameResult(RequestInfo req)
{
	RequestResult res;


	GetGameResultsResponse getGameResultsRes;

	for (auto iter : m_game.getPlayers())
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

	res.respones = JsonResponsePacketSerializer::serializeResponse(getGameResultsRes);
	res.newHandler = this;
	return res;
}


RequestResult GameRequestHandler::leaveGame(RequestInfo req)
{
	RequestResult res;

	LeaveGameResponse leaveGameRes;

	leaveGameRes.status = 1;

	m_game.removePlayer(m_user.getUsername());


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