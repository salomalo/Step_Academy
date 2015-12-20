// Fruit machine.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "Interface.h"

#define ever ;;

int main(int argc, char* argv[])
{
	BOOL bExit = FALSE;
	int iRetVal = 0;
	char cUserResponce;
	 //Create and initialise a new instance of interface
	Interface myInterface(iStartCredits);
	 //Setup the screen
	myInterface.DrawMachine();
	 //Continue execution until user cancels
	for(ever)
	{
		iRetVal = myInterface.GetCreditsRemain();
		if (iRetVal == 0)
		{
			cout << "Your out of credits! play again? (y/n)";
			cin >> cUserResponce;
			switch (cUserResponce)
			{
				case 'y': 
					myInterface.SetCreditsRemain(iStartCredits);
					myInterface.DrawMachine();
					break;
				case 'n':
					bExit = TRUE;
					break;
				default:
					break;
			}
		}
		else
		myInterface.DrawMachine();
		{
			cout << "Would you like to gamble? (y/n) ";
			cin >> cUserResponce;
			switch (cUserResponce)
			{
				case 'y': 
					myInterface.PullArm();
					break;
				case 'n':
					bExit = TRUE;
					break;
				default:
					break;
			}
		}
		 //If user selected exit then break.
		if (bExit) break;
	}
	cout << "Thanks for playing and come again!\n";
	return 0;
}

 //Sets the cursor (next print position for the console in windows.
void SetCursor(int iX, int iY)
{
	COORD myCoord;
	myCoord.X = iX;
	myCoord.Y = iY;
	SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), myCoord);
}

 //Sets the console text colour in windows
void SetColour(unsigned short iColour)
{
	BOOL b = SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), iColour);
}

 //Prints a number to the screen - as a number, not an ASCII.
 //Can handle any positive number lower than 999
void PutNumber(unsigned short iNumber, int iX, int iY)
{
	char cPrintNum;
	unsigned short iOffSet = 0;
	BOOL bOverHundred = FALSE;

	if ((iNumber >= 100) && (iNumber < 1000))
	{
		cPrintNum = char((iNumber / 100) + 48);
		iNumber = iNumber % 100;
		SetCursor(iX,iY);
		putc(cPrintNum,stdout);
		iOffSet++;
		bOverHundred = TRUE;
	}
	if (((iNumber >= 10) && (iNumber < 100))|bOverHundred)
	{
		cPrintNum = char((iNumber / 10) + 48);
		iNumber = iNumber % 10;
		SetCursor(iX + iOffSet,iY);
		putc(cPrintNum,stdout);
		iOffSet++;
	}
	if ((iNumber >= 0) && (iNumber < 10))
	{
		cPrintNum = char(iNumber + 48);
		SetCursor(iX + iOffSet, iY);
		putc(cPrintNum,stdout);
	}	
}
