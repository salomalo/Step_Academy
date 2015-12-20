#include"bandit.h"

Bandit::Bandit()
	:money(0),d1(10,5),d2(13,5),d3(16,5)
{}

Bandit::~Bandit()
{}

void Bandit::Start()
{
	while(money>0)
	{
		system("cls");
		cout<<"Balance is "<<getMoney()<<endl;
		int bet;
		cout<<"Your bet : "<<endl;
		cin>>bet;

		if(bet<=getMoney())
		{
			money-=bet;
			cout<<"Balance is "<<getMoney()<<endl;

			srand(time(NULL));
			int count1=rand()%10+5;
			int count2=rand()%11+5;
			int count3=rand()%12+5;

			for(int i=0; i<count1; i++)
			{
				d1.Rotate();
				d1.show();
				Sleep(100);
			}

			for(int i=0; i<count2; i++)
			{	
				d2.Rotate();
				d2.show();
				Sleep(100);
			}

			for(int i=0; i<count3; i++)
			{
				d3.Rotate();
				d3.show();
				Sleep(100);
			}

			if(d1.getChar()==d2.getChar() || d2.getChar()==d3.getChar() || d1.getChar()==d3.getChar())
			{
				money+=100;
				cout<<"Win + 100 !!!"<<endl;
				cout<<"Balance is "<<getMoney()<<endl;
				getch();
			}

			if(d1.getChar()==d2.getChar() == d3.getChar())
			{
				money+=300;
				cout<<"WIN + 300 !!!"<<endl;
				cout<<"Balance is "<<getMoney()<<endl;
				getch();
			}
			else
				cout<<"Try again..."<<endl;
			getch();
		}
	}

	if(money==0||money<0)
	{
		cout<<"Balance is "<<getMoney()<<endl;
		cout<<"Sorry you lose all money "<<endl;
		getch();
	}
}

void Bandit::setMoney(int money)
{
	this->money+=money;
}

int Bandit::getMoney()
{
	return money;
}