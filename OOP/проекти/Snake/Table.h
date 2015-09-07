# pragma once
# include <iostream>
# include <windows.h>
# include <time.h> // для функции Sleep()
# include <conio.h>// для  функций kbhit() и getch()
using namespace std;





class Table
{
public:
	Table() :N(20), M(20){};

	 //void show_table();// функция для вывода таблицы


	int N;
	int	M;
	//char a[1000][1000]; //- наша таблица, в которой происходит вся игра
};