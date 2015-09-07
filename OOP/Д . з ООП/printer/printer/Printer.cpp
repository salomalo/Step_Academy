#include "Printer.h"

Printer::Printer( int size )
	: size( size ), idxTail( -1 ) //, arr( new Enqueued [ size ] )
{
	arr = new Enqueued [ size ];
	//histArr= new Enqueued [ size ];
}

Printer::~Printer()
{
	delete [] arr;
}

Printer::Printer( Printer & oSrc )
	: size( oSrc.size ), idxTail( oSrc.idxTail )
{
	arr = new Enqueued [ size ];			// виділяємо нову пам'ять для нового об'єкта
	for( int i = 0; i <= idxTail ; i++ )	// цикл від голови (0) до хвоста (idxTail)
		this->arr[i] = oSrc.arr[i];			// копіюємо елементи з oSrc у this
}

bool Printer::enqueue(const char*value, int priority )
{
	if( idxTail + 1 == size )
		return false;

	int idxInsert = -1;		// індекс куди вставляємо
	
	for( int i = 0 ; i <= idxTail ; i++ )	// переглядаємо з голови до хвоста
	{
		if( arr[i].prior < priority )	// якщо знайшли перший елемент з меншим пріоритетом
		{
			idxInsert = i;				// то вставимо на його місце, посунувши його до хвоста
			break;						// далі шукати не будемо ! далі -- тільки нижчі пріоритети
		}
	} 

	if( idxInsert < 0 )	// отже, вставляємо в кінець черги
	{
		idxTail++;							// хвіст посунеться
		strcpy(arr[ idxTail ].document,value);
		arr[ idxTail ].prior = priority;
		return true;						// Виконано !
	}

	// спочатку зсунемо до хвоста елементи починаючи з idxInsert до кінця 
	for( int i = idxTail ; i >= idxInsert ; i-- )	// зсуваємо в напрямку хвоста черги
		arr[ i+1 ] = arr[ i ];
	idxTail++;

	arr[ idxInsert ].prior = priority;
	strcpy(arr[ idxInsert ].document,value);
	return true;	// Виконано !
}

ostream & operator << ( ostream & left, const Printer & right )
{
	for( int i = 0; i <= right.idxTail; i++ )
		left << right.arr[i].document <<" (" <<right.arr[i].prior <<")   "<<endl;
	return left;
}

bool Printer::dequeue( char* value, int &priority)
{
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
	strcpy(value,arr[ idxMaxPr ].document);
	priority	= arr[ idxMaxPr ].prior;
	// зсунемо елементи в напрямку до голови і зменшимо чергу
	for( int i = idxMaxPr + 1 ; i <= idxTail ; i++ )
	{
		arr[i-1] = arr[i];
	}
	idxTail--;
	return true;
}

//void Printer::enqueueHistory(char* value)
//{
//
//
//}