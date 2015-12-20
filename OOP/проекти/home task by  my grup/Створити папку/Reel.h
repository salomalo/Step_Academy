// Reel.h: interface for the Reel class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_REEL_H__4246D65D_E083_40AD_A710_4DED8BB93436__INCLUDED_)
#define AFX_REEL_H__4246D65D_E083_40AD_A710_4DED8BB93436__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

class Reel  
{
private:
	char cReelArr[6];
	unsigned short int iCurIdx;
	unsigned short int iLastIdx;
	BOOL bMeHeld;

public:
	BOOL GetHeld();
	int GetCurrentSelect();
	 //Constructors/Destructors
	Reel();
	virtual ~Reel();
	 //Operations
	void Hold();
	int Spin();
	int RotateOne();
	 //Get/Set methods
	char GetCurrentSegment();
	char GetReelEntry(int Index);
	int GetPreviousSegment();
	int GetMaxSegments();
};

#endif // !defined(AFX_REEL_H__4246D65D_E083_40AD_A710_4DED8BB93436__INCLUDED_)
