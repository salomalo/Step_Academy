#pragma once

#include <iostream>
using namespace std;

#include "Part.h"


// в≥ртуальний базовий клас при множинному успадкуванн≥ 
// в к≥нцевому клас≥ присутн≥й в Їдиному екземпл€р≥
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



protected:			// можемо звертатис€ напр€му (без гетер≥в) з пох≥дних клас≥в
	short weight;

};