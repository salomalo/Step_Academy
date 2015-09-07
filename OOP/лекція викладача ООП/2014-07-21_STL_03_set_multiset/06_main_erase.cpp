#include <iostream>
#include <ctime>

#include <set>		// щоби мати set i multiset

using namespace std;


template <typename TYPE>
void Show( const TYPE & oContainer , const char * name )
{
	cout <<name <<" : ";

	TYPE::const_iterator itCur = oContainer.cbegin();	// константний ітератор не дає можливості змінити елемент контейнера, на котрий вказує (самозахист)
	TYPE::const_iterator itEnd = oContainer.cend();	//  
	while( itCur != itEnd)
	{
		cout <<*itCur <<' ';
		++itCur;
	}
	cout <<endl;
}



void main()
{
	srand( time(0) );


	set<int> oSet;
	multiset<int> oMSet;

	int iVal;
	for( int i = 0 ; i < 22 ; i++ )
	{
		iVal = rand() % 23 - 11;
		cout <<endl <<"adding " <<iVal <<" : " <<endl;

		oSet.insert( iVal );
		Show( oSet ,  " oSet" );
		cout <<"count( " <<iVal <<" ) = " <<oSet.count(iVal )<<endl<<endl;		// скільки iVal є в контейнері на даний момент

		oMSet.insert( iVal );
		Show( oMSet , "oMSet" );
		cout <<"count( " <<iVal <<" ) = " <<oMSet.count(iVal )<<endl<<endl;		// скільки iVal є в контейнері на даний момент

	}
	cout <<"\n\n\n";

	set<int>		 oSet2( oMSet.crbegin() , oMSet.crend() );	//	створюємо новий set на основі існуючого multiset, причому у зворотньому порядку
	multiset<int>	oMSet2( oMSet.crbegin() , oMSet.crend() );	//	створюємо новий set на основі існуючого multiset, причому у зворотньому порядку
	Show( oSet2 , "oSet2" );
	Show( oMSet2 , "oMSet2" );

	cout <<"\n\n\n";


	/////////////////////////////////////////////////////////////////////////////
	///////////     ERASE ////////////////////////





	int iErased;
	for( int i = 0 ; i < 5 ; i++ )
	{
		iVal = rand() % 23 - 11;
		cout <<endl <<"erasing " <<iVal <<" : " <<endl;

		iErased = oSet.erase( iVal );
		Show( oSet ,  " oSet" );
		cout <<"erased "<<iErased <<endl<<endl;		// скільки iVal видалено з контейнера

		iErased = oMSet.erase( iVal );
		Show( oMSet , "oMSet" );
		cout <<"erased "<<iErased <<endl<<endl;		// скільки iVal видалено з контейнера
	}


	cout <<"\n\n\n";
}

