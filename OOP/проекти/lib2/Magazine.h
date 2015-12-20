#pragma once
#include "Edition.h"
#include <set>

class Magazine : virtual public Edition
{
public:
	Magazine() : month(0), Edition() {}
	Magazine (int yearNEW, string titleNEW, string typeNEW, string mon, double priceNEW, bool ishe)
		: Edition(yearNEW, titleNEW, typeNEW, priceNEW, ishe), month(mon) 
			{}

	string getMonth()
	{
		return month;
	}

	friend ostream & operator << (ostream & left, Magazine &right)
	{

		left<<setw(20)<<right.title<<"    "<<setw(10)<<right.type<<"    "<<setw(5)<<right.year<<"    "<<setw(10)<<right.month<<"  "<<setw(10)<<right.price<<"  "<<setw(3)<<right.isHere<< endl;
		return left;
	}

	friend ofstream & operator << ( ofstream & file, Magazine & obj )
	{
	ofstream fout("name",ios::binary);
	
	if(!fout)
	{
		cout<<"ERROR wrong char"<<endl;
	}


	fout << obj.title <<endl;
	


	return file;
	
	}


	//friend ifstream & operator >> ( ifstream & file, Magazine & obj );

private:
	string month;
};