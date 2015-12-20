#include "Stack.h"

Stack::Stack()
	: quantity(0), pTop(0)		// ����������� ������ ����
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

	// ��������� �������� �� ����� oSrc
	Node * pCurNode = oSrc.pTop;	// �������� � ��������� �����
	while( pCurNode->getPrev() )	// ���� �������� ����� �� ����������� - ����� ���
	{

		pCurNode = pCurNode->getPrev();		// �������� ��� ��������� ���� -- ����� ����� �����
	}
}



Stack & Stack::operator = ( Stack & oSrc )
{
	//delete [] this->arr;	// ���� ������� ��� ��� ������� ���'���, ���� ������ �� ��������, ��� ���� ��� ����� �� �������

	//// ������� ������� ����
	//this->size = oSrc.size;
	//this->quantity = oSrc.quantity;
	//this->arr = new int [ this->size ];
	//for( int i = 0; i < this->quantity ; i++ )
	//{
	//	this->arr[i] = oSrc.arr[i];
	//}
	return *this;
}


// "������" value � ����
bool Stack::push( int value )
{
	Node * pNewNode = new Node( value, pTop );
	if( ! pNewNode )
		return false;

	pTop = pNewNode;
	quantity++;
	return true;
}



// � ������� ����� ������ �������� � "����� ���� � value  
bool Stack::pop( int & value )
{
	if( quantity == 0 )
		return false;

	--quantity;
	value = pTop->getValue();
	Node * pNodeForDelete = pTop;
	pTop = pNodeForDelete->getPrev();	// �������� ���� ��������� ����
	pNodeForDelete->setPrev( 0 );		// ��� ���� ��� � �� �� �� �����, � �� ����� ��������
	delete pNodeForDelete;
	return true;
}



// �������� �� ���� ����� �������
ostream & operator << ( ostream & left, const Stack & oStack )
{
	cout <<oStack.quantity <<" :   ";
	Node * pCurNode = oStack.pTop;		// ����, ����� �������� �����
	while( pCurNode )
	{
		left <<pCurNode->getValue() <<' ';
		pCurNode = pCurNode->getPrev();		// �� ���������� ������ -- �������� ��������� (���� �)
	}
	return left;
}

