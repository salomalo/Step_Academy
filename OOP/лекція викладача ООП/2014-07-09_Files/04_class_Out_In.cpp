#include <iostream>
#include <fstream>		// ��� ������ � �������
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



	////////////////////////////   ����� � ���� /////////////////////////////////

	int		first;
	double	second;
	char	third;

	//________________ ���������� ���� ______________
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


	//_________________ �������� ���� ______________
	ofstream fout ( FileName, ios::binary );	// ��������� ���� � ���'����� � ������� ������ � ����
	fout.write( (const char *) &src , sizeof( src ) );	// �������� ���������, ��������� �� ������ �� �����
	fout.close();
	//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^


	////////////////////////////   ������� � ����� /////////////////////////////////
	Example dest;	// ������ ��'��� �����

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