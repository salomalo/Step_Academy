#include "Queue.h"



Queue::Queue()
	: pHead( nullptr ), pTail( nullptr )
{}



Queue::~Queue()
{
	Enqueued * pDel  = pHead;		// видалення починаємо з голови

	while( pDel )	// якщо є кого видаляти
	{
		Enqueued * pNext = pDel->pNext;	// зберігаємо адрусу наступного, щоб не втратити
		delete pDel;					// видалаємо елемент по вказівнику pDel
		pDel = pNext;					// готуємось видалити наступний
	}
}


// ставить value у хвіст черги 
bool Queue::enqueue( int   value )
{
	Enqueued * pNew = new Enqueued;
	if( !pNew )
		return false;

	pNew->pNext = nullptr;	// за новою ніхто не займав чергу
	pNew->value = value;

	if( pTail == nullptr )
	{
		pHead = pNew;
	}
	else
	{
		pTail->pNext = pNew;	// кажемо останньому "я за вами"
	}
	pTail = pNew;			// кажему усім "я -- крайній"

	return true;
}


// забирає з голови черги значення у value
bool Queue::dequeue( int & value )
{
	if( pHead == nullptr )
		return false;

	value = pHead->value;		// виводимо значення елемента, що у голові черги
	Enqueued * pDel = pHead;	// перший -- на вихід !!!
	pHead = pHead->pNext;		// тепер першим буде наступний
	if( pHead == nullptr )
		pTail = nullptr;		// якщо видаляється останній -- то черга спорожнюється

	delete pDel;				// позбавляємось зайвого

	return true;
}

