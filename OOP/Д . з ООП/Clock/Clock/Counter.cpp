#include"Counter.h"

Counter::Counter(int minValue, int maxValue, int curValue)
	{
		this->minValue=minValue;
		this->maxValue=maxValue;
		this->curValue=curValue;
	}

	int Counter::getValue()
	{
		return curValue;
	}

	bool Counter::tick()
	{
		curValue++;
		if (curValue>maxValue)
		{
			curValue=minValue;
			return true;
		}
		else return false;
	}

	bool Counter::tim()
	{
		curValue--;
		if (curValue<maxValue)
		{
			curValue=minValue;
			return true;
		}
		else return false;
	}



