#include <iostream>
#include <string>

using namespace std;


void showString( string & oStr , const char * name );

void main()
{
	string oFirst( "Value from (const char *) literal" );	// from c-string
	showString( oFirst, "oFirst" );

	cout <<"\n\n___________ after reserve() _____\n";
	oFirst.reserve( 111 );
	showString( oFirst, "oFirst" );

	cout <<"\n\n___________ char adding and capacity test _____\n";
	for( int i = 33 ; i < 77 ; i++ )
	{
		oFirst += (char) i;	// Додаємо по 1 символу
		showString( oFirst, "oFirst" );
	}
	showString( oFirst, "oFirst" );


}




void showString( string & oStr , const char * name)
{
	cout <<name <<":\n"
		 <<"length="   <<oStr.length() <<'\t'
		 <<"size="     <<oStr.size() <<'\t'
		 <<"capacity=" <<oStr.capacity() <<'\t'
		 <<"max_size=" <<oStr.max_size() <<'\n'
		 <<"content: '" <<oStr <<'\n'
		 <<'\n';
}


