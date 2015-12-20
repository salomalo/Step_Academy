#pragma once

#include <iostream>
using namespace std;


#include "Part.h"

// ���������� ������� ���� ��� ���������� ����������� 
// � �������� ���� �������� � ������� ���������
class Hoofs : virtual public Part 
//class Hoofs : public Part 
{
public:

	Hoofs( int diameter )
		: diameter( diameter )
		, Part( "black" )
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