#include"magazine.h"
using namespace edition;


Magazine::Magazine()
	:Title(0)
	,price(0)
	,isNew(0)
{
	Title=new char[25];
}

Magazine::Magazine(char * newTitle
			 , int newprice
			 , bool newNew)
{
	Title=new char[strlen(newTitle)+1];
	Title=strcpy(Title,newTitle);
	this->price=newprice;
	this->isNew=newNew;
}

Magazine::~Magazine()
{
	delete[]Title;
}

int Magazine::getPrice()
{
	return this->price;
}

ostream & edition::operator << (ostream & left,edition::Magazine &right)
{
	left<<right.Title<<"    "<<right.price<<"    "<<right.isNew<<endl;
	return left;
}

bool  Magazine::operator>(Magazine & tmp)
{
	if(this->price > tmp.getPrice());
	return this->price > tmp.getPrice();
}
bool Magazine::operator < (Magazine & tmp)
{
	if(this->price < tmp.getPrice());
	return this->price < tmp.getPrice();
}

bool  Magazine::operator > (int & tmp)
{
	if(  this->price > tmp);
	return  this->price > tmp ;
}
bool  Magazine::operator < (int & tmp)
{
	if(  this->price < tmp);
	return  this->price < tmp ;
}

bool Magazine::getIsNew()
{
	return isNew;
}


Magazine Magazine::operator=(Magazine & tmp)
{
	this->Title=strcpy(this->Title,tmp.Title);
	this->isNew=tmp.isNew;
	this->price=tmp.price;
	return Magazine(this->Title,this->price,this->isNew);
}