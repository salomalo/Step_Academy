#include "QueuePrior.h"

QueuePrior::QueuePrior( int size )
	: size( size ), idxTail( -1 ) //, arr( new Enqueued [ size ] )
{
	arr = new Enqueued [ size ];
}



QueuePrior::~QueuePrior()
{
	delete [] arr;
}



// конструктор копій викликається при передчі об'єкта у функцію
// і при поверненні об'єкта з функції
QueuePrior::QueuePrior( QueuePrior & oSrc )
	: size( oSrc.size ), idxTail( oSrc.idxTail )
{
	arr = new Enqueued [ size ];			// виділяємо нову пам'ять для нового об'єкта
	for( int i = 0; i <= idxTail ; i++ )	// цикл від голови (0) до хвоста (idxTail)
		this->arr[i] = oSrc.arr[i];			// копіюємо елементи з oSrc у this
}




bool QueuePrior::enqueue( int value, int priority )
{
	cout <<"\nenqueue( " <<value <<", " <<priority <<") :\n";
	// перевіримо, чи є у черзі місце
	if( idxTail + 1 == size )
		return false;

	// а тепер треба знайти, куди вставити -- перший елемент з нижчим пріоритетом і вставити перед ним
	int idxInsert = -1;		// індекс куди вставляємо
	
	for( int i = 0 ; i <= idxTail ; i++ )	// переглядаємо з голови до хвоста
	{
		if( arr[i].prior < priority )	// якщо знайшли перший елемент з меншим пріоритетом
		{
			idxInsert = i;				// то вставимо на його місце, посунувши його до хвоста
			break;						// далі шукати не будемо ! далі -- тільки нижчі пріоритети
		}
	} // кінець цикла пошуку меншого пріоритету
	// у цьому місці idxInsert містить індекс, куди треба всталяти
	// або -1, якщо треба вставити у кінець черги

	if( idxInsert < 0 )	// отже, вставляємо в кінець черги
	{
		idxTail++;							// хвіст посунеться
		arr[ idxTail ].value = value;
		arr[ idxTail ].prior = priority;
		return true;						// Виконано !
	}

	// idxInsert >= 0, отже, вставляємо всередину черги

	// спочатку зсунемо до хвоста елементи починаючи з idxInsert до кінця 
	for( int i = idxTail ; i >= idxInsert ; i-- )	// зсуваємо в напрямку хвоста черги
		arr[ i+1 ] = arr[ i ];
	idxTail++;


	// тепер можна вставити нове значення, бо idxInsert вільний
	arr[ idxInsert ].prior = priority;
	arr[ idxInsert ].value = value;

	return true;	// Виконано !

}



bool QueuePrior::enqueue_NoPr( int value, int priority )
{
	cout <<"\enqueue_NoPr( " <<value <<", " <<priority <<") :\n";
	// перевіримо, чи є у черзі місце
	if( idxTail + 1 == size )
		return false;

	idxTail++;							// хвіст посунеться
	arr[ idxTail ].value = value;
	arr[ idxTail ].prior = priority;
	return true;
}



ostream & operator << ( ostream & left, const QueuePrior & right )
{
	for( int i = 0 ; i <= right.idxTail ; i++ )
		left << right.arr[i].value <<" (" <<right.arr[i].prior <<")   ";

	return left;
}



bool QueuePrior::dequeue( int & value, int & priority )
{
	//cout <<"\dequeue( " <<value <<", " <<priority <<") :\n";
	// перевіримо, чи є у черзі місце
	if( idxTail < 0 )
		return false;

	int priorMax = arr[0].prior ;		// припустимо, що це -- макс.пріоритет
	int idxMaxPr = 0;

	for( int i = 1 ; i <= idxTail ; i++ )
	{
		if( arr[i].prior > priorMax )	// якщо вдалося наштовхнутись на ел-т з більшим пріоритетом
		{
			idxMaxPr = i;				// запам'ятаємо цей елемент
			priorMax = arr[i].prior;	// і його пріоритет
		}
	}

	value		= arr[ idxMaxPr ].value;
	priority	= arr[ idxMaxPr ].prior;

	// зсунемо елементи в напрямку до голови і зменшимо чергу
	for( int i = idxMaxPr + 1 ; i <= idxTail ; i++ )
	{
		arr[i-1] = arr[i];
	}
	idxTail--;

	return true;
}




