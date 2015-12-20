
#include <iostream>
using namespace std;



class CInt
{

public:
	CInt() : value(0) 
	{}

	CInt( int val ) : value( val )
	{ /*cout <<"CInt( int " << val <<" )";*/ }

	int getValue() { return value; }



	CInt operator + ( CInt & right )
	{
		CInt res( this->value + right.value );
		return res;
		//return this->value + right.value;
	}


	CInt operator + ( int right );


	friend CInt operator - ( int left, CInt right );

	CInt operator = ( double right );
	CInt operator = ( CInt right );


	CInt operator ++ ();				// ����������
	CInt operator ++ ( int ingnore );	// �����������


	///////////////////// ��������� ��в����  ///////////////////
	bool operator <  ( CInt & right );
	bool operator <  ( const CInt & right );
	bool operator == ( CInt & right );

	bool operator <  ( const int & right );
	bool operator == ( const int & right );

	friend bool operator <  ( const int & left, CInt right );	// friend �� � ������ ����� -- ������ ��� ���������

	const char * operator && ( CInt right );


	//////////////////// ���������� ���� //////////////
	/// int operator int();				��� �� �������, �� ���������� ����������
	//  operator int( CInt & right );	�������� �� ������� -- �� ����� � �� this
	operator int();
	operator char*();


private:
	int value;
};


CInt operator + ( int left, CInt right );
