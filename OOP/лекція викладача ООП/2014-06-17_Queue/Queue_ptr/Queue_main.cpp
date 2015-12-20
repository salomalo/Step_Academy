#include "Queue.h"

#include <iostream>
#include <ctime>
using namespace std;

void main()
{
	srand( time( NULL ) );

	int  value;
	bool isSucces;

	Queue q1;
	int limit = 9;

	cout <<"___________________ ENQUEUE ___________________\n";
	do{
		value = rand() % 222;
		isSucces = q1.enqueue( value );
		cout <<"value " <<value <<" enqueued " <<( isSucces ? "successfully\n" : "--- FAIL ! ---\n" );
	} while( isSucces && limit-- );

	cout <<"___________________ DEQUEUE ___________________\n";
	do{
		isSucces = q1.dequeue( value );
		cout <<"value " <<value <<" dequeued " <<( isSucces ? "successfully\n" : "--- FAIL ! ---\n" );
	} while( isSucces );




}
