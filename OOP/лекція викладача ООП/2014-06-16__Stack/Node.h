class Node
{

public:
	Node( int value, Node *pPrev = 0 );
	~Node();
	// ���������� ��ﳿ � ��������� �� ������ -- �������������������� ����


	inline int		 getValue() { return value; }
	inline Node		*getPrev()	{ return pPrev; }
	inline void		 setPrev( Node * pPrev ) { this->pPrev = pPrev; }


private:
	int		 value;		// ���, �� ����������� � ��� ( � ���� )
	Node	*pPrev;		// ��'���� --  �������� �� ��������� ������� ����� (��������� ����)

};