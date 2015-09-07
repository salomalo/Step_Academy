#include <vector>

#include <iostream>

using namespace std;

template <typename TYPE >
void showVector( vector<TYPE> & oVec , const char * name )
{

	cout <<"vector '" <<name  <<"':\n";
	vector<TYPE>::iterator itCur = oVec.begin();	// �������� �������
	vector<TYPE>::iterator itEnd = oVec.end();		// �������� ����

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
	
	//vector<double> oVec( 5 , 55.55 );		// ���������� ������ �'����� 55.55
	vector<double> oVec ( dArr , dArr + 7 );	// ���������� ������ �������, ������� �������� �� ������� � �����
	showVector( oVec , "oVec" );


	vector<double> oVec1( oVec.begin() +2 , oVec.end() - 3 );	// ���������� ������ ����� ��������, �������� ���� ���������
	showVector( oVec1 , "oVec1" );

	oVec.push_back( 44.66 );
	oVec.push_back( 88.7 );
	oVec.push_back( 458.97 );

	vector<double> oVec2( oVec.rbegin(), oVec.rend() );	// ���������� ������ ����� ��������, �������� ���� ���������
	showVector( oVec2 , "oVec2" );



	cout <<"\n\n\n";
}
