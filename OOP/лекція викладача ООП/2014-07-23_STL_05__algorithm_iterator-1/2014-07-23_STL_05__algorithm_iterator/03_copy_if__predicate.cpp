#include <iostream>
#include <iomanip>

#include <vector>
#include <deque>

#include <algorithm>	// copy_if
#include <iterator>		// ostream_iterator

using namespace std;

// унарний предикат - ф-я, котра приймає одни int, а повертає bool
bool MyPredicate( int iVal )
{
	bool bRes =  ! ( iVal % 2 );
	cout <<"\t\tMyPredicate( " <<iVal <<" ) = " <<boolalpha <<bRes  <<"\n";
	return bRes;	// повертає true для парних значень
}




void main()
{
	ostream_iterator<int> itOutInt ( cout , " " );	// такий ітератор виводить усі елементи через " | "



	int arr[] = { 11, 22, 33, 44, 55, 66, 77, 88, 99 };

	cout <<"\n\n__________ initialization by iterators __________\n";

	vector<int> oVec( arr, arr + 9 );
	cout <<"oVec  : ";
	copy ( oVec.begin() , oVec.end() , itOutInt );	// копіюємо в потік виводу -- алгоритму copy байдуже КУДИ копіювати: він бачить лише ітератор
	cout <<endl;

	cout <<"\n\n_______________ copy_if _________________\n";

	vector<int> oVec2( oVec.size() );
	copy_if( oVec.begin() , oVec.end(), oVec2.begin(), MyPredicate ); 

	// копіюємо в потік виводу -- алгоритму copy байдуже КУДИ копіювати: він бачить лише ітератор
	cout <<"oVec2  : ";
	copy ( oVec2.begin() , oVec2.end() , itOutInt );	
	cout <<endl;



	cout <<"\n\n\n";
}

