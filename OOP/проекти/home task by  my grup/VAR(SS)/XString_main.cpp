//Створіть клас XString, який описує рядок. Клас повинен містити наступні конструктори:
//
//конструктор по замовчуванню, який дозволяє створити рядок довжиною 80 символів;
//конструктор, який створює рядок та ініціалізує його рядком, переданим в якості параметра;
//конструктор копій.
//Крім того, даний клас повинен містити набір перевантажених операцій для роботи з XString-ами:
//операція *: повинна повертати новий рядок, який утворюється шляхом перетину двох рядків, 
//тобто їх спільні символи. Наприклад, результатом перетину рядків "Microsoft" та "Windows" буде рядок "ioso".


//операція /: повинна повертати новий рядок, який утворюється шляхом відбору символів першого рядка, яких немає в другому. Наприклад, результатом ділення рядка "Microsoft" на "Windows" буде рядок "Mcrft".
//операцію +, що дозволяє додати два рядки (конкатенація рядків). Наприклад, результатом додавання двох рядків "Microsoft" та "Windows" буде рядок "MicrosoftWindows".
//операцій *=, /= та +=, які діють по вищеописаному принципу. 
//Операторів порівняння: <, >, <=, >=, ==, != для можливості порівняння двох рядків
//Оператора ! (NOT), що дозволить здійснити реверс рядка. Наприклад, результатом реверсу рядка "Windows" буде рядок "swodniW".
//Приведення до типу char*.
#include "XString.h"
#include "Var.h"



int main()
{
	//XString str( "My first XString object!  I`m exalted!!!!" );
	//cout <<"Look at this:   '" <<str <<"'\n\n\n";		// тут спрацює перевантажений оператор << ( рядок 27)

	//cout <<"Enter new value for XString : ";
	//cin  >>str;		// працює перевантажений оператор >>
	//cout <<"Look at this:   '" <<str <<"'\n\n\n";		// тут спрацює перевантажений оператор << ( рядок 27)

	//str[2] = '#';
	//str[12] = '#';
	//str[22] = '#';
	//cout <<"Look at this:   '" <<str <<"'\n\n\n";		// тут спрацює перевантажений оператор << ( рядок 27)


	//str( 5, 5, '$' );
	//cout <<"Look at this:   '" <<str <<"'\n\n\n";		// тут спрацює перевантажений оператор << ( рядок 27)

	//int s=2;
	//XString abr("Look at me");
	//XString bora("Lppok qz");
	//
	//(abr*bora).Show();
	//cout<<endl;
	//(abr/bora).Show();
	//cout<<endl;
	//(abr+bora).Show();
	//cout<<endl;
	//cout<<"Nezminulos"<<endl;
	//abr.Show();
	//cout<<endl;
	//cout<<boolalpha <<(abr>bora)<<endl;
	//cout<<boolalpha <<(abr<=bora)<<endl;                                         //-чому працює??????? унарний
	//
	//(!abr).Show();
	//cout<<endl;
	//cout<<bora.toChar();
	//char *result=(char*)bora;
	
	Var a(1);
	Var b(1.5);
	Var c("a32");
	Var d("345");
	Var resI(0);
	Var resD(0.0);
	Var resX("0");

	cout<<"a+b="<<(a+b)<<endl;
	resI=a+b;
	cout<<a<<"+"<<b<<" = " <<resI<<endl;
	resX=c+d;
	cout<<c<<"+"<<d<<" = " <<resX<<endl;
    resD=b-a;
	cout<<b<<"-"<<a<<" = " <<resD<<endl;
    resX=c*d;
	cout<<c<<"*"<<d<<" = " <<resX<<endl;
	resX=c/d;
	cout<<c<<"/"<<d<<" = " <<resX<<endl;
	
	cout<<a<<">"<<b<<boolalpha<<"\t" <<(a>b)<<endl;
	cout<<a<<"<"<<b<<boolalpha<<"\t" <<(a<b)<<endl;
	cout<<a<<"=="<<b<<boolalpha<<"\t" <<(a==b)<<endl;
	cout<<a<<"!="<<b<<boolalpha<<"\t" <<(a!=b)<<endl;
	cout<<c<<">"<<d<<boolalpha<<"\t" <<(c==d)<<endl;
	cout<<c<<"=="<<d<<boolalpha<<"\t" <<(c==d)<<endl;
	cout<<c<<"!="<<d<<boolalpha<<"\t" <<(c!=d)<<endl;
	//cout<<b.toInt();

	return 0;

}



