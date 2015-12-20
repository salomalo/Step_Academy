#include <iostream>
using namespace std;


template <typename TYPE>	// у шаблонного класу -- кожен метод також шаблонний !!!!
class Queue
{

public:
	explicit Queue( int size );

	~Queue<TYPE>()
	{ delete [] arr; }

	// конструнструктор копій і оператор присвоєння зараз несуттєво, але ПОТРІБНО

	bool enqueue( TYPE   value );	// ставить value у хвіст черги 
	bool dequeue( TYPE & value );	// забирає з голови черги значення у value


	// дружня ф-я НЕ Є ЧЛЕНОМ КЛАСУ !!!!!
	template < typename TYPE >		// тому ми явно вказуємо, що вона шаблонна ( бо "шаблонність" класу поширується ЛИШЕ НА Ф-Ї -- ЧЛЕНИ КЛАСУ ( лише на методи)
	friend ostream & operator << ( ostream & oLeft , Queue<TYPE> & oRight );


private:
	TYPE	*arr;		// масив, у якому черга
	int		 idxTail;	// індекс останнього елемента у черзі ( -1 -- черга пуста )
	int		 size;		// розмір (місткість) черги

};



///////////////////////////////////////////////////////////////////////////////////////////////////////
//
// реалізація шаблонних ф-й (в т.ч. методів класу) повинна бути в одному файлі з їх оголошенням ( тобто, у *.h )
//
/////////////////////////////////////////////////////////////////////////////



template <typename TYPE>
Queue<TYPE>::Queue( int size )
	: idxTail(-1), size(size)
{
	arr = new TYPE [size];
}

//----------------------------- виносимо реалізацію всередину класв
//template <typename TYPE>
//Queue::~Queue()
//{
//	delete [] arr;
//}


// ставить value у хвіст черги 
template <typename TYPE>
bool Queue<TYPE>::enqueue( TYPE   value )
{
	if( idxTail + 1 == size )
		return false;

	arr[ ++idxTail ] = value;
	return true;
}


// забирає з голови черги значення у value
template <typename TYPE>
bool Queue<TYPE>::dequeue( TYPE & value )
{
	if( idxTail < 0 )
		return false;

	value = arr[0];

	for( int i = 0 ; i < idxTail ; i++ )
		arr[i] = arr[ i+1 ];

	idxTail--;
	return true;
}



// дружня ф-я НЕ Є ЧЛЕНОМ КЛАСУ !!!!!
template < typename TYPE >		// тому ми явно вказуємо, що вона шаблонна ( бо "шаблонність" класу поширується ЛИШЕ НА Ф-Ї -- ЧЛЕНИ КЛАСУ ( лише на методи)
ostream & operator << ( ostream & oLeft , Queue<TYPE> & oRight )
{
	for( int i = 0 ; i <= oRight.idxTail ; i++ )
		oLeft << oRight.arr[i] <<' ';

	return oLeft;
}


