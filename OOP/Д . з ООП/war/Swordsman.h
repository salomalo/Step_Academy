#include"Unit.h"	


class Swordsman: public Unit 
{
public :
	Swordsman(int hp, int dmg, int dodge);
	void name();

	
	void Show();
	
};