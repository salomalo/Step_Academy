#include  "Stack.h"
#include <time.h>
#include <conio.h>


char pressAnyKey();


void main()
{
	srand( time(0) );

	char chr;
	int  val;
	bool isOk;


	Stack st1( 70, 5 );
	cout <<"\n\n";


	do{
 		chr = pressAnyKey();
		val = rand() % 10000;
		printf( "pushing %5i ... ", val);
		if( isOk = st1.push( val ) )
			cout <<"ok.\n" ;
		else
			cout <<"stack overflow !\n";

	} while( isOk );


	cout <<"\n";


	do{
 		chr = pressAnyKey();
		val = rand() % 10000;
		cout <<"poping ... ";
		if( isOk = st1.pop( val ) )
			printf( "%5i poped.\n", val);
		else
			cout <<"stack is empty !\n";

	} while( isOk );


	cout <<"\n\n\n";
}



char pressAnyKey()
{
	HANDLE hCon = GetStdHandle( STD_OUTPUT_HANDLE );
	CONSOLE_SCREEN_BUFFER_INFO csbi;
	GetConsoleScreenBufferInfo( hCon, &csbi );

	COORD pos = csbi.dwCursorPosition;
	pos.Y += 1;

	SetConsoleCursorPosition( hCon, pos );
	cout <<"... press any key, please ...";
	char chr = _getch();
	SetConsoleCursorPosition( hCon, pos );
	cout <<"                             ";


	SetConsoleCursorPosition( hCon, csbi.dwCursorPosition );
	return chr;
}
