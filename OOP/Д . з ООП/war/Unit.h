#pragma once
#include <iostream>
using namespace std;

class Unit
{

public:
	Unit();
	Unit(int hp, int dmg, int dodge);

	virtual void Show();
	void Attack(Unit* tmp);

	virtual int protection();
	virtual void name();
	bool alive();

//protected:
	int hp;
	int dmg;
	int dodge;

};