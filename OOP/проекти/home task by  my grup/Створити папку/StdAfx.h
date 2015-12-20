// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__517263A9_85F6_4913_9056_D98E4110695D__INCLUDED_)
#define AFX_STDAFX_H__517263A9_85F6_4913_9056_D98E4110695D__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

 //Include often used libraries
#include <stdio.h>
#include <windows.h>
#include <iostream.h>
#include <time.h>

enum MSGS {MSG_OUT_OF_CREDITS, MSG_OKAY};

const int iStartCredits = 30;

void SetCursor(int iX, int iY);
void SetColour(unsigned short iColour);
void PutNumber(unsigned short iNumber, int iX, int iY);

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.


#endif // !defined(AFX_STDAFX_H__517263A9_85F6_4913_9056_D98E4110695D__INCLUDED_)
