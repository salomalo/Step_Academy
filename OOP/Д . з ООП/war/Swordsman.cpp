#include"Swordsman.h"

Swordsman::Swordsman(int hp,int dmg,int dodge)
	:Unit(hp, dmg, dodge)
{}

void Swordsman::name()
{
	cout<<"Swordsman";
}

void Swordsman::Show()
{
	cout<<" Swordsman "<<" hp - "<<hp<<" ( dmg - "<<dmg<<" dodge - "<<dodge<<")"<<endl;
}

