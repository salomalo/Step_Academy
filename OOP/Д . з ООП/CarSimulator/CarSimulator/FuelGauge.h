#pragma once
#include <cstdio>
#include <iostream>
using namespace std;

class FuelGauge
{
public:
	FuelGauge(int maxValue, int curValue);
	void toFuel(int x);
	void burn(int y);
	int getCurValue();

private:
	int maxValue;
	int curValue;
};