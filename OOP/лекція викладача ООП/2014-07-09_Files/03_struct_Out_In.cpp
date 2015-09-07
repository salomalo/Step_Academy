#include <iostream>
#include <fstream>		// ��� ������ � �������
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



	////////////////////////////   ����� � ���� /////////////////////////////////

	Example source;

	//________________ ���������� �������� ______________
	cout <<"Enter int    first : ";
	cin  >>source.first;

	cout <<"Enter double second : ";
	cin  >>source.second;

	cout <<"Enter char   third : ";
	cin  >>source.third;
	//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^


	//_________________ �������� ���������� ______________
	ofstream fout ( FileName, ios::binary );	// ��������� ���� � ���'����� � ������� ������ � ����
	fout.write( (const char *) &source , sizeof( source ) );	// �������� ���������, ��������� �� ������ �� �����
	fout.close();
	//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^


	////////////////////////////   ������� � ����� /////////////////////////////////
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