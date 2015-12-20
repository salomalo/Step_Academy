#include <Windows.h>
#include <conio.h>
#include <iostream>
using namespace std;

enum direct {Left =75 , Right =77, Up = 72 , Down=80, Esc = 27};


struct ColoredChar
{
	char chr;
	WORD attr;
};


void Show( HANDLE hCon, ColoredChar ccVar )
{
	CONSOLE_SCREEN_BUFFER_INFO csbi;
	GetConsoleScreenBufferInfo( hCon, &csbi );

	SetConsoleTextAttribute( hCon, ccVar.attr );
	cout << ccVar.chr;

	SetConsoleTextAttribute( hCon, csbi.wAttributes );
}


ColoredChar CreateColoredChar( char chr, WORD attr )
{
	ColoredChar ccVar;
	ccVar.attr	= attr;
	ccVar.chr	= chr;
	return ccVar;
}


void main()
{
	HANDLE hCon = GetStdHandle( STD_OUTPUT_HANDLE );
	Show( hCon, CreateColoredChar( 'B', FOREGROUND_BLUE ));
	Show( hCon, CreateColoredChar( 'G', FOREGROUND_GREEN ));
	Show( hCon, CreateColoredChar( 'R', FOREGROUND_RED ));
	Show( hCon, CreateColoredChar( 'C', FOREGROUND_BLUE | FOREGROUND_GREEN ));
	Show( hCon, CreateColoredChar( 'M', FOREGROUND_BLUE | FOREGROUND_RED ));
	cout <<'\n';

	Show( hCon, CreateColoredChar( 'b', FOREGROUND_BLUE | FOREGROUND_INTENSITY ));
	Show( hCon, CreateColoredChar( 'g', FOREGROUND_GREEN | FOREGROUND_INTENSITY ));
	Show( hCon, CreateColoredChar( 'r', FOREGROUND_RED | FOREGROUND_INTENSITY ));
	Show( hCon, CreateColoredChar( 'c', FOREGROUND_BLUE | FOREGROUND_GREEN | FOREGROUND_INTENSITY ));
	Show( hCon, CreateColoredChar( 'm', FOREGROUND_BLUE | FOREGROUND_RED | FOREGROUND_INTENSITY ));
	cout <<'\n';

	Show( hCon, CreateColoredChar( 'B', BACKGROUND_BLUE ));
	Show( hCon, CreateColoredChar( 'G', BACKGROUND_GREEN ));
	Show( hCon, CreateColoredChar( 'R', BACKGROUND_RED ));
	Show( hCon, CreateColoredChar( 'C', BACKGROUND_BLUE | BACKGROUND_GREEN ));
	Show( hCon, CreateColoredChar( 'M', BACKGROUND_BLUE | BACKGROUND_RED ));
	cout <<'\n';

	Show( hCon, CreateColoredChar( 'b', BACKGROUND_BLUE | BACKGROUND_INTENSITY ));
	Show( hCon, CreateColoredChar( 'g', BACKGROUND_GREEN | BACKGROUND_INTENSITY ));
	Show( hCon, CreateColoredChar( 'r', BACKGROUND_RED | BACKGROUND_INTENSITY ));
	Show( hCon, CreateColoredChar( 'c', BACKGROUND_BLUE | BACKGROUND_GREEN | BACKGROUND_INTENSITY ));
	Show( hCon, CreateColoredChar( 'm', BACKGROUND_BLUE | BACKGROUND_RED | BACKGROUND_INTENSITY ));
	cout <<'\n';

	cout <<"\n\n\n\n\n";
}


