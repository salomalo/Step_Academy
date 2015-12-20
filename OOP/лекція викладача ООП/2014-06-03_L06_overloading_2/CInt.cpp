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


bool CInt::operator < ( CInt & right )
{
	return this->value < right.value;
}


bool CInt::operator < ( const int & right )
{
	return this->value < right;
}


bool CInt::operator < ( const CInt & right )
{
	cout <<" const ";
	return this->value < right.value;
}



bool CInt::operator == ( CInt & right )
{
	return this->value == right.value;
}


bool CInt::operator == ( const int & right )
{
	return this->value == right;
}



// friend не є членом класу -- приймає два параметри
bool operator <  (const int & left, CInt right )
{
	return left < right.value;
}


const char * CInt::operator && ( CInt right )
{
	char aaa[44];
	if( value == right.value  )
		strcpy( aaa, "equal" );
	else
		strcpy( aaa, "not equal" );
//	return aaa; // по завершенні ф-ї aaa перестала існувати і повернений вказівник став недійсним

	return ( value == right.value ? "equal" : "not equal" );
}



CInt::operator int()
{
	return value;
}


CInt::operator char*()
{
	char * res = new char [55];
	sprintf( res, "Value of this CInt is %d. It`s good!", value );
	return res;

}
