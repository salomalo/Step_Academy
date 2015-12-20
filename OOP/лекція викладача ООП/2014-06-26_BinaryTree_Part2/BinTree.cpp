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
	:   pRoot( nullptr )			// пусте дерево
	  , pCurNode( nullptr )			// нема поточної ноди
	  , pCurNodeParent( nullptr )	// нема попередника поточної ноди
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
	if( oRight.pRoot )
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




const char * BinTree:: find( const int keyToFind ) const
{
	cout <<" find( " <<keyToFind <<")....\n";

	NODE * pPrev = nullptr;	// попередник pCur
	NODE * pCur  = pRoot;	// починаємо пошук з кореня дерева

	while( pCur ) // цикл пошуку
	{
		cout <<" ..." <<pCur->key ;

		if( keyToFind == pCur->key )
		{
			cout <<"  found ! \n\n";	// якщо знайшли ключ -- 
			pCurNode		= pCur;			// встановлюємо знайдену ноду як поточну, у константному методі допомагає mutable
			pCurNodeParent	= pPrev;			// встановлюємо знайдену ноду як поточну, у константному методі допомагає mutable

			return pCur->pText;			// повертаємо значення
		}

		// якщо не знайшли -- ідемо далі

		pPrev = pCur;			// поточна нода стане попередньою

		if( keyToFind > pCur->key )		// якщо шукаємо більший ключ -- переходимо на ноду з більшим ключем
			pCur = pCur->pMore;		
		else							// якщо шукаємо менший ключ -- переходимо на ноду з меншим ключем
			pCur = pCur->pLess;


	}//		цикл пошуку

	// тут ми опинимося, лише якщо не знайшли keyToFind
	cout <<"  NOT found ! \n\n";
	pCurNode		= nullptr;			// немає знайденої ноди!!!!
	pCurNodeParent	= nullptr;			// немає попередника знайденої ноди!!!!

	return nullptr;


}// const char * BinTree:: find( int keyToFind ) const



bool BinTree:: getMinKey( int & minKey ) const
{

	if( !pRoot )			// якщо пусте дерево
		return false;		// не знайшли меншого


	NODE * pCur = pRoot;	// починаємо пошук з кореня дерева

	while( pCur->pLess )	// поки є нода зі ЩЕ МЕНШИМ ключем
	{
		pCur = pCur->pLess;	// переходимо на ноду з меншим ключем
	}

	// тут ми опинимося, коли дійдемо до ноди, яка не має дочірньої ноди з меншим ключем
	minKey = pCur->key;
	return true;

}


bool BinTree:: getMaxKey( int & maxKey ) const
{

	if( !pRoot )			// якщо пусте дерево
		return false;		// не знайшли більшого


	NODE * pCur = pRoot;	// починаємо пошук з кореня дерева

	while( pCur->pMore )	// поки є нода зі ЩЕ БІЛЬШИМ ключем
	{
		pCur = pCur->pMore;	// переходимо на ноду з більшим ключем
	}

	// тут ми опинимося, коли дійдемо до ноди, яка не має дочірньої ноди з більшим ключем
	maxKey = pCur->key;
	return true;

}



void BinTree:: removeByKey( int keyRemove )
{
	this->find( keyRemove );	// шукаємо ноду по ключу, на неї вкаже pCurNode
	if( ! pCurNode )
		return;


	// тут ми будемо, якщо пошук був успішним


	// вилучаємо знайдену ноду з дерева
	if( pCurNodeParent->pLess == pCurNode )	
		pCurNodeParent->pLess = nullptr;

	if( pCurNodeParent->pMore == pCurNode )	
		pCurNodeParent->pMore = nullptr;


	// передодаємо нижні гілки
	reAdd( pCurNode->pLess );
	reAdd( pCurNode->pMore );

	delete pCurNode;


}// void BinTree:: removeByKey( int keyRemove )


// рекурсивно обходить ноди, починаючи з pStar і додає їх до this
void BinTree:: reAdd( NODE * pStart )
{
	if( ! pStart )
		return;

	this->add( pStart->key , pStart->pText );

	reAdd( pStart->pLess );
	reAdd( pStart->pMore );

}


