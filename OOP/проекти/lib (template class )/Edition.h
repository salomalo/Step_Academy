#pragma once
#include <iostream>
#include <iomanip>
#include <string>
#include <conio.h>
#include <fstream>	
using namespace std;

class Edition
{
public:
	Edition() : year(0), title(0), type(0), price(0), isHere(0) {}
	Edition (int yearNEW, string titleNEW, string typeNEW, double priceNEW, bool ishe) 
		: year(yearNEW), title(titleNEW), type(typeNEW), price(priceNEW), isHere(ishe) 
			{}

	void edit()
	{
		cout<<"type: " ;  cin>>this->type;
		cout<<"title: ";  cin>>this->title;
		cout<<"year:  ";  cin>>this->year;
		cout<<"isHere: "; cin>>this->isHere;
	}

	string getType()
	{
		return type;
	}

	string getTitle()
	{
		return title;
	}


	int getYear()
	{
		return year;
	}



protected:
	int year;
	double price;
	string title;
	string type;
	bool isHere;
};