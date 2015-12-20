#include "Patron.h"
#include <Windows.h>

#include <iostream>
using namespace std;

class Magazine
{

public:
	Magazine() : quantity(0), Top(0) {}
	~Magazine() {delete Top;}

	bool Push();
	bool Pop(int & Num);

	friend ostream & operator << ( ostream & left, const Magazine & right);
	int getQuantity() {return quantity;}
	
private:
	Magazine(Magazine & src);
	Magazine operator = (Magazine & right);

	int      quantity;
	Patron * Top;

};
