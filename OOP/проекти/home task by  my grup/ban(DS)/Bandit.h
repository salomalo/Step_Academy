#include"Drum.h"
#include<conio.h>

class Bandit
{
public:
	Bandit():money(0){}
	void start();
	friend istream & operator >> ( istream & left, Bandit & right );
	friend ostream & operator << ( ostream & left, Bandit & right );
private:
	int money;
	Drum d1;
	Drum d2;
	Drum d3;
};