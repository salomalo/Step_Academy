#pragma once
#ifndef cDATE_H
	#define cDATE_H



#include <cstdio>
#include<iostream>
using namespace std;


class Cdate
{

public:
	Cdate();
	Cdate( short year, short month, short day );
	
	void setDate(char* string);
	void ShowDate();

private:
	short day;
	short month;
	short year;
};


#endif