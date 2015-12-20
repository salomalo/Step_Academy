#include "SmartPtr.h"



SmartPtr::SmartPtr( XString * pXString )
{
	pStr = pXString;
	pCnt = new int(1);
	cout <<"\n   Constructor SmartPtr for '" <<(*pXString) <<"' at " <<(int)pXString <<"   (*pCnt) = " <<(*pCnt) <<endl;
}


SmartPtr::SmartPtr( SmartPtr & oSrc )
{
	pStr = oSrc.pStr;
	pCnt = oSrc.pCnt;
	(*pCnt)++;			// ��� �� �������� �������� �� ��������� pCnt
	// pCnt++;			// � ��� �� �������� ��� ���ǲ����, � �� ��������, �� �� �� �����

	cout <<"\n   Copy constructor SmartPtr for '" <<(*pStr) <<"' at " <<(int)pStr <<"   (*pCnt) = " <<(*pCnt) <<endl;
}



SmartPtr::~SmartPtr()
{
	(*pCnt)--;		// ������� ��������� ���������� �� 1

	cout <<"\n   Destructor SmartPtr for '" <<(*pStr) <<"' at " <<(int)pStr <<"   (*pCnt) = " <<(*pCnt) <<endl;

	if( *pCnt )
		return;		// ���� ������� ��� ���� -- ����� �� ������

	// ��������� ���'���
	delete pStr;
	delete pCnt;

	cout <<"     Memory cleaned\n";

}




SmartPtr & SmartPtr::operator = ( SmartPtr & oRight )
{
	// � ����� ��'��� (this) ��� ���� ����� ���� !
	(*(this->pCnt) )--;			// �������� ������� ���������

	cout <<"\n   operator = SmartPtr for '" <<(*pStr) <<"' at " <<(int)pStr <<"   (*pCnt) = " <<(*pCnt) <<endl;

	if( !( *(this->pCnt) ) )	// ���� �� ��� ������� ��������
	{
		// ������� ���'���
		delete pStr;
		delete pCnt;
		cout <<"     Memory cleaned\n";

	}

	// ����� �� ���� �� ���� ��������� ������� "��������� ���������"
	pStr = oRight.pStr;
	pCnt = oRight.pCnt;
	(*pCnt)++;			// ��� �� �������� �������� �� ��������� pCnt
	// pCnt++;			// � ��� �� �������� ��� ���ǲ����, � �� ��������, �� �� �� �����

	cout <<"\n   operator = SmartPtr for '" <<(*pStr) <<"' at " <<(int)pStr <<"   (*pCnt) = " <<(*pCnt) <<endl;

	return *this;
}


