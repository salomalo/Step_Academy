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

	bool addHead( int val );		// ���� val � ������ ������ (������   ���������)
	bool addTail( int val );		// ���� val � ����  ������ (������� ���������)

	bool remHead( int & val );		// ������ � �������    �������� � ����� � val
	bool remTail( int & val );		// ������ � ���������� �������� � ����� � val

	void clear();					// ����� ������


	friend ostream & operator << ( ostream & oLeft , List & oRight );



private:
	Node * pHead;	// �� ������   ������� ������ 
	Node * pTail;	// �� ������� ������� ������ 

}; // class List