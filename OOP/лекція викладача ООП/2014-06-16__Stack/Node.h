class Node
{

public:
	Node( int value, Node *pPrev = 0 );
	~Node();
	// констуктор копії і присвоєння не пишемо -- вузькоспеціалізований клас


	inline int		 getValue() { return value; }
	inline Node		*getPrev()	{ return pPrev; }
	inline void		 setPrev( Node * pPrev ) { this->pPrev = pPrev; }


private:
	int		 value;		// дані, що зберігаються в ноді ( у вузлі )
	Node	*pPrev;		// зв'язка --  вказівник на попередній елемент стека (попередню ноду)

};