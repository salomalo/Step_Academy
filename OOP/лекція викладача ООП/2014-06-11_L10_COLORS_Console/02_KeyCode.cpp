#include <Windows.h>
#include <iostream>
#include <conio.h>
using namespace std;

#define KEY_ESC 27


void main()
{
	char chr;
	do{
		do{
			chr = getch();				// повертає натиснену клавішу (символ), або чекає, поки буде натиснута
			cout <<(int)chr <<' ' ;
		} while ( kbhit() );			// говорить, чи є у буфері клавіатури щось (чи є непрочитані символи)
		cout <<"\n";
//	}while ( chr != 27 );
	}while ( chr != KEY_ESC );
}