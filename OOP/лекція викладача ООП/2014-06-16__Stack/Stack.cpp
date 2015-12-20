#include "Stack.h"

Stack::Stack()
	: quantity(0), pTop(0)		// створюється пустий стек
{}



Stack::~Stack()
{
	delete pTop;
}



Stack::Stack( Stack & oSrc )
	: quantity( oSrc.quantity ), pTop(0)
{
	if( quantity == 0 )
		return;

	// послідовно обходимо усі вузли oSrc
	Node * pCurNode = oSrc.pTop;	// починаємо з верхнього вузла
	while( pCurNode->getPrev() )	// якщо поточний вузол має попередника - ідемо далі
	{

		pCurNode = pCurNode->getPrev();		// поточною стає попередня нода -- ідемо вглиб стеку
	}
}



Stack & Stack::operator = ( Stack & oSrc )
{
	//delete [] this->arr;	// лівий операнд уже мав виділену пам'ять, тому мусимо її звільнити, раз вона нам більше не потрібна

	//// глибоко копіюємо стек
	//this->size = oSrc.size;
	//this->quantity = oSrc.quantity;
	//this->arr = new int [ this->size ];
	//for( int i = 0; i < this->quantity ; i++ )
	//{
	//	this->arr[i] = oSrc.arr[i];
	//}
	return *this;
}


// "запихає" value у стек
bool Stack::push( int value )
{
	Node * pNewNode = new Node( value, pTop );
	if( ! pNewNode )
		return false;

	pTop = pNewNode;
	quantity++;
	return true;
}



// з вершини стеку забирає значення і "кладе його у value  
bool Stack::pop( int & value )
{
	if( quantity == 0 )
		return false;

	--quantity;
	value = pTop->getValue();
	Node * pNodeForDelete = pTop;
	pTop = pNodeForDelete->getPrev();	// верхньою буде попередня нода
	pNodeForDelete->setPrev( 0 );		// оця нода уже ні на що не вказує, і її можна видаляти
	delete pNodeForDelete;
	return true;
}



// виводить усі ноди через пропуск
ostream & operator << ( ostream & left, const Stack & oStack )
{
	cout <<oStack.quantity <<" :   ";
	Node * pCurNode = oStack.pTop;		// нода, котру виведемо зараз
	while( pCurNode )
	{
		left <<pCurNode->getValue() <<' ';
		pCurNode = pCurNode->getPrev();		// на наступному проході -- виведемо попередню (якщо є)
	}
	return left;
}

