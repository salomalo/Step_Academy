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
	int curKMage;//������� �������� ��
	int fuelGauge;//�������� ����� ������
	double wayToLiter;//������ �� ������� �� 1 ����
	int kmLeftinLiter;//������ �� ����� ������� �� �������� ��������
};

#endif