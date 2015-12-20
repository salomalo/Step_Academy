#pragma once

#include <iostream>
using namespace std;


class List
{

	struct Node		// приватна, недоступна за межами класу
	{
		int		 value;		// значення, що зберігається у ноді
		Node	*pNext;		// вказівник на наступну ноду у списку
	};


public:

	List();			// створює пустий список
	~List();
	List( List & oSrc );

	bool addHead( int val );		// додає val у голову списку (першим   елементом)
	bool addTail( int val );		// додає val у хвіст  списку (останнім елементом)

	bool remHead( int & val );		// забирає з першого    елемента і кладе у val
	bool remTail( int & val );		// забирає з останнього елемента і кладе у val

	void clear();					// очищує список


	friend ostream & operator << ( ostream & oLeft , List & oRight );



private:
	Node * pHead;	// на перший   елемент списку 
	Node * pTail;	// на останній елемент списку 

}; // class List