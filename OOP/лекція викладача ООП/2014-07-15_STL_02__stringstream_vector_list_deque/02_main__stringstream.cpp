#include <string>
#include <sstream>	// string'ові потоки

#include <iostream>
#include <iomanip>
using namespace std;



void main()
{
	string oFirst;
	//cout <<"Enter string: ";
	////cin >> oFirst;
	//do{
	//	getline( cin , oFirst , '$' );
	//	cout <<"\nEntered string: '" <<oFirst <<'\'' <<endl;
	//} while( ! cin.eof() );


	ostringstream sout;
	sout <<"Hello, world!!!!" <<endl;
	sout <<setw(11) <<setfill('_') <<5+5 <<endl;

	string oNew ( sout.str() );
	cout <<"\n\n__________________ string from string stream __________\n";
	cout <<oNew <<endl <<endl <<endl;

	sout <<"\nAnother text\n";
	cout <<sout.str()  <<endl <<endl;

	cout <<"\n\n__________________ strings from input string stream __________\n";
	istringstream sin( oNew );
	do{
		//getline( sin , oFirst );
		sin >> oFirst;
		cout <<"\nEntered string: '" <<oFirst <<'\'' <<endl;
	} while( ! sin.eof() );



	cout <<"\n\n\n";
}
