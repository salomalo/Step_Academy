#include <iostream>
using namespace std;

class BinTree
{
	struct NODE;		// обіцяємо компілятору, що оголосимо пізніше

public:
	BinTree();
	~BinTree() { delete pRoot; }

	bool add( int key, const char * text );

	friend ostream & operator << ( ostream & oLeft, BinTree & oRight );
	friend ostream & operator << ( ostream & oLeft, BinTree::NODE * pRight );


private:

	struct NODE
	{
		int		 key;	// ключ
		char	*pText;	// значення, що шукатиметься по ключу

		NODE	*pLess;	// вказ. на наступну ноду з МЕНШИМ  ключем
		NODE	*pMore;	// вказ. на наступну ноду з БІЛЬШИМ ключем

		NODE( int key, const char * pText );
		~NODE();

	}; 
	// struct NODE


	NODE	*pRoot;		// кореневий елемент дерева (початок)





};