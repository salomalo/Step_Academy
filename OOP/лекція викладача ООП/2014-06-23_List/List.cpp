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
	// перебираємо елементи oSrc, починаючи з голови
	Node * pCur = oSrc.pHead;			// починаємо з голови
	while( pCur )
	{
		this->addTail( pCur->value );	// до this додаємо чергове значення
		pCur = pCur->pNext;				// переходимо до наступного елемента списку-оригіналу
	}
}





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






