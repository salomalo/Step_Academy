#pragma once
#include<iostream>
using namespace std;

class Shooter
{

public:
	Shooter():name(0),count(0){}
		
	Shooter(char*newName, int newCount)
	{
		this->count=newCount;
		this-> name=new char[strlen(newName)+1];
		strcpy(name,newName);
	}

	void setAmunition(char*newName, int newCount)
	{
		this->count=newCount;
		this-> name=new char[strlen(newName)+1];
		strcpy(name,newName);
	}

	~Shooter()
	{
		cout<<"destructor for Shooter "<<endl;
		delete[]name;
	}

	bool shot()
	{
		if(count>0)
		{
			count--;
			cout<<"name is "<<name<<endl;
			cout<<"shot one "<<name<<endl;
			cout<<"count is "<<count<<endl;
			return true;
		}
		else
		{
			cout<<"There is no amunition "<<count<<endl;
			return false;
		}
	}

	void show()
	{
		cout<<"name is "<<name<<endl;
		cout<<"count is "<<count<<endl;
	}

protected:
	char*name;
	int count;
};
















