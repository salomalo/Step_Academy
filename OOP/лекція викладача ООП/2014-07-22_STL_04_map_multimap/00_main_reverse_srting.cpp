/// реверс стрінга -- просто !!!!



#include <iostream>
#include <string>

using namespace std;


void main()
{
	string sStr1("1234567890");
	cout <<"source: '" <<sStr1 <<"'\n";

	string sRev( sStr1.rbegin() , sStr1.rend() );
	cout <<"revers: '" <<sRev <<"'\n";


	cout <<"\n\n\n";
}

