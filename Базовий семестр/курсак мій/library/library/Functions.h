#include<iostream>
#include<conio.h>
#include<ctime>
#include<cstring>
#include<iomanip>
#include <stdio.h>
#include <windows.h>
using namespace std;
using namespace System;

struct author
{
	char* Name;
	char* Surname;
};

struct publication
{
	char* Type;
	char* Title;
	char* Genre;
	int year;
};

struct source
{
	author AUTHOR;
	publication PUBLICATION;
	char INFO;
};

typedef void (*ptrF)(source*&,int&);

void gotoxy(int xpos, int ypos);
void Menu(source *& BOOKS,int & size);
void Counter(source *& tmp, int n);
void Fill(source & BOOKS);
void Print(source & BOOKS,int i);
void Frame(source *& BOOKS,int &size);//
void Copy(source &tmp, source & BOOKS);

void Add(source *& BOOKS,int & size);
void Delete(source *& BOOKS,int &size);

void CreatArry(source *&tmp, source BOOKS, int &n);

void Find(source *& BOOKS, int &size);
void Sort(source *& BOOKS, int &size);
void debtors(source *& BOOKS, int &size);

void CursorVisible();
void Load(source *& BOOKS,int &size);
void Save(source *   &    BOOKS, int &size);//
void exit(source *& BOOKS,int &size);