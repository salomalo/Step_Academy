//���� Drum -- �� ������� �����. ����� rotate() ������� ��������� �������� � ����������
//�������� (������� -- �������������� clock() ). ����� show() ������ �������� ���� ��������. 
//³������� getChar() ������� �����, ������ "�����".
#pragma once
#include<iostream>
#include <conio.h>
#include"Console.h"
using namespace std;



class Drum
{
	
public:
	
	Drum();
	~Drum();
	void push(int count);
    void rotate(int& count,int a);
	void Show(int a);
	char getChar();

private:
	struct Node
	{
		char symbol;
		Node *pNext;
	};
	Node	*pHead;		// �������� �� ������ �����
	Node	*pTail;
	Node    *pCur;// �������� �� ���� �����

};


