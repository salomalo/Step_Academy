//#include "Magazine.h"

#include "Shop.h"

//template <typename TYPE >
//void Add( CShop <TYPE> * SOURCE, string type)
//{

//
//
//}

void main()
{
	/*int a=9;
	string tit("klas");
	string ty("magazine");
	string mon("october");
	bool ishe=1;

	int a2=6;
	string tit2("klas");
	string ty2("tu222");
	string mon2("dec ");
	bool ishe2=1;

	int a3=77;
	string tit3("bora");
	string ty3("tupe3");
	string mon3("nov");
	bool ishe3=1;

	int a4=5;
	string tit4("voyna i mir");
	string ty4("nov");
	string mon4("nov");
	bool ishe4=1;*/

	//Magazine edit(a,tit,ty,mon, 4.5, ishe);
	//Magazine edit2(a2,tit2,ty2,mon2, 55.6, ishe2);
	//Magazine edit3(a3,tit3,ty3,mon3, 76.4, ishe3);
	//Magazine edit4(a4,tit4,ty4,mon4, 43.5, ishe4);

	//CShop <Magazine> * m_CShop  = new CShop <Magazine> ();
	//m_CShop->add(edit);
	//m_CShop->add(edit2);
	//m_CShop->add(edit3);
	//m_CShop->add(edit4);

	
	//cout<<"/////////////////////////////////////"<<endl;
	//cout<<m_CShop;
	//m_CShop->show();

	//cout<<endl;

	//m_CShop->sortTitle();
	//m_CShop->sortType();
	//m_CShop->sortMonth();
	//m_CShop->sortYear();
	

	//try
	//{
	//m_CShop->del(0);
	////m_CShop->show();
	//}
	//catch( int  error )
	//{
	//	cout<<"index wrong"<<endl;
	//	cout<<"try again"<<endl;
	//	m_CShop->del(3);
	//}

	//m_CShop->show();
	


	
	//string key("j");
	//m_CShop->findTitle(key);


	//m_CShop->findMonth(key);





	


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
				//Add(b_Shop,"book");

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
				//Add(m_CShop,"magazine");
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

			//switch(ch)
			//{
			//case 8:
			//	
			//		//Add(b_Shop,"book");
			//	break;
			//case 9:
			//	system("cls");
			//	Add(m_CShop,"magazine");

			//	break;
			//}
			break;

		case 2: 
			system("cls");
			cout<<"Magazine: "<<endl;
			m_CShop->show();
			
			cout<<"Book: "<<endl;
			b_Shop->show();
			break;

		}
	}
	while(getch()!=27);












	//int year1=91;
	//string title1("klas1");
	//string type1("book1");
	//string author1("october1");
	//string ganre1("ganre1");
	//double price1=99.81;
	//bool ishe1=11;

	//	int year2=92;
	//string title2("klas2");
	//string type2("book2");
	//string author2("october2");
	//string ganre2("ganre2");
	//double price2=99.82;
	//bool ishe2=12;

	//	int year3=93;
	//string title3("klas3");
	//string type3("book3");
	//string author3("october3");
	//string ganre3("ganre3");
	//double price3=99.83;
	//bool ishe3=1;

	//	int year4=94;
	//string title4("alas4");
	//string type4("book4");
	//string author4("october4");
	//string ganre4("ganre4");
	//double price4=99.8;
	//bool ishe4=1;

	//Book edit1(year1,title1, type1, author1, ganre1, price1, ishe1);
	//Book edit2(year2,title2, type2, author2, ganre2, price2, ishe2);
	//Book edit3(year3,title3, type3, author3, ganre3, price3, ishe3);
	//Book edit4(year4,title4, type4, author4, ganre4, price4, ishe4);
	//	
	////CShop <Magazine> * m_CShop  = new CShop <Magazine> ();
	//CShop <Book> * b_Shop  = new CShop <Book> ();
	//
	//b_Shop->add(edit1);
	//b_Shop->add(edit2);
	//b_Shop->add(edit3);
	//b_Shop->add(edit4);

	//b_Shop->sortTitle();





	//b_Shop->show();
	//cout<<endl;
}