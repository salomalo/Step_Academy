#include "Drum.h"
#include<ctime>
#include"Console.h"

class Bandit
{
	
public:
	Bandit();
	~Bandit();
	void Start();
	void Win(int &bet);
	bool Check(int &bet,char a,char b,char c);
	void DepositMoney(int money);
	void Withdraw();
	int Sum();
	void ShowSum();
	int sum;
	void FillDrum(int amount);
private:
	Drum D1;
	Drum D2;
	Drum D3;
	
	
};