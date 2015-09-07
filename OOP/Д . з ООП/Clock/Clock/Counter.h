#pragma once
#include<iostream>
#include<conio.h>
using namespace std;

class Counter
{
public:
	Counter(int minValue, int maxValue, int curValue);
	int getValue();
	bool tick();
	bool tim();

private:
	mutable	int minValue, maxValue, curValue;
};