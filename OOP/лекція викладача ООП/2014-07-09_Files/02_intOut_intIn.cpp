#include <iostream>
#include <fstream>		// для роботи з файлами
using namespace std;


void main()
{
	const char * FileName = "1qaz.dat";



	////////////////////////////   ЗАПИС У ФАЙЛ /////////////////////////////////


	int  iVal;
	char cVal;

	cout <<"Enter int  iVal : ";
	cin  >>iVal;

	cout <<"Enter char cVal : ";
	cin  >>cVal;

	ofstream fout ( FileName, ios::binary );	// створюємо файловий потік і одразу пов'язуємо з файлом ( ios::out -- по замовчуванню )
	// fout << iVal;  -- цей спосіб не підходить, бо int'ове значення зберігається як текст (як і на екран)
	
	// для запису у внутрішньому представленні -- ф-єю write записуємо у файл кусок памяті.
	fout.write( (const char*) &iVal , sizeof(iVal) );		// перший параметр - адреса початку (приводимо до const char* )
														// другий параметр - розмір блоку пам'яті, котрий зберігаємо

	fout.write( (const char*) &cVal , sizeof(cVal) );		// перший параметр - адреса початку (приводимо до const char* )
														// другий параметр - розмір блоку пам'яті, котрий зберігаємо

	fout.close();

	cout <<"\n\n\n";


	//////////////////////////// ЧИТАННЯ З ФАЙЛУ ///////////////////////////
	int  iRead = 0;
	char cRead = 0;
	cout <<"before iRead=" <<iRead <<endl;
	cout <<"       cRead=" <<cRead <<endl;

	ifstream fin( FileName , ios::binary );

	fin.read( (char *) &iRead , sizeof( iRead ) );
	fin.read( (char *) &cRead , sizeof( cRead ) );

	cout <<"after  iRead=" <<iRead <<endl;
	cout <<"       cRead=" <<cRead <<endl;

	fin.close();

	cout <<"\n\n\n";


	//////////////////////////// -----===== ЧИТАННЯ З ФАЙЛУ =====---- ///////////////////////////
	iRead = 0;
	cRead = 0;
	cout <<"_______BAD______\n";
	cout <<"before iRead=" <<iRead <<endl;
	cout <<"       cRead=" <<cRead <<endl;

	fin.open( FileName , ios::binary );

	fin.read( (char *) &cRead , sizeof( cRead ) );
	fin.read( (char *) &iRead , sizeof( iRead ) );

	cout <<"after  iRead=" <<iRead <<endl;
	cout <<"       cRead=" <<cRead <<endl;

	fin.close();




	cout <<"\n\n\n";
}
