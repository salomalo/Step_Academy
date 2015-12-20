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


CInt CInt::operator += ( CInt right )
{
	this->value += right.value ;
	return *this;
}


CInt operator - ( int left, CInt right )
{
	return CInt( left - right.value );
}


CInt CInt::operator = ( double right )
{
	this->value = right;
	return *this;
}


CInt CInt::operator = ( CInt right )
{
	this->value = right.value;
	return *this;
}


CInt CInt::operator ++ ()
{
	value++;
	value++;
	value++;
	return *this;
}


CInt CInt::operator ++ ( int ignore ) // int ignore -- ������ ������ ���������� �����
{
	value++;
	return *this;
}




