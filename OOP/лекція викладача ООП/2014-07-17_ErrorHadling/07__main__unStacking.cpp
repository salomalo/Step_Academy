#include <iostream>
#include <iomanip>
#include <string>
using namespace std;


class Monitor
{

public:

	Monitor( string msg )
		: txt( msg )
	{ cout <<"Constructor for Monitor( '" <<txt <<"' )\n"; }


	~Monitor()
	{ cout <<"Destructor  for Monitor( '" <<txt <<"' )\n"; }



private:
	string txt;

};




void doIt( string str )
{
	Monitor obj( str );

	if( str.length() > 33 )
	{
		cout <<"\n _________ throw _________ \n\n";
		throw 2222;			// "перериваємо" рекурсію
	}

	doIt( "___ " + str );	// рекурсія

}






void main()
{
	cout <<"main() starts.... \n";

	try
	{
		doIt( "test" );
	}
	catch( int ee)
	{
		cout <<"Catched int " <<ee <<endl;
	}


	cout <<"main() finished\n\n\n\n";

}
