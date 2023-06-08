#pragma once
#include "Game.h"
#include "GameManager.h"
#include "IRequestHandler.h"
#include "RequestHandlerFactory.h"


class GameRequestHandler :
    public IRequestHandler
{
public:

	GameRequestHandler(Game& game, LoggedUser& user, GameManager& gameManager, RequestHandlerFactory& handlerFactory);

	bool isRequestRelevant(RequestInfo req) override;
	RequestResult handleRequest(RequestInfo req) override;

	RequestResult getQuestion(RequestInfo req);
	RequestResult submitAnswer(RequestInfo req);
	RequestResult getGameResult(RequestInfo req);
	RequestResult leaveGame(RequestInfo req);

	RequestResult error(RequestInfo req, string errorMessage);

private:
	clock_t m_startTime;
    Game& m_game;
    LoggedUser m_user;
	GameManager& m_gameManager;
	RequestHandlerFactory& m_handlerFactory;
};

