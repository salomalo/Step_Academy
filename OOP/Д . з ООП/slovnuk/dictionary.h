#include <iostream>
#include <locale>
#include <conio.h>
#include <windows.h>
using namespace std;

class Dictionary
{
	struct NODE;		// обіцяємо компілятору, що оголосимо пізніше

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
		char	*key;	// ключ
		char	*pText;	// значення, що шукатиметься по ключу
		NODE	*pLess;	// вказ. на наступну ноду з МЕНШИМ  ключем
		NODE	*pMore;	// вказ. на наступну ноду з БІЛЬШИМ ключем
		NODE( char	*key, const char * pText );
		~NODE();
	}; 
	// struct NODE

	NODE	*pRoot;		// кореневий елемент дерева (початок)
	mutable NODE	*pCurNode;			// поточна нода -- службове поле, для обміну даними між методами
	mutable NODE	*pCurNodeParent;	// попередник поточної ноди -- службове поле, для обміну даними між методами
	void reAdd( NODE * pStar );	// рекурсивно обходить ноди, починаючи з pStar і додає їх до this
};