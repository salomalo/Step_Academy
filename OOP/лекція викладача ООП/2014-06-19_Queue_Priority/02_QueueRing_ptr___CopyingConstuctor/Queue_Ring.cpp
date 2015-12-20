#include "Queue_Ring.h"



Queue_Ring::Queue_Ring()
	: pHead( nullptr ), pTail( nullptr )
{}



Queue_Ring::~Queue_Ring()
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
bool Queue_Ring::enqueue( int   value )
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
bool Queue_Ring::dequeue( int & value )
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





bool Queue_Ring::dequeueRing( int & value )
{
	bool isSuccess = dequeue( value );

	if( !isSuccess )	// черга була пустою -- це біда
		return false;

	// якщо черга була не пустою -- то треба поставити це значення у хвіст
	enqueue( value );
	return true;

}



ostream & operator << ( ostream & left , Queue_Ring & right )
{
	Queue_Ring::Enqueued * pCur;	// цей вказівник вказує на елемент, котрий будемо виводити
	pCur = right.pHead;				// починаємо з голови черги
	while( pCur )					// поки маємо що виводити
	{
		left <<setw(4) <<pCur->value <<' ';		// виводимо
		pCur = pCur->pNext;						// і переходимо до наступного елемнта черги
	}

	return left;
}




Queue_Ring::Queue_Ring( Queue_Ring & oSrc )
	: pHead(0), pTail(0)
{
	Enqueued * pCur = oSrc.pHead;	// починаємо з голови
	while( pCur )
	{
		this->enqueue( pCur->value );	// додаємо елемент у чергу-копію
		pCur = pCur->pNext;				// Беремо наступний
	}
}



