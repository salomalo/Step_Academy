#include"Unit.h"	



class Archer: public Unit 
{
public :
	Archer(int hp,int dmg,int dodge);

	
	void Show();
	void name();
};