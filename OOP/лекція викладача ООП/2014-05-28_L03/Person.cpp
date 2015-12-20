#include "Person.h"



Person::Person( 
		const char * const firstName
	, const char * const surName
	, int age  
	, short year
	, short month
	, short day
	)
	: firstName(0), surName(0), age( age )
	, birth( year, month, day )
{
	setFirstName( firstName );
	setSurName( surName );
}


void Person::setFirstName( const char * const firstName )	// const ������ ����� !!!!
{
	if( this->firstName )
		delete [] this->firstName;
	this->firstName = new char [ strlen( firstName ) +1 ];
	strcpy( this->firstName, firstName );
}



void Person::setSurName( const char * const surName )	// const ������ ����� !!!!
{
	if( this->surName )
		delete [] this->surName;
	this->surName = new char [ strlen( surName ) +1 ];
	strcpy( this->surName, surName );
}



void Person::show() const		// const ������ ����� !!!
{
	// ��� ����� �� ���� ���� ������� !!!!
	//if( age = 22 )
	//	cout <<"Why ? \n\n";

	char str[12];
	birth.getString( str );
	cout <<"Person: surName='" <<this->surName 
			<<"', firstName='" <<this->firstName
			<<"', age=" <<this->age
			<<" birth=" <<str
			<<"\n";
		
}




Person::~Person()
{
	cout <<"Destructor of ";
	show();
	delete [] firstName;
	delete [] surName;
}





