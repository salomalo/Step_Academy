#pragma once

#include "Cat.h"


class Lion : public Cat
{
public: 

	Lion( int weight )
		: Cat( weight )
	{}

	void Say()
	{
		cout <<"Grr-r-r-r-r!\n" <<"I`m a Lion. My weight is " <<weight <<".\n";
	}

	void Other()
	{
		cout <<"\nnew method.\n\n";
	}

};