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

	bool addHead( int val );			// додає val у голову списку (першим   елементом)
	bool addTail( int val );			// додає val у хвіст  списку (останнім елементом)
	bool insert(  int val, int idxIns );// вставляє val всередину списку по індексу idxIns

	bool remHead( int & val );		// забирає з першого    елемента і кладе у val
	bool remTail( int & val );		// забирає з останнього елемента і кладе у val
	bool remove(  int & val, int idxRem );// вилучає val з середини списку по індексу idxRem


	void clear();					// очищує список


	friend ostream & operator << ( ostream & oLeft , List & oRight );

	List & operator = ( List & oRight );


private:
	Node * pHead;	// на перший   елемент списку 
	Node * pTail;	// на останній елемент списку 

	void   copy( List & oSrc );		// сервісний метод, котрий копіює з oSrc у this
	Node * getPtrByIdx( int idx );	// шукає ноду по індексу, і повертає вказівник на неї, або nullptr

}; // class List