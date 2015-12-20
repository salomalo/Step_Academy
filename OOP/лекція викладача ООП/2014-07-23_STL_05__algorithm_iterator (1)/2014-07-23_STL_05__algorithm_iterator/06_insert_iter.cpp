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
	Show( oVec2 ,"oVec2 before" );

	copy_backward( oVec.begin() , oVec.end(), oVec2.end() );	// copy_backward -- ����� � ����������� �������, ��������� � ����
	Show( oVec2 ,"oVec2 after" );

	cout <<"\n\n_______________ move _________________\n";
	//move( oVec2.end() - 5 , oVec2.end() , oVec2.begin() );
	copy( oVec2.end() - 5 , oVec2.end() , oVec2.begin() );
	Show( oVec2 ,"oVec2 after" );
	// ������, �� move � copy ������� ���� � �� � :(

	cout <<"\n\n_______________ inserting_iterator _________________\n";
	deque<int> oDec;
	Show( oDec ,"oDec before" );

	//copy( oVec2.end() - 5 , oVec2.end() ,oDec.begin() ); ������� -- ����� �������� "�������� ����" ��� � ��� ��������

	// ��� ....

	// ������������ "����������� ����������"
	insert_iterator< deque<int> > itInsDec ( oDec, oDec.begin() );	// ��� �������� ( ���� ��'� itInsDec ) ����������� � oDec, ��������� � oDec.begin()
	copy( oVec2.end() - 5 , oVec2.end() , itInsDec ); 
	Show( oDec ,"oDec  after" );

	insert_iterator< deque<int> > itInsDecEnd ( oDec, oDec.end() );	// ��� �������� ( ���� ��'� itInsDecEnd ) ����������� � oDec, ��������� � oDec.end()
	copy( oVec2.begin() +7 , oVec2.begin() + 11 , itInsDecEnd ); 
	Show( oDec ,"oDec  after" );

	insert_iterator< deque<int> > itInsDecMid ( oDec, oDec.begin() + 5 );	// ��� �������� ( ���� ��'� itInsDecMid ) ����������� � oDec, ��������� � oDec.begin() + 5
	copy( oVec2.begin() +13 , oVec2.end() , itInsDecMid ); 
	Show( oDec ,"oDec  after" );



	cout <<"\n\n\n";
}

