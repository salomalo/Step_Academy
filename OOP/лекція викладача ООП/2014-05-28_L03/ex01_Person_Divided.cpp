#include "Person.h"
#include "Date.h"


void main()
{
	Person katya( "Kateryna", "Demydenko", 33, 1955, 11, 11 );
	katya.show();

	katya.setSurName( "Yushchenko" );
	katya.show();

	cout <<"\n\n-----------DATE TEST ------------\n";
	Date date( 2014, 5, 88 );
	char str[12];
	date.getString( str );
	cout <<str <<'\n';
	cout <<"\n-----------obj returning ------------\n";
	(date.increment()).getString( str );
	cout <<str <<'\n';
	cout <<"\n-----------obj_ptr returning ------------\n";
	(date.increment_Ptr())->getString( str );
	cout <<str <<'\n';


	cout <<"\nisValid = " <<Date::isValid( 2012, 02, 29 ) <<"\n\n";

}