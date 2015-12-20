#pragma once

#include "Hoofs.h"
#include "Horns.h"


// клас Elk успадковується від двох базових класів
class Elk : public Hoofs, public Horns // порядок базових класів при успадкуванні визначає порядк виконання їхніх конструкторів (і деструкторів також)
{

public:


	Elk( const char * name, short hoofDiameter , short hornsWeight )
		: Hoofs( hoofDiameter )
		, Horns( hornsWeight )
	{
		this->name = new char [ strlen( name ) + 1 ];
		strcpy( this->name, name );
		cout <<"Elk (" <<name <<", " <<hoofDiameter <<", " <<hornsWeight <<") constructor.\n";
	}

	~Elk()
	{
		cout <<"Elk (" <<name <<", " <<diameter <<", " <<weight <<") constructor.\n";	// успадковано по protected, тому доступне напряму
		delete [] name;
	}

	void Show()
	{
		cout <<"Hi! My name is " <<name <<endl
			 <<"I`m Elk. I have horns. It`s weight " <<weight <<endl
			 <<"I have hoofs too. It`s diameter " <<diameter <<endl
			 <<"And what you have ?\n"
			 <<endl;

	}



protected:
	char * name;

};

