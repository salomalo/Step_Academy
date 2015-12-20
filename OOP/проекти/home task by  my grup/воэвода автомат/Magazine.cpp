#include "Magazine.h"

bool Magazine :: Push ()
{
	if(quantity == 30)
	{
		cout<<"! Magazine is full ... \n\n";
		return false;
	}

	Patron * NewPatron = new Patron (Top);
	if(!NewPatron) 
		return false;

	Top = NewPatron;
	quantity++;
	return true;
}


bool Magazine :: Pop (int & Num)
{
	if(quantity == 0)
	{
		cout<<"! Magazine is empty ... \n\n";
		return false;
	}

	quantity--;
	Num = Top->getNum();
	Patron * DelPatron = Top;
	Top = DelPatron->getPrev();
	DelPatron->setPrev(0);
	delete DelPatron;
	return true;
}


ostream & operator << ( ostream & left, const Magazine & right)
{
	HANDLE hConsole = GetStdHandle( STD_OUTPUT_HANDLE);
	COORD coord;
	coord.X=37;
	coord.Y=4;
	SetConsoleCursorPosition(hConsole, coord);
	
	Patron * CurPatron = right.Top;
	while(CurPatron)
	{
		left<<CurPatron->getNum()<<"\n";
		coord.Y++;
		SetConsoleCursorPosition(hConsole, coord);
		CurPatron = CurPatron->getPrev();
	}
	
	coord.X=0;
	coord.Y=39;
	SetConsoleCursorPosition(hConsole, coord);
	return left;
}