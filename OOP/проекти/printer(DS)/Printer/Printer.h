#include<iostream>
#include<Windows.h>
#include<ctime>
using namespace std;


class Printer
{

public:
	explicit Printer( int size );				
	Printer( Printer & oSrc );
	~Printer();									
	bool enqueue(const char* value, int priority );		
	bool dequeue(char*num );
	friend ostream & operator << ( ostream & left, const Printer & right );

private:
	struct Enqueued		
	{	
		char value[128];		
		int prior;		

	}; 

	Enqueued	*arr;		
	int			 size;
	int			 idxTail;
						

};