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


	~Part()
	{
		cout <<"Part (" <<color <<") destructor.\n";
		delete [] color;
	}


protected:
	char * color;

};
