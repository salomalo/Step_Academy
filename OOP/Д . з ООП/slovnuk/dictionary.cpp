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
	:   pRoot( nullptr )			// ����� ������
	  ,pCurNode( nullptr )			// ���� ������� ����
	  ,pCurNodeParent( nullptr )	// ���� ����������� ������� ����
{
	add("word","�����");
	add("sky","����");
	add("sun","�����");
	add("rain","���");
	add("flag","������");
	add("friend","����");
	add("dog","������");
	add("cat","��");
	add("hedgehog","����");
	add("chocolate","�������");
}

// ���� ���� ���� � ��������� ������ � ��������� �� ������
bool Dictionary::add( char * key, const char * text )
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
		if( strcmp(pNew->key,pCur->key)==0)	// ���� ������ ���� ��������� !!!!
			return false;

		if( strcmp(pNew->key,pCur->key)>0 )
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
	if( pCurNode->pLess )		// ���� ����� ���� ����
		oLeft <<"word =" <<pCurNode->pLess->key <<"   translation: '" <<pCurNode->pLess->pText <<"'\n";
	else
		oLeft <<" -- The end !\n";

	oLeft <<"\t more NODE " ;
	if( pCurNode->pMore )		// ���� ����� ���� ����
		oLeft <<"word =" <<pCurNode->pMore->key <<"   translation: '" <<pCurNode->pMore->pText <<"'\n";
	else
		oLeft <<" -- The end !\n";

	oLeft <<endl;*/

	if( pCurNode->pLess )		// ���� ����� ���� ����
		oLeft << pCurNode->pLess;

	if( pCurNode->pMore )		// ���� ����� ���� ����
		oLeft << pCurNode->pMore;

	return oLeft;
}// ostream & operator << ( ostream & oLeft, Dictionary::NODE * pRight )

const char * Dictionary:: find( const char *  keyToFind ) const
{
	//cout <<keyToFind <<" - ";

	NODE * pPrev = nullptr;	// ���������� pCur
	NODE * pCur  = pRoot;	// �������� ����� � ������ ������

	while( pCur ) // ���� ������
	{
		//cout <<" ..." <<pCur->key ;
		if(strcmp( keyToFind,pCur->key)==0 )
		{
			//cout <<"  found ! \n\n";	// ���� ������� ���� -- 
			pCurNode		= pCur;			// ������������ �������� ���� �� �������, � ������������ ����� �������� mutable
			pCurNodeParent	= pPrev;			// ������������ �������� ���� �� �������, � ������������ ����� �������� mutable
			cout<<pCur->pText<<endl;
			return pCur->pText;			// ��������� ��������
		}
		// ���� �� ������� -- ����� ���
		pPrev = pCur;			// ������� ���� ����� �����������
		if( strcmp( keyToFind,pCur->key)>0 )		// ���� ������ ������ ���� -- ���������� �� ���� � ������ ������
			pCur = pCur->pMore;		
		else							// ���� ������ ������ ���� -- ���������� �� ���� � ������ ������
			pCur = pCur->pLess;
	}//		���� ������

	// ��� �� ���������, ���� ���� �� ������� keyToFind
	cout <<"  NOT found ! \n\n";

	pCurNode		= nullptr;			// ���� �������� ����!!!!
	pCurNodeParent	= nullptr;			// ���� ����������� �������� ����!!!!
	return nullptr;

}// const char * Dictionary:: find( const char *  keyToFind ) const

void Dictionary:: removeByKey( const char * keyRemove )
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

}// void Dictionary:: removeByKey( const char * keyRemove )

// ���������� �������� ����, ��������� � pStar � ���� �� �� this
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
	pCurNode		= nullptr;			// ���� �������� ����!!!!
	pCurNodeParent	= nullptr;			// ���� ����������� �������� ����!!!!
 return false;
 }