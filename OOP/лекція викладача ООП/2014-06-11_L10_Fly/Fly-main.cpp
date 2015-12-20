#include "Fly.h"

#include <conio.h>


void main()
{
	srand( time(0) );
	const int nFlys = 8;

	Fly aFlys [nFlys];

	do{

		for( int i = 0 ; i < nFlys ; i ++ )
			aFlys[i].move();

//	}while( 27 != ( kbhit() ? getch() : 0 ) );	// вихід по [Esc]
	}while( ! ( kbhit() && 27 == getch() )  );	// вихід по [Esc] 

	HANDLE hCon = GetStdHandle( STD_OUTPUT_HANDLE );
	SetConsoleTextAttribute( hCon , FOREGROUND_BLUE | FOREGROUND_GREEN | FOREGROUND_RED | FOREGROUND_INTENSITY );
	COORD coord;
	coord.X = 0;
	coord.Y = 23;
	SetConsoleCursorPosition( hCon, coord );

}