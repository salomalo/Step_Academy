#include <iostream>
#include <iomanip>
#include <ctime>
using namespace std;


int doIt()
{
	int rnd = rand() % 11 ;
	if( rnd > 8 )
	{
		return 3;
	}
	else if( rnd > 6 )
	{
		return 2;
	}
	else if( rnd > 4 )
	{
		return 1;
	}

	return 0;
}



void main()
{
	srand( time(0) );

	for( int i = 0 ; i < 20 ; i++ )
	{
		cout <<'[' <<setw(2) <<i <<"] Calling doIt() ... ";

		int errorCode = doIt();

		if(	errorCode == 0 )
			cout <<"finished successfully\n";
		else
		{
			cout <<"ERROR : ";
			switch( errorCode )
			{

			case 1:
				cout <<"file opening error\n";
				break;

			case 2:
				cout <<"memory allocation error\n";
				break;

			case 3:
				cout <<"user input error\n";
				break;

			}

		}
	}

	cout <<endl <<endl <<endl;
}

