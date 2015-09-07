#include "Trio.h"

void main()
{
	Duet< int , char > oDuet1( 12345 , '$' );
	oDuet1.Show();
	cout <<endl <<endl;

	Duet< const char * , char > oDuet2( "___1_2_3_4_5___" , '$' );
	oDuet2.Show();
	cout <<endl <<endl;

	Trio< double, short , int > oTrio( 123.456, 222, 1234567 );
	oTrio.Show();
	cout <<endl <<endl;


	Trio < int, int , void* > oVoid( 123, 456 , (void*)111 );
	oVoid.Show();

	cout <<"\n\n\n";

}