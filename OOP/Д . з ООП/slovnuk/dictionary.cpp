#include "dictionary.h"

Dictionary::NODE::NODE( char * newKey, const char * pTextSrc )
	: pLess( nullptr ), pMore( nullptr ), pText( nullptr ), key( newKey )
{
	this->pText = new char [ strlen( pTextSrc ) + 1 ];
	strcpy( this->pText, pTextSrc );
}

Dictionary::NODE::~NODE()
{
	//cout <<" destructor for NODE with key=" <<key <<"   pText: '" <<pText <<"'\n";
	delete [] pText;
	delete pLess;
	delete pMore;
}

Dictionary::Dictionary()
	:   pRoot( nullptr )			// пусте дерево
	  ,pCurNode( nullptr )			// нема поточної ноди
	  ,pCurNodeParent( nullptr )	// нема попередника поточної ноди
{
	add("word","слово");
	add("sky","небо");
	add("sun","сонце");
	add("rain","дощ");
	add("flag","прапор");
	add("friend","друг");
	add("dog","собака");
	add("cat","кіт");
	add("hedgehog","їжак");
	add("chocolate","шоколад");
}

// додає нову ноду з вказаними ключем і значенням до дерева
bool Dictionary::add( char * key, const char * text )
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
		if( strcmp(pNew->key,pCur->key)==0)	// ключ мусить бути унікальним !!!!
			return false;

		if( strcmp(pNew->key,pCur->key)>0 )
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
}// bool Dictionary::add( char *key, const char * text )

ostream & operator << ( ostream & oLeft, Dictionary & oRight )
{
	if( oRight.pRoot )
		oLeft << oRight.pRoot;
	return oLeft;

}// ostream & operator << ( ostream & oLeft, BinTree & oRight )

ostream & operator << ( ostream & oLeft, Dictionary ::NODE * pCurNode )
{
	oLeft <</*" word = " <<*/pCurNode->key <</*"   translation:  */" - '" <<pCurNode->pText <<"'\n";

	/*oLeft <<"\t less NODE ";
	if( pCurNode->pLess )		// якщо менша нода існує
		oLeft <<"word =" <<pCurNode->pLess->key <<"   translation: '" <<pCurNode->pLess->pText <<"'\n";
	else
		oLeft <<" -- The end !\n";

	oLeft <<"\t more NODE " ;
	if( pCurNode->pMore )		// якщо більша нода існує
		oLeft <<"word =" <<pCurNode->pMore->key <<"   translation: '" <<pCurNode->pMore->pText <<"'\n";
	else
		oLeft <<" -- The end !\n";

	oLeft <<endl;*/

	if( pCurNode->pLess )		// якщо менша нода існує
		oLeft << pCurNode->pLess;

	if( pCurNode->pMore )		// якщо більша нода існує
		oLeft << pCurNode->pMore;

	return oLeft;
}// ostream & operator << ( ostream & oLeft, Dictionary::NODE * pRight )

const char * Dictionary:: find( const char *  keyToFind ) const
{
	//cout <<keyToFind <<" - ";

	NODE * pPrev = nullptr;	// попередник pCur
	NODE * pCur  = pRoot;	// починаємо пошук з кореня дерева

	while( pCur ) // цикл пошуку
	{
		//cout <<" ..." <<pCur->key ;
		if(strcmp( keyToFind,pCur->key)==0 )
		{
			//cout <<"  found ! \n\n";	// якщо знайшли ключ -- 
			pCurNode		= pCur;			// встановлюємо знайдену ноду як поточну, у константному методі допомагає mutable
			pCurNodeParent	= pPrev;			// встановлюємо знайдену ноду як поточну, у константному методі допомагає mutable
			cout<<pCur->pText<<endl;
			return pCur->pText;			// повертаємо значення
		}
		// якщо не знайшли -- ідемо далі
		pPrev = pCur;			// поточна нода стане попередньою
		if( strcmp( keyToFind,pCur->key)>0 )		// якщо шукаємо більший ключ -- переходимо на ноду з більшим ключем
			pCur = pCur->pMore;		
		else							// якщо шукаємо менший ключ -- переходимо на ноду з меншим ключем
			pCur = pCur->pLess;
	}//		цикл пошуку

	// тут ми опинимося, лише якщо не знайшли keyToFind
	cout <<"  NOT found ! \n\n";

	pCurNode		= nullptr;			// немає знайденої ноди!!!!
	pCurNodeParent	= nullptr;			// немає попередника знайденої ноди!!!!
	return nullptr;

}// const char * Dictionary:: find( const char *  keyToFind ) const

void Dictionary:: removeByKey( const char * keyRemove )
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

}// void Dictionary:: removeByKey( const char * keyRemove )

// рекурсивно обходить ноди, починаючи з pStar і додає їх до this
void Dictionary:: reAdd( NODE * pStart )
{
	if( ! pStart )
		return;
	this->add( pStart->key , pStart->pText );
	reAdd( pStart->pLess );
	reAdd( pStart->pMore );
}


bool Dictionary::edit( const char * keyToFind)
 {
	 NODE * pPrev=nullptr;
	 NODE * pCur=pRoot;
	 while (pCur)
	 {
		 if (strcmp(keyToFind,pCur->key)==0)
		 {
			 char buffer[50];
			 pCurNode=pCur;
			 pCurNodeParent=pPrev;
			 cout<<"Enter new translation - ";cin>>buffer;
			 delete[]pCurNode->pText;
			pCurNode->pText=new char[strlen(buffer)+1];
			strcpy(pCurNode->pText,buffer);
			 return true;
		 }
		 pPrev=pCur;
		 if(strcmp(keyToFind,pCur->key)>0)
			 pCur=pCur->pMore;
		 else
			 pCur=pCur->pLess;
	 }
	pCurNode		= nullptr;			// немає знайденої ноди!!!!
	pCurNodeParent	= nullptr;			// немає попередника знайденої ноди!!!!
 return false;
 }