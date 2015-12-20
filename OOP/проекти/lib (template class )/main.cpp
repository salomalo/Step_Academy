#include "Shop.h"

void main()
{
	CShop <Magazine> * m_CShop  = new CShop <Magazine> ();
	CShop <Book> * b_Shop  = new CShop <Book> ();

	int year;
	double price;
	string title, month, author, ganre;
	bool ishe;


	do
	{
		system("cls");
		cout<<"      "<<endl<<"**********************MAIN MENU*********************"<<endl<<endl;
		cout<<"                   Choose an action:"<<endl<<endl;
		cout<<"      "<<"Add source.......1"<<endl;
		cout<<"      "<<"Show source.......2"<<endl;
		//cout<<"      "<<"Save mag.......3"<<endl;

		int choice;
		cin>>choice;
		switch(choice)
		{

		case 1:
			system("cls");
			cout<<"to add book......8"<<endl;
			cout<<"to add magazine..9"<<endl;
			int ch;
			cin>>ch;

			if(ch==8)
			{
				system("cls");
				string type1 ("book");

				rewind(stdin);
				cout<<" Title : "; getline(cin,title);
				cout<<" Year : "; cin>>year;
				cout<<" Price : "; cin>>price;
				rewind(stdin);
				cout<<" ishe : "; cin>>ishe;

				rewind(stdin);
				cout<<" Author : "; getline(cin,author);
				cout<<" Ganre : "; cin>>ganre;
				Book source2(year,title, type1, author, ganre, price, ishe);
				b_Shop->add(source2);
			}

			if(ch==9)
			{
				system("cls");
				string type2 ("magazine");

				rewind(stdin);
				cout<<" Title : "; getline(cin,title);
				cout<<" Year : "; cin>>year;
				cout<<" Price : "; cin>>price;
				rewind(stdin);
				cout<<" ishe : "; cin>>ishe;

				cout<<" Month : "; cin>>month;
				Magazine source(year,title,type2,month, price, ishe);
				m_CShop->add(source);
			}

			break;

		case 2: 
			system("cls");
			cout<<"Magazine: "<<endl;
			m_CShop->show();
			
			cout<<"Book: "<<endl;
			b_Shop->show();
			break;
		case 3:
			//m_CShop->Save();
			break;

		}
	}
	while(getch()!=27);



}