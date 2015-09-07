#include "book.h"
#include"CShop.h"
#include"Audio.h"
#include"magazine.h"
using namespace edition;

void main()
{
	Book book1("TiTl111","pr1","lev1", 10,true);
	Book book2("Title22","pr2","lev2", 70,true);
	Book book3("Title33","pr3","lev3", 5,false);
	CShop <Book>  * b_shop =new  CShop <Book> (  ) ;
	b_shop->add(book1);
	b_shop->add(book2);
	b_shop->add(book3);
	cout<<"__________________Book ______________"<<endl;
	cout<<(*b_shop);
	cout<<endl;
	b_shop->MaxPrice();
	cout<<endl;
	b_shop->MinPrice();
	cout<<endl;
	b_shop->AveragePrice();
	cout<<endl;
	b_shop->showIsNew();

	cout<<endl;
	cout<<endl;
	cout<<endl;

	Magazine mag1("klas",12,true);
	Magazine mag2("nationalGeografic",8,true);
	Magazine mag3("discovery",15,false);
	CShop <Magazine>  * m_shop =new  CShop <Magazine> (  ) ;
	m_shop->add(mag1);
	m_shop->add(mag2);
	m_shop->add(mag3);
	cout<<"________________Magazine ______________"<<endl;
	cout<<(*m_shop);
	cout<<endl;
	m_shop->MaxPrice();
	cout<<endl;
	m_shop->MinPrice();
	cout<<endl;
	m_shop->AveragePrice();
	cout<<endl;
	m_shop->showIsNew();



	cout<<endl;
	cout<<endl;
	cout<<endl;

	Audio au1("skyIsOver","SOAD",15,123,true);
	Audio au2("friend","you",23,9,true);
	Audio au3("meterora","linkinPark",20,150,false);
	CShop <Audio>  * a_shop =new  CShop <Audio> (  ) ;
	a_shop->add(au1);
	a_shop->add(au2);
	a_shop->add(au3);
	cout<<"________________________Audio ______________"<<endl;
	cout<<(*a_shop);
	cout<<endl;
	a_shop->MaxPrice();
	cout<<endl;
	a_shop->MinPrice();
	cout<<endl;
	a_shop->AveragePrice();
	cout<<endl;
	a_shop->showIsNew();

	cout<<endl;
	cout<<endl;
	cout<<endl;





}