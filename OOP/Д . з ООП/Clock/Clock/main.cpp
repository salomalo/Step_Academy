#include<Windows.h>
#include"Counter.h"
#include"Clock.h"
#include"timer.h"


void main()
{
	Clock a;
	timer b;

	while (true)
	{
		system("cls");
		a.cloc();
		a.getTime();


		b.time();
		b.getTime();
		Sleep(100);
	}


}