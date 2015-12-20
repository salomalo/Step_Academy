#include "CInt.h"

#include <iostream>
using namespace std;



// перевантажуємо ПОЗА класом, тому ДВА аргументи
bool operator <= ( CInt & left, CInt & right )
{
	return ( left < right ) || ( left == right );
}




void main()
{
	CInt a(5), b(99), c(-9), d(5);
	const CInt ccc(33);

	cout <<a.getValue();

	cout <<"\n\n\n";
	CInt res = a + b + c;
	cout <<"res = a + b + c = " <<res.getValue() <<"\n\n";

	CInt res1 = res + 44;
	cout <<"res1 = res + 44 = " <<res1.getValue() <<"\n\n";

	CInt res2 = 5 + res;
	cout <<"res2 = 5 + res = " <<res2.getValue() <<"\n\n";


	CInt res3 = 5 - res;
	cout <<"res3 = 5 - res = " <<res3.getValue() <<"\n\n";

	CInt z, x, q;
	z = x = q = 12.3;
	cout <<"z=" <<z.getValue() <<"   "
		 <<"x=" <<x.getValue() <<"   "
		 <<"q=" <<q.getValue() <<"   \n\n";

	++z;
	cout <<" after ++z, z=" <<z.getValue() <<"\n\n";

	z++ /* тіпа int */;
	cout <<" after z++, z=" <<z.getValue() <<"\n\n";

	cout <<"\n\n______________ operator  < == _____________\n";
	cout <<"a=" <<a.getValue() <<"  b=" <<b.getValue() <<"  d=" <<d.getValue() <<"\n";
	cout <<"a <  b is " <<( a <  b ? "true" : "false" ) <<"\n";
	cout <<"b <  a is " <<( b <  a ? "true" : "false" ) <<"\n";
	cout <<"b < 99 is " <<( b < 99 ? "true" : "false" ) <<"\n";
	cout <<"b <100 is " <<( b <100 ? "true" : "false" ) <<"\n";
	cout <<"99 < b is " <<( 99 < b ? "true" : "false" ) <<"\n";
	cout <<"98 < b is " <<( 98 < b ? "true" : "false" ) <<"\n";
	cout <<"a <= b is " <<( a <= b ? "true" : "false" ) <<"\n";
	cout <<"b <= a is " <<( b <= a ? "true" : "false" ) <<"\n";
	cout <<"b <= ccc is " <<( b < ccc ? "true" : "false" ) <<"\n";
	cout <<"\n";
	cout <<"a == b is " <<( a == b ? "true" : "false" ) <<"\n";
	cout <<"a == d is " <<( a == d ? "true" : "false" ) <<"\n";
	cout <<"a == 5 is " <<( a == 5 ? "true" : "false" ) <<"\n";
	cout <<"a == 6 is " <<( a == 6 ? "true" : "false" ) <<"\n";
	cout <<"a <= d is " <<( a <= d ? "true" : "false" ) <<"\n";
	cout <<"d <= a is " <<( d <= a ? "true" : "false" ) <<"\n";
	cout <<"\n";

	cout <<"\n\n______________ operator  && _____________\n";
	cout <<"a && b is " <<( a && b ) <<"\n";
	cout <<"a && d is " <<( a && d ) <<"\n";

	cout <<"\n\n______________ Type conversion  _____________\n";
	int qq = a;
	cout <<"qq=" <<qq <<"\n";
	char * converted = a;
	cout <<converted <<"\n";
	delete [] converted;	// очищаємо пам'ять !!! ;

}
