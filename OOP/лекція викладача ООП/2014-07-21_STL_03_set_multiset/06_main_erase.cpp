#include <iostream>
#include <ctime>

#include <set>		// ���� ���� set i multiset

using namespace std;


template <typename TYPE>
void Show( const TYPE & oContainer , const char * name )
{
	cout <<name <<" : ";

	TYPE::const_iterator itCur = oContainer.cbegin();	// ����������� �������� �� �� ��������� ������ ������� ����������, �� ������ ����� (����������)
	TYPE::const_iterator itEnd = oContainer.cend();	//  
	while( itCur != itEnd)
	{
		cout <<*itCur <<' ';
		++itCur;
	}
	cout <<endl;
}



void main()
{
	srand( time(0) );


	set<int> oSet;
	multiset<int> oMSet;

	int iVal;
	for( int i = 0 ; i < 22 ; i++ )
	{
		iVal = rand() % 23 - 11;
		cout <<endl <<"adding " <<iVal <<" : " <<endl;

		oSet.insert( iVal );
		Show( oSet ,  " oSet" );
		cout <<"count( " <<iVal <<" ) = " <<oSet.count(iVal )<<endl<<endl;		// ������ iVal � � ��������� �� ����� ������

		oMSet.insert( iVal );
		Show( oMSet , "oMSet" );
		cout <<"count( " <<iVal <<" ) = " <<oMSet.count(iVal )<<endl<<endl;		// ������ iVal � � ��������� �� ����� ������

	}
	cout <<"\n\n\n";

	set<int>		 oSet2( oMSet.crbegin() , oMSet.crend() );	//	��������� ����� set �� ����� ��������� multiset, ������� � ����������� �������
	multiset<int>	oMSet2( oMSet.crbegin() , oMSet.crend() );	//	��������� ����� set �� ����� ��������� multiset, ������� � ����������� �������
	Show( oSet2 , "oSet2" );
	Show( oMSet2 , "oMSet2" );

	cout <<"\n\n\n";


	/////////////////////////////////////////////////////////////////////////////
	///////////     ERASE ////////////////////////





	int iErased;
	for( int i = 0 ; i < 5 ; i++ )
	{
		iVal = rand() % 23 - 11;
		cout <<endl <<"erasing " <<iVal <<" : " <<endl;

		iErased = oSet.erase( iVal );
		Show( oSet ,  " oSet" );
		cout <<"erased "<<iErased <<endl<<endl;		// ������ iVal �������� � ����������

		iErased = oMSet.erase( iVal );
		Show( oMSet , "oMSet" );
		cout <<"erased "<<iErased <<endl<<endl;		// ������ iVal �������� � ����������
	}


	cout <<"\n\n\n";
}

