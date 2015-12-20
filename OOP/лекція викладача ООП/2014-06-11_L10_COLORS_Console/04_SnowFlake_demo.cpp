/*
	��������� �� ����� ��� ������� �������(��������� "*") ���� ������� ����� �������� �������. 
	�������� ������� �������� ���������� ������.
*/

#include <iostream>
#include <time.h>
#include <conio.h>
#include <Windows.h>

using namespace std;

int main()
{
	const HANDLE	hCon = GetStdHandle( STD_OUTPUT_HANDLE );
	const clock_t	period = 80;

	COORD	position;
	clock_t	nextMoment = clock();	// ������� �-�� �������� �� ������� ������ ��������	
	char	keyPressed;

	srand(time(0));

	do
	{
		// ��������� ��������� ������
		position.X = rand() % 80;
		position.Y = 0;

		do
		{
			// �������� ������
			SetConsoleCursorPosition( hCon, position );
			cout <<'*';

			nextMoment += period;	// ������ ���������� ������

			// sleep( period ) ; ���� ������� ��������� �������� �� period�.
			do { Beep( rand() % 10000, 5);  } while( nextMoment > clock() );	// � ���, ���� ������, ������ ���� ������� -- �����!!! ;)

			// ������ ������ (�� ������� ����)
			SetConsoleCursorPosition( hCon, position );
			cout <<' ';

			position.Y++;	// ������� ������� ������

			keyPressed =  kbhit() ? getch() : 0;		// �� ���� ��������� ������ ?
			

		}while( position.Y < 25 && ! keyPressed );	// ������ ����, ���� �� ����� �� ��� ������

		Beep( 8443, 3);
		Beep( 9443, 3);
		Beep( 443, 7);
		Beep( 1443, 13);
		Beep( 124, 30);
		Beep( 10443, 3);
		Beep( 1443, 7);

	}while( ! keyPressed );
}