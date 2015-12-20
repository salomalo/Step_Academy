#pragma once

#include <iostream>
using namespace std;


class List
{

	struct Node		// ��������, ���������� �� ������ �����
	{
		int		 value;		// ��������, �� ���������� � ���
		Node	*pNext;		// �������� �� �������� ���� � ������
	};


public:

	List();			// ������� ������ ������
	~List();
	List( List & oSrc );

	bool addHead( int val );			// ���� val � ������ ������ (������   ���������)
	bool addTail( int val );			// ���� val � ����  ������ (������� ���������)
	bool insert(  int val, int idxIns );// �������� val ��������� ������ �� ������� idxIns

	bool remHead( int & val );		// ������ � �������    �������� � ����� � val
	bool remTail( int & val );		// ������ � ���������� �������� � ����� � val
	bool remove(  int & val, int idxRem );// ������ val � �������� ������ �� ������� idxRem


	void clear();					// ����� ������


	friend ostream & operator << ( ostream & oLeft , List & oRight );

	List & operator = ( List & oRight );


private:
	Node * pHead;	// �� ������   ������� ������ 
	Node * pTail;	// �� ������� ������� ������ 

	void   copy( List & oSrc );		// �������� �����, ������ ����� � oSrc � this
	Node * getPtrByIdx( int idx );	// ���� ���� �� �������, � ������� �������� �� ��, ��� nullptr

}; // class List