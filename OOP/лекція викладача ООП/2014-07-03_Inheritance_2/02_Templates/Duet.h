#pragma once

#include <iostream>
using namespace std;


template < typename TYPE1 , typename TYPE2 >
class Duet
{

public:

	Duet( TYPE1 frst, TYPE2 scnd  )
		: first( frst )
		, second( scnd )
	{}


	void Show()
	{
		cout <<"first = " <<first <<"    second = " <<second;
	}


private:
	TYPE1	first;
	TYPE2	second;

};