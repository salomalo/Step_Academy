
class Queue
{

public:
	explicit Queue();
	~Queue();

	// конструнструктор копій і оператор присвоєння зараз несуттєво, але ПОТРІБНО

	bool enqueue( int   value );	// ставить value у хвіст черги 
	bool dequeue( int & value );	// забирає з голови черги значення у value



private:

	struct Enqueued
	{
		int			 value;		// саме значення, поставлене у чергу
		Enqueued	*pNext;		// вказівник на наступного у черзі
	};


	Enqueued	*pHead;		// вказівник на голову черги
	Enqueued	*pTail;		// вказівник на хвіст черги

};