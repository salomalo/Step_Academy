#include "BinTree.h"

// відео написання цього коду (без звуку) викладено за адресою http://www.ex.ua/edit/78789972
// у файлі		2014-06-25_binTree_1_(without_audio).tvs


void main()
{
	BinTree btr;

	btr.add( 7, "seven" );
	btr.add( 3, "three" );
	btr.add( 5, "five" );
	btr.add( 2, "two" );
	btr.add( 2, "two" );
	btr.add( 4, "four" );
	btr.add( 6, "six" );
	btr.add( 1, "one" );

	cout <<btr;

}
