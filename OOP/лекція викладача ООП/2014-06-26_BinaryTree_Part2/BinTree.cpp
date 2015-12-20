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
	:   pRoot( nullptr )			// ����� ������
	  , pCurNode( nullptr )			// ���� ������� ����
	  , pCurNodeParent( nullptr )	// ���� ����������� ������� ����
{}


// ���� ���� ���� � ��������� ������ � ��������� �� ������
bool BinTree::add( int key, const char * text )
{
	NODE * pNew = new NODE( key, text );

	if( pRoot == nullptr )	// �����, ������ �������
	{
		pRoot = pNew;
		return true;
	}

	// ���� � ������ �� �����.....

	// ������ ������, ���� �������� ���� ����
	NODE * pCur = pRoot;	// ����-�, ���� "������" �� ������


	while( pCur )	// ���� ������ � �������
	{
		if( pNew->key == pCur->key )	// ���� ������ ���� ��������� !!!!
			return false;

		if( pNew->key > pCur->key )
		{

			// ��������, �� � ���� � ������ ������
			if( pCur->pMore == nullptr )	// ���� ���� ����
			{
				pCur->pMore = pNew;		// ���������� ���� ���� 
				return true;
			}
			else	// ���� � ���� � ������ ��������� ����
			{
				pCur = pCur->pMore;		// ������ ���	
			}

		}
		else
		{

			// ��������, �� � ���� � ����� ������
			if( pCur->pLess == nullptr )	// ���� ���� ����
			{
				pCur->pLess = pNew;		// ���������� ���� ���� 
				return true;
			}
			else	// ���� � ���� � ������ ��������� ����
			{
				pCur = pCur->pLess;		// ������ ���	
			}

		}

	}// ���� ������ � �������



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
	if( pCurNode->pLess )		// ���� ����� ���� ����
		oLeft <<"with key=" <<pCurNode->pLess->key <<"   pText: '" <<pCurNode->pLess->pText <<"'\n";
	else
		oLeft <<" -- The end !\n";

	oLeft <<"\t more NODE " ;
	if( pCurNode->pMore )		// ���� ����� ���� ����
		oLeft <<"with key=" <<pCurNode->pMore->key <<"   pText: '" <<pCurNode->pMore->pText <<"'\n";
	else
		oLeft <<" -- The end !\n";

	oLeft <<endl;

	if( pCurNode->pLess )		// ���� ����� ���� ����
		oLeft << pCurNode->pLess;

	if( pCurNode->pMore )		// ���� ����� ���� ����
		oLeft << pCurNode->pMore;

	return oLeft;
}// ostream & operator << ( ostream & oLeft, BinTree::NODE * pRight )




const char * BinTree:: find( const int keyToFind ) const
{
	cout <<" find( " <<keyToFind <<")....\n";

	NODE * pPrev = nullptr;	// ���������� pCur
	NODE * pCur  = pRoot;	// �������� ����� � ������ ������

	while( pCur ) // ���� ������
	{
		cout <<" ..." <<pCur->key ;

		if( keyToFind == pCur->key )
		{
			cout <<"  found ! \n\n";	// ���� ������� ���� -- 
			pCurNode		= pCur;			// ������������ �������� ���� �� �������, � ������������ ����� �������� mutable
			pCurNodeParent	= pPrev;			// ������������ �������� ���� �� �������, � ������������ ����� �������� mutable

			return pCur->pText;			// ��������� ��������
		}

		// ���� �� ������� -- ����� ���

		pPrev = pCur;			// ������� ���� ����� �����������

		if( keyToFind > pCur->key )		// ���� ������ ������ ���� -- ���������� �� ���� � ������ ������
			pCur = pCur->pMore;		
		else							// ���� ������ ������ ���� -- ���������� �� ���� � ������ ������
			pCur = pCur->pLess;


	}//		���� ������

	// ��� �� ���������, ���� ���� �� ������� keyToFind
	cout <<"  NOT found ! \n\n";
	pCurNode		= nullptr;			// ���� �������� ����!!!!
	pCurNodeParent	= nullptr;			// ���� ����������� �������� ����!!!!

	return nullptr;


}// const char * BinTree:: find( int keyToFind ) const



bool BinTree:: getMinKey( int & minKey ) const
{

	if( !pRoot )			// ���� ����� ������
		return false;		// �� ������� �������


	NODE * pCur = pRoot;	// �������� ����� � ������ ������

	while( pCur->pLess )	// ���� � ���� � �� ������ ������
	{
		pCur = pCur->pLess;	// ���������� �� ���� � ������ ������
	}

	// ��� �� ���������, ���� ������ �� ����, ��� �� �� �������� ���� � ������ ������
	minKey = pCur->key;
	return true;

}


bool BinTree:: getMaxKey( int & maxKey ) const
{

	if( !pRoot )			// ���� ����� ������
		return false;		// �� ������� �������


	NODE * pCur = pRoot;	// �������� ����� � ������ ������

	while( pCur->pMore )	// ���� � ���� � �� ������� ������
	{
		pCur = pCur->pMore;	// ���������� �� ���� � ������ ������
	}

	// ��� �� ���������, ���� ������ �� ����, ��� �� �� �������� ���� � ������ ������
	maxKey = pCur->key;
	return true;

}



void BinTree:: removeByKey( int keyRemove )
{
	this->find( keyRemove );	// ������ ���� �� �����, �� �� ����� pCurNode
	if( ! pCurNode )
		return;


	// ��� �� ������, ���� ����� ��� �������


	// �������� �������� ���� � ������
	if( pCurNodeParent->pLess == pCurNode )	
		pCurNodeParent->pLess = nullptr;

	if( pCurNodeParent->pMore == pCurNode )	
		pCurNodeParent->pMore = nullptr;


	// ���������� ���� ����
	reAdd( pCurNode->pLess );
	reAdd( pCurNode->pMore );

	delete pCurNode;


}// void BinTree:: removeByKey( int keyRemove )


// ���������� �������� ����, ��������� � pStar � ���� �� �� this
void BinTree:: reAdd( NODE * pStart )
{
	if( ! pStart )
		return;

	this->add( pStart->key , pStart->pText );

	reAdd( pStart->pLess );
	reAdd( pStart->pMore );

}


