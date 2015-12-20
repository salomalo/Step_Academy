// Interface.cpp: implementation of the Interface class.
//  Class to model the front end of a fruit machine.
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "Interface.h"

#define ever ;;

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

Interface::Interface(int iCredits)
{
	myAvailCredits = iCredits;
}

Interface::~Interface()
{

}
 
 //Draws the arm release animation
void Interface::DrawArmRelease()
{
	int iHeight = 0;
	char cDraw;
	//There's eight frames in the animation.
	for (int i = 0;i < 9; i++)
	{
		for (int ii = 0; ii < 9; ii++)
		{
			 //if we're at the top of the handle
			if (ii == iHeight)
			{
				cDraw = 'O';
				SetColour(FOREGROUND_BLUE|FOREGROUND_GREEN|FOREGROUND_RED|BACKGROUND_RED);
			}
			else if (ii > iHeight)
			{
				cDraw = ' ';
				SetColour(FOREGROUND_BLUE|FOREGROUND_GREEN|FOREGROUND_RED);
			}
			else if (ii == 0)
			{
				cDraw = '+';
				SetColour(FOREGROUND_BLUE|FOREGROUND_GREEN|FOREGROUND_RED|BACKGROUND_BLUE);
			}
			else
			{
				cDraw = '|';
				SetColour(FOREGROUND_BLUE|FOREGROUND_GREEN|FOREGROUND_RED|BACKGROUND_BLUE);
			}
			SetCursor(22,(10 - ii));
			putc(cDraw, stdout);
		}
		 //pause for 100 ms
		Sleep(100);
		 //increment iHeight
		iHeight++;
	}
}

 //Draws the arm pull animation
void Interface::DrawArmPull()
{
	int iHeight = 8;
	char cDraw;
	//There's eight frames in the animation.
	for (int i = 0;i < 9; i++)
	{
		for (int ii = 0; ii < 9; ii++)
		{
			 //if we're at the top of the handle
			if (ii == iHeight)
			{
				cDraw = 'O';
				SetColour(FOREGROUND_BLUE|FOREGROUND_GREEN|FOREGROUND_RED|BACKGROUND_RED);
			}
			else if (ii > iHeight)
			{
				cDraw = ' ';
				SetColour(FOREGROUND_BLUE|FOREGROUND_GREEN|FOREGROUND_RED);
			}
			else if (ii == 0)
			{
				cDraw = '+';
				SetColour(FOREGROUND_BLUE|FOREGROUND_GREEN|FOREGROUND_RED|BACKGROUND_BLUE);
			}
			else
			{
				cDraw = '|';
				SetColour(FOREGROUND_BLUE|FOREGROUND_GREEN|FOREGROUND_RED|BACKGROUND_BLUE);
			}
			SetCursor(22,(10 - ii));
			putc(cDraw, stdout);
		}
		 //pause for 100 ms
		Sleep(100);
		 //decrement iHeight
		iHeight--;
	}
}

 //Draws the arm without animation
void Interface::DrawArm()
{
	SetColour(FOREGROUND_BLUE|FOREGROUND_GREEN|FOREGROUND_RED|BACKGROUND_RED);
	SetCursor(22,2);
	putc('O',stdout);
	SetColour(FOREGROUND_BLUE|FOREGROUND_GREEN|FOREGROUND_RED|BACKGROUND_BLUE);
	for (int i = 3; i < 10; i++)
	{
		SetCursor(22,i);
		putc('|',stdout);
	}
	SetCursor(22,10);
	putc('+',stdout);
	SetColour(FOREGROUND_BLUE|FOREGROUND_GREEN|FOREGROUND_RED);
}


 //Draws the machine
void Interface::DrawMachine()
{
	 //Clear the screen
	system("cls");
	 //The following lines draw the one armed bandit ASCII graphics to the screen.
	SetColour(FOREGROUND_BLUE|FOREGROUND_GREEN|FOREGROUND_RED|BACKGROUND_BLUE);

	printf("                     \n      ");

	SetColour(FOREGROUND_RED|BACKGROUND_BLUE|BACKGROUND_GREEN|BACKGROUND_RED|BACKGROUND_INTENSITY);

	printf("C++ Games");

	SetColour(FOREGROUND_BLUE|FOREGROUND_GREEN|FOREGROUND_RED|BACKGROUND_BLUE);

	printf("      \n                     \n");
	printf("  ");
	
	SetColour(FOREGROUND_RED|BACKGROUND_BLUE|BACKGROUND_GREEN|BACKGROUND_RED|BACKGROUND_INTENSITY);

	printf("  +-+  +-+  +-+  ");
	
	SetColour(FOREGROUND_BLUE|FOREGROUND_GREEN|FOREGROUND_RED|BACKGROUND_BLUE);

	printf("  \n");
	
	printf("  ");
	
	SetColour(FOREGROUND_RED|BACKGROUND_BLUE|BACKGROUND_GREEN|BACKGROUND_RED|BACKGROUND_INTENSITY);

	printf("  | |  | |  | |  ");
	
	SetColour(FOREGROUND_BLUE|FOREGROUND_GREEN|FOREGROUND_RED|BACKGROUND_BLUE);

	printf("  \n");
	
	printf("  ");
	
	SetColour(FOREGROUND_RED|BACKGROUND_BLUE|BACKGROUND_GREEN|BACKGROUND_RED|BACKGROUND_INTENSITY);

	printf("--| |--| |--| |--");
	
	SetColour(FOREGROUND_BLUE|FOREGROUND_GREEN|FOREGROUND_RED|BACKGROUND_BLUE);

	printf("  \n");
	
	printf("  ");
	
	SetColour(FOREGROUND_RED|BACKGROUND_BLUE|BACKGROUND_GREEN|BACKGROUND_RED|BACKGROUND_INTENSITY);

	printf("  | |  | |  | |  ");
	
	SetColour(FOREGROUND_BLUE|FOREGROUND_GREEN|FOREGROUND_RED|BACKGROUND_BLUE);

	printf("  \n");
	
	printf("  ");
	
	SetColour(FOREGROUND_RED|BACKGROUND_BLUE|BACKGROUND_GREEN|BACKGROUND_RED|BACKGROUND_INTENSITY);

	printf("  +-+  +-+  +-+  ");

	SetColour(FOREGROUND_BLUE|FOREGROUND_GREEN|FOREGROUND_RED|BACKGROUND_BLUE);	

	printf("  \n");
	
	printf("                     \n               ");
	
	SetColour(FOREGROUND_BLUE|FOREGROUND_GREEN|FOREGROUND_RED);	

	printf("<_>");

	SetColour(FOREGROUND_BLUE|FOREGROUND_GREEN|FOREGROUND_RED|BACKGROUND_BLUE);	

	printf("   \n                     -\n   ");

	SetColour(FOREGROUND_BLUE|FOREGROUND_GREEN|FOREGROUND_RED);	

	printf("<_____________>");

	SetColour(FOREGROUND_BLUE|FOREGROUND_GREEN|FOREGROUND_RED|BACKGROUND_BLUE);	

	printf("   \n");

	for (int i = 0; i < 6; i++)
	{
		for (int ii = 0; ii < 21; ii++) printf(" ");
		printf("\n");
	}

	 //Display the number of available credits.
	SetColour(FOREGROUND_GREEN|FOREGROUND_RED|BACKGROUND_BLUE);
	SetCursor(2,9);
	printf("Credits=");
	PutNumber(myAvailCredits,10,9);
	
	 //Draw the reel start positions
	SetColour(FOREGROUND_BLUE|FOREGROUND_GREEN|FOREGROUND_RED);
	
	SetCursor(5,4);
		putc(mySpindle.GetReelEntry(1,(mySpindle.GetReelSelected(1) + 1)),stdout);
	SetCursor(5,5);
		putc(mySpindle.GetReelEntry(1,mySpindle.GetReelSelected(1)),stdout);
	SetCursor(5,6);
		putc(mySpindle.GetReelEntry(1,(mySpindle.GetReelSelected(1) - 1)),stdout);
	
	SetCursor(10,4);
		putc(mySpindle.GetReelEntry(2,(mySpindle.GetReelSelected(2) + 1)),stdout);
	SetCursor(10,5);
		putc(mySpindle.GetReelEntry(2,mySpindle.GetReelSelected(2)),stdout);
	SetCursor(10,6);
		putc(mySpindle.GetReelEntry(2,(mySpindle.GetReelSelected(2) - 1)),stdout);

	SetCursor(15,4);
		putc(mySpindle.GetReelEntry(3,(mySpindle.GetReelSelected(3) + 1)),stdout);
	SetCursor(15,5);
		putc(mySpindle.GetReelEntry(3,mySpindle.GetReelSelected(3)),stdout);
	SetCursor(15,6);
		putc(mySpindle.GetReelEntry(3,(mySpindle.GetReelSelected(3) - 1)),stdout);

	DrawArm();

	 //Reset the cursor position
	SetCursor(0,18);
}

 //Draws a pull animation for the arm and spins the reels.
MSGS Interface::PullArm()
{
	MSGS myMSG = MSG_OKAY;
	int iNumMatching = 0;
	int iWonCredits = 0;

	if (myAvailCredits > 0)
	{
		 //Remove one credit
		myAvailCredits--;
		 //Redraw the entire game machine
		DrawMachine();
		 //Draw the arm pull animation
		DrawArmPull();
		DrawArmRelease();
		 //Randomize the reels
		mySpindle.SpinReels(5,10,15,5);

		 //if not awarded nudges the randomize holds
		if (!CheckNudges()) CheckHolds();

		 //Now Check for win
		if (mySpindle.GetReelSelected(1) == mySpindle.GetReelSelected(2))
			iNumMatching++;
		if (mySpindle.GetReelSelected(1) == mySpindle.GetReelSelected(3))
			iNumMatching++;
		if (mySpindle.GetReelSelected(2) == mySpindle.GetReelSelected(3))
			iNumMatching++;

		SetCursor(0,19);

		DrawMachine();
		switch (iNumMatching)
		{
			case 0: cout << "Lose!\n";
					break;
			case 1: cout << "One Match!\n";
					break;
			case 2: //if iNumMatching = 2 or 3 then this is a win, so fall through.
			case 3: cout << "We have a winner!\n";
					 //Calculate the number of credits won.
					iWonCredits = (((mySpindle.GetReelSelected(1) + 1) / 2) + 1);
					cout << "You have won " << iWonCredits << " credits!\n";
					myAvailCredits = myAvailCredits + iWonCredits;
					break;
			default: cout << "This (should be) impossible!";
					break;
		}

		SetCursor(0,18);
	}
	else myMSG = MSG_OUT_OF_CREDITS;
	 //Return the messages to the main function
	return myMSG;
}

 //Returns the number of credits remaining
int Interface::GetCreditsRemain()
{
	return myAvailCredits;
}

void Interface::SetCreditsRemain(int iCredits)
{
	myAvailCredits = iCredits;
}

 //Randomly decides whether or not to award a nudge(s), if a nudge is award holds won't be award.
BOOL Interface::CheckNudges()
{
	int iRand = 0;
	char cUserResponce;
	SetCursor(0,20);
	 //seed randomization
	srand(time(NULL));
	iRand = rand()%10;
	 //if iRand = 7 then award a nudge
	if (iRand == 7)
	{
		 //Work out how many nudges they get
		 //RandomSeed%(high-(low-1))+low
		iRand = rand()%(4)+1;
		SetCursor(0,20);
		cout << "You have been awarded " << iRand << " nudges\n";
		while (iRand > 0)
		{
			cout << "Nudges left " << iRand << " Which reel you would like to nudge (1/2/3) ";
			cin >> cUserResponce;
			switch (cUserResponce)
			{
				case '1': mySpindle.Nudge(1);
						iRand--;
						break;
				case '2': mySpindle.Nudge(2);
						iRand--;
						break;
				case '3': mySpindle.Nudge(3);
						iRand--;
						break;
				default: break;
			}
			DrawMachine();
			if (iRand > 0)
			{
				cout << "Do you want to use your ramaining nudges? (y/n) ";
				cin >> cUserResponce;
				if (cUserResponce == 'n') iRand = 0;
			}
		}
		return TRUE;
	}
	else return FALSE;
}
 
 //Randomly decides whether or not to award holds
void Interface::CheckHolds()
{
	int iRand = 0;
	BOOL bExit = FALSE, bReelSel = FALSE;
	char cUserResponce;
	
	SetCursor(0,20);
	 //seed randomization
	srand(time(NULL));
	iRand = rand()%5;
	 //if iRand = 3 then award holds
	if (iRand == 3)
	{
		cout << "You have been awarded holds!\n";
		for(ever)
		{
			cout << "Which Reels would you like to hold (1/2/3) ";
			cin >> cUserResponce;
			switch (cUserResponce)
			{
				case '1': mySpindle.Hold(1);
						bReelSel = TRUE;
						break;
				case '2': mySpindle.Hold(2);
						bReelSel = TRUE;
						break;
				case '3': mySpindle.Hold(3);
						bReelSel = TRUE;
						break;
				default :
						bReelSel = FALSE;
						break;
			}
			if (bReelSel)
			{
				cout << "Would you like to select another reel? (y/n) ";
				cin >> cUserResponce;
				if (cUserResponce == 'y');
				else bExit = TRUE;
			}
			DrawMachine();
			if (bExit) break;
		}
	}
}
