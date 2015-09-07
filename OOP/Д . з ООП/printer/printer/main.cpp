#include "Printer.h"
void main()
{
	Printer P(5);
	char doc[200];
	int pri,choice;
	bool isSucces;
	
	while(true)
	{
		system("cls");
		cout<<"Director whants to  print ...........1"<<endl;
		cout<<"Accountant  whants to  print ........2"<<endl;
		cout<<"Clerk  whants to   print.............3"<<endl<<endl;

		cout<<endl<<" Print queue  is : "<<P<<endl;
		isSucces=P.dequeue(doc,pri);
		if(isSucces)
		{
			cout<<endl<<"Printer is printing now, wait for your turn"<<endl;
			int size = rand()%5001+5000;
			for(int i=0; i<10; i++)
			{
				if(kbhit() == true)
				{
					choice=getch();
					switch(choice)
					{
					case '1':
						P.enqueue("Director's document",5);
						break;
					case '2':
						P.enqueue("Accountant's document",3);
						break;
					case '3':
						P.enqueue("Clerk's document",1);
						break;
					}
				}
				Sleep(size/10);
				cout<<char(177);
			}
		}
		else
			cout<<"Printer is free\n";
		if(kbhit() == true)
		{
			choice=getch();
			switch(choice)
			{
			case '1':
				P.enqueue("Director's document",5);
				break;
			case '2':
				P.enqueue("Accountant's document",3);
				break;
			case '3':
				P.enqueue("Clerk's document",1);
				break;
			}
		}
		Sleep(500);
	}
}