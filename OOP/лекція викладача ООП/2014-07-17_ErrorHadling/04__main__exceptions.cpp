#include <iostream>
using namespace std;



void main()
{

	// за межами try пишемо "безпечний" код
	cout <<"Normal main() execution\n\n";


	// у блок try загортаємо потенційно "небезпечний" код, котрий може спричинити виключення
	try
	{
		cout <<"Start of dangerous code \n";


		// саме виключення генерується ("викидається") оператором throw
		throw '$';		// виконання переривається на throw !!!!
		throw "54.66";	// виконання переривається на throw !!!!
		throw 54.66;	// виконання переривається на throw !!!!
		throw 54;		// виконання переривається на throw !!!!
		// і продовжується ЛИШЕ у ВІДПОВІДНОМУ catch

		cout <<"End of dangerous code \n";

	}

	//  cout <<"aything"; -- НЕ МОЖНА РОЗДІЛЯТИ try i catch НІЧИМ

	// у блоки catch загортаємо код, котрий обробляє виключення

	///////////////////////   дефолтний catch  ставимо після усіх ( але можна і без нього )
	//catch ( ... )	// дефолтний catch ловить УСЕ !  але не дає "улов"
	//{
	//	cout <<"Any undefined exception\n Refer to the support team, please!\n";
	//}
	catch ( int e )	
	{
		cout <<"Catched int " <<e <<endl;
	}
	catch ( double e )	
	{
		cout <<"Catched double " <<e <<endl;
	}
	catch ( const char * e )
	{
		cout <<"Catched const char * " <<e <<endl;
	}
	catch ( ... )	// дефолтний catch ловить УСЕ !  але не дає "улов"
	{
		cout <<"Any undefined exception\n Refer to the support team, please!\n";
	}




	cout <<"\nmain() finished\n\n\n";

}
