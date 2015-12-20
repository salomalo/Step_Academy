#ifndef dISCAUNTcARD_H
	#define dISCAUNTcARD_H

#include"Cdate.h"
#include<iostream>
using namespace std;

class DiscauntCard
{
public:
	DiscauntCard();
	DiscauntCard(int discaunt, double summaryBuy,short day,short month,short year);

	void setdiscaunt();
	
	void ToBuy(double tovar);
	
	void ShowDiscaunt();
	
	void ShowToBuyforDisc();
	
	double getsummaryBuy();
	
	void getCdate();

private:
	int discaunt;
	double summaryBuy;
	Cdate date;
};

#endif