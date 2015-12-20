#include <iostream>
using namespace std;


class QueuePrior
{

public:
	explicit QueuePrior( int size );				// конструктор, приймає розмір черги
	QueuePrior( QueuePrior & oSrc );				// конструктор копій
	~QueuePrior();									// деструктор, звільняє пам'ять
//	QueuePrior & operator = ( QueuePrior & oSrc );	// щоби коректно копіювати об'єкти при присвоєнні
	
	bool enqueue( int value, int priority );		// ставить у чергу value з пріоритетом priority і повертає true, якщо помістився
													// ( ставить у чергу, враховуючи пріоритет, хоча можна просто ставити у кінець, але тоді треба вилучати по пріоритету)

	bool enqueue_NoPr( int value, int priority );	// ставить у чергу value з пріоритетом priority і повертає true, якщо помістився
													// ( ставить у чергу, НЕ враховуючи пріоритет)

	bool dequeue( int & value, int & priority );	// знаходить у черзі ел-т з найвищим пріоритетом і повертає його


	friend ostream & operator << ( ostream & left, const QueuePrior & right );

private:
	struct Enqueued		// ця структура буде приватна, тобто, недоступні ззовні
	{	
		int value;		// занчення, поставлене у чергу
		int prior;		// пріоритет цього значення

	}; // struct Enqueued

	Enqueued	*arr;		// масив з елементами черги
	int			 size;		// розмір масиву (ємність черги)
	int			 idxTail;	// індекс хвоста черги (останнього елемента у черзі, коли черга порожня -- -1 )
							// голова черги -- завжди у елементі з індексом 0

};