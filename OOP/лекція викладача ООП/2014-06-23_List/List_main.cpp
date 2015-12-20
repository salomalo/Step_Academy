#include "List.h"


void TestCopy( List oLst )
{
	cout <<"\n\nin TestCopy()   oLst:" <<oLst <<endl;
	cout <<"TestCopy finished\n";
}



void main()
{



	List lst;
	lst.addTail(11);
	lst.addTail(33);
	lst.addTail(44);
	lst.addTail(66);
	cout <<"lst: " <<lst <<endl;

	TestCopy( lst );

	bool isRemoved;
	int  val = 0;

	isRemoved = lst.remHead( val );
	cout <<"isRemoved=" <<isRemoved <<"  val=" <<val <<"   lst: " <<lst <<endl;

	isRemoved = lst.remHead( val );
	cout <<"isRemoved=" <<isRemoved <<"  val=" <<val <<"   lst: " <<lst <<endl;

	isRemoved = lst.remHead( val );
	cout <<"isRemoved=" <<isRemoved <<"  val=" <<val <<"   lst: " <<lst <<endl;

	isRemoved = lst.remHead( val );
	cout <<"isRemoved=" <<isRemoved <<"  val=" <<val <<"   lst: " <<lst <<endl;

	isRemoved = lst.remHead( val );
	cout <<"isRemoved=" <<isRemoved <<"  val=" <<val <<"   lst: " <<lst <<endl;

	isRemoved = lst.remHead( val );
	cout <<"isRemoved=" <<isRemoved <<"  val=" <<val <<"   lst: " <<lst <<endl;


	cout <<"\n\n\n";


	List tsl;
	tsl.addHead(22);
	tsl.addHead(33);
	tsl.addHead(66);
	tsl.addHead(99);
	tsl.addHead(22);
	cout <<"tsl: " <<tsl <<endl;

	//tsl.clear();

	isRemoved = tsl.remTail( val );
	cout <<"isRemoved=" <<isRemoved <<"  val=" <<val <<"   tsl: " <<tsl <<endl;

	isRemoved = tsl.remTail( val );
	cout <<"isRemoved=" <<isRemoved <<"  val=" <<val <<"   tsl: " <<tsl <<endl;

	isRemoved = tsl.remTail( val );
	cout <<"isRemoved=" <<isRemoved <<"  val=" <<val <<"   tsl: " <<tsl <<endl;

	isRemoved = tsl.remTail( val );
	cout <<"isRemoved=" <<isRemoved <<"  val=" <<val <<"   tsl: " <<tsl <<endl;

	isRemoved = tsl.remTail( val );
	cout <<"isRemoved=" <<isRemoved <<"  val=" <<val <<"   tsl: " <<tsl <<endl;

	isRemoved = tsl.remTail( val );
	cout <<"isRemoved=" <<isRemoved <<"  val=" <<val <<"   tsl: " <<tsl <<endl;


	cout <<"\n\nTODO: operator =";


	cout <<"\n\n\n";
}

