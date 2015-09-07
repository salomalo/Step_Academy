#include <iostream>
#include <locale>
#include <conio.h>
#include <windows.h>
using namespace std;

class Dictionary
{
	struct NODE;		// ������� ����������, �� ��������� �����

public:
	Dictionary();
	~Dictionary() { delete pRoot; }
	bool add( char * key, const char * text );
	friend ostream & operator << ( ostream & oLeft, Dictionary & oRight );
	friend ostream & operator << ( ostream & oLeft, Dictionary::NODE * pRight );
	const char * find( const char * keyToFind ) const;
	void removeByKey( const char * keyRemove );
	bool edit(const char * keyToFind);

private:
	struct NODE
	{
		char	*key;	// ����
		char	*pText;	// ��������, �� ������������ �� �����
		NODE	*pLess;	// ����. �� �������� ���� � ������  ������
		NODE	*pMore;	// ����. �� �������� ���� � ������� ������
		NODE( char	*key, const char * pText );
		~NODE();
	}; 
	// struct NODE

	NODE	*pRoot;		// ��������� ������� ������ (�������)
	mutable NODE	*pCurNode;			// ������� ���� -- �������� ����, ��� ����� ������ �� ��������
	mutable NODE	*pCurNodeParent;	// ���������� ������� ���� -- �������� ����, ��� ����� ������ �� ��������
	void reAdd( NODE * pStar );	// ���������� �������� ����, ��������� � pStar � ���� �� �� this
};