#include <iostream>
#include <fstream>		// ��� ������ � �������
using namespace std;


void main()
{
	const char * FileName = "1qaz.dat";



	////////////////////////////   ����� � ���� /////////////////////////////////


	int  iVal;
	char cVal;

	cout <<"Enter int  iVal : ";
	cin  >>iVal;

	cout <<"Enter char cVal : ";
	cin  >>cVal;

	ofstream fout ( FileName, ios::binary );	// ��������� �������� ���� � ������ ���'����� � ������ ( ios::out -- �� ������������ )
	// fout << iVal;  -- ��� ����� �� ��������, �� int'��� �������� ���������� �� ����� (�� � �� �����)
	
	// ��� ������ � ����������� ������������ -- �-�� write �������� � ���� ����� �����.
	fout.write( (const char*) &iVal , sizeof(iVal) );		// ������ �������� - ������ ������� (��������� �� const char* )
														// ������ �������� - ����� ����� ���'��, ������ ��������

	fout.write( (const char*) &cVal , sizeof(cVal) );		// ������ �������� - ������ ������� (��������� �� const char* )
														// ������ �������� - ����� ����� ���'��, ������ ��������

	fout.close();

	cout <<"\n\n\n";


	//////////////////////////// ������� � ����� ///////////////////////////
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


	//////////////////////////// -----===== ������� � ����� =====---- ///////////////////////////
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
