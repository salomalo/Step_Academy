#pragma once

#include "Node.h"
#include <iostream>
using namespace std;

class Stack
{

public:
	explicit Stack();
	Stack( Stack & oSrc );
	~Stack();


	bool push( int   value );
	bool pop(  int & value  );

	friend ostream & operator << ( ostream & left, const Stack & oStack );

private:
	Stack & operator = ( Stack & oSrc );


private:
	int		 quantity;	// поточна к-ть елементів у стеку
	Node	*pTop;		// вказівник на вузол, котрий на вершині стеку

};