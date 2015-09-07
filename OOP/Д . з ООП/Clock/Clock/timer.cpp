#ifndef cLOCK_H
#define cLOCK_H

#include"timer.h"

timer::timer()
	:hour(23,0,23),min(59,0,59),sec(59,0,59),desec(9,0,9)
{}

void timer::time()
{
	if(desec.tim())
	{
		if(sec.tim())
		{
			if(min.tim())
			{
				hour.tim();
			}
		}
	}
}


void timer::getTime()
{
	printf("%02d-%02d-%02d-%02d\n",hour.getValue(),min.getValue(),sec.getValue(),desec.getValue());
}

#endif