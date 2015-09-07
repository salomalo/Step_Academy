#pragma once

#include "Human.h"


class Employee : protected Human		// ще можна успадковуватись по private і  protected -- вибираємо щось одне !!!
{

public:

	Employee(	  const char * name, const char * phone
				, const char * birth , const char * hired )
		: Human( name, phone, birth )
	{
		this->hired = new char [ strlen(hired) +1 ] ;
		strcpy( this->hired , hired );

		cout <<"\Employee constructor for " <<getName() <<endl;	
	}


	friend ostream & operator << ( ostream & left , const Employee & right )
	{
		right.Show( left );
		left <<"I`m an Employee. Hired " <<right.hired <<endl;
		return left;
	}


	~Employee()
	{	cout <<"\Employee destructor for " <<getName() <<endl; 	}



private:
	char	*hired;		// дата прийому на роботу

};

