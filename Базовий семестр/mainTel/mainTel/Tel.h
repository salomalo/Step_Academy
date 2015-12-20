#include<iostream>
#include <conio.h>
#include<ctime>
#include<cstring>
using namespace std;

struct adr
{
	char* City;
	char* Street;
	int HousNumber;
	int FlatNumber;
};

struct fnum
{
	char* Name;
	char* Surname;
	char* MiddleName;
};

struct abonent
{
	int TelephoneNumber;
	fnum FullNume;
	adr Adres;
};

void Choise(abonent*,int);

void Print(const abonent&, int);

void Fill(abonent&);

void Copy(abonent&, abonent&);

void Add(abonent*&, int&);

void find(abonent*&, int);

void Delete(abonent*&,int&);

void Edit(abonent*&,int&);