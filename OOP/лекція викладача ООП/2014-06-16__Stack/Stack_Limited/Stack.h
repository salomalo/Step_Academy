#pragma once

#include <iostream>
using namespace std;

class Stack
{

public:
	explicit Stack( int size );
	Stack( Stack & oSrc );
	~Stack();

	Stack & operator = ( Stack & oSrc );

	bool push( int   value );
	bool pop(  int & value  );

	friend ostream & operator << ( ostream & left, const Stack & oStack );

private:
	int	 quantity;
	int	 size;
	int	*arr;

};