#include <iostream>
#include <iomanip>
using namespace std;


class Queue_Ring
{

public:
	explicit Queue_Ring();
	~Queue_Ring();

	// ____________ конструнструктор копій ___________________
	Queue_Ring( Queue_Ring & oSrc );


	bool enqueue( int   value );	// ставить value у хвіст черги 
	bool dequeue( int & value );	// забирає з голови черги значення у value

	friend ostream & operator << ( ostream & left , Queue_Ring & right );

	bool dequeueRing( int & value );


private:

	struct Enqueued
	{
		int			 value;		// саме значення, поставлене у чергу
		Enqueued	*pNext;		// вказівник на наступного у черзі
	};


	Enqueued	*pHead;		// вказівник на голову черги
	Enqueued	*pTail;		// вказівник на хвіст черги

};