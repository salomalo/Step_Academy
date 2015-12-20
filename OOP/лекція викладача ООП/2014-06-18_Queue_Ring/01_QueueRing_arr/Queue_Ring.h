#include <iostream>
#include <iomanip>
using namespace std;


class Queue_Ring
{

public:
	explicit Queue_Ring( int size );
	~Queue_Ring();

	// конструнструктор копій і оператор присвоєння зараз несуттєво, але ПОТРІБНО

	friend ostream & operator << ( ostream & left , Queue_Ring & right );


	bool enqueue( int   value );	// ставить value у хвіст черги 
	bool dequeue( int & value );	// забирає з голови черги значення у value

	/// ------------- КІЛЬЦЕ ------------------
	bool dequeueRing( int & value );	// повертає у value значення з голови черги і ставить його у хвіст




private:
	int		*arr;		// масив, у якому черга
	int		 idxTail;	// індекс останнього елемента у черзі ( -1 -- черга пуста )
	int		 size;		// розмір (місткість) черги

};