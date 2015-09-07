#ifndef XsTRING_H
#define XsTRING_H
#pragma once
#include <cstring>
#include<iostream>
using namespace std;

class xString
{
public:
	xString();
	xString(const char * const str);
	xString(const xString & oSrc);
	~xString();
	void setStr( const char * const str);
	
	char* getStr();

	friend ostream & operator<< (ostream & left, xString & right);
	friend istream & operator>> (istream & left, xString & right);
	
	operator int() const;
	operator double() const;
	operator char*()const;
	xString	operator + (const int & number);
	xString	operator + (const double & number);
	xString operator + (const  xString &str)	;


	
	//xString  operator ! ();
	//bool  operator > (xString & str);
	//bool  operator < (xString & str);
	//bool  operator != (xString & str);
	//bool  operator == (xString & str);
	//bool  operator <= (xString & str);
	//bool  operator >= (xString & str);
	//xString operator *  (xString & str);
	//xString operator *= (xString & str);
	//xString operator +  (xString & str);
	//xString operator += (xString & str);
	//xString operator /  (xString & str);
	//xString operator /= (xString & str);

private:
	char*string;
};

#endif