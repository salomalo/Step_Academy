#include"Mage.h"

Mage::Mage(int hp,int dmg,int dodge)
	:Unit( hp, dmg, dodge)
{}

void Mage::name()
{
	cout<<"Mage";
}

void Mage::Show()
{
	cout<<" Mage "<<"    hp - "<<hp<<" ( dmg - "<<dmg<<" dodge - "<<dodge<<" )"<<endl;
}


