#include <iostream>
#include <string>

using namespace std;


void main()
{
	char str [] = "Hello, world!";
	cout <<"str: '" <<str <<"'\n"
		 <<"strlen(str) = " <<strlen(str) <<"\n"
		 <<"sizeof(str) = " <<sizeof(str) <<"\n"
		 <<endl;
	char str1 [33] ;
	strcpy( str1, "My string: ");
	strcat( str1, str );
	cout <<"str1: '" <<str1 <<"'\n"
		 <<"strlen(str1) = " <<strlen(str1) <<"\n"
		 <<"sizeof(str1) = " <<sizeof(str1) <<"\n"
		 <<endl;
	cout <<endl;
	string strn( "String: " );
	strn += str;
	cout <<strn <<endl;


	cout <<"\n\n\n";


	// "новий" тип символів -- широкі символи wide chars -- на кожен символ по 2 байти
	// рядкові ф-ї, котрі для char починалися з str, для wchar_t починаються з wcs (wide charset)
	wchar_t wstr [] = L"Hello, world!";		// Сивол L перед лапками вказує, що літерл -- Unicode'ний
	wcout <<"wstr: '" <<wstr <<"'\n"
		 <<"wcslen(wstr) = " <<wcslen(wstr) <<"\n"	
		 <<"sizeof(wstr) = " <<sizeof(wstr) <<"\n"
		 <<endl;
	wchar_t wstr1 [33];
	wcscpy( wstr1, L"My string: ");
	wcscat( wstr1, wstr );
	wcout <<"wstr1: '" <<wstr1 <<"'\n"
		 <<"wcslen(wstr1) = " <<wcslen(wstr1) <<"\n"	
		 <<"sizeof(wstr1) = " <<sizeof(wstr1) <<"\n"
		 <<endl;

	wstring wstrn ( L"Wide string: " );
	wstrn += wstr1;
	wcout <<wstrn <<endl;


	cout <<"\n\n\n";
}