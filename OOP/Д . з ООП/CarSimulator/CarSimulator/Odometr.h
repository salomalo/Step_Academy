#ifndef fUELgAUGE_H
	#define fUELgAUGE_H

#pragma once
#include <cstdio>
#include<iostream>
#include"FuelGauge.h"

using namespace std;

class Odometr
{
public:
	Odometr();
	Odometr(int curKMage, int  fuelGauge, int wayToLiter);
	bool counter();
	int getcurKMage()const;
	double burnLit();
	void wayLeft(FuelGauge a);

private:
	int curKMage;//кількість проїханих км
	int fuelGauge;//покажчик рывня палива
	double wayToLiter;//скільки км проїхати на 1 лятр
	int kmLeftinLiter;//скільки ще можна проїхати на залишках пального
};

#endif