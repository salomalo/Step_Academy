# pragma once
# include <iostream>
# include <windows.h>
# include <time.h> // ��� ������� Sleep()
# include <conio.h>// ���  ������� kbhit() � getch()
using namespace std;





class Table
{
public:
	Table() :N(20), M(20){};

	 //void show_table();// ������� ��� ������ �������


	int N;
	int	M;
	//char a[1000][1000]; //- ���� �������, � ������� ���������� ��� ����
};