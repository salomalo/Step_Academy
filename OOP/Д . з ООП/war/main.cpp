#include"Swordsman.h"
#include"Archer.h"
#include"Mage.h"
#include <ctime>
#include <conio.h>
#include <Windows.h>


void main()
{
	srand( time(0));
	const int SIZE = 3;
	Unit * gr1[ SIZE ];	// кожен елемент масиву має тип "вказівник на Unit", тобто може містити вказівник на будь-якого звіра 
	for(int i=0; i<SIZE; i++)     // насправді тип gr1 -- Unit **
	{
		switch( rand()%3 )
		{
		case 0:
			gr1[i] = new Swordsman( 15, 5, /*1 + rand()% */60);
			break;
		case 1:
			gr1[i] = new Archer( 12,4,  /*1 + rand()% */40);
			break;
		case 2:
			gr1[i] = new Mage( 8,10,  /*1 + rand()% */30);
			break;
		}
	}// заповнюємо масив unitами
	cout<<"first team :"<<endl;
	for(int i=0; i<SIZE; i++)
	{
		gr1[i]->Show();
	}

	Unit * gr2[ SIZE ];	
	for(int i=0; i<SIZE; i++)
	{
		switch( rand()%3 )
		{
		case 0:
			gr2[i] = new Swordsman( 15, 5, /*1 + rand()% */60 );
			break;
		case 1:
			gr2[i] = new Archer( 12, 4, /*1 + rand()%*/ 40  );
			break;
		case 2:
			gr2[i] = new Mage( 8, 10,  /*1 + rand()%*/ 30   );
			break;
		}
	}// заповнюємо масив unitами
	cout<<endl<<"second team :"<<endl;
	for( int i=0; i<SIZE; i++ )
	{
		gr2[i]->Show();
	}

	cout<<"_________war____________"<<endl;
	int k=1;
	while(getch()==13)
	{

		//system("cls");
		for( int i=0; i<SIZE; i++)
		{
			cout<<endl<<k++<<" Attack: ";
			switch( rand()%2 )
			{
			case 0:
				if((gr1[i]->alive()==true) && (gr2[i]->alive()==true))
				{
					cout<<"by first  team"<<endl;
					gr1[i]->Attack(gr2[i]);
					cout<<endl;
				}

				else if(gr2[i]->alive()!=true)
				{
					gr2[i]->name();
					cout<<" this one is dead: ";
				}
				break;


			case 1:
				if((gr1[i]->alive()==true) && (gr2[i]->alive()==true))
				{
					cout<<"by first  team"<<endl;
					gr2[i]->Attack(gr1[i]);
					cout<<endl;
				}
				
				else if(gr1[i]->alive()!=true)
				{
					gr1[i]->name();
					cout<<" this one is dead: ";
				}
				break;
			}
		}
	}
	



	cout<<endl;
}