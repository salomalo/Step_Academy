#include <iostream>
#include <iomanip>
using namespace std;


class Queue_Ring
{

public:
	explicit Queue_Ring();
	~Queue_Ring();

	// ���������������� ���� � �������� ��������� ����� ��������, ��� ���в���

	bool enqueue( int   value );	// ������� value � ���� ����� 
	bool dequeue( int & value );	// ������ � ������ ����� �������� � value

	friend ostream & operator << ( ostream & left , Queue_Ring & right );

	bool dequeueRing( int & value );


private:

	struct Enqueued
	{
		int			 value;		// ���� ��������, ���������� � �����
		Enqueued	*pNext;		// �������� �� ���������� � ����
	};


	Enqueued	*pHead;		// �������� �� ������ �����
	Enqueued	*pTail;		// �������� �� ���� �����

};