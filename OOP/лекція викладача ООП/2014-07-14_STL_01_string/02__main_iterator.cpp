#include <iostream>
#include <string>

using namespace std;

void main()
{
	string sText( "This content only for iterators" );
	cout <<"sText: '" <<sText <<"'\n";

	cout <<"\n\n__________ operator [] _____\n";
	for( int i = 0 ; i < sText.length() ; i++)
		cout <<sText[i] <<"..";

	cout <<"\n\n__________ operator at() _____\n";
	for( int i = 0 ; i < sText.length() ; i++)
		cout <<sText.at(i) <<"..";

	cout <<"\n\n\n";

	cout <<"\n\n__________ iterator _____\n";
	string::iterator itCur = sText.begin();		// ітератор на перший елемент контейнера
	string::iterator itEnd = sText.end();		// ітератор на кінець контейнера (на УЯВНИЙ елемент, котрий ніби то стоїть за останнім елементом )
	while( itCur != itEnd )
	{
		cout <<(*itCur) <<"..";					// "розіменовуючи" ітератор, одержуємо елемнт, на котрий він вказує
		itCur++;
	}
	//itCur++ -- ПОМИЛКА, коли ітератор дійшов до кінця, його не можна ++

	cout <<"\n\n\n";
	cout <<"\n\n__________ reverse iterator _____\n";
	string::reverse_iterator ritCur = sText.rbegin();	// початкове значення реверсного ітерататора -- ОСТАННІЙ елемент
	string::reverse_iterator ritEnd = sText.rend();		// кінцеве значення реверсного ітерататора -- УЯВНИЙ елемент, що нібито стоїть перед першим
	while( ritCur != ritEnd )
	{
		cout <<(*ritCur) <<"..";						// "розіменовуючи" ітератор, одержуємо елемнт, на котрий він вказує
		ritCur++;
	}



	cout <<"\n\n\n";
	cout <<"\n\n__________ modyfying _____\n";
	cout <<"Before: " <<sText <<endl;
	sText[5] = '$';
	sText.at(7) = '#';
	itCur = sText.begin() + 3;
	*itCur = '%';
	ritCur = sText.rbegin() + 5;
	*ritCur = '@';
	ritCur -= 3;
	*ritCur ='_';
	cout <<"After : " <<sText <<endl;


	cout <<"\n\n\n";
	string sInput;
	cout <<"Enter the string : " ;
//	cin  >> sInput;				// string вміє заповнюватися з клавіатури
	getline( cin, sInput );		// string вміє заповнюватися з клавіатури
	cout <<"\nEntered : " <<sInput;




	cout <<"\n\n\n";
}
