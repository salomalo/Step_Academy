#pragma once

#include <iostream>
using namespace std;


class Human
{

public:
	Human( const char * name, const char * phone, const char * birth );
	~Human();

	friend ostream & operator << ( ostream & left , const Human & right );

	void Show( ostream & left ) const
	{
		left << (*this);
	}


	const char * getName() const
	{ return name ; }

private:
	char	*name;		// ����� ��'�
	char	*phone;		// �������
	char	*birth;		// ���� ����������


	// ����������� ������, ���� ������� ������ :)
	Human( Human & );					// ����������� ����
	Human & operator = ( Human & );		// �������� ���������



};