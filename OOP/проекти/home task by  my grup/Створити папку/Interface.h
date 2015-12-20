// Interface.h: interface for the Interface class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_INTERFACE_H__91F2358C_498C_4861_B81C_F76AD93FEEAC__INCLUDED_)
#define AFX_INTERFACE_H__91F2358C_498C_4861_B81C_F76AD93FEEAC__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "Spindle.h"

class Interface  
{
private:
	void CheckHolds();
	BOOL CheckNudges();
	Spindle mySpindle;
	int myAvailCredits;

public:
	void DrawArm();
	 //Constructors/Destructors
	Interface(int iCredits);
	virtual ~Interface();
	 //Operations
	void DrawMachine();
	void DrawArmRelease();
	void DrawArmPull();
	MSGS PullArm();
	 //Get/Set methods
	int GetCreditsRemain();
	void SetCreditsRemain(int iCredits);
};

#endif // !defined(AFX_INTERFACE_H__91F2358C_498C_4861_B81C_F76AD93FEEAC__INCLUDED_)
