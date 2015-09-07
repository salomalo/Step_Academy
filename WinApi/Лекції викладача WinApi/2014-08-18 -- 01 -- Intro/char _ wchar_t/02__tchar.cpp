//#define _UNICODE
#include <iostream>
#include <tchar.h>	// дає можливість використовувати або char, або wchar_t залежно від того, чи визначена зміння _UNICODE (в т.ч. у властивостях проекту)

using namespace std;

#ifdef _UNICODE
	#define _cout wcout
#else
	#define _cout cout
#endif


void main()
{
	TCHAR str [] = _TEXT("Hello, world!");
	_cout <<"str: '" <<str <<"'\n"
		<<"strlen(str) = " <<_tcslen(str) <<"\n"
		 <<"sizeof(str) = " <<sizeof(str) <<"\n"
		 <<endl;
	//char str1 [33] ;
	//strcpy( str1, "My string: ");
	//strcat( str1, str );
	//cout <<"str1: '" <<str1 <<"'\n"
	//	 <<"strlen(str1) = " <<strlen(str1) <<"\n"
	//	 <<"sizeof(str1) = " <<sizeof(str1) <<"\n"
	//	 <<endl;
	//cout <<endl;
	//string strn( "String: " );
	//strn += str;
	//cout <<strn <<endl;


	cout <<"\n\n\n";
}