
class Queue
{

public:
	explicit Queue();
	~Queue();

	// ���������������� ���� � �������� ��������� ����� ��������, ��� ���в���

	bool enqueue( int   value );	// ������� value � ���� ����� 
	bool dequeue( int & value );	// ������ � ������ ����� �������� � value



private:

	struct Enqueued
	{
		int			 value;		// ���� ��������, ���������� � �����
		Enqueued	*pNext;		// �������� �� ���������� � ����
	};


	Enqueued	*pHead;		// �������� �� ������ �����
	Enqueued	*pTail;		// �������� �� ���� �����

};