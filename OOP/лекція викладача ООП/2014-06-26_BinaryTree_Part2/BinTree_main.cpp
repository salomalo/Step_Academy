#include "BinTree.h"

// відео написання цього коду (без звуку) викладено за адресою http://www.ex.ua/edit/78789972
// у файлі		2014-06-25_binTree_1_(without_audio).tvs


void main()
{
	BinTree btr;

	btr.add(  7, "seven" );
	btr.add(  3, "three" );
	btr.add(  5, "five" );
	btr.add(  2, "two" );
	btr.add(  2, "two" );
	btr.add(  4, "four" );
	btr.add(  6, "six" );
	btr.add(  1, "one" );
	btr.add(  9, "nine" );
	btr.add( 11, "eleven" );
	btr.add( 10, "ten" );
	btr.add(  8, "eight" );
	btr.add( 12, "twelve" );
	btr.add( -1, "minus one" );

	cout <<btr;

	cout <<"\n\n _______ find _____\n";

	const char * pText;

	pText = btr.find( 3 );
	cout <<"found text: '" <<( pText ? pText : "--none--" ) <<"'\n\n";

	pText = btr.find( 6 );
	cout <<"found text: '" <<( pText ? pText : "--none--" ) <<"'\n\n";

	pText = btr.find( 8 );
	cout <<"found text: '" <<( pText ? pText : "--none--" ) <<"'\n\n";

	cout <<"\n\n _______ getMaxKey, getMinKey _____\n";
	int key;

	btr.getMaxKey(key);
	cout <<"maximal key: " <<key <<"\n";

	btr.getMinKey(key);
	cout <<"minimal key: " <<key <<"\n";

	cout <<"\n\n _______ deleted 8 _____\n";
	cout <<"removeByKey ...\n";
	btr.removeByKey( 8 );
	cout <<"removeByKey ... finished\n";

	cout <<"\n\n Try to find 8... \n";
	pText = btr.find( 8 );
	cout <<"found text: '" <<( pText ? pText : "--none--" ) <<"'\n\n";
	cout <<btr;


	cout <<"\n\n\n";
}
