#include"Snake.h"


////////////////////////////////
//������� � ���� ����
char a[1000][1000]; //- ���� �������, � ������� ���������� ��� ����
////////////////////////////////

void Snake::change_direction()// �������, ����������� ������� �������
{
	int symbol = getch();// ��������� ������� ������� � ������� ������� getch()
	switch (symbol)
	{
	case 72: if(change_x != 1  || change_y != 0)  { change_x = -1; change_y = 0;  } break;
	case 75: if(change_x != 0  || change_y != 1)  { change_x = 0;  change_y = -1; } break;
	case 80: if(change_x != -1 || change_y != 0)  { change_x = 1;  change_y = 0;  } break;
	case 77: if(change_x != 0  || change_y != -1) { change_x = 0;  change_y = 1;  } break;

	default : break; 
	}
}



void Snake::clear_snake_on_table() // ������� ����������, � ������� ������������� ������
{
	Table t;
	for (int i = 1; i <= snake_size; ++i)
		// t. 
		a[coordinates_x[i]][coordinates_y[i]] = ' ';  //a[1000][1000] - ���� �������, � ������� ���������� ��� ����
}



void Snake::show_snake_on_table() // ������ ���������� ������
{
	Table t;
	if(change_x == 1 && change_y == 0) /*t.*/  a[coordinates_x[1]][coordinates_y[1]] = 'v';
	if(change_x == -1 && change_y == 0) /*t.*/ a[coordinates_x[1]][coordinates_y[1]] = '^';
	if(change_x == 0 && change_y == 1)  /*t.*/   a[coordinates_x[1]][coordinates_y[1]] = '>';
	if(change_x == 0 && change_y == -1)  /*t. */  a[coordinates_x[1]][coordinates_y[1]] = '<';
	// �������� ��� ������

	for (int i = 2; i <= snake_size; ++i)
		//t.
		a[coordinates_x[i]][coordinates_y[i]] = '@';
	// ������ ������
}


bool Snake::game_over()// ���������, ����� �� ������ ���� ����
{
	for (int i = 2; i <= snake_size; ++i)
		if (coordinates_x[1] == coordinates_x[i] && coordinates_y[1] == coordinates_y[i]) return true;
	// ���� ���������� ������ ������ ����� ���������� �����-���� ����� ���� ������, �� ������ ����� ���� ����
	return false;
	// ���� ��� ���������� ��������, �� ��� � ������� - ������ ������
}


void Snake::check_coordinates()// ���������, �� ����� �� ������ �� ����, ���� �� �� ���������� �� �������
{
	Table t;
	if (coordinates_x[1] > t.N) coordinates_x[1] = 1;
	if (coordinates_x[1] < 1) coordinates_x[1] = t.N;
	if (coordinates_y[1] > t.M) coordinates_y[1] = 1;
	if (coordinates_y[1] < 1) coordinates_y[1] = t.M;
}


void Snake::next_step() // ������� ���������� ����, � ������� ���� ������ ���������� � ������� �� 1 ������
{
	clear_snake_on_table();       // ������ ������� �� ������

	for (int i = snake_size; i >= 2; --i)
	{
		coordinates_x[i] = coordinates_x[i - 1];
		coordinates_y[i] = coordinates_y[i - 1];
	}// ����������� ���� ������

	coordinates_x[1] += change_x;
	coordinates_y[1] += change_y;// ����������� ������ ������

	check_coordinates();// ��������� � ������� �� ����������


	//if(coordinates_x[1] == food_x && coordinates_y[1] == food_y)
	//{
	//    snake_size++;
	//    food_x = -1;
	//    food_y = -1;
	//}
	// ���� ������ ������ ��� �� ��� � ���, �� ����������� ������ ������ � ������� ���������� ������


	show_snake_on_table(); // ������ ������

	if (game_over() == true) // ���� ���� ������� ����
	{
		cout << "You're looser! \n";
		// �������� ��� ������ � ������
		system("pause");
		// ���������������� ����
		exit(0);
		// ��������� ���������
	}
}



void Snake::show_table()
	// ������� ��� ������ �������
{
	Table t;
	system("cls");
	// ������� �������
	for (int i = 0; i <= t.N + 1; ++i)
		for (int j = 0; j <= t.M + 1; ++j)
			cout << (i == 0 || j == 0 || i == t.N + 1 || j == t.M + 1 ? '#' : a[i][j]) << (j <= t.M ? "" : "\n");
	// ������� ������� � ����
}