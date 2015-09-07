#pragma once
#include <iostream>
using namespace std;

namespace edition
{
class Magazine
{
public:
	Magazine();
	Magazine(char* newTitle,int newprice,bool newisNew);
	~Magazine();

	int getPrice();
	bool getIsNew();

	friend  ostream & operator << (ostream & left,Magazine &right );
	bool operator > (Magazine & tmp);
	bool operator < (Magazine & tmp);

	bool operator > (int & tmp);
	bool operator < (int & tmp);

	Magazine operator=(Magazine & tmp);


private:
		char* Title;
		int price;
		bool isNew;

};

}