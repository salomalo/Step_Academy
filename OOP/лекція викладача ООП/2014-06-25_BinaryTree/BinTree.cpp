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


