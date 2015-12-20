#include "List.h"

List::List()	// створює пустий список
	: pHead( nullptr ), pTail( nullptr )
{}


List::~List()
{
	cout <<" \n Destructor for pHead=" <<(int)pHead <<endl;
	clear();
}



List::List( List & oSrc )
	: pHead( nullptr ), pTail( nullptr )	// список this спочатку пустий
{
	this->copy( oSrc );
}



void List::copy( List & oSrc )
{
	// перебираємо елементи oSrc, починаючи з голови
	Node * pCur = oSrc.pHead;			// починаємо з голови
	while( pCur )
	{
		this->addTail( pCur->value );	// до this додаємо чергове значення
		pCur = pCur->pNext;				// переходимо до наступного елемента списку-оригіналу
	}
}// void List::copy( List & oSrc )




bool List::addTail( int val )	// додає val у хвіст списку (останнім елементом)
{
	Node * pNew = new Node;
	if( !pNew )			// якщо не вистачає пам'яті
		return false;

	pNew->value = val;			// зберігаємо у ній значення
	pNew->pNext = nullptr;		// вона буде кінцевою (у хвості)

	if( !pTail )	// якщо список був пустим
	{
		// нова нода - стає єдиною нодою списку, одночасно головою і хвостом
		pTail = pNew;	
		pHead = pNew;	
	}
	else
	{
		pTail->pNext = pNew;		// вона стає слідом за тою, що була останньою
		pTail = pNew;				// вона стає останньою, на неї вказуватим pTail
	}
	return true;
}





ostream & operator << ( ostream & oLeft , List & oRight )
{	
	cout <<"pHead=" <<(int)oRight.pHead <<"  ";				// показуємо адресу пам'яті
	List::Node * pCur = oRight.pHead;
	while( pCur )	// поки pCur містить якийсь вказівник (не null )
	{
		oLeft << pCur->value <<' ';
		pCur = pCur->pNext;		// далі виведемо наступний елемент списку
	}

	return oLeft;
}



bool List::addHead( int val )		// додає val у голову списку (першим   елементом)
{
	Node * pNew = new Node;
	if( !pNew )
		return false;

	pNew->value = val;		// значення
	pNew->pNext = pHead;	// нова нода стає ПЕРЕД тією, що була першою

	if( ! pHead )	// якщо був пустий список
	{
		// нова нода буде і у голові, і у хвості
		//pHead = pNew;
		pTail = pNew;
	}

	pHead = pNew;			// нова нода стала першою

	return true;
}


bool List::remHead( int & val )
{
	if( ! pHead )		// якщо список порожній ...
		return false;

	if( pHead == pTail )	// якщо список був з одного елемента
	{
		// видаляємо ЄДИНИЙ елемент
		val = pTail->value;
		delete pTail;
		pTail = nullptr;
		pHead = nullptr;
		return true;
	}


	Node * pDel = pHead;	// ось по цьому вказівнику видалимо
	val = pHead->value;		// виводимо вміст
	pHead = pHead->pNext;	// головою стане наступний елемент

	delete pDel;			// непотрібну ноду видаляємо

	return true;
}



bool List::remTail( int & val )		// забирає з останнього елемента і кладе у val
{
	if( ! pTail )		// якщо список порожній ...
		return false;


	if( pHead == pTail )	// якщо список був з одного елемента
	{
		// видаляємо ЄДИНИЙ елемент
		val = pTail->value;
		delete pTail;
		pTail = nullptr;
		pHead = nullptr;
		return true;
	}


	// шукаємо ПЕРЕДОСТАННІЙ елемент
	Node * pPrev = pHead;	// починаємо з голови
	while( pPrev->pNext != pTail )	// поки не дійдемо до передостаннього
	{
		pPrev = pPrev->pNext;	// перебираємо по порядку
	}
	// у цьому місці pPrev вказує на передостанню ноду

	val = pTail->value;			// повертаємо значення
	delete pTail;				// видаляємо останню ноду, котра стала непотрібною
	pPrev->pNext = nullptr;		// передостання нода стає останньою, тобто, не має наступника
	pTail = pPrev;				// офіційно реєструємо її як останню ноду

	return true;
}




void List::clear()					// очищує список
{
	int tmp;
	while( pHead )
		remHead( tmp );

}




List & List::operator = ( List & oRight )
{
	// перш за все, треба звільнити пам'ять, виділену для this
	this->clear();

	// тепер треба зкопіювати структуру з oRight у this
	this->copy( oRight );


	return *this;
}



// вставляє val всередину списку по індексу idxIns
bool List::insert(  int val, int idxIns )
{
	if( !pHead )
		return false;

	if( idxIns < 0 )
		return false;

	if( idxIns == 0 )
		return addHead( val );

	//// шукаємо елемент, котрий стоятиме ПЕРЕД вставленим
	//Node * pPrev   = pHead;	// пошук почнемо з голови списку
	//int    idxPrev = 0;		// голова має індекс 0
	//while( pPrev && idxPrev < (idxIns-1) )	// цикл продовжується до кінця списку, або поки надибаємо ПОПЕРЕДНІЙ елемент (з індексом на 1 меншим idxIns)
	//{
	//	pPrev = pPrev->pNext;	// переходимо до наступного
	//	idxPrev++;
	//}

	Node * pPrev = getPtrByIdx( idxIns-1 );

	// у цьому місці pPrev або nullptr, або вказує на попередній елемент (після якого маємо вставити)

	if( pPrev == nullptr )
		return false;		// за хвостом списку вставити неможливо

	if( pPrev->pNext == nullptr )	// якщо вставляємо як останній елемент
		return addTail( val );


	// у цьому місці pPrev вказує на попередній елемент (після якого маємо вставити)

	Node * pNew = new Node;		// нова нода
	pNew->value = val;			// її значення
	pNew->pNext = pPrev->pNext;	// ця нода стає МІЖ pPrev і наступним елементом
	pPrev->pNext= pNew;			// після pPrev 

	return true;

}// bool List::insert(  int val, int idxIns )


// шукає ноду по індексу, і повертає вказівник на неї, або nullptr
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



// вилучає val з середини списку по індексу idxRem
bool List::remove(  int & val, int idxRem )
{
	if( !pHead )
		return false;

	if( idxRem < 0 )
		return false;

	if( idxRem == 0 )
		return remHead( val );

	// шукаємо попередній елемент (перед тим, що видалиться)
	Node * pPrev = getPtrByIdx( idxRem - 1 );
	if( !pPrev )
		return false;

	if( pPrev == pTail )		// якщо idxRem відповідає останньому елементу
		return remTail( val );

	// вилучаємо ноду
	Node * pDel = pPrev->pNext;		// зберігаємо вказ. на ноду, що видаляється
	pPrev->pNext= pDel->pNext;		// список "оминає" pDel;
	val = pDel->value;				// повертаємо значення
	delete pDel;

	return true;
}// List::remove(  int & val, int idxRem )


