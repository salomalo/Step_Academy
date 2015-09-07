#include <deque>

#include <iostream>

using namespace std;

template <typename TYPE >
void showDeque( deque<TYPE> & oDeque , const char * name )
{

	cout <<"deque '" <<name  <<"':\n";
	deque<TYPE>::iterator itCur = oDeque.begin();	// ≥тератор початку
	deque<TYPE>::iterator itEnd = oDeque.end();		// ≥тератор к≥нц€

	while( itCur != itEnd )
	{
		cout << *itCur <<' ';
		itCur++;
	}
	cout <<endl<<endl;
}


void main()
{
	double dArr [] = { 11.11, 22.22, 33.33, 44.44, 55.55, 66.66, 77.77 };
	
	//deque<double> oDeque( 5 , 55.55 );		// ≥н≥ц≥ал≥зуЇмо вектор п'€тьма 55.55
	deque<double> oDeque ( dArr , dArr + 7 );	// ≥н≥ц≥ал≥зуЇмо вектор масивом, задавши вказ≥вник на початок ≥ к≥нець
	showDeque( oDeque , "oDeque" );


	deque<double> oDeque1( oDeque.begin() +2 , oDeque.end() - 3 );	// ≥н≥ц≥ал≥зуЇмо вектор ≥ншим вектором, вказавши його ≥тератори
	showDeque( oDeque1 , "oDeque1" );

	oDeque.push_back( 44.66 );
	oDeque.push_back( 88.7 );
	oDeque.push_back( 458.97 );
	oDeque.push_front( 0.11);
	oDeque.push_front( 0.22);
	oDeque.push_front( 0.33);
	showDeque( oDeque , "oDeque" );

	deque<double> oDeque2( oDeque.rbegin(), oDeque.rend() );	// ≥н≥ц≥ал≥зуЇмо вектор ≥ншим вектором, вказавши його ≥тератори
	showDeque( oDeque2 , "oDeque2" );



	cout <<"\n\n\n";
}
