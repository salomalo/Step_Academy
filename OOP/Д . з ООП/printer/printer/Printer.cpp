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
	arr = new Enqueued [ size ];			// �������� ���� ���'��� ��� ������ ��'����
	for( int i = 0; i <= idxTail ; i++ )	// ���� �� ������ (0) �� ������ (idxTail)
		this->arr[i] = oSrc.arr[i];			// ������� �������� � oSrc � this
}

bool Printer::enqueue(const char*value, int priority )
{
	if( idxTail + 1 == size )
		return false;

	int idxInsert = -1;		// ������ ���� ����������
	
	for( int i = 0 ; i <= idxTail ; i++ )	// ����������� � ������ �� ������
	{
		if( arr[i].prior < priority )	// ���� ������� ������ ������� � ������ ����������
		{
			idxInsert = i;				// �� �������� �� ���� ����, ��������� ���� �� ������
			break;						// ��� ������ �� ������ ! ��� -- ����� ����� ���������
		}
	} 

	if( idxInsert < 0 )	// ����, ���������� � ����� �����
	{
		idxTail++;							// ���� ����������
		strcpy(arr[ idxTail ].document,value);
		arr[ idxTail ].prior = priority;
		return true;						// �������� !
	}

	// �������� ������� �� ������ �������� ��������� � idxInsert �� ���� 
	for( int i = idxTail ; i >= idxInsert ; i-- )	// ������� � �������� ������ �����
		arr[ i+1 ] = arr[ i ];
	idxTail++;

	arr[ idxInsert ].prior = priority;
	strcpy(arr[ idxInsert ].document,value);
	return true;	// �������� !
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
	strcpy(value,arr[ idxMaxPr ].document);
	priority	= arr[ idxMaxPr ].prior;
	// ������� �������� � �������� �� ������ � �������� �����
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