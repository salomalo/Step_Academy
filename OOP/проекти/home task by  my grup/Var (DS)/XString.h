#include <iostream>
#include <cstring>
using namespace std;


class XString
{

public:

	XString() : str(0)           { str = new char [80]; };
	XString(int size) : str(0)	 { str = new char [size]; };
	XString(char * str) : str(0) { this->str = new char [strlen(str)+1]; setStr(str);};
	
	
	XString(const XString & src)
	{
		this->str = new char [strlen(src.str)+1];
		strcpy(this->str, src.str);
	};

	~XString() {delete [] str;}
	
	void setStr(const char * str) {delete[] this->str; this->str = new char [strlen(str)+1]; strcpy(this->str,str);}
	char * getStr() {return str;}
	
	XString operator= (const XString & right);

	XString operator+ (const XString & right);
	XString operator* (const XString & right);
	XString operator/ (const XString & right);

	XString operator+= (const XString & right);
	XString operator*= (const XString & right);
	XString operator/= (const XString & right);

	bool operator< (const XString & right);
	bool operator> (const XString & right);
	bool operator<= (const XString & right);
	bool operator>= (const XString & right);
	bool operator== (const XString & right);
	bool operator!= (const XString & right);

	XString operator! ();

	operator char* ();


private:

	char * str;

};