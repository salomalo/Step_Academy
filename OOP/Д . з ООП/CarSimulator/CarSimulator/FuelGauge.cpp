#include"FuelGauge.h"




	FuelGauge::FuelGauge(int maxValue, int curValue)
	{
		this->maxValue=maxValue;
		this->curValue=curValue;
	}

	void FuelGauge::toFuel(int x)
	{
		if (curValue<maxValue)
		{
			curValue+=x;
			if(curValue>maxValue)
			{
				curValue=maxValue;
			}
		}
	}

	void FuelGauge::burn(int y)//скыльки лытрыв злишилось
	{
		curValue-=y;
		if(curValue>0)
		{
			cout<<"in gauge left - "<<curValue<<" l of fuel"<<endl;
		}
		else
			cout<<"you need to fuel"<<endl;
	}

	int FuelGauge::getCurValue()
	{
		return curValue;
	}