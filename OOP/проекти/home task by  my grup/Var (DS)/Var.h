#include "XString.h"

class Var
{

public:

	Var()           : intNumber(0), doubleNumber(0), strNumber(0)  {};
	Var(int ch)     : intNumber(ch), doubleNumber(0), strNumber(0) {};
	Var(double ch)  : intNumber(0), doubleNumber(ch), strNumber(0) {};
	
	
	Var(char * ch)  : intNumber(0), doubleNumber(0), strNumber(0)  {strNumber.setStr(ch);};

	Var(const Var & src)
		: intNumber( src.intNumber), doubleNumber (src.doubleNumber), strNumber(src.strNumber)
	{};

	~Var() {delete [] this->strNumber;}

	friend ostream & operator << (ostream & left, Var & right);
	friend istream & operator >> (istream & left, Var & right);
	
	
	Var operator= (const int right);
	Var operator= (const double right);
	Var operator= (const char * right);

	operator int ();
	operator double ();
	operator char * ();

	Var operator+ (Var & right);
	Var operator- (Var & right);
	Var operator* (Var & right);
	Var operator/ (Var & right);

	Var operator+= (Var & right);
	Var operator-= (Var & right);
	Var operator*= (Var & right);
	Var operator/= (Var & right);

	bool operator< (Var & right);
	bool operator> (Var & right);
	bool operator<= (Var & right);
	bool operator>= (Var & right);
	bool operator== (Var & right);
	bool operator!= (Var & right);


private:
	int intNumber;
	double doubleNumber;
	XString strNumber;

};