/*
	³���: 
		����	2014-07-03_01_Polymorphism.tvs
		�� ����	http://www.ex.ua/79269561?r=79269548,78789972,78155343
*/


#include "Lion.h"
#include "Volf.h"

#include <ctime>


void main()
{
	cout <<"\n___________ objects ________\n\n";

	Cat cat1(5);
	cat1.Say();
	
	cout <<"\n";

	Animal a1(7);
	a1.Say();



	cout <<"\n___________ pointers ________\n\n";
	Animal	*pA = new Animal(9);
	Cat		*pC = new Cat(2);

	pA->Say();
	pC->Say();


	cout <<"\n\n _______ Pointer to base class ______\n";
	// � ����� ���� "�������� �� ������� ����"
	// �� ������ �������� �������� �� ��'��� ����-����� ��������� �����
	Animal *pVirt = pC;	// � ����� "����. �� Animal" ������� �������� �� Cat
	cout <<"\nptr to Cat : \n";
	pVirt->Say();
	//cout <<"\n weight in main = " <<pVirt->weight

	pVirt = pA;
	cout <<"\nptr to Animal : \n";
	//cout <<"\n weight in main = " <<pVirt->weight;
	pVirt->Say();

	// �� ����� ��������
	// Cat * pCat = pA;

	cout <<"\nptr to Lion : \n";
	pVirt = new Lion( 333 );
	pVirt->Say();



	cout <<"\n\n\n\n _______ Zoo ______\n";

	srand( time(0));

	const int SIZE = 10;
	Animal * zoo[ SIZE ];	// ����� ������� ������ �� ��� "�������� �� Animal", ����� ���� ������ �������� �� ����-����� ����
	// �������� ��� zoo -- Animal **

	// ���������� ����� �������
	for( int i = 0 ; i < SIZE ; i++ )
	{
		switch( rand() % 4 )
		{
		case 0:
			zoo[i] = new Animal( 3 + rand()% 100 );
			break;

		case 1:
			zoo[i] = new Cat( 3 + rand()% 7 );
			break;

		case 2:
			zoo[i] = new Lion( 150 + rand()% 500 );
			break;

		case 3:
			zoo[i] = new Volf( 50 + rand()% 120 );
			break;

		}
	}// ���������� ����� �������


	// ������ ����� ����������, ��� �� �쳺
	for( int i = 0 ; i < SIZE ; i++ )
	{
		cout <<"\nzoo[" <<i <<"]: \n ";
		zoo[i]->Say();
	}





	cout <<"\n\n\n";
}