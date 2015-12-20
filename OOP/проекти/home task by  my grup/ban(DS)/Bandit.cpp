#include"Bandit.h"
#include<Windows.h>


istream & operator >> ( istream & left, Bandit & right )
{
	left>>right.money;
	return left;
}

ostream & operator << ( ostream & left, Bandit & right )
{
	left << right.money;
	return left;
}

void Bandit::start()
	{
		if( money >= 200 )
		{
		srand(time(NULL));
		int size = rand()%20+1;
		
		for(int i = 0; i<size; i++)
		{
			
			d1.rotate();
			Sleep(300);
			system("cls");
		}
		
		char a = d1.getChar();
		int size2 = rand()%20+1;
	
		for(int i = 0; i<size2; i++)
		{
			d2.rotate(a);
			Sleep(300);
			system("cls");
		}
		
		char b = d2.getChar();
		int size3 = rand()%20+1;
		;
		for(int i = 0; i<size3; i++)
		{
			d3.rotate(a,b);
			Sleep(300);
			system("cls");
		}
		system("cls");
		cout<<"\n";
	cout<<"\t   ______        ______        ______\n";
	cout<<"\t  |      |      |      |      |      |\n";
	cout<<"\t _|      |______|      |______|      |_\n";
	cout<<"\t|_|  "<<d1.getChar()<<"   |______|  "<<d2.getChar()<<"   |______|  "<<d3.getChar()<<"   |_|\n";
	cout<<"\t  |      |      |      |      |      |\n";
	cout<<"\t  |______|      |______|      |______|\n";
		if (d1.getChar() == d2.getChar() && d1.getChar() == d3.getChar() )
		{
			cout<<" \n Win 1000 :) \n\n";
			money += 1000;
			cout<<" Yousr money: "<<money<<endl;
		}
		else
			if( d1.getChar() == d2.getChar() || d1.getChar() == d3.getChar() || d2.getChar() == d3.getChar())
		{
			cout<<"\n\n Win 200 :| \n\n";
			money += 200;
			cout<<" Yousr money: "<<money<<endl;
		}
		else
		{
			cout<<"\n Loss :( \n\n";
			money -= 200;
			cout<<" Yousr money: "<<money<<endl;
			}
		}
		else
		{
			cout<<"\n\n Game Over :(\n\n";
			Sleep(2000);
			cout<<" Refill balance\n\n";
			int symbol = getch();
			if(symbol == 27)
			{
				cout<<"\n\n Game Over :(\n\n";
				cout<<"EXIT"<<"\n\n";
				exit(0);
			}
			cout<<"\n\n   Enter money: ";
			int temp = 0;
			cin>>temp;
			money+=temp;
		}

	}