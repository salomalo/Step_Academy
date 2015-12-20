#include <iostream>
#include <string>
using namespace std;



// клас для відслідковування
class Monitor
{
public:

	Monitor( string value )
		: name( value )
	{ cout <<"Constructor for '" <<name <<"'\n"; }


	~Monitor()
	{ cout <<"Destructor for '" <<name <<"'\n"; }



private:
	string name;

};



class myException
{
public:
	myException( string msg )
		: txt( msg )
	{}


	myException( myException & eSrc )
	{
		this->txt = eSrc.txt;
		cout <<"\nCopying constructor myException\n\n";
	}


	void Show()
	{ cout <<txt ; }


protected:
	string txt;

};



class DerivedException : public myException
{
public:
	DerivedException( string msg )
		: myException( msg )
	{}


	DerivedException( DerivedException & eSrc )
		: myException( eSrc.txt )
	{
		cout <<"\nCopying constructor DerivedException\n\n";
	}


};







void doIt( string str )
{
	Monitor obj( str );

	if( str.length() > 25 )	// коли рекурсія стане достатньо глибокою -- викидаємо виключення
	{
		cout <<"\nthrow myException( \"ERROR!\" )\n";
		throw myException( "ERROR!" );

		//cout <<"\nthrow DerivedException( \"ERROR!\" )\n";
		//throw DerivedException( "ERROR!" );
	}

	doIt( "___ "+str );
}






void main()
{
	try
	{
		doIt( "test" );
	}
	catch( DerivedException  e )	// щоби "ловити" виключення типу похідного класу, catch базового класу має бути розташований ПІСЛЯ усіх catch похідних класів
	{
		cout <<"Catched DerivedException '";
		e.Show() ;
		cout <<"'\n";
	}
	catch( myException & e )	// catch базового класу "ловить" виключення похідних класів
	{
		cout <<"Catched myException '";
		e.Show() ;
		cout <<"'\n";
	}
	//catch( DerivedException & e )	
	//{
	//	cout <<"Catched DerivedException '";
	//	e.Show() ;
	//	cout <<"'\n";
	//}


	cout <<"\n\n\n";
}
