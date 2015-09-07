#include <iostream>
#include <fstream>		// для роботи з файлами
using namespace std;


struct Example
{
	int		first;
	double	second;
	char	third;
};


void main()
{
	const char * FileName = "1qaz_struct.dat";



	////////////////////////////   ЗАПИС У ФАЙЛ /////////////////////////////////

	Example source;

	//________________ заповнюємо струутру ______________
	cout <<"Enter int    first : ";
	cin  >>source.first;

	cout <<"Enter double second : ";
	cin  >>source.second;

	cout <<"Enter char   third : ";
	cin  >>source.third;
	//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^


	//_________________ зберігаємо структруту ______________
	ofstream fout ( FileName, ios::binary );	// створюємо файл і пов'язуємо з потоком виводу у файл
	fout.write( (const char *) &source , sizeof( source ) );	// зберігаємо структуру, передавши її адресу та розмір
	fout.close();
	//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^


	////////////////////////////   ЧИТАННЯ З ФАЙЛУ /////////////////////////////////
	Example dest;
	dest.first = 0;
	dest.second = 0;
	dest.third = 0;

	cout <<"Before: dest.first = " <<dest.first <<endl;
	cout <<"        dest.second = " <<dest.second <<endl;
	cout <<"        dest.third = " <<dest.third <<endl<<endl;

	ifstream fin  ( FileName, ios::binary );
	fin.read( (char *) &dest , sizeof( dest ) );
	fin.close();

	cout <<"After:  dest.first = " <<dest.first <<endl;
	cout <<"        dest.second = " <<dest.second <<endl;
	cout <<"        dest.third = " <<dest.third <<endl;

	cout <<"\n\n\n";
}