#include <iostream>
#include <iomanip>
#include <ctime>
using namespace std;


void doIt()
{
	if( rand() % 10 > 8 )
	{
		cout <<"error in doIt()\n";
		exit( EXIT_FAILURE );
	}

}



void main()
{
	srand( time(0) );

	for( int i = 0 ; i < 20 ; i++ )
	{
		cout <<'[' <<setw(2) <<i <<"] Calling doIt() ... ";
		doIt();
		cout <<"successfully\n";
	}

		cout <<endl <<endl <<endl;
}

