#include <iostream>
using namespace std;



class Person 
{
public:

	Person( const char * const firstName, const char * const surName, int age  )
		: firstName(0), surName(0), age( age )
	{
		//this -- �� �������� �� ��'���, �� ����� ��������� �-�
		// this->age = age;	// ��� ����� ��������� ����� �������� � ������������
		setFirstName( firstName );
		setSurName( surName );

	}



	void setFirstName( const char * const firstName )	// const ������ ����� !!!!
	{
		if( this->firstName )
			delete [] this->firstName;
		this->firstName = new char [ strlen( firstName ) +1 ];
		strcpy( this->firstName, firstName );
	}



	void setSurName( const char * const surName )	// const ������ ����� !!!!
	{
		if( this->surName )
			delete [] this->surName;
		this->surName = new char [ strlen( surName ) +1 ];
		strcpy( this->surName, surName );
	}


	// ����������� ����� -- �� ���� �������� ���� ��'���� !!!
	void show() const		// const ������ ����� !!!
	{
		// ��� ����� �� ���� ���� ������� !!!!
		//if( age = 22 )
		//	cout <<"Why ? \n\n";

		cout <<"Person: surName='" <<this->surName 
			 <<"', firstName='" <<this->firstName
			 <<"', age=" <<this->age
			 <<"\n";
		
	}


	~Person()
	{
		cout <<"Destructor of ";
		show();
		delete [] firstName;
		delete [] surName;
	}


private:
	char * firstName;
	char * surName;
	int    age;

};//class Person 



void doIt()
{
	Person petya( "Pedro", "Gonslaes", 44 );
	petya.show();
}







void main()
{
	Person masha( "Masha", "Pupkina", 33 );
	masha.show();
	masha.setSurName( "Vasina" );
	masha.show();

	doIt();

	Person vasya( "Vasya", "Pupkin", 33 );
	vasya.show();

}





