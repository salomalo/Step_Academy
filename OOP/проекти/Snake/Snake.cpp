#include"Snake.h"


////////////////////////////////
//винести в клас поле
char a[1000][1000]; //- наша таблица, в которой происходит вся игра
////////////////////////////////

void Snake::change_direction()// функция, считывающая нажатую клавишу
{
	int symbol = getch();// считываем нажатую клавишу с помощью функции getch()
	switch (symbol)
	{
	case 72: if(change_x != 1  || change_y != 0)  { change_x = -1; change_y = 0;  } break;
	case 75: if(change_x != 0  || change_y != 1)  { change_x = 0;  change_y = -1; } break;
	case 80: if(change_x != -1 || change_y != 0)  { change_x = 1;  change_y = 0;  } break;
	case 77: if(change_x != 0  || change_y != -1) { change_x = 0;  change_y = 1;  } break;

	default : break; 
	}
}



void Snake::clear_snake_on_table() // очищаем координаты, в которых располагалась змейка
{
	Table t;
	for (int i = 1; i <= snake_size; ++i)
		// t. 
		a[coordinates_x[i]][coordinates_y[i]] = ' ';  //a[1000][1000] - наша таблица, в которой происходит вся игра
}



void Snake::show_snake_on_table() // красим координаты змейки
{
	Table t;
	if(change_x == 1 && change_y == 0) /*t.*/  a[coordinates_x[1]][coordinates_y[1]] = 'v';
	if(change_x == -1 && change_y == 0) /*t.*/ a[coordinates_x[1]][coordinates_y[1]] = '^';
	if(change_x == 0 && change_y == 1)  /*t.*/   a[coordinates_x[1]][coordinates_y[1]] = '>';
	if(change_x == 0 && change_y == -1)  /*t. */  a[coordinates_x[1]][coordinates_y[1]] = '<';
	// изменяем тип головы

	for (int i = 2; i <= snake_size; ++i)
		//t.
		a[coordinates_x[i]][coordinates_y[i]] = '@';
	// красим змейку
}


bool Snake::game_over()// проверяем, съела ли змейка саму себя
{
	for (int i = 2; i <= snake_size; ++i)
		if (coordinates_x[1] == coordinates_x[i] && coordinates_y[1] == coordinates_y[i]) return true;
	// если координаты головы змейки равны координате какой-либо части тела змейки, то змейка съела саму себя
	return false;
	// если все координаты различны, то все в порядке - играем дальше
}


void Snake::check_coordinates()// проверяем, не вышла ли змейка за поле, если да то возвращаем ее обратно
{
	Table t;
	if (coordinates_x[1] > t.N) coordinates_x[1] = 1;
	if (coordinates_x[1] < 1) coordinates_x[1] = t.N;
	if (coordinates_y[1] > t.M) coordinates_y[1] = 1;
	if (coordinates_y[1] < 1) coordinates_y[1] = t.M;
}


void Snake::next_step() // функция следующего хода, в которой наша змейка сдвигается в сторону на 1 ячейку
{
	clear_snake_on_table();       // чистим таблицу от змейки

	for (int i = snake_size; i >= 2; --i)
	{
		coordinates_x[i] = coordinates_x[i - 1];
		coordinates_y[i] = coordinates_y[i - 1];
	}// передвигаем тело змейки

	coordinates_x[1] += change_x;
	coordinates_y[1] += change_y;// передвигаем голову змейки

	check_coordinates();// проверяем в порядке ли координаты


	//if(coordinates_x[1] == food_x && coordinates_y[1] == food_y)
	//{
	//    snake_size++;
	//    food_x = -1;
	//    food_y = -1;
	//}
	// если голова змейки там же где и еда, то увеличиваем размер змейки и очищаем координаты змейки


	show_snake_on_table(); // рисуем змейку

	if (game_over() == true) // если змея укусила себя
	{
		cout << "You're looser! \n";
		// сообщаем всю правду о игроке
		system("pause");
		// приостанавливаем игру
		exit(0);
		// завершаем программу
	}
}



void Snake::show_table()
	// функция для вывода таблицы
{
	Table t;
	system("cls");
	// очищаем консоль
	for (int i = 0; i <= t.N + 1; ++i)
		for (int j = 0; j <= t.M + 1; ++j)
			cout << (i == 0 || j == 0 || i == t.N + 1 || j == t.M + 1 ? '#' : a[i][j]) << (j <= t.M ? "" : "\n");
	// выводим таблицу и края
}