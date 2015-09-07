#pragma once
#include"Catapult.h"
#include"ArcherTower.h"

class Fortress: public Catapult, public ArcherTower
{
public:
	Fortress(int newl, int newEnemy)
		: l( newl),enemy(newEnemy)
		, ArcherTower("   arrows",4)
		, Catapult("   stones",2)

	{
//		ArcherTower::setAmunition("   arrows",4);
//		Catapult::setAmunition("   stones",1);
		//cout<<"constructor Fortress "<<endl;
	}
	
	~Fortress()
	{
	//cout<<" destructor for Fortress "<<endl;
	}

	bool shotArcher() 
	{
		ArcherTower::Archer::shot();
		return true;
	}

	bool shotRanger() 
	{
		ArcherTower::Ranger::shot();
		return true;
	}

	bool shotCatapult() 
	{
		Catapult::shot();
		return true;
	}


protected:
	int l;
	int enemy;
};