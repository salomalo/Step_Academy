#pragma once
#include <iostream>
using namespace std;

class Audio
{
public:
	Audio();
	Audio(char * newTitle, char * newSinger, int newcountTreck, int newprice, bool newNew);
	~Audio();
	int getPrice();
	bool getIsNew();

	friend  ostream & operator << (ostream & left,Audio &right );
	bool operator>(Audio & tmp);
	bool operator < (Audio & tmp);

	bool operator > (int & tmp);
	bool operator < (int & tmp);

	Audio operator=(Audio & tmp);

private:
	char* Title;
	char*singer;
	int countTreck;
	int price;
	bool isNew;
};