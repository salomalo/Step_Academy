
#include "Odometr.h"


	Odometr::Odometr()
		: curKMage(0),fuelGauge(0),wayToLiter(0)
	{}

	Odometr::Odometr(int curKMage, int  fuelGauge, int wayToLiter)
		:curKMage(curKMage),fuelGauge(50),wayToLiter(wayToLiter){}

	bool Odometr::counter()
	{
		curKMage++;
		if (curKMage=999999)
		{
			return true;
			curKMage= 0;
		}
		else return false;
	}

	int Odometr::getcurKMage()const//вертаэ кількість проїханих км
	{
		return curKMage;
	}

	double Odometr::burnLit()//рахуэ скыльки лытрыв спалено
	{
		return curKMage/wayToLiter;
	}

	void Odometr::wayLeft(FuelGauge a)
	{
		a.getCurValue()*wayToLiter;
		if(a.getCurValue()*wayToLiter>0)
			cout<<"you can ride also - "<<a.getCurValue()*wayToLiter<<" km"<<endl;
		else
			cout<<"you can not ride!!! you need to fuel!!!"<<endl;
	}
