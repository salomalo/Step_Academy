
class Queue
{

public:
	explicit Queue( int size );
	~Queue();

	// конструнструктор копій і оператор присвоєння зараз несуттєво, але ПОТРІБНО

	bool enqueue( int   value );	// ставить value у хвіст черги 
	bool dequeue( int & value );	// забирає з голови черги значення у value



private:
	int		*arr;		// масив, у якому черга
	int		 idxTail;	// індекс останнього елемента у черзі ( -1 -- черга пуста )
	int		 size;		// розмір (місткість) черги

};