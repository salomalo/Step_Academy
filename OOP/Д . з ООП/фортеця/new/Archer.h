#pragma once
#include"Shooter.h"


class Archer: virtual public Shooter
{
public:
	Archer() : Shooter()
	{
		//setAmunition(newName, newCount);
		//cout<<"constructor for Archer"<<endl;
	}

	~Archer()
	{
		//cout<<"destructor for Archer "<<endl;
	}

	bool shot() 
	{
		cout<<name<<" is shooting"<<endl;
		Shooter::shot();
		return true;
	}



};