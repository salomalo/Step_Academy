#pragma once 

#include <iostream>
using namespace std;


// клас, котрий містить хоча б одну ЧИСТО ВІРТУАЛЬНУ ф-ю, називається АБСТРАКТНИМ
// і не може бути створено жодного об'єкта абстрактного класу
class Animal
{
public:

	Animal( int weight ) 
		: weight( weight )
	{}


	// ЧИСТО віртуальна функція
	//                 vvvv --  оця конструкція позначає ЧИСТУ ВІРТУАЛЬНІСТЬ функції
	virtual void Say() = 0
	{
		cout <<"I`m an Animal. My weight is " <<weight <<" I don`t know what to say...\n";
	}
	// тіло ЧВФ може бути присутнім, але воно може бути викликаним лише з методів похідного класу
	//		див. Volf::Say()




protected:	// дозволяє доступ ЛИШЕ членам похідних класів ( ззовні так і лишеється недоступним )

	int	weight;


};