#include<iostream>
using namespace std;
#define ERROR 0

class Fraction
{
public:
	Fraction();
	Fraction(int up,int down);
	
	void normalize();
	void show();

	Fraction operator + (Fraction &drib2);
	Fraction operator - (Fraction &drib2);
	Fraction operator * (Fraction &drib2);
	Fraction operator / (Fraction &drib2);

	Fraction operator + (int &a);
	Fraction operator - (int &a);
	Fraction operator * (int &a);
	Fraction operator / (int &a);

	friend  Fraction operator + (int &a, Fraction drib2);
	friend	Fraction operator - (int &a,Fraction &drib2);
	friend	Fraction operator * (int &a,Fraction &drib2);
	friend	Fraction operator / (int &a,Fraction &drib2);

	Fraction operator ++ ();
	Fraction operator ++ (int ignore);
	Fraction operator -- ();
	Fraction operator -- (int ignore);

	void operator = (Fraction &drib2);
	void operator = (int &a);
	


private:
	int up;
	int down;
};