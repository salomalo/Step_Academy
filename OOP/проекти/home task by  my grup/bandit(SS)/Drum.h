//Клас Drum -- це кільцева черга. Метод rotate() запускає обертання барабана з випадковою
//швидкістю (періодом -- використовуйте clock() ). Метод show() показує поточний стан барабана. 
//Відповідно getChar() повертає симол, котрий "випав".
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
	Node	*pHead;		// вказівник на голову черги
	Node	*pTail;
	Node    *pCur;// вказівник на хвіст черги

};


