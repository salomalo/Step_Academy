#include "Fly.h"

// ���������� �������� �����
HANDLE Fly::hCon = GetStdHandle( STD_OUTPUT_HANDLE );

Fly::Fly() 
	:   sym( 33+rand()%100 )
{
	pos.X	= rand() % 77 + 1;
	pos.Y	= rand() % 23 + 1;
	step.X	= rand() % 2 ? -1 : 1 ;
	step.Y	= rand() % 2 ? -1 : 1  ;

	period.X = rand() % 500 + 50;
	period.Y = rand() % 500 + 50;

	next.X = clock() + period.X;
	next.Y = clock() + period.Y;

	attr = 0;
	for( int i = 0 ; i < 5 ; i++ )
	{
		switch( rand() % 4 )
		{
		case 0:
			attr ^= FOREGROUND_INTENSITY;
			break;

		case 1:
			attr ^= FOREGROUND_GREEN ;
			break;

		case 2:
			attr ^= FOREGROUND_RED ;
			break;

		case 3:
			attr ^= FOREGROUND_BLUE ;
			break;

		}
	}

	// "�������" ����
	SetConsoleTextAttribute( hCon, attr );
	SetConsoleCursorPosition( hCon, pos );
	cout <<sym;

}


void Fly::move()
{
	time_t	clc = clock();
	bool	isMoved = false ;
	COORD	posOld	= pos;

	if( next.X <= clc )
	{
		// "�������" ���� �� ������� ����
		//SetConsoleCursorPosition( hCon, pos );
		//cout <<' ';

		pos.X += step.X;
		if( pos.X <= 0 || pos.X >= 78 )
			step.X *= -1;
		next.X = clc + period.X;
		isMoved = true;

		// "�������" ���� �� ������ ����
		//SetConsoleTextAttribute( hCon, attr );
		//SetConsoleCursorPosition( hCon, pos );
		//cout <<sym;
	}

	if( next.Y <= clc )
	{
		// "�������" ���� �� ������� ����
		//SetConsoleCursorPosition( hCon, pos );
		//cout <<' ';

		pos.Y += step.Y;
		if( pos.Y <= 0 || pos.Y >= 24 )
			step.Y *= -1;
		next.Y = clc + period.Y;
		isMoved = true;

		// "�������" ���� �� ������ ����
		//SetConsoleTextAttribute( hCon, attr );
		//SetConsoleCursorPosition( hCon, pos );
		//cout <<sym;
	}


	// ���� ��������� ��� ��������� ������, cout ������ ���� ���, ���� �����
	if( isMoved )
	{
		// "�������" ���� �� ������� ����
		SetConsoleCursorPosition( hCon, posOld );
		cout <<' ';

		// "�������" ���� �� ������ ����
		SetConsoleTextAttribute( hCon, attr );
		SetConsoleCursorPosition( hCon, pos );
		cout <<sym;
	}


}