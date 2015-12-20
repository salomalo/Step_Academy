#include "Stack.h"
#include <ctime>


void main()
{
	srand( time(0));
	int value;

	Stack st1( 5 );
	Stack * st2 = new Stack( 5 );

	//value =  rand()% 1000;
	//cout <<"Pushing " <<value  <<" ... " <<( st1.push( value ) ? "Ok" : "overflow") <<endl;

	//value =  rand()% 1000;
	//cout <<"Pushing " <<value  <<" ... " <<( st1.push( value ) ? "Ok" : "overflow") <<endl;

	//value =  rand()% 1000;
	//cout <<"Pushing " <<value  <<" ... " <<( st1.push( value ) ? "Ok" : "overflow") <<endl;

	//value =  rand()% 1000;
	//cout <<"Pushing " <<value  <<" ... " <<( st1.push( value ) ? "Ok" : "overflow") <<endl;

	//value =  rand()% 1000;
	//cout <<"Pushing " <<value  <<" ... " <<( st1.push( value ) ? "Ok" : "overflow") <<endl;

	//value =  rand()% 1000;
	//cout <<"Pushing " <<value  <<" ... " <<( st1.push( value ) ? "Ok" : "overflow") <<endl;

	bool isSuccess;
	do{
		value =  rand()% 1000;
		isSuccess = st1.push( value );
		cout <<"Pushing " <<value  <<" ... " <<( isSuccess ? "Ok" : "overflow") <<endl;
		cout << st1 <<endl <<endl;
	} while( isSuccess );

	st2->push( 1234567 );
	cout <<"\n\nst2:\n" <<(*st2) <<endl;
	(*st2) = st1;
	cout <<"\n\nst2 after:\n" <<(*st2) <<endl;

	delete st2;

	cout <<"st1  " <<st1;

	cout <<"\n\n\n";

}