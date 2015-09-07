#pragma once
#include"Shooter.h"


class Ranger: virtual public Shooter
{
public:
	Ranger() : Shooter()
	{
	//	setAmunition(newName, newCount);
	//	cout<<"constructor for Ranger"<<endl;
	}

	~Ranger()
	{
	//	cout<<"destructor for Ranger "<<endl;
	}

	bool shot() 
	{
		cout<<name<<" is shooting"<<endl;
		Shooter::shot();
		return true;
	}



};