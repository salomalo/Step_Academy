// відео написання цього коду викладено на сторінці http://www.ex.ua/78789972?r=78155343



#include "Queue.h"
#include "CInt.h"

#include <ctime>
#include <iostream>
using namespace std;

void main()
{
	srand( time( NULL ) );

	int  iValue;
	bool isSucces;

	Queue<int> q1( 7 );		// обов'язково вказуємо, якого типу елементи прийматиме наша шаблонна черга

	cout <<"___________________ ENQUEUE INT  ___________________\n";
	do{
		iValue = rand() % 222;
		isSucces = q1.enqueue( iValue );
		cout <<"iValue " <<iValue <<" enqueued " <<( isSucces ? "successfully\n" : "--- FAIL ! ---\n" );
	} while( isSucces );

	cout <<"queue: " <<q1 <<endl;

	cout <<"___________________ DEQUEUE INT ___________________\n";
	do{
		isSucces = q1.dequeue( iValue );
		cout <<"iValue " <<iValue <<" dequeued " <<( isSucces ? "successfully\n" : "--- FAIL ! ---\n" );
	} while( isSucces );




	cout <<"\n\n\n";
	cout <<"___________________ ENQUEUE double  ___________________\n";
	Queue<double> q2(5);	// обов'язково вказуємо, якого типу елементи прийматиме наша шаблонна черга
	double dValue;
	q2.enqueue( 11.1 );
	q2.enqueue( 12.2 );
	q2.enqueue( 33.3 );
	q2.enqueue( 44.4 );
	cout <<"queue: " <<q2 <<endl;

	cout <<"___________________ DEQUEUE double ___________________\n";
	do{
		isSucces = q2.dequeue( dValue );
		cout <<"dValue " <<dValue <<" dequeued " <<( isSucces ? "successfully\n" : "--- FAIL ! ---\n" );
	} while( isSucces );




	cout <<"\n\n\n";
	cout <<"___________________ ENQUEUE CInt  ___________________\n";
	Queue<CInt> q3(5);		// черга з об'єктів класу CInt
	do{
		iValue = rand() % 222;
		isSucces = q3.enqueue( iValue );		// для неявно приведення типів ( з int до CInt ) використовується конструктор з одним параметиром
		cout <<"iValue " <<iValue <<" enqueued " <<( isSucces ? "successfully\n" : "--- FAIL ! ---\n" );
	} while( isSucces );
	cout <<"queue: " <<q3 <<endl;
	
	cout <<"___________________ DEQUEUE CInt ___________________\n";
	CInt ciVal;
	do{
		isSucces = q3.dequeue( ciVal );
		cout <<"ciVal " <<ciVal <<" dequeued " <<( isSucces ? "successfully\n" : "--- FAIL ! ---\n" );
	} while( isSucces );


	cout <<"\n\n\n";

}
