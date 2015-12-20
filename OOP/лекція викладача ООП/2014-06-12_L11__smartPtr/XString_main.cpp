#include "SmartPtr.h"



SmartPtr doIt( SmartPtr sp )
{
	cout <<" (*sp) doIt( " <<(*sp) <<" )\n";
	cout <<"Print(): ";
	sp->Print();
	cout <<"\n";
	return sp;
}



void main()
{
	SmartPtr sp1( new XString( "First  XString" ) );
	SmartPtr sp2( new XString( "Second XString" ) );

	SmartPtr sp3 = doIt( sp2 );

	sp2 = sp1;



	cout <<"\n\n\n    main() terminated \n\n";
}