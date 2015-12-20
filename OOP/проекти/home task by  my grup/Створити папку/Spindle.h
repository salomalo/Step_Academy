// Spindle.h: interface for the Spindle class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_SPINDLE_H__8C63985B_3F59_4FDE_A925_3F25F9DACB80__INCLUDED_)
#define AFX_SPINDLE_H__8C63985B_3F59_4FDE_A925_3F25F9DACB80__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "reel.h"

class Spindle  
{
private:
	Reel Reel1, Reel2, Reel3;
	int iReel1Idx, iReel2Idx, iReel3Idx, CurR1Idx, CurR2Idx, CurR3Idx;

public:
	void Nudge(int iReelIdx);
	 //Constructors/Destructors
	Spindle();
	virtual ~Spindle();
	 //Operations
	void Hold(int iReelNum);
	void SpinReels(int iR1X, int iR2X, int iR3X, int iRY);
	 //Get/Set methods
	int GetReelEntry(int iReelNum, int iReelEntry);
	int GetReelSelected(int iReelNum);

};

#endif // !defined(AFX_SPINDLE_H__8C63985B_3F59_4FDE_A925_3F25F9DACB80__INCLUDED_)
