#include "Queue_Ring.h"

#include <iostream>
#include <ctime>
using namespace std;

void main()
{
	srand( time( NULL ) );

	int  value;
	bool isSucces;

	Queue_Ring q1( 7 );

	cout <<"___________________ ENQUEUE ___________________\n";
	do{
		value = rand() % 222;
		isSucces = q1.enqueue( value );
		cout <<"value " <<value <<" enqueued " <<( isSucces ? "successfully\n" : "--- FAIL ! ---\n" );
	} while( isSucces );
	
	cout <<"\n\n" << q1 <<"\n";
	for( int i = 0 ; i < 22 ; i++ )
	{
		q1.dequeueRing( value );
		cout <<"\ndequeued : " <<setw(4) <<value <<"  queue:";
		cout << q1;

	}

	cout <<"\n\n";


	cout <<"___________________ DEQUEUE ___________________\n";
	do{
		isSucces = q1.dequeue( value );
		cout <<"value " <<value <<" dequeued " <<( isSucces ? "successfully\n" : "--- FAIL ! ---\n" );
	} while( isSucces );




}
