#include <iostream>
#include <iomanip>
#include <ctime>
using namespace std;


bool doIt()
{
	if( rand() % 10 > 8 )
	{
		return false;
	}

	return true;
}



void main()
{
	srand( time(0) );

	for( int i = 0 ; i < 20 ; i++ )
	{
		cout <<'[' <<setw(2) <<i <<"] Calling doIt() ... ";
	
		if( ! doIt() )
			cout <<"ERROR\n";
		else
			cout <<"successfully\n";

	}

		cout <<endl <<endl <<endl;
}

