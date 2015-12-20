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

	bool enqueue( char   value );	// ������� value � ���� ����� 
	bool dequeue( char & value );	// ������ � ������ ����� �������� � value
	bool dequeueRing( char & value );
	friend ostream & operator << ( ostream & left, Drum & right);
	void Rotate ();
	char getChar();
	void show();
	void gotoxy(int xpos, int ypos);

private:
	struct Enqueued
	{
		char		value;		// ���� ��������, ���������� � �����
		Enqueued	*pNext;		// �������� �� ���������� � ����
	};
	Enqueued	*pHead;		// �������� �� ������ �����
	Enqueued	*pTail;		// �������� �� ���� �����
	int xpos;
	int ypos;
};