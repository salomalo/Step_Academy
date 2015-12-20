#include <iostream>
using namespace std;

class BinTree
{
	struct NODE;		// ������� ����������, �� ��������� ������

public:
	BinTree();
	~BinTree() { delete pRoot; }

	bool add( int key, const char * text );

	void removeByKey( int keyRemove );

	const char * find( const int keyToFind ) const;

	bool getMinKey( int & minKey ) const;
	bool getMaxKey( int & maxKey ) const;

	friend ostream & operator << ( ostream & oLeft, BinTree & oRight );
	friend ostream & operator << ( ostream & oLeft, BinTree::NODE * pRight );


private:

	struct NODE
	{
		int		 key;	// ����
		char	*pText;	// ��������, �� ������������ �� �����

		NODE	*pLess;	// ����. �� �������� ���� � ������  ������
		NODE	*pMore;	// ����. �� �������� ���� � ������� ������

		NODE( int key, const char * pText );
		~NODE();

	}; 
	// struct NODE


	NODE	*pRoot;		// ��������� ������� ������ (�������)

	mutable NODE	*pCurNode;			// ������� ���� -- �������� ����, ��� ����� ������ �� ��������
	mutable NODE	*pCurNodeParent;	// ���������� ������� ���� -- �������� ����, ��� ����� ������ �� ��������


	void reAdd( NODE * pStar );	// ���������� �������� ����, ��������� � pStar � ���� �� �� this

};