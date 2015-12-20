
#include "XString.h"
#pragma once
class Var
{
public:
	Var();
	explicit Var(const int i);
	explicit Var(const double d);
	explicit Var (const char  *const str);

	Var operator+ (const Var& i);
	Var operator- ( const Var& i);
	Var operator*  ( const Var& i);
	Var operator/ (const Var& i);
	Var& operator = ( const Var &newVar);
	
	Var operator+= (const Var& i);
	Var operator-= (const Var& i);
	Var operator*= (const Var& i);
	Var operator/= (const Var& i);

	bool operator > (const Var &i);
	bool operator < (const Var &i);
	bool operator >= (const Var &i);
	bool operator <= (const Var &i);

	bool operator == (const Var &newVar);
	bool operator != (const Var &newVar);
	friend ostream & operator << ( ostream & left, Var  right ) ;
	friend istream & operator >> ( istream & left, Var & right ) ;
	Var getVar();


	operator int();
	operator double();
	operator char*();
	
	
private:
	int i;
	double d;
	XString content;
	char type;

};//class XString