#pragma once 

#include <iostream>
using namespace std;


// ����, ������ ������ ���� � ���� ����� ²�������� �-�, ���������� �����������
// � �� ���� ���� �������� ������� ��'���� ������������ �����
class Animal
{
public:

	Animal( int weight ) 
		: weight( weight )
	{}


	// ����� ��������� �������
	//                 vvvv --  ��� ����������� ������� ����� ²������Ͳ��� �������
	virtual void Say() = 0
	{
		cout <<"I`m an Animal. My weight is " <<weight <<" I don`t know what to say...\n";
	}
	// ��� ��� ���� ���� ��������, ��� ���� ���� ���� ���������� ���� � ������ ��������� �����
	//		���. Volf::Say()




protected:	// �������� ������ ���� ������ �������� ����� ( ����� ��� � �������� ����������� )

	int	weight;


};