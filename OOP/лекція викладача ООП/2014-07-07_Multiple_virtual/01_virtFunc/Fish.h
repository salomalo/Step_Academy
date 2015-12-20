#pragma once

#include "Animal.h"


// class Fish успадкував чисто віртуальну ф-ю Say() від Animal
// не перевизначив її,
// тобто, став АБСТРАКТНИМ КЛАСОМ !!!
class Fish : public Animal
{
public: 

	Fish( int weight )
		: Animal( weight )
	{}


};