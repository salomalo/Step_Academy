#include <iostream>
using namespace std;

#include <iomanip>

#include <fstream>


void main()
{
	char str[255];

//	cin  >> str;
//	cin.getline( str, 255 );
//	cin.getline( str, 255, '$' );	// вказуємо символ-розділювач (кінець рядка)
//	cout <<"\nYou entered: '" <<str  <<'\'' <<endl;


	const char * FileName = "D:\\1qaz.txt";

	/////////////////////////////   ВИВЕДЕННЯ У ФАЙЛ ////////////////

	ofstream fileOut;				// створюємо потік виведення у файл
//	fileOut.open( FileName );		// зв'язуємо потік з конкретним файлом
//	fileOut.open( FileName , ios::out );		// зв'язуємо потік з конкретним файлом ( ios::out -- по замовчуванню, створює пустий файл )
//	fileOut.open( FileName , ios::app );		// зв'язуємо потік з конкретним файлом ( ios::app -- дописує до існуючого, або створює, якщо файла нема)
	fileOut.open( FileName , ios::app | ios::binary );		// зв'язуємо потік з конкретним файлом ( ios::binary -- файл відкривається у бінарному режимі)

	if( ! fileOut )		// якщо потік не готовий (напр.файл не відкрився)
	{
		cout <<"\n\nERROR: stream not ready !\n" <<"File '" <<FileName <<"\n\n\n";
		exit( EXIT_FAILURE );
	}

	//int lineNo = 123456;
	int lineNo = 12;
	while( ! cin.eof() )		// цикл поки не кінець файлу ( cin -- Consloe INput )
	{ 
		cout << "Enter text : ";
		cin.getline( str, 255 );	// зчитує з потоку рядок без символа-розділювача, але виймає його з потоку

		if( ! cin.eof() )
		{
			cout <<"\nYou entered: '" <<str  <<'\'' <<endl;
			fileOut <<"Line " <<setw(5) <<setfill('0') <<lineNo++ <<" : " << str <<'\n';					// виводимо у файл str і символ переводу рядка
		}
	}

	fileOut.close();	// закриваємо файл після завершення роботи з ним
	cout <<"\n\n\n";


	/////////////////////////////   ВВЕДЕННЯ З ФАЙЛУ ////////////////
	ifstream fileIn;			// створюємо потік введення з файлу
	fileIn.open( FileName );	// зв'язуємо потік з конкретним файлом

	while( ! fileIn.eof() )		// цикл поки не кінець файлу
	{
		fileIn.getline( str, 255 );		// зчитує з потоку рядок без символа-розділювача, але виймає його з потоку
		if( ! fileIn.eof() )
			cout <<"\nRead: '" <<str  <<'\'' <<endl;
	}

	cout <<"\n\n\n";
}
