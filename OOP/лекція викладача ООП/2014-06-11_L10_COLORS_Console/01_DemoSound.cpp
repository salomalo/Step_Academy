#include <Windows.h>
#include <iostream>
using namespace std;



void main()
{
	Beep(494, 1000/2);
    Beep(494, 1000/4);
    Beep(494, 1000/4);
    Beep(440, 1000/4);
    Beep(494, 1000/4);
    Beep(523, 1000/4);
    Beep(587, 1000/2 +1000/8);
    Beep(523, 1000/4);
    Beep(494, 1000/2);


	cout <<"Press any\n";
	cin.get();

	for( int cntr = 0; cntr < 11; cntr++ )
	{
		Beep( 3000, 10 );
		Sleep( 300 );
		Beep( 5000, 10 );
		Sleep( 300 );
		Beep( 8000, 10 );
		Sleep( 300 );
	}



}// void main()