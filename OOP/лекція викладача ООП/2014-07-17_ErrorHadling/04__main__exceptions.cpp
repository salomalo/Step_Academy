#include <iostream>
using namespace std;



void main()
{

	// �� ������ try ������ "���������" ���
	cout <<"Normal main() execution\n\n";


	// � ���� try ��������� ���������� "�����������" ���, ������ ���� ���������� ����������
	try
	{
		cout <<"Start of dangerous code \n";


		// ���� ���������� ���������� ("����������") ���������� throw
		throw '$';		// ��������� ������������ �� throw !!!!
		throw "54.66";	// ��������� ������������ �� throw !!!!
		throw 54.66;	// ��������� ������������ �� throw !!!!
		throw 54;		// ��������� ������������ �� throw !!!!
		// � ������������ ���� � ²���²����� catch

		cout <<"End of dangerous code \n";

	}

	//  cout <<"aything"; -- �� ����� ���Ĳ���� try i catch Ͳ���

	// � ����� catch ��������� ���, ������ �������� ����������

	///////////////////////   ��������� catch  ������� ���� ��� ( ��� ����� � ��� ����� )
	//catch ( ... )	// ��������� catch ������ ��� !  ��� �� �� "����"
	//{
	//	cout <<"Any undefined exception\n Refer to the support team, please!\n";
	//}
	catch ( int e )	
	{
		cout <<"Catched int " <<e <<endl;
	}
	catch ( double e )	
	{
		cout <<"Catched double " <<e <<endl;
	}
	catch ( const char * e )
	{
		cout <<"Catched const char * " <<e <<endl;
	}
	catch ( ... )	// ��������� catch ������ ��� !  ��� �� �� "����"
	{
		cout <<"Any undefined exception\n Refer to the support team, please!\n";
	}




	cout <<"\nmain() finished\n\n\n";

}
