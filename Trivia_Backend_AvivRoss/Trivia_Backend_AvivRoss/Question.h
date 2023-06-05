#pragma once
#include <string>
#include <vector>

class Question
{

public:
	Question();

	Question(std::string question, std::vector<std::string> possibleAnswers, int correctAnswerId);

	std::string getQuestion();
	std::vector<std::string> getPossibleAnswers();
	int getCorrectAnswerId();

private:
	int m_correctAnswerId;
	std::string m_question;
	std::vector<std::string> m_possibleAnswers;
};

