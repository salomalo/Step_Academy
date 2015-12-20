#include "QueuePrior.h"


void main()
{
	QueuePrior q1(7);

	cout <<"___________	ENQUEUE ____________\n";
	q1.enqueue_NoPr( 5, 7 );
	cout <<q1 <<"\n";
	q1.enqueue_NoPr( 5, 3 );
	cout <<q1 <<"\n";
	q1.enqueue_NoPr( 5, 6 );
	cout <<q1 <<"\n";
	q1.enqueue_NoPr( 5, 3 );
	cout <<q1 <<"\n";
	q1.enqueue_NoPr( 5, 8 );
	cout <<q1 <<"\n";
	q1.enqueue_NoPr( 5, 1 );

	cout <<q1 <<"\n\n\n";

	cout <<"___________	DEQUEUE ____________\n";
	int val, pri;
	q1.dequeue( val, pri );
	cout <<"dequeued: " <<val <<'(' <<pri <<"): \n";
	cout <<q1 <<"\n\n";

	q1.dequeue( val, pri );
	cout <<"dequeued: " <<val <<'(' <<pri <<"): \n";
	cout <<q1 <<"\n\n";

	q1.dequeue( val, pri );
	cout <<"dequeued: " <<val <<'(' <<pri <<"): \n";
	cout <<q1 <<"\n\n";

	cout <<q1 <<"\n\n\n";

}