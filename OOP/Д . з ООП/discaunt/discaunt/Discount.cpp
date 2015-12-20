#include"Discount.h"

	DiscauntCard::DiscauntCard():discaunt(0),summaryBuy(0){}

	DiscauntCard::DiscauntCard(int discaunt
		, double summaryBuy
		,short day
		,short month
		,short year)
		:discaunt(0),summaryBuy(0),date(day,month,year)
	{
		this->discaunt=discaunt;
		this->summaryBuy=summaryBuy;
	}

	void DiscauntCard::setdiscaunt()
	{
	if(summaryBuy-1000>0 )
	{
	discaunt++;
	}
	
	}

	void DiscauntCard::ToBuy(double tovar)
	{
	summaryBuy+=tovar;
	}

	double DiscauntCard::getsummaryBuy()
	{
	return summaryBuy;
	}

	void DiscauntCard::ShowDiscaunt()
	{
	cout<<"Your discaunt is - "<<discaunt<<endl;
	}

	//void DiscauntCard::ShowToBuyforDisc()
	//{
	//
	//
	//
	//}

	void DiscauntCard::getCdate()
	{
		date.ShowDate();
	}