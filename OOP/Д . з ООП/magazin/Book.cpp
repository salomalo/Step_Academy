#include "Book.h"

edition::Book::Book()
	:Title(0)
	,Publication(0)
	,Author(0)
	,price(0)
	,isNew(0)
{
	Title=new char[25];
	Publication=new char[25];
	Author=new char[25];
}

edition::Book::Book(	char * newTitle
		,char * newPublication
		,char * newAuthor
		,int    newprice
		,bool   newNew)
{
	Title=new char[strlen(newTitle)+1];
	Title=strcpy(Title,newTitle);
	Publication=new char[strlen(newPublication)+1];
	Publication=strcpy(Publication,newPublication);
	Author=new char[strlen(newAuthor)+1];
	Author=strcpy(Author,newAuthor);
	this->price=newprice;
	this->isNew=newNew;
}

edition::Book::~Book()
{
delete[]Title;
delete[]Publication;
delete[]Author;
}

int edition::Book::getPrice()
{
	return this->price;
}

bool edition::Book::operator > (Book & tmp)
{
	if(this->price > tmp.getPrice());
	return this->price > tmp.getPrice();
}

bool edition::Book::operator < (Book & tmp)
{
	if(this->price < tmp.getPrice());
	return this->price < tmp.getPrice();
}

bool  edition::Book::operator > (int & tmp)
{
	if(  this->price > tmp);
	return  this->price > tmp ;
}
bool edition:: Book::operator < (int & tmp)
{
	if(  this->price < tmp);
	return  this->price < tmp ;
}



edition::Book edition::Book::operator=(Book & tmp)
{
	this->Author=strcpy(this->Author,tmp.Author);
	this->Publication=strcpy(this->Publication,tmp.Publication);
	this->Title=strcpy(this->Title,tmp.Title);
	this->isNew=tmp.isNew;
	this->price=tmp.price;

	return Book(this->Author,this->Publication,this->Title,this->isNew,this->price);
}

ostream & edition::operator << (ostream & left, edition:: Book & right)
{
	left<<right.Title<<"    "<<right.Publication<<"    "<<right.Author<<"    "<<right.price<<"    "<<right.isNew<<endl;
	return left;
}


bool edition::Book::getIsNew()
{
	return isNew;

}