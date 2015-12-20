
#include<windows.h>
#ifndef HCONSOLE_H
#define HCONSOLE_H
class ConsoleWorker
{
	static HANDLE hConsole;
	static COORD coord;

public:
	static void SetConsolePosition(int x, int y)
	{
		if(!hConsole)
			hConsole = GetStdHandle( STD_OUTPUT_HANDLE );
		coord.X = x;
		coord.Y = y;
		SetConsoleCursorPosition(hConsole, coord);
		//return hConsole;
	}
};

#endif HCONSOLE_H