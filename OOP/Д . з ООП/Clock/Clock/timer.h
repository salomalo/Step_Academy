#pragma once
#include<iostream>
#include"Counter.h"

class timer
{
public:
	timer();
	void time();
	void getTime();

private:
	Counter hour;
	Counter min;
	Counter sec;
	Counter desec;
};