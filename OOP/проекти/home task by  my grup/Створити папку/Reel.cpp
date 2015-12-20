// Reel.cpp: implementation of the Reel class.
//  Class to model a single fruit machine spinning reel.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "Reel.h"

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

Reel::Reel()
{
	 // seed randomization
	srand(time(NULL));
	 //Create reel class
	for (int iCount = 0;iCount < 6;iCount++) 
		cReelArr[iCount] = (char) iCount + 1;	
	
	cReelArr[6] = 'j';

	iCurIdx = 0;
	iLastIdx = 0;
}

Reel::~Reel()
{

}

//////////////////////////////////////////////////////////////////////
// Operations
//////////////////////////////////////////////////////////////////////

 //Prevents this reel from spinning
void Reel::Hold()
{
	bMeHeld = TRUE;
}

 //Returns a random number which is the final index of the array.
int Reel::Spin()
{
	 //Get a random number, which will be the index of the final item in the array	
	 //returns a random number between 0 and 5 (array is 0-5).
	 //Uses this formula : RandomSeed%(high-(low-1))+low or RandomSeed%(6-(0-1))+0 which simplifies to RandomSeed%6
	if (!bMeHeld)
	{
		iLastIdx = iCurIdx;
		iCurIdx = rand()%6;
	}
	bMeHeld = FALSE;
	return iCurIdx;
}
 
 //'Rotates' the reel one segment up (down on screen), and returns the new selected index
int Reel::RotateOne()
{
	 //decrement current selected index variable.
	iLastIdx = iCurIdx;
	if (iCurIdx == 6) iCurIdx = 0;
	else iCurIdx++;
	return iCurIdx;
}

 //returns the currently selected reel segment.
char Reel::GetCurrentSegment()
{
	return cReelArr[iCurIdx];
}

 //Returns the Reel entry held at index.
char Reel::GetReelEntry(int Index)
{
	 //If the index value is out of bounds wrap it.
	if (Index < 0) Index = Index + 6;
	if (Index > 6) Index = Index - 6;
		
	return cReelArr[Index];
}

int Reel::GetPreviousSegment()
{
	return iLastIdx;
}

 //Returns the last index in the reel.
int Reel::GetMaxSegments()
{
	return 6;
}

int Reel::GetCurrentSelect()
{
	return iCurIdx;
}

BOOL Reel::GetHeld()
{
	return bMeHeld;
}
