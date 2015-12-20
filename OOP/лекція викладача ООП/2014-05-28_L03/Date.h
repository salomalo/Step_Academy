#pragma once

#include <cstdio>

class Date
{

public:
	 
	Date();		// або ініціалізує поточною дато, або 01.01.1970, 01.01.1900
	Date( short year, short month, short day );

	Date increment()		{ day++ ; return *this; }
	Date * increment_Ptr()	{ day++ ; return this; }

	void getString( char* string ) const; // кладе "YYYY-MM-DD"

	static bool isValid( short year, short month, short day );


private:

	short day;
	short month;
	short year;

	static int example;	// пам'ять для неї не виділена


};