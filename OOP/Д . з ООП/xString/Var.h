#include"xString.h"
#include <conio.h>
#pragma once

class Var
{
public:
	Var();
	Var( const  int tmp);
	Var( const  double tmp);
	Var(const char* const tmp);
	


	friend ostream & operator << (ostream & left, Var  right);
	//friend istream & operator >> (istream & left, Var & right);//-------------------------------
	
	operator int();
	operator double();

	Var operator + (Var & right);




	//Var operator+= (Var & right);
	//Var operator- (Var & right);
	//Var operator-= (Var & right);
	//Var operator* (Var & right);
	//Var operator*= (Var & right);
	//Var operator/ (Var & right);
	//Var operator/= (Var & right);



	//Var operator= (const char * right);           // +
	//Var operator= (const int right);
	//Var operator= (const double right);
	
	//operator int ();
	//operator double ();
	//operator char * ();





	//bool operator< (Var & right);
	//bool operator<= (Var & right);
	//bool operator> (Var & right);
	//bool operator>= (Var & right);
	//bool operator== (Var & right);
	//bool operator!= (Var & right);




private:
	int iVar;
	double dVar;
	xString sVar;
	char check;
};