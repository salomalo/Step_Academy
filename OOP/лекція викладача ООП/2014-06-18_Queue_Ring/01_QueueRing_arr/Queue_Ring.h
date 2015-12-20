#include <iostream>
#include <iomanip>
using namespace std;


class Queue_Ring
{

public:
	explicit Queue_Ring( int size );
	~Queue_Ring();

	// ���������������� ���� � �������� ��������� ����� ��������, ��� ���в���

	friend ostream & operator << ( ostream & left , Queue_Ring & right );


	bool enqueue( int   value );	// ������� value � ���� ����� 
	bool dequeue( int & value );	// ������ � ������ ����� �������� � value

	/// ------------- ʲ���� ------------------
	bool dequeueRing( int & value );	// ������� � value �������� � ������ ����� � ������� ���� � ����




private:
	int		*arr;		// �����, � ����� �����
	int		 idxTail;	// ������ ���������� �������� � ���� ( -1 -- ����� ����� )
	int		 size;		// ����� (�������) �����

};