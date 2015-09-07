#pragma once
#include"Shooter.h"


class Catapult: public Shooter
{
public:
	Catapult(){}


	Catapult(char*newName, int newCount) : Shooter(newName,newCount)
	{
		setAmunition(newName, newCount);
	}

	~Catapult()
	{
	//	cout<<"destructor for Catapult "<<endl;
	}

	bool shot() 
	{
		cout<<name<<" is shooting"<<endl;
		Shooter::shot();
		return true;
	}



};