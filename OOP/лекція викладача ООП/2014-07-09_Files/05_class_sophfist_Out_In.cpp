#include <iostream>
#include <fstream>		// для роботи з файлами
using namespace std;




class Example
{
public:

	Example( int first =0, double second =0, char * third =0 )
		: first(first)
		, second(second)
		, third(0)
	{

		if( third )
		{
			this->third = new char [ strlen( third ) + 1 ];
			strcpy( this->third , third );
		}
		else
		{
			this->third = new char [ 1 ];
			*(this->third) = 0;
		}
	
	}



	friend ofstream & operator << ( ofstream & file, Example & obj )
	{
		// поля first i second зберігаємо традиційно
		file.write( (const char *) & obj.first  , sizeof( obj.first  ) );
		file.write( (const char *) & obj.second , sizeof( obj.second ) );

		// як будемо читати рядок ? Де будемо брати його розмір ??????
		// збережемо розмір рядка перед самим рядком
		int size = strlen( obj.third ) +1 ; // +1 -- щоби автоматично записався нуль-символ у файл, а потім - і зчитався
		file.write( (const char *) & size , sizeof( size ) );	// зберігаємо у файл розмір рядка
		file.write( obj.third , size );							// зберігаємо у файл сам рядок

		return file;
	}



	friend ifstream & operator >> ( ifstream & file, Example & obj )
	{
		// поля first i second читаємо традиційно
		file.read( (char *) & obj.first  , sizeof( obj.first  ) );
		file.read( (char *) & obj.second , sizeof( obj.second ) );

		// перед читанням рядка прочитаємо його довжину
		int size = 0;
		file.read( (char *) & size , sizeof( size ) );	// читаємо з файлу розмір рядка

		// перед читанням рядка -- вивільняємо пам'ять старого рядка !!!!
		delete [] obj.third;

		// і виділяємо пам'ять на новий рядок
		obj.third = new char [ size ];		// в size уже включено місце на нуль-символ! 
		file.read( obj.third , size );		// читаємо з файлу сам рядок
		
		return file;

	}




	void Show()
	{
		cout <<"        first = "  <<first <<endl;
		cout <<"        second = " <<second <<endl;
		cout <<"        third = '"  <<third <<'\''<<endl<<endl;
	}


private:
	int		 first;
	double	 second;
	char	*third;
};






void main()
{
	const char * FileName = "1qaz_class_soph.dat";



	////////////////////////////   ЗАПИС У ФАЙЛ /////////////////////////////////

	int		first;
	double	second;
	char	third [222];

	//________________ заповнюємо клас ______________
	cout <<"Enter int    first : ";
	cin  >>first;

	cout <<"Enter double second : ";
	cin  >>second;

	cin.ignore();
	cout <<"Enter char*  third : ";
	cin.getline( third, 222 );

	Example src( first, second, third );
	cout <<endl <<"Source:" <<endl;
	src.Show();
	cout <<endl;

	//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^


	//_________________ зберігаємо клас НЕПРАВИЛЬНО -- зберігається вказівник, а не рядок !!!!! ______________
	//ofstream fout ( FileName, ios::binary );	// створюємо файл і пов'язуємо з потоком виводу у файл
	//fout.write( (const char *) &src , sizeof( src ) );	// зберігаємо структуру, передавши її адресу та розмір
	//fout.close();
	//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^


	/// ЗБЕРІГАЄМО ПРАВИЛЬНО !
	ofstream fout ( FileName, ios::binary );	// створюємо файл і пов'язуємо з потоком виводу у файл
	fout << src;
	fout.close();



	////////////////////////////   ЧИТАННЯ З ФАЙЛУ /////////////////////////////////
	Example dest;	// пустий об'єкт класу

	cout <<endl <<"Before:" <<endl;
	dest.Show();
	cout <<endl;

	//_________НЕПРАВИЛЬНО -- ЧИТАЄТЬСЯ ВКАЗІВНИК, А НЕ РЯДОК ________
	//ifstream fin  ( FileName, ios::binary );
	//fin.read( (char *) &dest , sizeof( dest ) );
	//fin.close();


	/// ЧИТАЄМО ПРАВИЛЬНО !
	ifstream fin ( FileName, ios::binary );	// створюємо файл і пов'язуємо з потоком виводу у файл
	fin >> dest;
	fin.close();



	cout <<"After:" <<endl;
	dest.Show();


	cout <<"\n\n\n";
}