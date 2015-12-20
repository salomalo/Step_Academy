#include "XString.h"


class SmartPtr
{

public:
	SmartPtr( XString * pXString );
	SmartPtr( SmartPtr & oSrc );
	~SmartPtr();

	SmartPtr & operator = ( SmartPtr & oRight );

	XString & operator *  () { return *pStr; }
	XString * operator -> () { return  pStr; }


private:
	XString	* pStr;		// ��� �������� ��� SmartPoiner ���������, �� ������ ��� !
	int		* pCnt;

};