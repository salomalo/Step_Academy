#include <iostream>
using namespace std;


class QueuePrior
{

public:
	explicit QueuePrior( int size );				// �����������, ������ ����� �����
	QueuePrior( QueuePrior & oSrc );				// ����������� ����
	~QueuePrior();									// ����������, ������� ���'���
//	QueuePrior & operator = ( QueuePrior & oSrc );	// ���� �������� �������� ��'���� ��� ��������
	
	bool enqueue( int value, int priority );		// ������� � ����� value � ���������� priority � ������� true, ���� ���������
													// ( ������� � �����, ���������� ��������, ���� ����� ������ ������� � �����, ��� ��� ����� �������� �� ���������)

	bool enqueue_NoPr( int value, int priority );	// ������� � ����� value � ���������� priority � ������� true, ���� ���������
													// ( ������� � �����, �� ���������� ��������)

	bool dequeue( int & value, int & priority );	// ��������� � ���� ��-� � �������� ���������� � ������� ����


	friend ostream & operator << ( ostream & left, const QueuePrior & right );

private:
	struct Enqueued		// �� ��������� ���� ��������, �����, ��������� �����
	{	
		int value;		// ��������, ���������� � �����
		int prior;		// �������� ����� ��������

	}; // struct Enqueued

	Enqueued	*arr;		// ����� � ���������� �����
	int			 size;		// ����� ������ (������ �����)
	int			 idxTail;	// ������ ������ ����� (���������� �������� � ����, ���� ����� ������� -- -1 )
							// ������ ����� -- ������ � ������� � �������� 0

};