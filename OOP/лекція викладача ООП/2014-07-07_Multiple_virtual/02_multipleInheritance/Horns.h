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



protected:			// можемо звертатися напряму (без гетерів) з похідних класів
	short weight;

};