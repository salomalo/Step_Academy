#include <iostream>
#include <ctime>

#include <set>		// щоби мати set i multiset

using namespace std;


//////////////////////////////////////////////////////////////////
// ФУНКТОР (фунціональний об'єкт ) -- об'єкт, у якому є перевантажений operator()
// він має приймати ДВА (бінарний функтор ) або ОДНЕ (унарний) значення типу вмісту контейнера
// а повертає -- bool
// використовується для порівняння елементів контейнерів
// для set i multiset він має повертати true, коли перший арг-т має стояти ПЕРЕД другим
//////////////////////////////////////////////////////////////////
class MyFunctor
{
public:

	bool operator () ( int iFirst, int iSecond )
	{
		return iFirst > iSecond;	
		//return iFirst < iSecond;	// ось це -- аналог стандартного less<int>, котрий викор-ся по замовчуванню у set i multiset
	}


};
//////////////////////////////////////////////////////////////////




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

	////////////////  використовуємо функтор -- передаємо цілий клас як другий типовий параметр /////////////////
	set<int , MyFunctor>		oSet;
	multiset<int , MyFunctor>	oMSet;

	int iVal;
	for( int i = 0 ; i < 22 ; i++ )
	{
		iVal = rand() % 23 - 11;
		cout <<endl <<"adding " <<iVal <<" : " <<endl;

		oSet.insert( iVal );
		Show( oSet ,  " oSet" );

		oMSet.insert( iVal );
		Show( oMSet , "oMSet" );

	}
	cout <<"\n\n\n";

	set<int  , MyFunctor>		 oSet2( oMSet.crbegin() , oMSet.crend() );	//	створюємо новий set на основі існуючого multiset, причому у зворотньому порядку
	multiset<int  , MyFunctor>	oMSet2( oMSet.crbegin() , oMSet.crend() );	//	створюємо новий set на основі існуючого multiset, причому у зворотньому порядку
	Show( oSet2 , "oSet2" );
	Show( oMSet2 , "oMSet2" );


	cout <<"\n\n\n";
}

