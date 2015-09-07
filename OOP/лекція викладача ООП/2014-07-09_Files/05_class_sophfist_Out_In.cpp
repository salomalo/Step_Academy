#include <iostream>
#include <fstream>		// ��� ������ � �������
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
		// ���� first i second �������� ����������
		file.write( (const char *) & obj.first  , sizeof( obj.first  ) );
		file.write( (const char *) & obj.second , sizeof( obj.second ) );

		// �� ������ ������ ����� ? �� ������ ����� ���� ����� ??????
		// ��������� ����� ����� ����� ����� ������
		int size = strlen( obj.third ) +1 ; // +1 -- ���� ����������� ��������� ����-������ � ����, � ���� - � ��������
		file.write( (const char *) & size , sizeof( size ) );	// �������� � ���� ����� �����
		file.write( obj.third , size );							// �������� � ���� ��� �����

		return file;
	}



	friend ifstream & operator >> ( ifstream & file, Example & obj )
	{
		// ���� first i second ������ ����������
		file.read( (char *) & obj.first  , sizeof( obj.first  ) );
		file.read( (char *) & obj.second , sizeof( obj.second ) );

		// ����� �������� ����� ��������� ���� �������
		int size = 0;
		file.read( (char *) & size , sizeof( size ) );	// ������ � ����� ����� �����

		// ����� �������� ����� -- ���������� ���'��� ������� ����� !!!!
		delete [] obj.third;

		// � �������� ���'��� �� ����� �����
		obj.third = new char [ size ];		// � size ��� �������� ���� �� ����-������! 
		file.read( obj.third , size );		// ������ � ����� ��� �����
		
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



	////////////////////////////   ����� � ���� /////////////////////////////////

	int		first;
	double	second;
	char	third [222];

	//________________ ���������� ���� ______________
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


	//_________________ �������� ���� ����������� -- ���������� ��������, � �� ����� !!!!! ______________
	//ofstream fout ( FileName, ios::binary );	// ��������� ���� � ���'����� � ������� ������ � ����
	//fout.write( (const char *) &src , sizeof( src ) );	// �������� ���������, ��������� �� ������ �� �����
	//fout.close();
	//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^


	/// ���в����� ��������� !
	ofstream fout ( FileName, ios::binary );	// ��������� ���� � ���'����� � ������� ������ � ����
	fout << src;
	fout.close();



	////////////////////////////   ������� � ����� /////////////////////////////////
	Example dest;	// ������ ��'��� �����

	cout <<endl <<"Before:" <<endl;
	dest.Show();
	cout <<endl;

	//_________����������� -- ��������� ���ǲ����, � �� ����� ________
	//ifstream fin  ( FileName, ios::binary );
	//fin.read( (char *) &dest , sizeof( dest ) );
	//fin.close();


	/// ������� ��������� !
	ifstream fin ( FileName, ios::binary );	// ��������� ���� � ���'����� � ������� ������ � ����
	fin >> dest;
	fin.close();



	cout <<"After:" <<endl;
	dest.Show();


	cout <<"\n\n\n";
}