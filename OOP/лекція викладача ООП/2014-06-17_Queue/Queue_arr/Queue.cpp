#include "Queue.h"



Queue::Queue( int size )
	: idxTail(-1), size(size)
{
	arr = new int [size];
}



Queue::~Queue()
{
	delete [] arr;
}


// ставить value у хвіст черги 
bool Queue::enqueue( int   value )
{
	if( idxTail + 1 == size )
		return false;

	arr[ ++idxTail ] = value;
	return true;
}


// забирає з голови черги значення у value
bool Queue::dequeue( int & value )
{
	if( idxTail < 0 )
		return false;

	value = arr[0];

	for( int i = 0 ; i < idxTail ; i++ )
		arr[i] = arr[ i+1 ];

	idxTail--;
	return true;
}

