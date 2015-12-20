#include <Windows.h>
#include <iostream>


#include <conio.h>
using namespace std;

#define		KEY_LEFT	75 
#define		KEY_RIGHT	77
#define		KEY_UP		72
#define		KEY_DOWN	80
#define		KEY_ESC		27

#define		WHITE_ON_BLACK	FOREGROUND_BLUE | FOREGROUND_GREEN | FOREGROUND_RED | FOREGROUND_INTENSITY


bool processKeyboard( COORD & coord , DWORD & attr );



void main()
{
	HANDLE hConsole  = GetStdHandle(STD_OUTPUT_HANDLE);// �������� ����� ����
	SetConsoleTitle( L"Moving Star (������ ������ )" );

	// �������� ��������� ���������, �� ������ ���������� ��� ���������� �����
	CONSOLE_SCREEN_BUFFER_INFO csbi;

	//�������� ���������� ��� ���� ������ ������  ������ (back-up)
	GetConsoleScreenBufferInfo( hConsole, &csbi );

	// ���������� ���������
	COORD coordInfo;	
	coordInfo.X = 35;
	coordInfo.Y = 0;

	// ���������� ������
	COORD coordStar;
	coordStar.X = 39;
	coordStar.Y = 12; 

	// ������� ���� ������ �� ������� ��
	DWORD wAttr = WHITE_ON_BLACK;

	char sym = '*';

	do
	{

		// ��������
		SetConsoleCursorPosition( hConsole, coordInfo );
		SetConsoleTextAttribute( hConsole, WHITE_ON_BLACK );
		printf( "wAttr: %02X ", wAttr );

		// ������
		SetConsoleTextAttribute( hConsole, wAttr );
		SetConsoleCursorPosition( hConsole, coordStar);
//		cout << '*';
		cout << sym;

		sym++;
		if ( sym > 'z' )
			sym = 33;

	}
	while ( processKeyboard( coordStar , wAttr ) );


	//���������� �������� �������� ������ 
	SetConsoleTextAttribute( hConsole, csbi.wAttributes );	// ���� ����
	coordStar.X = 0;
	coordStar.Y = 24;
	SetConsoleCursorPosition( hConsole, coordStar );
}



bool processKeyboard( COORD & coord , DWORD & attr )
{
	//������, �� ����������� ������������
	char ch = _getch();		//������� 1-� ���� ��������� ������

	if ( ch == -32 )		// ���� ���� ��������� ������� (������ ��������� �������� ��������� 2 �����, ������ -32 )
		ch = _getch();		// ������� 2-� ���� ���� ������ 

	switch (ch)
	{

	case KEY_ESC:
		return false;

	case KEY_LEFT: 
		if ( coord.X > 0 )
			--coord.X; 
		break;

	case KEY_RIGHT: 
		if ( coord.X < 79 ) 
			++coord.X; 
		break;

	case KEY_UP: 
		if ( coord.Y > 0) 
			--coord.Y; 
		break;

	case KEY_DOWN: 
		if ( coord.Y < 24)
			++coord.Y; 
		break;

	case 'r': 
		attr = attr ^ FOREGROUND_RED;
		break;

	case 'R': 
		attr = attr ^ BACKGROUND_RED;
		break;

	case 'g': 
		attr = attr ^ FOREGROUND_GREEN;
		break;

	case 'G': 
		attr = attr ^ BACKGROUND_GREEN;
		break;

	case 'b': 
		attr = attr ^ FOREGROUND_BLUE;
		break;

	case 'B': 
		attr = attr ^ BACKGROUND_BLUE;
		break;

	case 'i': 
		attr = attr ^ FOREGROUND_INTENSITY;
		break;

	case 'I': 
		attr = attr ^ BACKGROUND_INTENSITY;
		break;

	}
	return true;
}
