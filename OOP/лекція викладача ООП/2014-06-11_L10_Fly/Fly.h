#include <Windows.h>
#include <time.h>
#include <iostream>
using namespace std;


struct STIME
{
	time_t	X;
	time_t	Y;
};



class Fly
{

public:
	Fly();
	void move();

private:
	char	sym;		// символ, яким відображається
	DWORD	attr;		// колір мухи
	COORD	pos;		// положення мухи
	COORD	step;		// напрямок руху по осях
	STIME	period;		// затримки руху по осях 
	STIME	next;		// момент наступного руху по кожній осі


	static HANDLE	hCon;		// кожна муха знає, на якому екрані вона літає !	Але -- для усіх мухи екран однин ! тому static

};