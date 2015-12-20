// Spindle.cpp: implementation of the Spindle class.
//  Class to model a collection of reels
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "Spindle.h"
//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

Spindle::Spindle()
{

}

Spindle::~Spindle()
{

}

void Spindle::Hold(int iReelNum)
{
	switch (iReelNum)
	{
		case 1: Reel1.Hold();
				break;
		case 2: Reel2.Hold();
				break;
		case 3: Reel3.Hold();
				break;
		default: cout << "Error: Reel ID out of range";
				break;
	}
}

 //Randomizes the reels and draws a spin animation
void Spindle::SpinReels(int iR1X, int iR2X, int iR3X, int iRY)
{
	BOOL bFinished = FALSE, bR1Finished = FALSE, bR2Finished = FALSE, bR3Finished = FALSE;
	BOOL bReel1Held = FALSE, bReel2Held = FALSE, bReel3Held = FALSE;
	//Randomize the reel positions
	
	bReel1Held = Reel1.GetHeld();
	bReel2Held = Reel2.GetHeld();
	bReel3Held = Reel3.GetHeld();

	iReel1Idx = Reel1.Spin();
	iReel2Idx = Reel2.Spin();
	iReel3Idx = Reel3.Spin();

	 //Get the animation start positions.
	CurR1Idx = Reel1.GetPreviousSegment();
	CurR2Idx = Reel2.GetPreviousSegment();
	CurR3Idx = Reel3.GetPreviousSegment(); 

	 //Move through the arrays one segment at a time, and print to the screen for
	 //a spinning reel animation effect.
	while (!bFinished) 
	{
		 //Check if the index should be frozen or incremented
		if ((CurR1Idx == iReel1Idx)|bReel1Held) bR1Finished = TRUE;
		else
		{
			if (CurR1Idx >= 6) CurR1Idx = 0;
			else ++CurR1Idx;
		}

		if ((CurR2Idx == iReel2Idx)|bReel2Held) bR2Finished = TRUE;
		else
		{
			if (CurR2Idx >= 6) CurR2Idx = 0;
			else ++CurR2Idx;
		}

		if ((CurR3Idx == iReel3Idx)|bReel3Held) bR3Finished = TRUE;
		else
		{
			if (CurR3Idx >= 6) CurR3Idx = 0;
			else ++CurR3Idx;
		}
		 //OutPut to the screen	

		SetColour(FOREGROUND_RED|FOREGROUND_GREEN|FOREGROUND_BLUE);

		SetCursor(iR1X, (iRY - 1));
		putc(Reel1.GetReelEntry(CurR1Idx + 1), stdout);

		SetCursor(iR2X, (iRY - 1));
		putc(Reel2.GetReelEntry(CurR2Idx + 1), stdout);

		SetCursor(iR3X, (iRY - 1));
		putc(Reel3.GetReelEntry(CurR3Idx + 1), stdout);

		SetCursor(iR1X, iRY);
		putc(Reel1.GetReelEntry(CurR1Idx), stdout);

		SetCursor(iR2X, iRY);
		putc(Reel2.GetReelEntry(CurR2Idx), stdout);

		SetCursor(iR3X, iRY);
		putc(Reel3.GetReelEntry(CurR3Idx), stdout);

		SetCursor(iR1X, (iRY + 1));
		putc(Reel1.GetReelEntry(CurR1Idx - 1), stdout);

		SetCursor(iR2X, (iRY + 1));
		putc(Reel2.GetReelEntry(CurR2Idx - 1), stdout);

		SetCursor(iR3X, (iRY + 1));
		putc(Reel3.GetReelEntry(CurR3Idx - 1), stdout);

		if (bR1Finished && bR2Finished && bR3Finished) bFinished = TRUE;

		 //Windows API call Sleep, found in windows.h. Pause program execution for specified number of milli-seconds.
		Sleep(500);
	}
}

 //Returns the entry iReelEntry from reel number iReelNum.
int Spindle::GetReelEntry(int iReelNum, int iReelEntry)
{
	int RetVal;
	switch (iReelNum)
	{
		case 1: RetVal = Reel1.GetReelEntry(iReelEntry);
				break;
		case 2: RetVal = Reel2.GetReelEntry(iReelEntry);
				break;
		case 3: RetVal = Reel3.GetReelEntry(iReelEntry);
				break;
		default: cout << "Error - No such Reel!";
				break;
	}
	return RetVal;
}

 //Returns the selected reel entry from reel iReelNum
int Spindle::GetReelSelected(int iReelNum)
{
	int RetVal;
	switch (iReelNum)
	{
		case 1: RetVal = Reel1.GetCurrentSelect();
				break;
		case 2: RetVal = Reel2.GetCurrentSelect();
				break;
		case 3: RetVal = Reel3.GetCurrentSelect();
				break;
		default: cout << "Error - No such Reel!";
				break;
	}
	return RetVal;
}

void Spindle::Nudge(int iReelIdx)
{
	switch (iReelIdx)
	{
		case 1: Reel1.RotateOne();
				break;
		case 2: Reel2.RotateOne();
				break;
		case 3: Reel3.RotateOne();
				break;
		default: cout << "Error - No such Reel!";
				break;
	}
}
