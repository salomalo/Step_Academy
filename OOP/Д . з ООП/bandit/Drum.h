#include <iostream>
#include <iomanip>
#include <ctime>
#include <Windows.h>
#include <conio.h>
using namespace std;
#pragma once

class Drum
{
public:
	Drum(int xpos, int ypos);
	~Drum();

	bool enqueue( char   value );	// ставить value у хвіст черги 
	bool dequeue( char & value );	// забирає з голови черги значення у value
	bool dequeueRing( char & value );
	friend ostream & operator << ( ostream & left, Drum & right);
	void Rotate ();
	char getChar();
	void show();
	void gotoxy(int xpos, int ypos);

private:
	struct Enqueued
	{
		char		value;		// саме значення, поставлене у чергу
		Enqueued	*pNext;		// вказівник на наступного у черзі
	};
	Enqueued	*pHead;		// вказівник на голову черги
	Enqueued	*pTail;		// вказівник на хвіст черги
	int xpos;
	int ypos;
};