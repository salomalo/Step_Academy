#include <list>

#include <iostream>

using namespace std;

template <typename TYPE >
void showList( list<TYPE> & oList , const char * name )
{

	cout <<"list '" <<name  <<"':\n";
	list<TYPE>::iterator itCur = oList.begin();	// �������� �������
	list<TYPE>::iterator itEnd = oList.end();		// �������� ����

	while( itCur != itEnd )
	{
		cout << *itCur <<' ';
		itCur++;
	}
	cout <<endl<<endl;
}


void main()
{
	double dArr [] = { 11.11, 22.22, 33.33, 44.44, 55.55, 66.66, 77.77 };
	
	//list<double> oList( 5 , 55.55 );		// ���������� ������ �'����� 55.55
	list<double> oList ( dArr , dArr + 7 );	// ���������� ������ �������, ������� �������� �� ������� � �����
	showList( oList , "oList" );


	list<double> oList1( oList.begin() , oList.end()  );	// ���������� ������ ����� ��������, �������� ���� ���������
	showList( oList1 , "oList1" );

	oList.push_back( 44.66 );
	oList.push_back( 88.7 );
	oList.push_back( 458.97 );

	list<double> oList2( oList.rbegin(), oList.rend() );	// ���������� ������ ����� ��������, �������� ���� ���������
	showList( oList2 , "oList2" );



	cout <<"\n\n\n";
}
