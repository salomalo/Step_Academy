#include "Snake.h"
# include "Table.h"

void main()
{
	Snake SN;
	Table t;


	while(1)
	{
		if (kbhit() == true) // ���� ������ �������
			SN.change_direction(); // ������������ ������� �������
		SN.next_step();// ������� ������


		SN.show_table();
		// ������ ������

		Sleep(INTERVAL);
		// "��������" ��������� �� �������� ��������

	}



}