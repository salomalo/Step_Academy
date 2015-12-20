#include "List.h"

List::List()	// ������� ������ ������
	: pHead( nullptr ), pTail( nullptr )
{}


List::~List()
{
	cout <<" \n Destructor for pHead=" <<(int)pHead <<endl;
	clear();
}



List::List( List & oSrc )
	: pHead( nullptr ), pTail( nullptr )	// ������ this �������� ������
{
	// ���������� �������� oSrc, ��������� � ������
	Node * pCur = oSrc.pHead;			// �������� � ������
	while( pCur )
	{
		this->addTail( pCur->value );	// �� this ������ ������� ��������
		pCur = pCur->pNext;				// ���������� �� ���������� �������� ������-��������
	}
}





bool List::addTail( int val )	// ���� val � ���� ������ (������� ���������)
{
	Node * pNew = new Node;
	if( !pNew )			// ���� �� ������� ���'��
		return false;

	pNew->value = val;			// �������� � �� ��������
	pNew->pNext = nullptr;		// ���� ���� ������� (� �����)

	if( !pTail )	// ���� ������ ��� ������
	{
		// ���� ���� - ��� ������ ����� ������, ��������� ������� � �������
		pTail = pNew;	
		pHead = pNew;	
	}
	else
	{
		pTail->pNext = pNew;		// ���� ��� ����� �� ���, �� ���� ���������
		pTail = pNew;				// ���� ��� ���������, �� �� ���������� pTail
	}
	return true;
}





ostream & operator << ( ostream & oLeft , List & oRight )
{	
	cout <<"pHead=" <<(int)oRight.pHead <<"  ";				// �������� ������ ���'��
	List::Node * pCur = oRight.pHead;
	while( pCur )	// ���� pCur ������ ������ �������� (�� null )
	{
		oLeft << pCur->value <<' ';
		pCur = pCur->pNext;		// ��� �������� ��������� ������� ������
	}

	return oLeft;
}



bool List::addHead( int val )		// ���� val � ������ ������ (������   ���������)
{
	Node * pNew = new Node;
	if( !pNew )
		return false;

	pNew->value = val;		// ��������
	pNew->pNext = pHead;	// ���� ���� ��� ����� ��, �� ���� ������

	if( ! pHead )	// ���� ��� ������ ������
	{
		// ���� ���� ���� � � �����, � � �����
		//pHead = pNew;
		pTail = pNew;
	}

	pHead = pNew;			// ���� ���� ����� ������

	return true;
}


bool List::remHead( int & val )
{
	if( ! pHead )		// ���� ������ ������� ...
		return false;

	if( pHead == pTail )	// ���� ������ ��� � ������ ��������
	{
		// ��������� ������ �������
		val = pTail->value;
		delete pTail;
		pTail = nullptr;
		pHead = nullptr;
		return true;
	}


	Node * pDel = pHead;	// ��� �� ����� ��������� ��������
	val = pHead->value;		// �������� ����
	pHead = pHead->pNext;	// ������� ����� ��������� �������

	delete pDel;			// ��������� ���� ���������

	return true;
}



bool List::remTail( int & val )		// ������ � ���������� �������� � ����� � val
{
	if( ! pTail )		// ���� ������ ������� ...
		return false;


	if( pHead == pTail )	// ���� ������ ��� � ������ ��������
	{
		// ��������� ������ �������
		val = pTail->value;
		delete pTail;
		pTail = nullptr;
		pHead = nullptr;
		return true;
	}


	// ������ ����������Ͳ� �������
	Node * pPrev = pHead;	// �������� � ������
	while( pPrev->pNext != pTail )	// ���� �� ������ �� ���������������
	{
		pPrev = pPrev->pNext;	// ���������� �� �������
	}
	// � ����� ���� pPrev ����� �� ������������ ����

	val = pTail->value;			// ��������� ��������
	delete pTail;				// ��������� ������� ����, ����� ����� ����������
	pPrev->pNext = nullptr;		// ������������ ���� ��� ���������, �����, �� �� ����������
	pTail = pPrev;				// �������� �������� �� �� ������� ����

	return true;
}




void List::clear()					// ����� ������
{
	int tmp;
	while( pHead )
		remHead( tmp );

}






