#include"Drum.h"

//HANDLE dhConsole = GetStdHandle( STD_OUTPUT_HANDLE );
//COORD dcoord;
Drum::Drum(): pHead( nullptr ), pTail( nullptr )
{


}
	Drum::~Drum()
	{}
	void Drum::push(int count)
{
	int LoadSymb=1;
	
	while(count>0)
	{
		Node * pNew = new Node;
		pNew->pNext = nullptr;
		pNew->symbol = (char)LoadSymb++;

		if( pTail == nullptr )
		{
			pHead = pNew;
		}
		else
		{
			pTail->pNext = pNew;	// кажемо останньому "я за вами"
		}
		pTail = pNew;
		//cout<<pTail->symbol<<"  ";
		count--;
	}
	
}

    void Drum::rotate(int& count,int a)
	{
		/*Node * pPrev = new Node;*/
		/*pPrev->pNext = nullptr;
		pPrev->symbol = 0;*/
		if(count>0)
		{
		Node * pNew = new Node;
		//Node * pPrev = new Node;
		pNew->pNext = nullptr;
		pNew->symbol = pHead->symbol;
		   
		//dcoord.X = a;
		//dcoord.Y = 12;
		//SetConsoleCursorPosition( dhConsole, dcoord );
		//cout<<pTail->symbol<<endl;//
		pTail->pNext = pNew;
		pCur=pTail;
		pTail = pNew;
		ConsoleWorker::SetConsolePosition(a,12);
		/*dcoord.X = a;
		dcoord.Y = 12;
		SetConsoleCursorPosition( dhConsole, dcoord );*/
		//GetCurrentConsoleFontEx(hConsole, TRUE, &fontInfo);
		cout<<pCur->symbol<<endl;//
/*
		dcoord.X = a;
		dcoord.Y = 13;
		SetConsoleCursorPosition( dhConsole, dcoord );*/
		ConsoleWorker::SetConsolePosition(a,13);

		cout<<pTail->symbol<<endl;///
		pHead=pHead->pNext;
		/*
		dcoord.X = a;
		dcoord.Y = 14;
		SetConsoleCursorPosition( dhConsole, dcoord );*/
		ConsoleWorker::SetConsolePosition(a,14);

		cout<<pHead->symbol<<endl;

		count--;

		}
		else
		{
		Show(a);
		}
		//Sleep(speed);
	}
	void Drum:: Show(int a)
	{
		{/*
		dcoord.X = a;
		dcoord.Y = 12;
		SetConsoleCursorPosition( dhConsole, dcoord );*/
		ConsoleWorker::SetConsolePosition(a,12);

		cout<<pCur->symbol<<endl;
				/*
	dcoord.X = a;
		dcoord.Y = 13;
		SetConsoleCursorPosition( dhConsole, dcoord );*/
		ConsoleWorker::SetConsolePosition(a,13);

		cout<<getChar()<<' ';
		/*dcoord.X = a;
		dcoord.Y = 14;
		SetConsoleCursorPosition( dhConsole, dcoord );*/
		ConsoleWorker::SetConsolePosition(a,14);

		cout<<pHead->symbol<<endl;
		}
	}
	
	char Drum:: getChar()
	{
		return pTail->symbol;
	}

