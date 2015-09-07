#pragma once

#include "Animal.h"


class Cat : public Animal
{
public: 

	Cat( int weight )
		: Animal( weight )
	{}

	void Say()
	{
		cout <<"Myav-myav-myav!\n" <<"I`m a Cat. My weight is " <<weight <<".\n";
	}

	void Other()
	{
		cout <<"\nnew method.\n\n";
	}

};