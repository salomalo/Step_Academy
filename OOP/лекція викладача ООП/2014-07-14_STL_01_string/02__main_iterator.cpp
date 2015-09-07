#include <iostream>
#include <string>

using namespace std;

void main()
{
	string sText( "This content only for iterators" );
	cout <<"sText: '" <<sText <<"'\n";

	cout <<"\n\n__________ operator [] _____\n";
	for( int i = 0 ; i < sText.length() ; i++)
		cout <<sText[i] <<"..";

	cout <<"\n\n__________ operator at() _____\n";
	for( int i = 0 ; i < sText.length() ; i++)
		cout <<sText.at(i) <<"..";

	cout <<"\n\n\n";

	cout <<"\n\n__________ iterator _____\n";
	string::iterator itCur = sText.begin();		// �������� �� ������ ������� ����������
	string::iterator itEnd = sText.end();		// �������� �� ����� ���������� (�� ������ �������, ������ ��� �� ����� �� ������� ��������� )
	while( itCur != itEnd )
	{
		cout <<(*itCur) <<"..";					// "������������" ��������, �������� ������, �� ������ �� �����
		itCur++;
	}
	//itCur++ -- �������, ���� �������� ����� �� ����, ���� �� ����� ++

	cout <<"\n\n\n";
	cout <<"\n\n__________ reverse iterator _____\n";
	string::reverse_iterator ritCur = sText.rbegin();	// ��������� �������� ���������� ����������� -- �����Ͳ� �������
	string::reverse_iterator ritEnd = sText.rend();		// ������ �������� ���������� ����������� -- ������ �������, �� ����� ����� ����� ������
	while( ritCur != ritEnd )
	{
		cout <<(*ritCur) <<"..";						// "������������" ��������, �������� ������, �� ������ �� �����
		ritCur++;
	}



	cout <<"\n\n\n";
	cout <<"\n\n__________ modyfying _____\n";
	cout <<"Before: " <<sText <<endl;
	sText[5] = '$';
	sText.at(7) = '#';
	itCur = sText.begin() + 3;
	*itCur = '%';
	ritCur = sText.rbegin() + 5;
	*ritCur = '@';
	ritCur -= 3;
	*ritCur ='_';
	cout <<"After : " <<sText <<endl;


	cout <<"\n\n\n";
	string sInput;
	cout <<"Enter the string : " ;
//	cin  >> sInput;				// string �쳺 ������������� � ���������
	getline( cin, sInput );		// string �쳺 ������������� � ���������
	cout <<"\nEntered : " <<sInput;




	cout <<"\n\n\n";
}
