#pragma once
#include"Archer.h"
#include"Ranger.h"

class ArcherTower: public Archer, public Ranger
{
public:
	ArcherTower(){}
	ArcherTower(char*newName, int newCount)
	{
		setAmunition(newName, newCount);
		//cout<<"constructor for ArcherTower"<<endl;
	}

	~ArcherTower()
	{
	//	cout<<"destructor for ArcherTower "<<endl;
	}


	bool shotArcher() 
	{

		Archer::shot();
		return true;
	}

	bool shotRanger() 
	{
		Ranger::shot();
		return true;
	}





};