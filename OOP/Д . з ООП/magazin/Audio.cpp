#include"Audio.h"

Audio::Audio()
	:Title(0)
	,singer(0)
	,countTreck(0)
	,price(0)
	,isNew(0)
{
	Title=new char[25];
	singer=new char[25];
}

Audio::Audio(char * newTitle
			 , char * newSinger
			 , int newcountTreck
			 , int newprice
			 , bool newNew)
{
	Title=new char[strlen(newTitle)+1];
	Title=strcpy(Title,newTitle);
	singer=new char[strlen(newSinger)+1];
	singer=strcpy(singer,newSinger);
	this->countTreck=newcountTreck;
	this->price=newprice;
	this->isNew=newNew;
}

Audio::~Audio()
{
	delete[]Title;
	delete[]singer;
}

int Audio::getPrice()
{
	return this->price;
}

ostream & operator << (ostream & left,Audio &right)
{
	left<<right.Title<<"    "<<right.singer<<"    "<<right.countTreck<<"    "<<right.price<<"    "<<right.isNew<<endl;
	return left;
}

bool  Audio::operator>(Audio & tmp)
{
	if(this->price > tmp.getPrice());
	return this->price > tmp.getPrice();
}
bool Audio::operator < (Audio & tmp)
{
	if(this->price < tmp.getPrice());
	return this->price < tmp.getPrice();
}

bool  Audio::operator > (int & tmp)
{
	if(  this->price > tmp);
	return  this->price > tmp ;
}
bool  Audio::operator < (int & tmp)
{
	if(  this->price < tmp);
	return  this->price < tmp ;
}

bool Audio::getIsNew()
{
	return isNew;

}


Audio Audio::operator=(Audio & tmp)
{
	this->singer=strcpy(this->singer,tmp.singer);
	this->Title=strcpy(this->Title,tmp.Title);
	this->countTreck=tmp.countTreck;
	this->isNew=tmp.isNew;
	this->price=tmp.price;

	return Audio(this->Title,this->singer,this->countTreck,this->price,this->isNew);
}