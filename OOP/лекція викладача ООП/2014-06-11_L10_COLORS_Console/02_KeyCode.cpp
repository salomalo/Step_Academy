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
			chr = getch();				// ������� ��������� ������ (������), ��� ����, ���� ���� ���������
			cout <<(int)chr <<' ' ;
		} while ( kbhit() );			// ��������, �� � � ����� ��������� ���� (�� � ���������� �������)
		cout <<"\n";
//	}while ( chr != 27 );
	}while ( chr != KEY_ESC );
}