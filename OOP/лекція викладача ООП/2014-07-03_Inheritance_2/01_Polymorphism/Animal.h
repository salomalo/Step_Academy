#pragma once 

#include <iostream>
using namespace std;

class Animal
{
public:

	Animal( int weight ) 
		: weight( weight )
	{}


	// ��������� �������
	virtual void Say()
	{
		cout <<"I`m an Animal. My weight is " <<weight <<" I don`t know what to say...\n";
	}




protected:	// �������� ������ ���� ������ �������� ����� ( ����� ��� � �������� ����������� )

	int	weight;


};