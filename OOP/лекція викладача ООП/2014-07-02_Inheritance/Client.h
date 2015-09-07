#pragma once

#include "Human.h"


// клас Client успадковує УСІ поля і методи Human відкрито 
// тобто рівень доступу до них не змінюється -- що було public те лишається public, що було private, те лишається private
class Client : public Human		// ще можна успадковуватись по private і  protected -- вибираємо щось одне !!!
{

public:

	Client( const char * name, const char * phone, const char * birth )
		: Human( name, phone, birth )
		, sum(0)
	{	cout <<"\Client constructor for " <<getName() <<endl;	}



	~Client()
	{	cout <<"\Client destructor for " <<getName() <<endl; 	}


	friend ostream & operator << ( ostream & left , Client & right )
	{
		right.Show( left );
		left << "I`m a Client. My sum = " <<right.sum <<endl ;

		return left;
	}



private:
	int		sum;	// сума усіх покупок клієнта

};

