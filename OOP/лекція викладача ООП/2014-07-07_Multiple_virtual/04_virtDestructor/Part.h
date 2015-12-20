#pragma once

#include <iostream>
using namespace std;

class Part
{
public:
	Part( const char * color )
	{
		this->color = new char [ strlen( color ) +1 ];
		strcpy( this->color, color );
		cout <<"Part (" <<color <<") constructor.\n";
	}


	// ���������� ���� ���� ²��������� !!!!!!!!
	// �� ���в��� ��� ���������� ������� ���������в� 
	// �������� � ����������� �����
	// ³���������� ����������� �������� ��������� ����������� �������� �����
	// ����� ���������� ���������� �� ����������� ����, �� � ����-��� ���� ����� ���. �-�
	// ����� ���������� ���������� ������� ���� ��������� -- ���� � ��k� : {  } -- ���� �� �� ����'������ �����������
	virtual ~Part() = 0
	{
		cout <<"Part (" <<color <<") destructor.\n";
		delete [] color;
	}


	virtual void Show() = 0;	// ����� ���������


protected:
	char * color;

};
