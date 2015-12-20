#include "Automat.h"

void Automat:: AK_47()
{
	system("cls");
	cout<<"\n\t\t|             ___________________________________\n";
	cout<<  "\t\t|____________/                                   |\n";
	cout<<  "\t\t|__________________        __________      _     |\n";
	cout<<  "\t\t                   |      |        \\_|    | \\    |\n";
	cout<<  "\t\t                   |      |          |    |  \\   |\n";
	cout<<  "\t\t                   |      |          |    |   \\__|\n";
	cout<<  "\t\t                   |      |          |    |   \n";
	cout<<  "\t\t                   |      |          |____|   \n";
	cout<<  "\t\t                   |      |\n";
	cout<<  "\t\t                   |      |\n";
	cout<<  "\t\t                   |      |\n";
	cout<<  "\t\t                   |      |\n";
	cout<<  "\t\t                   |      |\n";
	cout<<  "\t\t                   |      |\n";
	cout<<  "\t\t                   |      |\n";
	cout<<  "\t\t                   |      |\n";
	cout<<  "\t\t                   |      |\n";
	cout<<  "\t\t                   |      |\n";
	cout<<  "\t\t                   |      |\n";
	cout<<  "\t\t                   |      |\n";
	cout<<  "\t\t                   |      |\n";
	cout<<  "\t\t                   |      |\n";
	cout<<  "\t\t                   |      |\n";
	cout<<  "\t\t                   |      |\n";
	cout<<  "\t\t                   |      |\n";
	cout<<  "\t\t                   |      |\n";
	cout<<  "\t\t                   |      |\n";
	cout<<  "\t\t                   |      |\n";
	cout<<  "\t\t                   |      |\n";
	cout<<  "\t\t                   |      |\n";
	cout<<  "\t\t                   |      |\n";
	cout<<  "\t\t                   |      |\n";
	cout<<  "\t\t                   |______|\n";
	cout<<  "\n\t\t\t\t\t\t\t\t by Vadim Voyevoda\n";
}

void Automat :: Charge()
{
	AK_47();
	M.Push();
	cout<<M;
		
}


void Automat :: Shot()
{
	HANDLE hConsole = GetStdHandle( STD_OUTPUT_HANDLE);
	COORD coord;
	coord.X=14;
	coord.Y=2;
	SetConsoleCursorPosition(hConsole, coord);
	cout<<"\\";
	coord.X=14;
	coord.Y=3;
	SetConsoleCursorPosition(hConsole, coord);
	cout<<"-";
	coord.X=14;
	coord.Y=4;
	SetConsoleCursorPosition(hConsole, coord);
	cout<<"/";

	system("cls");
	AK_47();
	int num, _vluch;
	if(M.Pop(num))
	{
		cout<<M;
		cout<<"num "<<num<<" ";
		_vluch = rand()%10+1;
		
		if(_vluch < 8)
		{ 
			SetConsoleTextAttribute(hConsole, FOREGROUND_GREEN | FOREGROUND_INTENSITY);
			cout<<" ! Hit ! ";
		}
		else 
		{
			SetConsoleTextAttribute(hConsole, FOREGROUND_RED | FOREGROUND_INTENSITY);
			cout<<"... missed ... ";
		}

		SetConsoleTextAttribute(hConsole, FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE);
	}
}