#pragma once

#include "Human.h"


// ���� Client ��������� �Ѳ ���� � ������ Human ������� 
// ����� ����� ������� �� ��� �� ��������� -- �� ���� public �� �������� public, �� ���� private, �� �������� private
class Client : public Human		// �� ����� ��������������� �� private �  protected -- �������� ���� ���� !!!
{

public:

	Client( const char * name, const char * phone, const char * birth )
		: Human( name, phone, birth )
		, sum(0)
	{	cout <<"\Client constructor for " <<getName() <<endl;	}



	~Client()
	{	cout <<"\Client destructor for " <<getName() <<endl; 	}


	friend ostream & operator << ( ostream & left , Client & right )
	{
		right.Show( left );
		left << "I`m a Client. My sum = " <<right.sum <<endl ;

		return left;
	}



private:
	int		sum;	// ���� ��� ������� �볺���

};

