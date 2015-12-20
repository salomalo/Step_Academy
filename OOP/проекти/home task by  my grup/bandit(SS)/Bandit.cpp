#pragma once
#include"Bandit.h"
//HANDLE hConsole = GetStdHandle( STD_OUTPUT_HANDLE );
//COORD coord;
//CONSOLE_FONT_INFOEX fontInfo;

Bandit::Bandit():sum(0){}
Bandit::~Bandit(){}


void Bandit:: Start()
{
	srand( time(0));
	/*D1.push(4);
	D2.push(4);
	D3.push(4);*/
	while(sum>0)
	{

		ShowSum();
		int bet;
		cout<<"Enter your bet =  ";cin>>bet;

		if(bet<=sum)
		{
			sum-=bet;
			ShowSum();
			int a=rand()%21+30;
			int b=rand()%11+20;
			int c=rand()%11+10;
			int d=a;
			
			do
			{
				ShowSum();
				D3.rotate(a,33); D2.rotate(b,35);D1.rotate(c,37);
				Sleep(100);
				
			}
			while (--d);
			ShowSum();
			//coord.X = 32;
			//coord.Y = 10;
			//SetConsoleCursorPosition( hConsole, coord );
			ConsoleWorker::SetConsolePosition(32,10);
			cout<<"Stop!!!"<<endl;
			D3.Show(33);
			D2.Show(35);
			D1.Show(37);
			Sleep(1500);
			if(Check(bet,D3.getChar(),D2.getChar(),D1.getChar()))
			{
				Win(bet);
				cout<<"Press any key";
				getch();
			}
		}
		else
		{   
			ShowSum();
			cout<<endl;
			cout<<"Your bet is too big, try less sum"<<endl;
			cout<<"Press any key";
			getch();
		}
		system("cls");

	} 
	ShowSum();
	cout<<"Sorry you have now money, next time YOU will WIN!!! \n";
}
bool Bandit::Check (int &bet,char a,char b,char c)
{
	if(a==b&&b==c)
	{
		bet*=3;
		return true;
	}
	if(a==b||b==c||a==c)
	{
		bet+=100;
		return true;
	}
	return false;
}

void Bandit:: Win(int &bet)
{
	sum+=bet;	
	ShowSum();
	/*coord.X = 25;
	coord.Y = 16;
	SetConsoleCursorPosition( hConsole, coord );*/
	ConsoleWorker::SetConsolePosition(25, 16);
	cout<<"Your win ="<<bet<<"!!!"<<endl;
	Beep(1480,200);   
	Beep(1568,200);   
	Beep(1568,200);   
	Beep(1568,200);      
	Beep(739.99,200);   
	Beep(783.99,200);   
	Beep(783.99,200);   
	Beep(783.99,200);         
	Beep(369.99,200);   
	Beep(392,200);   
	Beep(369.99,200);   
	Beep(392,200);   
	Beep(392,400); 

}
void Bandit::DepositMoney(int money)
{
	sum+=money;
	ShowSum();
}
void Bandit::Withdraw()
{
	int money;
	cout<<"Enter sum which you want to withdraw =";cin>>money;
	sum-=money;
	ShowSum();
}

int Bandit::Sum()
{
	return sum;
}

void Bandit::ShowSum()
{
	ConsoleWorker::SetConsolePosition(0, 2);
	/*coord.X = 0;
	coord.Y = 2;
	SetConsoleCursorPosition( hConsole, coord );*/
	//printf("Your account equel = %d",Sum());
	cout<<"Your account equel ="<<sum<<"   "<<endl;
	ConsoleWorker::SetConsolePosition(0, 3);
	cout<<"If you get - 3 equel symbol your bet*3 "<<endl;
	cout<<"If you get - 2 equel symbol your will get +100 "<<endl;
	cout<<endl;
	

}
void Bandit:: FillDrum(int amount)
{
	D1.push(amount);
	D2.push(amount);
	D3.push(amount);
}