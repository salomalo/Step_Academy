// відео написання цього коду доступне за посиланням http://www.ex.ua/get/113329995
// файл 2014-06-30_template_function.tvs на сторінці http://www.ex.ua/78789972?r=78155343



#include <iostream>
using namespace std;

#include "CInt.h"


template < typename TYPE >
TYPE sumArr( const TYPE * arr, int size )
{
	TYPE sum = arr[0];
	for( int i = 1 ; i < size ; i++ )
		sum += arr[i];

	return sum;
}



//double sumArr( const double * arr, int size )
//{
//	double sum = arr[0];
//	for( int i = 1 ; i < size ; i++ )
//		sum += arr[i];
//
//	return sum;
//}




void main()
{
	int ai[] = {1, 2, 3, 4, 5, 6, 7, 8 };
	cout <<"sum = " <<sumArr( ai, 8 ) <<endl;


	double ad[] = {1.1, 2.2, 3.3, 4.4, 5.5, 6.6, 7.7, 8.8};
	cout <<"sum = " <<sumArr( ad, 8 ) <<endl;

	CInt ac[] = { 11, 22, 33, 55, 66, 77, 88 };
	cout <<"sum = " <<sumArr( ac, 7 ) <<endl;

	cout <<"\n\n\n";

}