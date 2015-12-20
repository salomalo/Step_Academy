#include "List.h"

List::List()	// ������� ������ ������
	: pHead( nullptr ), pTail( nullptr )
{}


List::~List()
{
	cout <<" \n Destructor for pHead=" <<(int)pHead <<endl;
	clear();
}



List::List( List & oSrc )
	: pHead( nullptr ), pTail( nullptr )	// ������ this �������� ������
{
	this->copy( oSrc );
}



void List::copy( List & oSrc )
{
	// ���������� �������� oSrc, ��������� � ������
	Node * pCur = oSrc.pHead;			// �������� � ������
	while( pCur )
	{
		this->addTail( pCur->value );	// �� this ������ ������� ��������
		pCur = pCur->pNext;				// ���������� �� ���������� �������� ������-��������
	}
}// void List::copy( List & oSrc )




bool List::addTail( int val )	// ���� val � ���� ������ (������� ���������)
{
	Node * pNew = new Node;
	if( !pNew )			// ���� �� ������� ���'��
		return false;

	pNew->value = val;			// �������� � �� ��������
	pNew->pNext = nullptr;		// ���� ���� ������� (� �����)

	if( !pTail )	// ���� ������ ��� ������
	{
		// ���� ���� - ��� ������ ����� ������, ��������� ������� � �������
		pTail = pNew;	
		pHead = pNew;	
	}
	else
	{
		pTail->pNext = pNew;		// ���� ��� ����� �� ���, �� ���� ���������
		pTail = pNew;				// ���� ��� ���������, �� �� ���������� pTail
	}
	return true;
}





ostream & operator << ( ostream & oLeft , List & oRight )
{	
	cout <<"pHead=" <<(int)oRight.pHead <<"  ";				// �������� ������ ���'��
	List::Node * pCur = oRight.pHead;
	while( pCur )	// ���� pCur ������ ������ �������� (�� null )
	{
		oLeft << pCur->value <<' ';
		pCur = pCur->pNext;		// ��� �������� ��������� ������� ������
	}

	return oLeft;
}



bool List::addHead( int val )		// ���� val � ������ ������ (������   ���������)
{
	Node * pNew = new Node;
	if( !pNew )
		return false;

	pNew->value = val;		// ��������
	pNew->pNext = pHead;	// ���� ���� ��� ����� ��, �� ���� ������

	if( ! pHead )	// ���� ��� ������ ������
	{
		// ���� ���� ���� � � �����, � � �����
		//pHead = pNew;
		pTail = pNew;
	}

	pHead = pNew;			// ���� ���� ����� ������

	return true;
}


bool List::remHead( int & val )
{
	if( ! pHead )		// ���� ������ ������� ...
		return false;

	if( pHead == pTail )	// ���� ������ ��� � ������ ��������
	{
		// ��������� ������ �������
		val = pTail->value;
		delete pTail;
		pTail = nullptr;
		pHead = nullptr;
		return true;
	}


	Node * pDel = pHead;	// ��� �� ����� ��������� ��������
	val = pHead->value;		// �������� ����
	pHead = pHead->pNext;	// ������� ����� ��������� �������

	delete pDel;			// ��������� ���� ���������

	return true;
}



bool List::remTail( int & val )		// ������ � ���������� �������� � ����� � val
{
	if( ! pTail )		// ���� ������ ������� ...
		return false;


	if( pHead == pTail )	// ���� ������ ��� � ������ ��������
	{
		// ��������� ������ �������
		val = pTail->value;
		delete pTail;
		pTail = nullptr;
		pHead = nullptr;
		return true;
	}


	// ������ ����������Ͳ� �������
	Node * pPrev = pHead;	// �������� � ������
	while( pPrev->pNext != pTail )	// ���� �� ������ �� ���������������
	{
		pPrev = pPrev->pNext;	// ���������� �� �������
	}
	// � ����� ���� pPrev ����� �� ������������ ����

	val = pTail->value;			// ��������� ��������
	delete pTail;				// ��������� ������� ����, ����� ����� ����������
	pPrev->pNext = nullptr;		// ������������ ���� ��� ���������, �����, �� �� ����������
	pTail = pPrev;				// �������� �������� �� �� ������� ����

	return true;
}




void List::clear()					// ����� ������
{
	int tmp;
	while( pHead )
		remHead( tmp );

}




List & List::operator = ( List & oRight )
{
	// ���� �� ���, ����� �������� ���'���, ������� ��� this
	this->clear();

	// ����� ����� ��������� ��������� � oRight � this
	this->copy( oRight );


	return *this;
}



// �������� val ��������� ������ �� ������� idxIns
bool List::insert(  int val, int idxIns )
{
	if( !pHead )
		return false;

	if( idxIns < 0 )
		return false;

	if( idxIns == 0 )
		return addHead( val );

	//// ������ �������, ������ �������� ����� ����������
	//Node * pPrev   = pHead;	// ����� ������� � ������ ������
	//int    idxPrev = 0;		// ������ �� ������ 0
	//while( pPrev && idxPrev < (idxIns-1) )	// ���� ������������ �� ���� ������, ��� ���� �������� �������Ͳ� ������� (� �������� �� 1 ������ idxIns)
	//{
	//	pPrev = pPrev->pNext;	// ���������� �� ����������
	//	idxPrev++;
	//}

	Node * pPrev = getPtrByIdx( idxIns-1 );

	// � ����� ���� pPrev ��� nullptr, ��� ����� �� ��������� ������� (���� ����� ���� ��������)

	if( pPrev == nullptr )
		return false;		// �� ������� ������ �������� ���������

	if( pPrev->pNext == nullptr )	// ���� ���������� �� ������� �������
		return addTail( val );


	// � ����� ���� pPrev ����� �� ��������� ������� (���� ����� ���� ��������)

	Node * pNew = new Node;		// ���� ����
	pNew->value = val;			// �� ��������
	pNew->pNext = pPrev->pNext;	// �� ���� ��� ̲� pPrev � ��������� ���������
	pPrev->pNext= pNew;			// ���� pPrev 

	return true;

}// bool List::insert(  int val, int idxIns )


// ���� ���� �� �������, � ������� �������� �� ��, ��� nullptr
List::Node * List::getPtrByIdx( int idx )
{
	Node * pFound = pHead;
	int idxFound  = 0;
	while( pFound && idxFound < idx )
	{
		pFound = pFound->pNext;
		idxFound++;
	}

	return pFound;
}//List::Node * List::getPtrByIdx( int idx )



// ������ val � �������� ������ �� ������� idxRem
bool List::remove(  int & val, int idxRem )
{
	if( !pHead )
		return false;

	if( idxRem < 0 )
		return false;

	if( idxRem == 0 )
		return remHead( val );

	// ������ ��������� ������� (����� ���, �� ����������)
	Node * pPrev = getPtrByIdx( idxRem - 1 );
	if( !pPrev )
		return false;

	if( pPrev == pTail )		// ���� idxRem ������� ���������� ��������
		return remTail( val );

	// �������� ����
	Node * pDel = pPrev->pNext;		// �������� ����. �� ����, �� �����������
	pPrev->pNext= pDel->pNext;		// ������ "�����" pDel;
	val = pDel->value;				// ��������� ��������
	delete pDel;

	return true;
}// List::remove(  int & val, int idxRem )


