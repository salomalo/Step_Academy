#include "Queue_Ring.h"



Queue_Ring::Queue_Ring( int size )
	: idxTail(-1), size(size)
{
	arr = new int [size];
}



Queue_Ring::~Queue_Ring()
{
	delete [] arr;
}


ostream & operator << ( ostream & left , Queue_Ring & right )
{
	for( int i = 0 ; i <= right.idxTail ; i ++ )
		left <<setw(4) <<right.arr[i] <<' ';

	return left;
}



// ставить value у хвіст черги 
bool Queue_Ring::enqueue( int   value )
{
	if( idxTail + 1 == size )
		return false;

	arr[ ++idxTail ] = value;
	return true;
}


// забирає з голови черги значення у value
bool Queue_Ring::dequeue( int & value )
{
	if( idxTail < 0 )
		return false;

	value = arr[0];

	for( int i = 0 ; i < idxTail ; i++ )
		arr[i] = arr[ i+1 ];

	idxTail--;
	return true;
}




bool Queue_Ring::dequeueRing( int & value )
{
	bool isSuccess = dequeue( value );

	if( !isSuccess )	// черга була пустою -- це біда
		return false;

	// якщо черга була не пустою -- то треба поставити це значення у хвіст
	enqueue( value );
	return true;

}

