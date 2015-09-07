#pragma once

#include <iostream>
using namespace std;


class Human
{

public:
	Human( const char * name, const char * phone, const char * birth );
	~Human();

	friend ostream & operator << ( ostream & left , const Human & right );

	void Show( ostream & left ) const
	{
		left << (*this);
	}


	const char * getName() const
	{ return name ; }

private:
	char	*name;		// повне ім'я
	char	*phone;		// телефон
	char	*birth;		// дата народження


	// забороняємо методи, котрі лінуємося писати :)
	Human( Human & );					// конструктор копій
	Human & operator = ( Human & );		// оператор присвоєння



};