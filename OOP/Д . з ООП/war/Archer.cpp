#include"Archer.h"


Archer::Archer(int hp,int dmg,int dodge)
	:Unit( hp, dmg, dodge)
{}

void Archer::name()
{
	cout<<"Archer";
}

void Archer::Show()
{
	cout<<" Archer "<<"   hp - "<<hp<<" ( dmg - "<<dmg<<" dodge - "<<dodge<<")"<<endl;
}


