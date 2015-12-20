/*
	Відео написання цього коду викладено на сторінці http://www.ex.ua/view/79269561
	у файлі 2014-07-07_02_multiple.tvs
*/

*/


#include "Lion.h"
#include "Volf.h"
#include "Fish.h"

#include <ctime>


void main()
{


	cout <<"\n\n\n\n _______ Zoo ______\n";

	srand( time(0));

	const int SIZE = 10;
	Animal * zoo[ SIZE ];	// кожен елемент масиву має тип "вказівник на Animal", тобто може містити вказівник на будь-якого звіра
	// насправді тип zoo -- Animal **

	// заповнюємо масив звіриною
	for( int i = 0 ; i < SIZE ; i++ )
	{
		switch( rand() % 4 )
		{
		// не можна створити об'єкт абстрактного класу !!!!
		//case 0:
		//	zoo[i] = new Animal( 3 + rand()% 100 );
		//	break;

		case 0:
		case 1:
			zoo[i] = new Cat( 3 + rand()% 7 );
			break;

		case 2:
			zoo[i] = new Lion( 150 + rand()% 500 );
			break;

		case 3:
			zoo[i] = new Volf( 50 + rand()% 120 );
			break;

		//case 4:
		//	zoo[i] = new Fish( 1 + rand()% 12 );
		//	break;

		}
	}// заповнюємо масив звіриною


	// кажемо звірям поговорити, хто як вміє
	for( int i = 0 ; i < SIZE ; i++ )
	{
		cout <<"\nzoo[" <<i <<"]: \n ";
		zoo[i]->Say();		// нам байдуже до типу конктретного zoo[i], бо ми знаємо, що він ТОЧНО має метод Say() !!! -- це є спільний інтерфейс
	}





	cout <<"\n\n\n";
}