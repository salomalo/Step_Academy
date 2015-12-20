#pragma once
#include "Magazine.h"
#include "Book.h"



class CShop
{
public:
	CShop ();
	~CShop ();

	
	void add (Magazine & newSource);
	

	//void del (const int index);
	void show ();

	/////////////////////////// find шукає обєкт і пропонує подальшу дію змінити обєкт або видалити його
	//void findYaer(int tmp);
	//void findTitle(string tmp);
	//void findMonth(string tmp);
	////void findGanre(string tmp); // only for looking books

	/////////////////////////// sort
	//void sortTitle(); // через перевантажений оператор порівняння
	//void sortMonth(); // через гетер
	//void sortYear();


private:
	Magazine **arr;
	int size;
};