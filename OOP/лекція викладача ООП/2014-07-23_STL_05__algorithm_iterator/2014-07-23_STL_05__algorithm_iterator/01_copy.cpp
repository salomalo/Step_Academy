#include <iostream>

#include <vector>
#include <deque>

#include <algorithm>

using namespace std;



template <typename TYPE >
void Show( const TYPE & oCont , const char * name )
{
	cout <<name <<" : ";
	TYPE::const_iterator itCur = oCont.begin();
	TYPE::const_iterator itEnd = oCont.end();
	while( itCur != itEnd )
	{
		cout <<*itCur <<' ';
		++itCur;
	}
	cout <<endl;
}



void main()
{
	int arr[] = { 11, 22, 33, 44, 55, 66, 77, 88, 99 };

	cout <<"\n\n__________ initialization by iterators __________\n";

	vector<int> oVec( arr, arr + 9 );
	Show( oVec , "oVec" );

	cout <<"\n";

	vector<int> oVec2( oVec.rbegin() , oVec.rend() );
	Show( oVec2 , "oVec2" );

	deque<int> oDec( oVec.rbegin() , oVec.rend() );
	Show( oDec , " oDec" );

	cout <<"\n\n__________ resize __________\n";
	size_t nOldSize = oDec.size();
	oDec.resize( 2 * nOldSize + 3 );
	Show( oDec , " oDec" );


	cout <<"\n\n__________ copy to deque __________\n";
	//copy( oVec.begin(), oVec.end() , oDec.end() - nOldSize +1 );	-- видає помилку, бо ітератор виходить за межі контейнера !!!!!
	copy( oVec.begin(), oVec.end() , oDec.end() - nOldSize );
	Show( oDec , " oDec" );

	cout <<"\n\n\n";
}

