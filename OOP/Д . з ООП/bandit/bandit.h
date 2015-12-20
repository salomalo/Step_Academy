#include"Drum.h"

class Bandit
{
public:
	Bandit();
	~Bandit();
	
	void Start();
	void setMoney(int money);
	int getMoney();

private:
	Drum d1;
	Drum d2;
	Drum d3;
	int money;
};