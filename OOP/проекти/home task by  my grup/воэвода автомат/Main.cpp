#include "Automat.h"
#include <conio.h>
#include <ctime>

void main()
{
	system("mode con cols=100 lines=40");
	srand(time(0));
	int vyb;
	Automat AK;
	AK.AK_47();
	
	while(true)
	if(kbhit() == true)
	{
		vyb = getch();
		vyb = getch();

		if(vyb == 80) AK.Charge();
		if(vyb == 72) AK.Shot();
		if(vyb == 75) exit(0);
	}
}