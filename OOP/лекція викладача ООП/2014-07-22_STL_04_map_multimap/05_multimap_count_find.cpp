#include <iostream>
#include <map>
#include <string>

using namespace std;


typedef pair< string , double > MyPair;

void main()
{
	multimap< string , double > oMap;	// перший -- тип ключа, другий -- тпи значення

	oMap.insert( pair< string , double >( "first" , 111.11 ) );
	oMap.insert( pair< string , double >( "second" , 22.22 ) );


	// використовуємо короткий псевдонім довгого типу
	oMap.insert( MyPair( "third" , 33.333 ) );
	oMap.insert( MyPair( "fifth" , 111.55 ) );
	oMap.insert( MyPair( "fourth" , 444.44 ) );
	oMap.insert( MyPair( "fifth" , 555.5 ) );
	oMap.insert( MyPair( "sixth" , 66.66 ) );
	oMap.insert( MyPair( "fifth" , 444.43 ) );
	oMap.insert( MyPair( "all" , 0 ) );
	oMap.insert( MyPair( "fifth" , 99.99 ) );

	multimap< string , double >::iterator itCur, itEnd;

	itCur = oMap.begin();
	itEnd = oMap.end();
	while( itCur != itEnd )
	{
		cout <<itCur->first <<" : " <<itCur->second <<endl;
		++itCur;
	}
	cout <<"\n\n\n";



	// НЕМА У multimap
	//cout <<oMap["fifth"] <<endl;
	//oMap["fifth"] = 77777.77;
	//cout <<oMap["fifth"] <<endl;

//	cout <<oMap["fifteenth"] <<endl;		НЕМА У multimap



	itCur = oMap.begin();
	itEnd = oMap.end();
	while( itCur != itEnd )
	{
		cout <<itCur->first <<" : " <<itCur->second <<endl;
		++itCur;
	}
	cout <<"\n\n\n";


	cout <<"\n\n__________ count _________\n";
	cout <<"count(\"fifth\") returns " <<oMap.count( "fifth" ) <<endl;
	cout <<"count(\"fourth\") returns " <<oMap.count( "fourth" ) <<endl;
	cout <<"count(\"fifteenth\") returns " <<oMap.count( "fifteenth" ) <<endl;
	cout <<"\n\n\n";

	cout <<"\n\n__________ find _________\n";
	itCur = oMap.find("fifth");
	cout <<"oMap.find(\"fifth\") returns    " <<itCur->first <<" : " <<itCur->second <<endl;
	cout <<"\nall:\n";
	while( itCur != itEnd && itCur->first == "fifth" )
	{
		cout <<itCur->first <<" : " <<itCur->second <<endl;
		itCur->second = 0;
		//itCur->first = "sdfsdf";		--- змінити ключ НІЗЗЯ
		++itCur;
	}

	cout <<"\n\n\n";
	itCur = oMap.begin();
	itEnd = oMap.end();
	while( itCur != itEnd )
	{
		cout <<itCur->first <<" : " <<itCur->second <<endl;
		++itCur;
	}
	cout <<"\n\n\n";


	cout <<"\n\n\n";
}

