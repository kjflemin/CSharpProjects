// DevilsDice.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <istream>
#include "stdio.h"
#include "string.h"
#include "stdlib.h"//rand
#include "time.h"
using namespace std;

char GetActionFromUser();
int RollDie();
void YouLoseAllYourPoints();
void YouWin();
bool PlayAgain();
int OpponentTurn(int, int, int);
string ParseString(string, int);

int main()
{
	int PlayerScore = 0;
	int TotalPlayerScore = 0;
	int OpponentScore = 0;
	int TotalOpponentScore = 0;
	bool PlayAgainFlag = true;
	char UserAction;
	int WinningPoints = 40;//force game to max points, good for debugging

	//string scores = ParseString("2,1", 0);
	//scores = ParseString("2,1", 1);
	//scores = ParseString("20,1", 0);
	//scores = ParseString("2,10", 1);
	//scores = ParseString("2,1", 0);
	//scores = ParseString("2,1", 1);

	do
	{
		UserAction = GetActionFromUser();
		int dieroll = 0;
		switch (UserAction)
		{
		case 'r':
			dieroll = RollDie();
			cout << "You Rolled a " << dieroll << endl;
			if (dieroll == 1)
			{
				YouLoseAllYourPoints();
				PlayerScore = 0;
				TotalOpponentScore += OpponentTurn(TotalPlayerScore, TotalOpponentScore, WinningPoints);
				if (TotalOpponentScore >= WinningPoints)
				{
					cout << "Devil wins!" << TotalOpponentScore << endl;
					//reset scores to play again
					PlayerScore = 0;
					TotalPlayerScore = 0;
					OpponentScore = 0;
					TotalOpponentScore = 0;
				}
			}
			else {
				PlayerScore += dieroll;
				if (PlayerScore >= WinningPoints)
				{
					YouWin();
					PlayAgainFlag = PlayAgain();
					//reset scores to play
					PlayerScore = 0;
					TotalPlayerScore = 0;
					OpponentScore = 0;
					TotalOpponentScore = 0;
				}
			}
			cout << "Your current score is > " << PlayerScore << endl;
			break;

		case 'h':
			cout << "Holding?" << " Ok, it's the Devils turn.";
			TotalPlayerScore += PlayerScore;
			TotalOpponentScore += OpponentTurn(TotalPlayerScore, TotalOpponentScore, WinningPoints);
			if (TotalOpponentScore >= WinningPoints)
			{
				cout << "Devil wins!" << TotalOpponentScore << endl;
			}
			break;

		case 'f':
			cout << "You Lose! Bye.";
			return 0;
			break;

		default:
			break;
		}

	} while (PlayAgainFlag);

	return 0;
}

int OpponentTurn(int playerScore, int devilScore, int WinningScore) {
	int devilTurnScore = 0;
	bool devilTurnOver = false;
	int devilGoal = 21;

	if (playerScore > devilScore)
	{
		devilGoal = 30;
	}

	cout << endl;

	while (!devilTurnOver)
	{
		if ((devilTurnScore < devilGoal) && (devilScore + devilTurnScore < WinningScore))
		{
			int devilRoll = RollDie();
			cout << "Devils Roll " << devilRoll << endl;
			if (devilRoll == 1)
			{
				devilTurnScore = 0;
				devilTurnOver = true;
			}
			else
			{
				devilTurnScore += devilRoll;
			}
		}
		else
		{
			devilTurnOver = true;
		}
	}

	cout << "Devil got " << devilTurnScore << " points" << endl << endl;
	return devilTurnScore;

}

int RollDie() {
	int dice = 0;
	srand(static_cast<unsigned int>(time(0)));//comment this if you want the same numbers every time
	time_t timer1, timer2;
	//double seconds;
	timer1 = time(NULL);

	//I had to add the loop here to use up time. Since the random # is based on time
	// if the macine is fast, it will get the same random number. Adding time will
	// make sure I get different die rolls. You can test this in Jarvis or your
	// machine.
	do
	{
		timer2 = time(NULL);

	} while (timer2 < timer1 + 1);

	dice = 1 + (rand() % 6);
	return dice;
}

bool PlayAgain() {
	char UserInput;
	bool GetOutOfLoop = false;

	while (true)//do this forever unless you get a valid char
	{
		cout << "Play Again? (Y/N)";
		cin >> UserInput;
		switch (UserInput)
		{
		case 'y':
		case 'Y':
			cout << endl;
			return true;

		case 'n':
		case 'N':
			cout << endl;
			return false;

		default:
			break;
		}
	}

}

char GetActionFromUser() {
	char UserInput;
	bool GetOutOfLoop = false;

	while (true)
	{
		cout << "[H]old  [R]oll  [F]orfeit:";
		cin >> UserInput;
		switch (UserInput)
		{
		case 'h':
		case 'H':
			return 'h';

		case 'r':
		case 'R':
			return 'r';

		case 'f':
		case 'F':
			return 'f';

		default:
			break;
		}
	}
}

void YouLoseAllYourPoints() {
	cout << "You lose all your points!";
}

void YouWin() {
	cout << "You win!";
}

string ParseString(string myString, int GetColumn) {
	int length = myString.length();
	string ReturnString = "";
	int CurrentColumn = 0;

	if (length > 0)
	{
		for (int cnt = 0; cnt < length; cnt++)
		{
			if (cnt == length - 1)
			{
				if (CurrentColumn == GetColumn)
				{
					ReturnString += myString[cnt];
					return ReturnString;
				}
				else
				{
					return "";//Wanted column does not exist
				}
			}
			if (myString[cnt] == ',')
			{
				if (CurrentColumn == GetColumn)
				{
					return ReturnString;
				}
				else
				{
					CurrentColumn++;
					ReturnString = "";
				}
			}
			else
			{
				ReturnString += myString[cnt];
			}

		}
	}
}