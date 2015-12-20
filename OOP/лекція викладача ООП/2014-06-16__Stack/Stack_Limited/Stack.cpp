#include "Stack.h"

Stack::Stack( int size )
	: quantity(0), size( size )
{
	arr = new int [ this->size ];
}



Stack::~Stack()
{
	delete [] arr;
}



Stack::Stack( Stack & oSrc )
	: quantity( oSrc.quantity ), size( oSrc.size )
{
	this->arr = new int [ this->size ];
	for( int i = 0; i < this->quantity ; i++ )
	{
		arr[i] = oSrc.arr[i];
	}

}



Stack & Stack::operator = ( Stack & oSrc )
{
	delete [] this->arr;	// лівий операнд уже мав виділену пам'ять, тому мусимо її звільнити, раз вона нам більше не потрібна

	// глибоко копіюємо стек
	this->size = oSrc.size;
	this->quantity = oSrc.quantity;
	this->arr = new int [ this->size ];
	for( int i = 0; i < this->quantity ; i++ )
	{
		this->arr[i] = oSrc.arr[i];
	}
	return *this;
}


// "запихає" value у стек
bool Stack::push( int value )
{
	if( quantity == size )
		return false;

	arr[ quantity ] = value;
	quantity++;
	return true;
}



// з вершини стеку забирає значення і "кладе його у value  
bool Stack::pop( int & value )
{
	if( quantity == 0 )
		return false;

	--quantity;
	value = arr[ quantity ];
	return true;
}




ostream & operator << ( ostream & left, const Stack & oStack )
{
	cout <<oStack.quantity <<" of " <<oStack.size <<" :   ";
	for( int i = 0 ; i < oStack.quantity ; i++ )
	{
		left <<oStack.arr[i] <<' ';
	}
	return left;
}

