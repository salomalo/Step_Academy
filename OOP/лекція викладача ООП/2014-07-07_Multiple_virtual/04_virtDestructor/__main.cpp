/*
	³��� ��������� ����� ���� ��������� �� ������� http://www.ex.ua/view/79269561
	� ���� 2014-07-07_03_virtBase_virtDestr.tvs
*/


#include "Elk.h"

void main()
{
	Part * pPart = new Elk ( "Vasya", 22, 33 );
	pPart->Show();

	cout <<"\n\n\n";

	delete pPart;

}
