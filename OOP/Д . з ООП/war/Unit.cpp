#include"Unit.h"	

Unit::Unit():hp(0), dmg(0), dodge(0)
{}

Unit::Unit(int hp, int dmg, int dodge) : hp(hp), dmg(dmg), dodge(dodge)
{}

void Unit::Show()
{
	cout<<" hp - "<<hp<<" dmg - "<<dmg<<" dodge - "<<dodge<<endl;
}

int Unit::protection()
{
	return this->dodge;
}

void Unit::Attack(Unit* tmp)
{
	/*	if(gr1[i]->alive(gr2[i])==true);
				{*/
		name(); cout<<" vs "; tmp->name();
		cout<<endl;
		tmp->hp -= (this->dmg*   (1 + rand()%tmp->protection()) )/100;                 //hp жертви = урон нападника * можливий захист жертви(%) / на 100 %
		cout<<"protection gertvu buv "<<1 + rand()%tmp->protection()<<endl;
		cout<<"nanesenuy uron "<<  (this->dmg* ( 1 + rand()%tmp->protection())           )/100<<endl;
		tmp->Show();
//}

	//if(alive(tmp)==false)
	//{
	//	
	//	tmp->name();
	//	cout<<"this one is dead: ";
	//}





}

void Unit:: name()
{
	cout<<" la la"<<endl;
}



bool Unit :: alive()
{
	return hp>0;
}