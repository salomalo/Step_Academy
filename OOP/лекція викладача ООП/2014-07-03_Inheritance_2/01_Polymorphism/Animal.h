#pragma once 

#include <iostream>
using namespace std;

class Animal
{
public:

	Animal( int weight ) 
		: weight( weight )
	{}


	// віртуальна функція
	virtual void Say()
	{
		cout <<"I`m an Animal. My weight is " <<weight <<" I don`t know what to say...\n";
	}




protected:	// дозволяє доступ ЛИШЕ членам похідних класів ( ззовні так і лишеється недоступним )

	int	weight;


};