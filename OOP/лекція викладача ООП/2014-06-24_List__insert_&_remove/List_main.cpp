/*
	відео лежить за адресою http://www.ex.ua/78789972?r=78155343
	Файли: 
		2014-06-24_LinkedList_1_Insert.tvs	http://www.ex.ua/get/112334260
		2014-06-24_LinkedList_2_remove.tvs	http://www.ex.ua/get/112334036

*/


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

	bool isSuccess;
	int  val = 0;

	isSuccess = lst.remHead( val );
	cout <<"isSuccess=" <<isSuccess <<"  val=" <<val <<"   lst: " <<lst <<endl;

	isSuccess = lst.remHead( val );
	cout <<"isSuccess=" <<isSuccess <<"  val=" <<val <<"   lst: " <<lst <<endl;

	isSuccess = lst.remHead( val );
	cout <<"isSuccess=" <<isSuccess <<"  val=" <<val <<"   lst: " <<lst <<endl;

	isSuccess = lst.remHead( val );
	cout <<"isSuccess=" <<isSuccess <<"  val=" <<val <<"   lst: " <<lst <<endl;

	isSuccess = lst.remHead( val );
	cout <<"isSuccess=" <<isSuccess <<"  val=" <<val <<"   lst: " <<lst <<endl;

	isSuccess = lst.remHead( val );
	cout <<"isSuccess=" <<isSuccess <<"  val=" <<val <<"   lst: " <<lst <<endl;


	cout <<"\n\n\n";


	List tsl;
	tsl.addHead(22);
	tsl.addHead(33);
	tsl.addHead(66);
	tsl.addHead(99);
	tsl.addHead(22);
	cout <<"tsl: " <<tsl <<endl;

	//tsl.clear();

	isSuccess = tsl.remTail( val );
	cout <<"isSuccess=" <<isSuccess <<"  val=" <<val <<"   tsl: " <<tsl <<endl;

	isSuccess = tsl.remTail( val );
	cout <<"isSuccess=" <<isSuccess <<"  val=" <<val <<"   tsl: " <<tsl <<endl;

	isSuccess = tsl.remTail( val );
	cout <<"isSuccess=" <<isSuccess <<"  val=" <<val <<"   tsl: " <<tsl <<endl;

	isSuccess = tsl.remTail( val );
	cout <<"isSuccess=" <<isSuccess <<"  val=" <<val <<"   tsl: " <<tsl <<endl;

	isSuccess = tsl.remTail( val );
	cout <<"isSuccess=" <<isSuccess <<"  val=" <<val <<"   tsl: " <<tsl <<endl;

	isSuccess = tsl.remTail( val );
	cout <<"isSuccess=" <<isSuccess <<"  val=" <<val <<"   tsl: " <<tsl <<endl;


	tsl.addTail(66);
	tsl.addTail(88);
	tsl.addTail(99);

	lst.addHead(11);
	lst.addHead(22);
	lst.addHead(33);
	lst.addHead(55);


	cout <<"\n\n________ operator = ________\n";
	cout <<"before: \n";
	cout <<"lst: " <<lst <<"\n";
	cout <<"tsl: " <<tsl <<"\n";

	tsl = lst;

	cout <<"\nafter: \n";
	cout <<"lst: " <<lst <<"\n";
	cout <<"tsl: " <<tsl <<"\n";

	tsl.addHead( 555 );
	tsl.addTail( 555 );

	cout <<"\nafter: \n";
	cout <<"lst: " <<lst <<"\n";
	cout <<"tsl: " <<tsl <<"\n";


	cout <<"\n\n________ insert ________\n";
	isSuccess = tsl.insert( 222, 2 );
	cout <<"isSuccess=" <<isSuccess <<"   tsl: " <<tsl <<endl;

	isSuccess = tsl.insert( 777, 7 );
	cout <<"isSuccess=" <<isSuccess <<"   tsl: " <<tsl <<endl;

	isSuccess = tsl.insert( 999, 9 );
	cout <<"isSuccess=" <<isSuccess <<"   tsl: " <<tsl <<endl;

	isSuccess = tsl.insert( 0, 0 );
	cout <<"isSuccess=" <<isSuccess <<"   tsl: " <<tsl <<endl;


	cout <<"\n\n________ remove ________\n";
	isSuccess = tsl.remove( val, 2 );
	cout <<"isSuccess=" <<isSuccess <<"  val=" <<val <<"   tsl: " <<tsl <<endl;

	isSuccess = tsl.remove( val, 0 );
	cout <<"isSuccess=" <<isSuccess <<"  val=" <<val <<"   tsl: " <<tsl <<endl;

	isSuccess = tsl.remove( val, 11);
	cout <<"isSuccess=" <<isSuccess <<"  val=" <<val <<"   tsl: " <<tsl <<endl;

	isSuccess = tsl.remove( val, 2 );
	cout <<"isSuccess=" <<isSuccess <<"  val=" <<val <<"   tsl: " <<tsl <<endl;

	isSuccess = tsl.remove( val, 5 );
	cout <<"isSuccess=" <<isSuccess <<"  val=" <<val <<"   tsl: " <<tsl <<endl;




	cout <<"\n\n\n";
}

