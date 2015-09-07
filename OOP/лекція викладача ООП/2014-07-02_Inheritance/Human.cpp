

#include "Human.h"


Human::Human( const char * name, const char * phone, const char * birth )
{
	this->name = new char [ strlen( name ) +1 ];
	strcpy( this->name , name );

	this->phone = new char [ strlen( phone ) +1 ];
	strcpy( this->phone , phone );

	this->birth = new char [ strlen( birth ) +1 ];
	strcpy( this->birth , birth );

	cout <<"\nHuman constructor for " <<name <<endl;

}

Human::~Human()
{
	cout <<"\nHuman destructor for " <<name <<endl;

	delete [] name;
	delete [] phone;
	delete [] birth;
}



ostream & operator << ( ostream & left , const Human & right )
{
	left <<"\nI`m a Human. My name is " <<right.name <<endl
		 <<"I was born " <<right.birth <<".\n"
		 <<"Call me: "  <<right.phone <<endl
		 ;

	return left;
}

