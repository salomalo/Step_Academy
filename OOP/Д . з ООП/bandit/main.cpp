#include"Drum.h"
#include"bandit.h"

void main()
{
	Bandit b;
	while(true)
	{
		int money;
		cout<<"Fill your balance "<<endl;
		cin>>money;
		b.setMoney(money);
		b.Start();
	}

}