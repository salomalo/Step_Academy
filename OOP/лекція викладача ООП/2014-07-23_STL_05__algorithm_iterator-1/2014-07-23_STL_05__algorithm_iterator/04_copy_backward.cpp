#include <iostream>
#include <iomanip>

#include <vector>
#include <deque>

#include <algorithm>	// copy_backward
#include <iterator>		// ostream_iterator

using namespace std;




void main()
{
	ostream_iterator<int> itOutInt ( cout , " " );	// ����� �������� �������� �� �������� ����� " | "



	int arr[] = { 11, 22, 33, 44, 55, 66, 77, 88, 99 };

	cout <<"\n\n__________ initialization by iterators __________\n";

	vector<int> oVec( arr, arr + 9 );
	cout <<"oVec  : ";
	copy ( oVec.begin() , oVec.end() , itOutInt );	// ������� � ���� ������ -- ��������� copy ������� ���� ��������: �� ������ ���� ��������
	cout <<endl;

	cout <<"\n\n_______________ copy_backward _________________\n";

	vector<int> oVec2( oVec.size() * 2 );
	cout <<"oVec2 before : ";
	copy ( oVec2.begin() , oVec2.end() , itOutInt );	
	cout <<endl;

	copy_backward( oVec.begin() , oVec.end(), oVec2.end() );	// copy_backward -- ����� � ����������� �������, ��������� � ����

	// ������� � ���� ������ -- ��������� copy ������� ���� ��������: �� ������ ���� ��������
	cout <<"oVec2  after : ";
	copy ( oVec2.begin() , oVec2.end() , itOutInt );	
	cout <<endl;



	cout <<"\n\n\n";
}

