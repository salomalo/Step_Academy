#ifndef bOOK_H
#define bOOK_H
#pragma once;

#include <iostream>
using namespace std;

namespace edition
{

class Book
{
public:
	Book();
	Book(char * newTitle, char * newPublication, char * newAuthor, int newprice, bool newNew);
	~Book();
	int getPrice();
	bool getIsNew();
	friend  ostream & operator << (ostream & right,Book & left);
	bool operator > (Book & tmp);//походу не використано(((
	bool operator < (Book & tmp);//порівнюю в сортуванні дві книги по ціні

	bool operator > (int & tmp);
	bool operator < (int & tmp);

	Book operator=(Book & tmp);

private:
	char * Title;
	char * Publication;
	char * Author;
	int    price;
	bool   isNew;
};

}

#endif