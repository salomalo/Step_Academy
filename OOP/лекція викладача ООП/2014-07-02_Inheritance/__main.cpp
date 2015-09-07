/*
	Відео написання цього коду доступне на сторіці http://www.ex.ua/79269561?r=79269548,78789972,78155343
	Файли:	2014-07-02_Inheritance_1.tvs

*/


# include "Client.h"
# include "Employee.h"



void main()
{
	Human h1( "Vasya Pupkin", "093-123-45-67", "01-01-1981" );
	cout <<h1 <<endl;

	Client c1( "Bill Gates", "098-123-45-67", "03-11-1955" );
	cout <<c1 <<endl;

	Employee e1( "Robin Good", "097-222-333-44", "22-11-1976", "01-07-2014" );
	cout <<e1 <<endl;

	cout <<"\n\n\n";
}

