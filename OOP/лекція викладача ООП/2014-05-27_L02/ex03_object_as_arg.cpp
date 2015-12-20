#include <iostream>
using namespace std;



class Seller 
{
public:

	Seller( const char * const firstName, const char * const surName, int age  )
		: firstName(0), surName(0), age( age ), averagePaymentsPercent(0), isCalculated(false)
	{
		//this -- це вказівник на об'єкт, від якого викликана ф-я
		// this->age = age;	// такі прості присвоєння варто виносити в ініціалізатори
		setFirstName( firstName );
		setSurName( surName );

	}



	void setFirstName( const char * const firstName )	// const береже нерви !!!!
	{
		if( this->firstName )
			delete [] this->firstName;
		this->firstName = new char [ strlen( firstName ) +1 ];
		strcpy( this->firstName, firstName );
	}



	void setSurName( const char * const surName )	// const береже нерви !!!!
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
			//Ось тут дуже дуже довго розраховується процент
			//
					 averagePaymentsPercent = 22;
					 isCalculated = true;
			//
			///////////////////////////////////////////////
		}

		return averagePaymentsPercent;
		
	}




	// константний метод -- не може змінювати поля об'єкта !!!
	void show() const		// const береже нерви !!!
	{
		// ТУТ МОГЛА БИ БУТИ ВАША ПОМИЛКА !!!!
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

	// середній процент оплат замовлень
	mutable int	   averagePaymentsPercent;
	mutable bool   isCalculated;

};//class Seller 



void doIt()
{
	Seller petya( "Pedro", "Gonslaes", 44 );
	petya.show();
}


void justDoIt_ptr( Seller * obj )
{
	cout <<"\n This is justDoIt !\n";
	obj->show();
	obj->setFirstName( "justDoIt_ptr_ed" );
	obj->show();
}


void justDoIt_ref( Seller & obj )
{
	cout <<"\n This is justDoIt !\n";
	obj.show();
	obj.setFirstName( "justDoIt_ref_ed" );
	obj.show();
}


void justDoIt( Seller obj )
{
	cout <<"\n This is justDoIt !\n";
	obj.show();
	obj.setFirstName( "justDoIt_ref_ed" );
	obj.show();
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

	cout <<"\n-------------------\n";
	justDoIt_ptr( &vasya );
	cout <<"\nin main():\n";
	vasya.show();

	cout <<"\n-------------------\n";
	justDoIt_ref( vasya );
	cout <<"\nin main():\n";
	vasya.show();

	cout <<"\n-------------------\n";
	justDoIt( vasya );
	cout <<"\nin main():\n";
	vasya.show();


	cout <<"\n-------- end of main() -----------\n";
}





