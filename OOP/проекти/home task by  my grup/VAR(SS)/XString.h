
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


	friend ostream & operator << ( ostream & left, XString & right );	// ��� left -- �� ������ cout'�
	friend istream & operator >> ( istream & left, XString & right );	// ��� left -- �� ������ cin'�

	char& operator[] ( int idx );	// �������� ��������� �� ���� ������ XString'� �� ������ �������
	void  operator() ( int idxStart, int length, char replace );	// ������, ���� ������� �������� replace length �������, ��������� � idxStart'�����


private:

	char * content;

};//class XString