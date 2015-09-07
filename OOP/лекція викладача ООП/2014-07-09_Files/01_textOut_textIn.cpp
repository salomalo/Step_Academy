#include <iostream>
using namespace std;

#include <iomanip>

#include <fstream>


void main()
{
	char str[255];

//	cin  >> str;
//	cin.getline( str, 255 );
//	cin.getline( str, 255, '$' );	// ������� ������-��������� (����� �����)
//	cout <<"\nYou entered: '" <<str  <<'\'' <<endl;


	const char * FileName = "D:\\1qaz.txt";

	/////////////////////////////   ��������� � ���� ////////////////

	ofstream fileOut;				// ��������� ���� ��������� � ����
//	fileOut.open( FileName );		// ��'����� ���� � ���������� ������
//	fileOut.open( FileName , ios::out );		// ��'����� ���� � ���������� ������ ( ios::out -- �� ������������, ������� ������ ���� )
//	fileOut.open( FileName , ios::app );		// ��'����� ���� � ���������� ������ ( ios::app -- ������ �� ���������, ��� �������, ���� ����� ����)
	fileOut.open( FileName , ios::app | ios::binary );		// ��'����� ���� � ���������� ������ ( ios::binary -- ���� ����������� � �������� �����)

	if( ! fileOut )		// ���� ���� �� ������� (����.���� �� ��������)
	{
		cout <<"\n\nERROR: stream not ready !\n" <<"File '" <<FileName <<"\n\n\n";
		exit( EXIT_FAILURE );
	}

	//int lineNo = 123456;
	int lineNo = 12;
	while( ! cin.eof() )		// ���� ���� �� ����� ����� ( cin -- Consloe INput )
	{ 
		cout << "Enter text : ";
		cin.getline( str, 255 );	// ����� � ������ ����� ��� �������-����������, ��� ����� ���� � ������

		if( ! cin.eof() )
		{
			cout <<"\nYou entered: '" <<str  <<'\'' <<endl;
			fileOut <<"Line " <<setw(5) <<setfill('0') <<lineNo++ <<" : " << str <<'\n';					// �������� � ���� str � ������ �������� �����
		}
	}

	fileOut.close();	// ��������� ���� ���� ���������� ������ � ���
	cout <<"\n\n\n";


	/////////////////////////////   �������� � ����� ////////////////
	ifstream fileIn;			// ��������� ���� �������� � �����
	fileIn.open( FileName );	// ��'����� ���� � ���������� ������

	while( ! fileIn.eof() )		// ���� ���� �� ����� �����
	{
		fileIn.getline( str, 255 );		// ����� � ������ ����� ��� �������-����������, ��� ����� ���� � ������
		if( ! fileIn.eof() )
			cout <<"\nRead: '" <<str  <<'\'' <<endl;
	}

	cout <<"\n\n\n";
}
