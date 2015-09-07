#include <iostream>
#include <string>

using namespace std;


void showString( string & oStr , const char * name );



void main()
{
	string oEmpty;	// створюємо пустий об'єкт
	showString( oEmpty, "oEmpty" );

	string oFirst( "Value from (const char *) literal" );	// from c-string
	showString( oFirst, "oFirst" );


//	cout <<"\n\n___________ char adding and capacity test _____\n";
//	for( int i = 33 ; i < 77 ; i++ )
//	{
////		oEmpty += (char) i;	// Додаємо по 1 символу
//		oEmpty.push_back( i );	// Додаємо по 1 символу
//		showString( oEmpty, "oEmpty" );
//	}
//
//	cout <<"\n\n___________ adding _____\n";
//	const char str[] = "any text";
//	oEmpty += str;
//	showString( oEmpty, "oEmpty" );
//	oEmpty += ' ';
//	oEmpty += oFirst;
//	showString( oEmpty, "oEmpty" );
//
//
//	cout <<"\n\n___________ pop_back() _____\n";
//	while( oEmpty.length() > 33 )
//	{
//		oEmpty.pop_back();
//		showString( oEmpty, "oEmpty" );
//	}
//
//
//	cout <<"\n\n___________ shrink_to_fit() _____\n";
//	oEmpty.shrink_to_fit();
//	showString( oEmpty, "oEmpty" );

	oEmpty.assign( "Value asigned to oEmpty" );

	cout <<"\n\n___________ .swap() _____\n";
	cout <<"Before:\n";
	showString( oEmpty, "oEmpty" );
	showString( oFirst, "oFirst" );
	oEmpty.swap( oFirst );
	cout <<"\nAfter:\n\n";
	showString( oEmpty, "oEmpty" );
	showString( oFirst, "oFirst" );


	cout <<"\n\n___________ global swap() _____\n";
	cout <<"Before:\n";
	showString( oEmpty, "oEmpty" );
	showString( oFirst, "oFirst" );
	swap( oFirst , oEmpty );
	cout <<"\nAfter:\n\n";
	showString( oEmpty, "oEmpty" );
	showString( oFirst, "oFirst" );


	size_t start = 5;
	size_t end  = 11;
	cout <<"\n\n___________ erase(" <<start <<", " <<end <<") _____\n";
	oEmpty.erase( start, end );
	oFirst.erase( start, end );
	showString( oEmpty, "oEmpty" );
	showString( oFirst, "oFirst" );


	cout <<"\n\n___________ find(3) _____\n";
	const char szMatch[] = "luiziana";
	size_t iFound1 = oEmpty.find( szMatch, 0, 2 );
	cout <<"In oEmpty found1 = " <<iFound1 ;
	if( iFound1 == string::npos )
		cout <<" (not found)";
	else
		cout <<" (found)";

	size_t iFound2 = oEmpty.find( szMatch, 0, 3 );
	cout <<"In oEmpty found2 = " <<iFound2 ;
	if( iFound2 == string::npos )
		cout <<" (not found)" <<endl;
	else
		cout <<" (found)" <<endl;


	cout <<"\n\n\n";
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
