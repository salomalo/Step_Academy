#include "CInt.h"

#include <iostream>
using namespace std;


void main()
{
	CInt a(5), b(99), c(-9);
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
}
