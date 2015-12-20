#include"Bandit.h"


void main()
{
	Bandit b;
	cout<<"\n\n Play?\n\n";
	int symbol = getch();
		if(symbol == 27)
		{
			cout<<"\n\n Game Over :(\n\n";
			cout<<"EXIT"<<"\n\n";
			exit(0);
		}

	while(true)
	{
		cout<<"\n\n   Enter money: ";
		cin>>b;
		
		system("cls");
		
	while(true)
	{
		b.start();
		cout<<"\n\n Play?\n\n";
		int symbol = getch();
		if(symbol == 27)
		{
			cout<<"\n\n Game Over :(\n\n";
			cout<<" Yousr money: "<<b<<endl;
			cout<<"\n EXIT"<<"\n\n";
			exit(0);
		}
		system("cls");
	}
	}
	
}