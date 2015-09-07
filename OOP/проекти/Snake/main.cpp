#include "Snake.h"
# include "Table.h"

void main()
{
	Snake SN;
	Table t;


	while(1)
	{
		if (kbhit() == true) // если нажата клавиша
			SN.change_direction(); // обрабатываем нажатую клавишу
		SN.next_step();// двигаем змейку


		SN.show_table();
		// рисуем змейку

		Sleep(INTERVAL);
		// "усыпляем" программу на заданный интервал

	}



}