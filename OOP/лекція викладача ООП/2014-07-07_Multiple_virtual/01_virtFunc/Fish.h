#pragma once

#include "Animal.h"


// class Fish ���������� ����� ��������� �-� Say() �� Animal
// �� ������������ ��,
// �����, ���� ����������� ������ !!!
class Fish : public Animal
{
public: 

	Fish( int weight )
		: Animal( weight )
	{}


};