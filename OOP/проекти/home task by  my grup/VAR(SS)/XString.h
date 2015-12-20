
#include <iostream>
#include <stdio.h>
using namespace std;
#pragma once
class XString
{

public:
	XString();
	XString( const char* const str );
	XString( XString & oSrc );
	~XString();
	void setString (const char *const newstring);
	//operator0 int();

	XString operator*( const XString &str);
	XString operator/ ( const XString &str);
	XString operator+ ( const XString &str);
	XString	operator + (const int & number);
	XString	operator + (const double & number);


	XString operator*=(const  XString &str);
	XString operator/= (const XString &str);
	
	XString operator+= ( XString &str);
	XString	&operator += (const int & number);
	XString	&operator += (const double & number);

	XString operator= (const XString & oSrc );
	XString operator= (const  int i );
	
	bool operator> (const XString &str);
	bool operator< (const XString &str);
	bool operator>= (const XString &str);
	bool operator<= (const XString &str);
	bool operator== (const XString &str);
	bool operator== (const int &i);
	bool operator!= (const XString &str);
	bool operator!= (const int i);
	

	XString operator!();
	operator char * ()const;
	operator int() const;
	operator double() const;
	friend ostream & operator << ( ostream & left, XString & right ) ;
	friend istream & operator >> ( istream & left, XString & right ) ;
	void Show();


	friend ostream & operator << ( ostream & left, XString & right );	// тут left -- це синонім cout'а
	friend istream & operator >> ( istream & left, XString & right );	// тут left -- це синонім cin'а

	char& operator[] ( int idx );	// повератає посилання на ОДИН символ XString'а по даному індексу
	void  operator() ( int idxStart, int length, char replace );	// хочемо, щоби замінило символом replace length символів, починаючи з idxStart'ового


private:

	char * content;

};//class XString