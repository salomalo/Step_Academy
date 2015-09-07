#include <iostream>
#include <fstream>		// для роботи з файлами
using namespace std;




class Example
{
public:

	Example( int first =0, double second =0, char third =0 )
		: first(first)
		, second(second)
		, third(third)
	{}


	void Show()
	{
		cout <<"        first = "  <<first <<endl;
		cout <<"        second = " <<second <<endl;
		cout <<"        third = "  <<third <<endl<<endl;
	}


private:
	int		first;
	double	second;
	char	third;
};






void main()
{
	const char * FileName = "1qaz_class.dat";



	////////////////////////////   ЗАПИС У ФАЙЛ /////////////////////////////////

	int		first;
	double	second;
	char	third;

	//________________ заповнюємо клас ______________
	cout <<"Enter int    first : ";
	cin  >>first;

	cout <<"Enter double second : ";
	cin  >>second;

	cout <<"Enter char   third : ";
	cin  >>third;

	Example src( first, second, third );
	cout <<endl <<"Source:" <<endl;
	src.Show();
	cout <<endl;

	//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^


	//_________________ зберігаємо клас ______________
	ofstream fout ( FileName, ios::binary );	// створюємо файл і пов'язуємо з потоком виводу у файл
	fout.write( (const char *) &src , sizeof( src ) );	// зберігаємо структуру, передавши її адресу та розмір
	fout.close();
	//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^


	////////////////////////////   ЧИТАННЯ З ФАЙЛУ /////////////////////////////////
	Example dest;	// пустий об'єкт класу

	cout <<endl <<"Before:" <<endl;
	dest.Show();
	cout <<endl;

	ifstream fin  ( FileName, ios::binary );
	fin.read( (char *) &dest , sizeof( dest ) );
	fin.close();

	cout <<"After:" <<endl;
	dest.Show();


	cout <<"\n\n\n";
}