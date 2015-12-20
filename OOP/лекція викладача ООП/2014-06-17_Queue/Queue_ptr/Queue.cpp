#include "Queue.h"



Queue::Queue()
	: pHead( nullptr ), pTail( nullptr )
{}



Queue::~Queue()
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
bool Queue::enqueue( int   value )
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
bool Queue::dequeue( int & value )
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

