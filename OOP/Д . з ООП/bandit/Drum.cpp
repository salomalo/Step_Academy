#include"Drum.h"

Drum::Drum(int x, int y)
	: xpos(x),ypos(y), pHead(nullptr), pTail(nullptr)
{
	char mas[]={003,004,005,006,014};
	for(int i=0; i<5; i++)
	enqueue(mas[i]);
}

void Drum::Rotate ()
{
	Enqueued * pCur=new Enqueued;
	pCur=pHead;
	pCur->value=pHead->value;

	enqueue(pCur->value);
	
	pHead=pHead->pNext;
	pHead->value=pCur->pNext->value;
}

Drum::~Drum()
{
	Enqueued * pDel  = pHead;	
	while( pDel )	
	{
		Enqueued * pNext = pDel->pNext;	
		delete pDel;					
		pDel = pNext;					
	}
}

bool Drum::enqueue( char   value )
{
	Enqueued * pNew = new Enqueued;
	if( !pNew )
		return false;
	pNew->pNext = nullptr;	
	pNew->value = value;
	if( pTail == nullptr )
		pHead = pNew;
	else
		pTail->pNext = pNew;	
	pTail = pNew;			
	return true;
}

bool Drum::dequeue( char & value )
{
	if( pHead == nullptr )
		return false;
	value = pHead->value;		
	Enqueued * pDel = pHead;	
	pHead = pHead->pNext;		
	if( pHead == nullptr )
		pTail = nullptr;		
	delete pDel;				
	return true;
}

bool Drum::dequeueRing( char & value )
{
	bool isSuccess = dequeue( value );
	if( !isSuccess )	
		return false;
	enqueue( value );
	return true;
}

ostream & operator << ( ostream & left , Drum & right )
{
	Drum::Enqueued * pCur;
	pCur = right.pHead;				
	while( pCur )					
	{
		left <<setw(4) <<pCur->value <<' ';	
		pCur = pCur->pNext;						
	}
	return left;
}

char Drum::getChar()
{
return pHead->value;
}

void Drum::show()
{
	gotoxy(xpos,ypos);
	cout<<pTail->value;
	
	gotoxy(xpos,ypos+3);
	cout<<getChar();
	
	gotoxy(xpos,ypos+6);
	cout<<pHead->pNext->value<<endl;
}

void Drum::gotoxy(int xpos, int ypos)
{
	COORD scrn;
	HANDLE hOuput = GetStdHandle(STD_OUTPUT_HANDLE);
	scrn.X = xpos; 
	scrn.Y = ypos;
	SetConsoleCursorPosition(hOuput,scrn);
}