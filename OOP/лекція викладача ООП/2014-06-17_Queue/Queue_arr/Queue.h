
class Queue
{

public:
	explicit Queue( int size );
	~Queue();

	// ���������������� ���� � �������� ��������� ����� ��������, ��� ���в���

	bool enqueue( int   value );	// ������� value � ���� ����� 
	bool dequeue( int & value );	// ������ � ������ ����� �������� � value



private:
	int		*arr;		// �����, � ����� �����
	int		 idxTail;	// ������ ���������� �������� � ���� ( -1 -- ����� ����� )
	int		 size;		// ����� (�������) �����

};