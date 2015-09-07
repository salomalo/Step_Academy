#pragma once
#include<iostream>
#include"Counter.h"

class Clock
{
public:
	Clock();
	void cloc();
	void getTime();


private:
	Counter hour;
	Counter min;
	Counter sec;
	Counter desec;
};