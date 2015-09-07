#pragma once

#include "Duet.h"


template < typename TYPE1 , typename TYPE2, typename TYPE3 = int >
class Trio : public Duet< TYPE1 , TYPE2 >
{
public:

	Trio( TYPE1 frst, TYPE2 scnd, TYPE3 thrd )
		: Duet( frst, scnd )
		, third( thrd )
	{}

	void Show()
	{
		Duet::Show();
		cout <<"   third = " <<third;
	}

	TYPE3 someMethod()
	{

	}


private:
	TYPE3	third;

};