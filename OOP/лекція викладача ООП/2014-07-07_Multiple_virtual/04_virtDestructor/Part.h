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


	// деструктор може бути ВІРТУАЛЬНИМ !!!!!!!!
	// ЦЕ ПОТРІБНО ДЛЯ КОРЕКТНОГО ВИКЛИКУ ДЕСТРУКТОРІВ 
	// похідних і абстрактних класів
	// Віртуальність деструктора дозволяє викликати деструктори похідних класів
	// Чисто віртуальний деструктор дає абстрактний клас, як і будь-яка інша чисто вірт. ф-я
	// Чисто віртуальний деструктор повинен мати реалізацію -- хоча б таkу : {  } -- тому що він обов'язково викличеться
	virtual ~Part() = 0
	{
		cout <<"Part (" <<color <<") destructor.\n";
		delete [] color;
	}


	virtual void Show() = 0;	// ЧИСТО КОНКРЕТНО


protected:
	char * color;

};
