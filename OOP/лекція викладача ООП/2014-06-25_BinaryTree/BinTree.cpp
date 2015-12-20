#include "BinTree.h"


BinTree::NODE::NODE( int newKey, const char * pTextSrc )
	: pLess( nullptr ), pMore( nullptr ), pText( nullptr ), key( newKey )
{
	this->pText = new char [ strlen( pTextSrc ) + 1 ];
	strcpy( this->pText, pTextSrc );
}


BinTree::NODE::~NODE()
{
	cout <<" destructor for NODE with key=" <<key <<"   pText: '" <<pText <<"'\n";
	delete [] pText;
	delete pLess;
	delete pMore;
}




BinTree::BinTree()
	: pRoot( nullptr )
{}


// додає нову ноду з вказаними ключем і значенням до дерева
bool BinTree::add( int key, const char * text )
{
	NODE * pNew = new NODE( key, text );

	if( pRoot == nullptr )	// тобто, дерево порожній
	{
		pRoot = pNew;
		return true;
	}

	// якщо ж дерево не пусте.....

	// будемо шукати, куди вставити нову ноду
	NODE * pCur = pRoot;	// вказ-к, яким "ходимо" по дереву


	while( pCur )	// цикл пошуку і вставки
	{
		if( pNew->key == pCur->key )	// ключ мусить бути унікальним !!!!
			return false;

		if( pNew->key > pCur->key )
		{

			// дивимось, чи є нода з більшим ключем
			if( pCur->pMore == nullptr )	// якщо нема ноди
			{
				pCur->pMore = pNew;		// вставляємо нову ноду 
				return true;
			}
			else	// якщо з нода з більшим значенням існує
			{
				pCur = pCur->pMore;		// шукаємо далі	
			}

		}
		else
		{

			// дивимось, чи є нода з меним ключем
			if( pCur->pLess == nullptr )	// якщо нема ноди
			{
				pCur->pLess = pNew;		// вставляємо нову ноду 
				return true;
			}
			else	// якщо з нода з більшим значенням існує
			{
				pCur = pCur->pLess;		// шукаємо далі	
			}

		}

	}// цикл пошуку і вставки



}// bool BinTree::add( int key, const char * text )



ostream & operator << ( ostream & oLeft, BinTree & oRight )
{
	oLeft <<oRight.pRoot;
	return oLeft;

}// ostream & operator << ( ostream & oLeft, BinTree & oRight )




ostream & operator << ( ostream & oLeft, BinTree::NODE * pCurNode )
{
	oLeft <<"NODE with key=" <<pCurNode->key <<"   pText: '" <<pCurNode->pText <<"'\n";

	oLeft <<"\t less NODE ";
	if( pCurNode->pLess )		// якщо менша нода існує
		oLeft <<"with key=" <<pCurNode->pLess->key <<"   pText: '" <<pCurNode->pLess->pText <<"'\n";
	else
		oLeft <<" -- The end !\n";

	oLeft <<"\t more NODE " ;
	if( pCurNode->pMore )		// якщо більша нода існує
		oLeft <<"with key=" <<pCurNode->pMore->key <<"   pText: '" <<pCurNode->pMore->pText <<"'\n";
	else
		oLeft <<" -- The end !\n";

	oLeft <<endl;

	if( pCurNode->pLess )		// якщо менша нода існує
		oLeft << pCurNode->pLess;

	if( pCurNode->pMore )		// якщо більша нода існує
		oLeft << pCurNode->pMore;

	return oLeft;
}// ostream & operator << ( ostream & oLeft, BinTree::NODE * pRight )


