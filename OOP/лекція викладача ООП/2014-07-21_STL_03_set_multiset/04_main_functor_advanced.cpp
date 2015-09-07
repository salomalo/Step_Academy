#include <iostream>
#include <iomanip>
#include <ctime>

#include <set>		// ���� ���� set i multiset

using namespace std;


//////////////////////////////////////////////////////////////////
// ������� (������������� ��'��� ) -- ��'���, � ����� � �������������� operator()
// �� �� �������� ��� (������� ������� ) ��� ���� (�������) �������� ���� ����� ����������
// � ������� -- bool
// ��������������� ��� ��������� �������� ����������
// ��� set i multiset �� �� ��������� true, ���� ������ ���-� �� ������ ����� ������
//////////////////////////////////////////////////////////////////
class MyFunctor
{
public:

	static void setShow()
	{	isShow = true; }

	static void setNoShow()
	{	isShow = false; }



	bool operator () ( int iFirst, int iSecond )
	{
		bool bRes = iFirst > iSecond;

		if( isShow )
			cout <<"\tMyFunctor::operator () ( " <<iFirst <<", " <<iSecond <<") = " <<boolalpha <<bRes <<"\n";

		return bRes;	
		//return iFirst < iSecond;	// ��� �� -- ������ ������������ less<int>, ������ �����-�� �� ������������ � set i multiset
	}


private:
	static bool isShow;

};

bool MyFunctor::isShow = true;

//////////////////////////////////////////////////////////////////




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

	////////////////  ������������� ������� -- �������� ����� ���� �� ������ ������� �������� /////////////////
	set<int , MyFunctor>		oSet;
	multiset<int , MyFunctor>	oMSet;

	int iVal;
	for( int i = 0 ; i < 11 ; i++ )
	{
		iVal = rand() % 23 - 11;
		cout <<endl <<"adding " <<iVal <<" : " <<endl;

		MyFunctor::setShow();		// "�� �����" ������ �������� ��������
		oSet.insert( iVal );
		Show( oSet ,  " oSet" );

		MyFunctor::setNoShow();		// "�� �����" ������ �������� ��������
		oMSet.insert( iVal );
		Show( oMSet , "oMSet" );

	}
	cout <<"\n\n\n";

	set<int  , MyFunctor>		 oSet2( oMSet.crbegin() , oMSet.crend() );	//	��������� ����� set �� ����� ��������� multiset, ������� � ����������� �������
	multiset<int  , MyFunctor>	oMSet2( oMSet.crbegin() , oMSet.crend() );	//	��������� ����� set �� ����� ��������� multiset, ������� � ����������� �������
	Show( oSet2 , "oSet2" );
	Show( oMSet2 , "oMSet2" );


	cout <<"\n\n\n";
}

