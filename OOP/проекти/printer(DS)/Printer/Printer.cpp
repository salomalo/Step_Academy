#include "Printer.h"

Printer::Printer( int size )
	: size( size ), idxTail( -1 ) 
{
	arr = new Enqueued [ size ];
}



Printer::~Printer()
{
	delete [] arr;
}

Printer::Printer( Printer & oSrc )
	: size( oSrc.size ), idxTail( oSrc.idxTail )
{
	arr = new Enqueued [ size ];			
	for( int i = 0; i <= idxTail ; i++ )	
		this->arr[i] = oSrc.arr[i];			
}




bool Printer::enqueue(const char* value, int priority )
{
	
	
	if( idxTail + 1 == size )
		return false;

	
	int idxInsert = -1;
	
	for( int i = 0 ; i <= idxTail ; i++ )	
	{
		if( arr[i].prior < priority )	
		{
			idxInsert = i;				
			break;						
		}
	} 

	if( idxInsert < 0 )
	{
		idxTail++;							
		strcpy(arr[ idxTail ].value,value);
		arr[ idxTail ].prior = priority;
		return true;						
	}

	
	for( int i = idxTail ; i >= idxInsert ; i-- )	
		arr[ i+1 ] = arr[ i ];
	idxTail++;


	
	arr[ idxInsert ].prior = priority;
	strcpy(arr[ idxInsert ].value,value);

	return true;	

}

bool Printer::dequeue( char* temp )
{
	
	
	if( idxTail < 0 )
		return false;

	strcpy(temp,arr[0].value);

	for( int i = 0 ; i < idxTail ; i++ )
	{
	
		arr[i] = arr[ i+1 ];
	}

	idxTail--;
	return true;
}
ostream & operator << ( ostream & left, const Printer & right )
{
	for( int i = 0 ; i <= right.idxTail ; i++ )
	{
		if(i % 3 == 0)
			cout<<endl;
		left <<"  Document:"<<i+1<<' '<<"\""<<right.arr[i].value <<" (" <<right.arr[i].prior <<")"<<"\"";
	}

	return left;
}
