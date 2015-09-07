#ifndef cLOCK_H
#define cLOCK_H

#include"Clock.h"

Clock::Clock()
	:hour(0,23,0),min(0,59,0),sec(0,59,0),desec(0,9,0)
{}

void Clock::cloc()
{
	if(desec.tick())
	{
		if(sec.tick())
		{
			if(min.tick())
			{
				hour.tick();
			}
		}
	}
}



void Clock::getTime()
{
	printf("%02d-%02d-%02d-%02d\n",hour.getValue(),min.getValue(),sec.getValue(),desec.getValue());
}


#endif