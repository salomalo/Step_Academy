#include "CInt.h"


CInt CInt::operator + ( int right )
{
	CInt res( this->value + right );
	return res;
	//return this->value + right.value;
}


CInt operator + ( int left, CInt right )
{
	return CInt( left + right.getValue() );
}


CInt operator - ( int left, CInt right )
{
	return CInt( left - right.value );
}


CInt CInt::operator = ( double right )
{
	this->value = right - 3;
	return *this;
}


CInt CInt::operator = ( CInt right )
{
	this->value = right.value - 3;
	return *this;
}


CInt CInt::operator ++ ()
{
	value++;
	value++;
	value++;
	return *this;
}


CInt CInt::operator ++ ( int ignore ) // int ignore -- просто ознака постфіксної форми
{
	value++;
	return *this;
}




