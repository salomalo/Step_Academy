#pragma once

#include <iostream>
using namespace std;


class Horns
{
public:

	Horns( int weight )
		: weight( weight )
	{
		cout <<"Horns (" <<weight <<") constructor.\n";
	}

	~Horns()
	{
		cout <<"Horns (" <<weight <<") destructor.\n";
	}



protected:			// ������ ���������� ������� (��� ������) � �������� �����
	short weight;

};