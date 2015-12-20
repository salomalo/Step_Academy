#include "Printer.h"
#include<conio.h>


void main()
{
	int ex;
	srand(time(NULL));
	Printer q1(15);
	
	while(true)
	{
		system("cls");

		cout<<"\n\n\t\t            _________         \n";
		cout<<"\t\t           |         |        \n";
		cout<<"\t\t           |         |        \n";
		cout<<"\t\t       ____|_________|____        \n";
		cout<<"\t\t      |                   |       \n";
		cout<<"\t\t      |       Cannon      |       \n";
		cout<<"\t\t      |___________________|       \n";
		cout<<"\t\t      |___________________|       \n";
		cout<<"\t\t        |_|           |_|         \n";
		char temp[128];
		bool isSucces;
		cout<<"\n\nQueue:  "<<q1<<endl;
		isSucces = q1.dequeue( temp );
		if(isSucces)
		{
			cout<<"\n Printer is busy \n";
			int size = rand()%5001+5000;
			
			cout<<"\n Print document number: "<<temp<<endl;
			
			cout<<"\n";
			
			for(int i =0;i<10;i++)
			{
				if(kbhit() == true)
		        {
					int s = getch();
					int choice = rand()%3+1;
					switch(choice)
					{
					case 1:
						q1.enqueue("BOSS",10);
						break;
					case 2:
						q1.enqueue("Booker",5);
						break;
					case 3:
						q1.enqueue("Clerk",1);
						break;
					}
		        }
		        
				Sleep(size/10);
				cout<<"| ";
			}
		}
		else
			cout<<"Printer is free\n";

				if(kbhit() == true)
		        {
					int s = getch();
					int choice = rand()%3+1;
					switch(choice)
					{
					case 1:
						q1.enqueue("BOSS",10);
						break;
					case 2:
						q1.enqueue("Booker",5);
						break;
					case 3:
						q1.enqueue("Clerk",1);
						break;
					}
		        }
			
		Sleep(500);
	
	}
	 
}