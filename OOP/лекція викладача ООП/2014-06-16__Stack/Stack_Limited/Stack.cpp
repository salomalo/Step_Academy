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
	delete [] this->arr;	// ���� ������� ��� ��� ������� ���'���, ���� ������ �� ��������, ��� ���� ��� ����� �� �������

	// ������� ������� ����
	this->size = oSrc.size;
	this->quantity = oSrc.quantity;
	this->arr = new int [ this->size ];
	for( int i = 0; i < this->quantity ; i++ )
	{
		this->arr[i] = oSrc.arr[i];
	}
	return *this;
}


// "������" value � ����
bool Stack::push( int value )
{
	if( quantity == size )
		return false;

	arr[ quantity ] = value;
	quantity++;
	return true;
}



// � ������� ����� ������ �������� � "����� ���� � value  
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

