#pragma once

#include <iostream>
using namespace std;


class Hoofs
{
public:

	Hoofs( int diameter )
		: diameter( diameter )
	{
		cout <<"Hoofs (" <<diameter <<") constructor.\n";
	}

	~Hoofs()
	{
		cout <<"Hoofs (" <<diameter <<") destructor.\n";
	}



protected:			// ������ ���������� ������� (��� ������) � �������� �����
	short diameter;

};