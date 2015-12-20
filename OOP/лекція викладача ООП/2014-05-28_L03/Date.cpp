#include "Date.h"

int Date::example;		// виділяється пам'ять


Date::Date() : day(1), month(1), year(1970) {}


Date::Date( short year, short month, short day )
	: day( day ), month( month ), year( year )
{}



void Date::getString( char* string ) const // кладе "YYYY-MM-DD"
{
	sprintf( string, "%d-%02d-%02d", year, month, day );
}



bool Date::isValid( short year, short month, short day )
{
	if( year < 1900 || month < 1 || month > 12 || day < 1 )
		return false;

	short maxDays = 30;
	switch( month )
	{
	case  1:
	case  3:
	case  5:
	case  7:
	case  8:
	case 10:
	case 12:
		maxDays = 31;
		break;


	case 2:
		if( year % 4 )
			maxDays = 28;
		else
			maxDays = 29;
		break;


	default:
		maxDays = 30;
	}

	if( day > maxDays )
		return false;

	return true;

}




