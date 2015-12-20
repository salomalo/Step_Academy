#pragma once

#include <iostream>
using namespace std;

#include "Part.h"


// ���������� ������� ���� ��� ���������� ����������� 
// � �������� ���� �������� � ������� ���������
class Horns : virtual public Part
//class Horns : public Part
{
public:

	Horns( int weight )
		: weight( weight )
		, Part( "brown" )
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