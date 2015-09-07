#include <conio.h>
#include <iostream>
#include<Windows.h>
using namespace std;


class Printer
{
public:
	explicit Printer( int size );			
	Printer( Printer & oSrc );				
	~Printer();									
	bool enqueue( const char* value, int priority );
	bool dequeue( char* value, int &priority);	
	friend ostream & operator << ( ostream & left, const Printer & right);
	//void enqueueHistory(char* value);

private:
		struct Enqueued
	{	
		char document[200];	
		int prior;
	}; 

	Enqueued	*arr;		
	int			 size;		
	int			 idxTail;
	//Enqueued	*histArr;

};