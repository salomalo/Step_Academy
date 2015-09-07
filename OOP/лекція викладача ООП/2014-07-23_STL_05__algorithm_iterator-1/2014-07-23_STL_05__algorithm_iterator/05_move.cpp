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
	ostream_iterator<int> itOutInt ( cout , " " );	// ����� �������� �������� �� �������� ����� " | "
	cout <<name <<" : ";
	copy ( oCont.begin() , oCont.end() , itOutInt );	// ������� � ���� ������ -- ��������� copy ������� ���� ��������: �� ������ ���� ��������
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
	Show( oVec2 ,"oVec2 before : " );

	copy_backward( oVec.begin() , oVec.end(), oVec2.end() );	// copy_backward -- ����� � ����������� �������, ��������� � ����
	Show( oVec2 ,"oVec2 after : " );

	cout <<"\n\n_______________ move _________________\n";
	//move( oVec2.end() - 5 , oVec2.end() , oVec2.begin() );
	copy( oVec2.end() - 5 , oVec2.end() , oVec2.begin() );
	Show( oVec2 ,"oVec2 after : " );
	// ������, �� move � copy ������� ���� � �� � :(


	cout <<"\n\n\n";
}

