#include  "Stack.h"


#define FG_WHITE	FOREGROUND_RED   | FOREGROUND_GREEN | FOREGROUND_BLUE | FOREGROUND_INTENSITY
#define BG_RED		BACKGROUND_RED   
#define BG_GREEN	BACKGROUND_GREEN 


HANDLE	Stack::hCon = GetStdHandle( STD_OUTPUT_HANDLE );


Stack::Stack( short x, short y )
	: x(x), y(y), quantity(0)
{
	show();
}



bool Stack::push( int   value )
{
	showPushing( value );

	if( quantity == MYSTACK_SIZE )
		return false;

	stack[ quantity++ ] = value;
	show();
	return true;
}



bool Stack::pop(  int & value )
{
	showPoping();

	if( quantity == 0 )
		return false;

	value = stack[ --quantity ];
	show();
	return true;
}



void Stack::show()
{
	CONSOLE_SCREEN_BUFFER_INFO csbi;
	GetConsoleScreenBufferInfo( hCon, &csbi );

	COORD pos;
	pos.X = x;
	pos.Y = y + 1;
	for( int i = 0 ; i <= MYSTACK_SIZE ; i++ )
	{
		SetConsoleCursorPosition( hCon, pos );
		if( i != MYSTACK_SIZE )
			if( quantity  && i < quantity )
				printf( "%c %5i %c", 186, stack[ quantity - i - 1 ], 186 );
			else
				printf( "%c       %c", 186, 186 );
		else
			printf( "%c%c%c%c%c%c%c%c%c", 200, 205, 205, 205, 205, 205, 205, 205, 188 );

		pos.Y++;
	}

	SetConsoleTextAttribute(  hCon, csbi.wAttributes );
	SetConsoleCursorPosition( hCon, csbi.dwCursorPosition );
}


void Stack::showPushing( int value )
{

	CONSOLE_SCREEN_BUFFER_INFO csbi;
	GetConsoleScreenBufferInfo( hCon, &csbi );

	COORD pos;
	pos.X = x + 1;
	pos.Y = y;

	SetConsoleCursorPosition( hCon, pos );
	printf( " %5i ", value );
	Sleep( 300 );

	bool isLights = false;
	for( int i = 0 ; i < 9 ; i++  )
	{
		
		if( isLights )
			if( quantity == MYSTACK_SIZE )
				SetConsoleTextAttribute(  hCon, FG_WHITE | BG_RED );
			else
				SetConsoleTextAttribute(  hCon, FG_WHITE | BG_GREEN );
		else
			SetConsoleTextAttribute(  hCon, csbi.wAttributes );

		SetConsoleCursorPosition( hCon, pos );
		printf( " %5i ", value );
		isLights = !isLights;
		Sleep(100);

	}

	SetConsoleCursorPosition( hCon, pos );
	cout <<"       ";

	SetConsoleTextAttribute(  hCon, csbi.wAttributes );
	SetConsoleCursorPosition( hCon, csbi.dwCursorPosition );
}



void Stack::showPoping()
{
	int value;

	CONSOLE_SCREEN_BUFFER_INFO csbi;
	GetConsoleScreenBufferInfo( hCon, &csbi );

	COORD pos;
	pos.X = x + 1;
	pos.Y = y + 1;
	bool isLights = false;
	for( int i = 0 ; i < 9 ; i++  )
	{
		
		if( isLights )
			if( quantity == 0 )
				SetConsoleTextAttribute(  hCon, FG_WHITE | BG_RED );
			else
				SetConsoleTextAttribute(  hCon, FG_WHITE | BG_GREEN);
		else
			SetConsoleTextAttribute(  hCon, csbi.wAttributes );

		SetConsoleCursorPosition( hCon, pos );
		if( quantity == 0 )
			cout <<"       ";
		else
			printf( " %5i ", stack[ quantity - 1 ] );
		isLights = !isLights;
		Sleep(100);

	}

	SetConsoleCursorPosition( hCon, pos );
	cout <<"      ";

	if( quantity != 0 )
	{
		pos.Y--;
		SetConsoleCursorPosition( hCon, pos );
		printf( " %5i ", stack[ quantity - 1 ] );
		Sleep( 300 );
		SetConsoleCursorPosition( hCon, pos );
		cout <<"      ";
	}

	SetConsoleTextAttribute(  hCon, csbi.wAttributes );
	SetConsoleCursorPosition( hCon, csbi.dwCursorPosition );
}

