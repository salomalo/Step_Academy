#pragma once

#include "Animal.h"


class Volf : public Animal
{
public: 

	Volf( int weight )
		: Animal( weight )
	{}

	void Say()
	{
		cout <<"Hau-u-u-u-u!\n" <<"I`m a Volf. My weight is " <<weight <<".\n";
		cout <<"Launching Animal::Say():\n";
		Animal::Say();
	}

	void Other()
	{
		cout <<"\nnew method.\n\n";
	}

};