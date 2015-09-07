#include "Edition.h"


class Book : virtual public Edition
{
public:
	Book() : author(0), ganre(0), Edition() {}
	Book (int yearNEW, string titleNEW, string typeNEW, string authorNEW, string ganreNEW, double priceNEW, bool ishe)
		: Edition(yearNEW, titleNEW, typeNEW, priceNEW, ishe), author(authorNEW) ,ganre(ganreNEW)
			{}

	string getGanre()
	{
		return ganre;
	}

	friend ostream & operator << (ostream & left, Book &right)
	{
		left<<setw(20)<<right.title<<"    "<<setw(10)<<right.type<<"    "<<setw(15)<<right.author<<setw(5)<<right.year<<"    "<<setw(10)<<right.ganre<<"  "<<setw(10)<<right.price<<"  "<<setw(3)<<right.isHere<< endl;
		return left;
	}

private:
	string author;
	string ganre;
};