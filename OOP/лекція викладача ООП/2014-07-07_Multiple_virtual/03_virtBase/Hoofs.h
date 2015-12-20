#pragma once

#include <iostream>
using namespace std;


#include "Part.h"

// в≥ртуальний базовий клас при множинному успадкуванн≥ 
// в к≥нцевому клас≥ присутн≥й в Їдиному екземпл€р≥
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



protected:			// можемо звертатис€ напр€му (без гетер≥в) з пох≥дних клас≥в
	short diameter;

};