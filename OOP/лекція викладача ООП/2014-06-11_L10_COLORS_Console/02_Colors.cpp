#include <Windows.h>
#include <iostream>
using namespace std;


void main()
{
	// хендл консолі
	HANDLE hConsole = GetStdHandle( STD_OUTPUT_HANDLE );
	COORD coord;

	cout <<"ababagalamaga]\n\n";

	// бекап стану екрану
	CONSOLE_SCREEN_BUFFER_INFO csbi;	// по-простому
	GetConsoleScreenBufferInfo( hConsole, &csbi );	// кладе у csbi стан екрану
	
	//лише починаючи з Vista
	//CONSOLE_SCREEN_BUFFER_INFOEX csbix;	// розширені параметри
	//GetConsoleScreenBufferInfoEx( hConsole, &csbix ); // кладе у csbi стан екрану (з курсором) 
	
	//cout <<"\n\nsizeof( csbi ) =" <<sizeof( csbi ) <<"\n\n";

	//SetConsoleTextAttribute( hConsole, 14 );
	SetConsoleTextAttribute( hConsole, FOREGROUND_GREEN | FOREGROUND_RED | FOREGROUND_INTENSITY | FOREGROUND_INTENSITY );
	coord.X = 33;
	coord.Y = 12;
	SetConsoleCursorPosition( hConsole, coord );	// ставимо курсор в позицію
	cout <<"This text must be GREEN\n\n\n";

	SetConsoleTextAttribute( hConsole, 38+128 );
	coord.X = 3;
	coord.Y = 2;
	SetConsoleCursorPosition( hConsole, coord );	// ставимо курсор в позицію
	cout <<"This text written later then previous";
	cout <<"\n any other text too long too long too long too long too long too long too long too long too long too long ";

	
	SetConsoleTextAttribute( hConsole, csbi.wAttributes );
	SetConsoleCursorPosition( hConsole, csbi.dwCursorPosition );	// ставимо курсор в позицію

//	SetConsoleTextAttribute( hConsole, csbix.wAttributes );			// для Vista+


	coord.X = 0;
	coord.Y = 24;
//	coord.Y = 28;
	SetConsoleCursorPosition( hConsole, coord );	// ставимо курсор в позицію

}