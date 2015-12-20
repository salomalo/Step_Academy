#include <iostream>
using namespace std;


template <typename TYPE>	// � ���������� ����� -- ����� ����� ����� ��������� !!!!
class Queue
{

public:
	explicit Queue( int size );

	~Queue<TYPE>()
	{ delete [] arr; }

	// ���������������� ���� � �������� ��������� ����� ��������, ��� ���в���

	bool enqueue( TYPE   value );	// ������� value � ���� ����� 
	bool dequeue( TYPE & value );	// ������ � ������ ����� �������� � value


	// ������ �-� �� � ������ ����� !!!!!
	template < typename TYPE >		// ���� �� ���� �������, �� ���� �������� ( �� "����������" ����� ���������� ���� �� �-� -- ����� ����� ( ���� �� ������)
	friend ostream & operator << ( ostream & oLeft , Queue<TYPE> & oRight );


private:
	TYPE	*arr;		// �����, � ����� �����
	int		 idxTail;	// ������ ���������� �������� � ���� ( -1 -- ����� ����� )
	int		 size;		// ����� (�������) �����

};



///////////////////////////////////////////////////////////////////////////////////////////////////////
//
// ��������� ��������� �-� (� �.�. ������ �����) ������� ���� � ������ ���� � �� ����������� ( �����, � *.h )
//
/////////////////////////////////////////////////////////////////////////////



template <typename TYPE>
Queue<TYPE>::Queue( int size )
	: idxTail(-1), size(size)
{
	arr = new TYPE [size];
}

//----------------------------- �������� ��������� ��������� �����
//template <typename TYPE>
//Queue::~Queue()
//{
//	delete [] arr;
//}


// ������� value � ���� ����� 
template <typename TYPE>
bool Queue<TYPE>::enqueue( TYPE   value )
{
	if( idxTail + 1 == size )
		return false;

	arr[ ++idxTail ] = value;
	return true;
}


// ������ � ������ ����� �������� � value
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



// ������ �-� �� � ������ ����� !!!!!
template < typename TYPE >		// ���� �� ���� �������, �� ���� �������� ( �� "����������" ����� ���������� ���� �� �-� -- ����� ����� ( ���� �� ������)
ostream & operator << ( ostream & oLeft , Queue<TYPE> & oRight )
{
	for( int i = 0 ; i <= oRight.idxTail ; i++ )
		oLeft << oRight.arr[i] <<' ';

	return oLeft;
}


