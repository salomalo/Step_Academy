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



// ����������� ���� ����������� ��� ������� ��'���� � �������
// � ��� ��������� ��'���� � �������
QueuePrior::QueuePrior( QueuePrior & oSrc )
	: size( oSrc.size ), idxTail( oSrc.idxTail )
{
	arr = new Enqueued [ size ];			// �������� ���� ���'��� ��� ������ ��'����
	for( int i = 0; i <= idxTail ; i++ )	// ���� �� ������ (0) �� ������ (idxTail)
		this->arr[i] = oSrc.arr[i];			// ������� �������� � oSrc � this
}




bool QueuePrior::enqueue( int value, int priority )
{
	cout <<"\nenqueue( " <<value <<", " <<priority <<") :\n";
	// ���������, �� � � ���� ����
	if( idxTail + 1 == size )
		return false;

	// � ����� ����� ������, ���� �������� -- ������ ������� � ������ ���������� � �������� ����� ���
	int idxInsert = -1;		// ������ ���� ����������
	
	for( int i = 0 ; i <= idxTail ; i++ )	// ����������� � ������ �� ������
	{
		if( arr[i].prior < priority )	// ���� ������� ������ ������� � ������ ����������
		{
			idxInsert = i;				// �� �������� �� ���� ����, ��������� ���� �� ������
			break;						// ��� ������ �� ������ ! ��� -- ����� ����� ���������
		}
	} // ����� ����� ������ ������� ���������
	// � ����� ���� idxInsert ������ ������, ���� ����� ��������
	// ��� -1, ���� ����� �������� � ����� �����

	if( idxInsert < 0 )	// ����, ���������� � ����� �����
	{
		idxTail++;							// ���� ����������
		arr[ idxTail ].value = value;
		arr[ idxTail ].prior = priority;
		return true;						// �������� !
	}

	// idxInsert >= 0, ����, ���������� ��������� �����

	// �������� ������� �� ������ �������� ��������� � idxInsert �� ���� 
	for( int i = idxTail ; i >= idxInsert ; i-- )	// ������� � �������� ������ �����
		arr[ i+1 ] = arr[ i ];
	idxTail++;


	// ����� ����� �������� ���� ��������, �� idxInsert ������
	arr[ idxInsert ].prior = priority;
	arr[ idxInsert ].value = value;

	return true;	// �������� !

}



bool QueuePrior::enqueue_NoPr( int value, int priority )
{
	cout <<"\enqueue_NoPr( " <<value <<", " <<priority <<") :\n";
	// ���������, �� � � ���� ����
	if( idxTail + 1 == size )
		return false;

	idxTail++;							// ���� ����������
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
	// ���������, �� � � ���� ����
	if( idxTail < 0 )
		return false;

	int priorMax = arr[0].prior ;		// ����������, �� �� -- ����.��������
	int idxMaxPr = 0;

	for( int i = 1 ; i <= idxTail ; i++ )
	{
		if( arr[i].prior > priorMax )	// ���� ������� ������������� �� ��-� � ������ ����������
		{
			idxMaxPr = i;				// �����'����� ��� �������
			priorMax = arr[i].prior;	// � ���� ��������
		}
	}

	value		= arr[ idxMaxPr ].value;
	priority	= arr[ idxMaxPr ].prior;

	// ������� �������� � �������� �� ������ � �������� �����
	for( int i = idxMaxPr + 1 ; i <= idxTail ; i++ )
	{
		arr[i-1] = arr[i];
	}
	idxTail--;

	return true;
}




