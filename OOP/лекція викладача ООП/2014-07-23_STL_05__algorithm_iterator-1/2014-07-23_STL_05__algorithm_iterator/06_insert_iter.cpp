#include <iostream>
#include <iomanip>

#include <vector>
#include <deque>

#include <algorithm>	// copy_backward
#include <iterator>		// ostream_iterator

using namespace std;


template <typename TYPE>
void Show( const TYPE & oCont , const char * name )
{
	ostream_iterator<int> itOutInt ( cout , " " );	// такий ≥тератор виводить ус≥ елементи через " | "
	cout <<name <<" : ";
	copy ( oCont.begin() , oCont.end() , itOutInt );	// коп≥юЇмо в пот≥к виводу -- алгоритму copy байдуже  ”ƒ» коп≥ювати: в≥н бачить лише ≥тератор
	cout <<endl;
}


void main()
{

	int arr[] = { 11, 22, 33, 44, 55, 66, 77, 88, 99 };

	cout <<"\n\n__________ initialization by iterators __________\n";

	vector<int> oVec( arr, arr + 9 );
	Show( oVec ,"oVec" );


	cout <<"\n\n_______________ copy_backward _________________\n";

	vector<int> oVec2( oVec.size() * 2 );
	Show( oVec2 ,"oVec2 before" );

	copy_backward( oVec.begin() , oVec.end(), oVec2.end() );	// copy_backward -- коп≥юЇ у зворотньому пор€дку, починаючи з к≥нц€
	Show( oVec2 ,"oVec2 after" );

	cout <<"\n\n_______________ move _________________\n";
	//move( oVec2.end() - 5 , oVec2.end() , oVec2.begin() );
	copy( oVec2.end() - 5 , oVec2.end() , oVec2.begin() );
	Show( oVec2 ,"oVec2 after" );
	// бачимо, що move ≥ copy робл€ть одне ≥ те ж :(

	cout <<"\n\n_______________ inserting_iterator _________________\n";
	deque<int> oDec;
	Show( oDec ,"oDec before" );

	//copy( oVec2.end() - 5 , oVec2.end() ,oDec.begin() ); помилка -- треба спочатку "створити м≥сц€" щоб у них коп≥ювати

	// јЅќ ....

	// скористатис€ "вставл€ючим ≥тератором"
	insert_iterator< deque<int> > itInsDec ( oDec, oDec.begin() );	// цей ≥тератор ( його ≥м'€ itInsDec ) вставл€тиме у oDec, починаючи з oDec.begin()
	copy( oVec2.end() - 5 , oVec2.end() , itInsDec ); 
	Show( oDec ,"oDec  after" );

	insert_iterator< deque<int> > itInsDecEnd ( oDec, oDec.end() );	// цей ≥тератор ( його ≥м'€ itInsDecEnd ) вставл€тиме у oDec, починаючи з oDec.end()
	copy( oVec2.begin() +7 , oVec2.begin() + 11 , itInsDecEnd ); 
	Show( oDec ,"oDec  after" );

	insert_iterator< deque<int> > itInsDecMid ( oDec, oDec.begin() + 5 );	// цей ≥тератор ( його ≥м'€ itInsDecMid ) вставл€тиме у oDec, починаючи з oDec.begin() + 5
	copy( oVec2.begin() +13 , oVec2.end() , itInsDecMid ); 
	Show( oDec ,"oDec  after" );



	cout <<"\n\n\n";
}

