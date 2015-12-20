#include <iostream>
using namespace std;



class Seller 
{
public:

	Seller( const char * const firstName, const char * const surName, int age  )
		: firstName(0), surName(0), age( age ), averagePaymentsPercent(0), isCalculated(false)
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



	int getAveragePaymentsPercent() const
	{
		if( ! isCalculated )
		{
			////////////////////////////////////////////////
			//
			//��� ��� ���� ���� ����� ������������� �������
			//
					 averagePaymentsPercent = 22;
					 isCalculated = true;
			//
			///////////////////////////////////////////////
		}

		return averagePaymentsPercent;
		
	}




	// ����������� ����� -- �� ���� �������� ���� ��'���� !!!
	void show() const		// const ������ ����� !!!
	{
		// ��� ����� �� ���� ���� ������� !!!!
		//if( age = 22 )
		//	cout <<"Why ? \n\n";

		cout <<"Seller: surName='" <<this->surName 
			 <<"', firstName='" <<this->firstName
			 <<"', age=" <<this->age
			 <<"\n";
		
	}


	~Seller()
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

	// ������� ������� ����� ���������
	mutable int	   averagePaymentsPercent;
	mutable bool   isCalculated;

};//class Seller 



void doIt()
{
	Seller petya( "Pedro", "Gonslaes", 44 );
	petya.show();
}







void main()
{
	Seller masha( "Masha", "Pupkina", 33 );
	masha.show();
	masha.setSurName( "Vasina" );
	masha.show();

	doIt();

	Seller vasya( "Vasya", "Pupkin", 33 );
	vasya.show();

}





