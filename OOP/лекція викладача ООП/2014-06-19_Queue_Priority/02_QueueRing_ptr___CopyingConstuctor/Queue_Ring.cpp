#include "Queue_Ring.h"



Queue_Ring::Queue_Ring()
	: pHead( nullptr ), pTail( nullptr )
{}



Queue_Ring::~Queue_Ring()
{
	Enqueued * pDel  = pHead;		// ��������� �������� � ������

	while( pDel )	// ���� � ���� ��������
	{
		Enqueued * pNext = pDel->pNext;	// �������� ������ ����������, ��� �� ��������
		delete pDel;					// �������� ������� �� ��������� pDel
		pDel = pNext;					// �������� �������� ���������
	}
}


// ������� value � ���� ����� 
bool Queue_Ring::enqueue( int   value )
{
	Enqueued * pNew = new Enqueued;
	if( !pNew )
		return false;

	pNew->pNext = nullptr;	// �� ����� ���� �� ������ �����
	pNew->value = value;

	if( pTail == nullptr )
	{
		pHead = pNew;
	}
	else
	{
		pTail->pNext = pNew;	// ������ ���������� "� �� ����"
	}
	pTail = pNew;			// ������ ��� "� -- ������"

	return true;
}


// ������ � ������ ����� �������� � value
bool Queue_Ring::dequeue( int & value )
{
	if( pHead == nullptr )
		return false;

	value = pHead->value;		// �������� �������� ��������, �� � ����� �����
	Enqueued * pDel = pHead;	// ������ -- �� ����� !!!
	pHead = pHead->pNext;		// ����� ������ ���� ���������
	if( pHead == nullptr )
		pTail = nullptr;		// ���� ����������� ������� -- �� ����� �������������

	delete pDel;				// ������������� �������

	return true;
}





bool Queue_Ring::dequeueRing( int & value )
{
	bool isSuccess = dequeue( value );

	if( !isSuccess )	// ����� ���� ������ -- �� ���
		return false;

	// ���� ����� ���� �� ������ -- �� ����� ��������� �� �������� � ����
	enqueue( value );
	return true;

}



ostream & operator << ( ostream & left , Queue_Ring & right )
{
	Queue_Ring::Enqueued * pCur;	// ��� �������� ����� �� �������, ������ ������ ��������
	pCur = right.pHead;				// �������� � ������ �����
	while( pCur )					// ���� ���� �� ��������
	{
		left <<setw(4) <<pCur->value <<' ';		// ��������
		pCur = pCur->pNext;						// � ���������� �� ���������� ������� �����
	}

	return left;
}




Queue_Ring::Queue_Ring( Queue_Ring & oSrc )
	: pHead(0), pTail(0)
{
	Enqueued * pCur = oSrc.pHead;	// �������� � ������
	while( pCur )
	{
		this->enqueue( pCur->value );	// ������ ������� � �����-����
		pCur = pCur->pNext;				// ������ ���������
	}
}



