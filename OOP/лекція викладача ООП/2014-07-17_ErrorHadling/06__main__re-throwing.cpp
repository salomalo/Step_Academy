#include <iostream>
#include <iomanip>
#include <ctime>
#include <string>
using namespace std;

// ����� ������� "������ ��������"
int doIt() throw() /* <---- ������'�������	 -- ������, �� �-� ������ ���������� */
{
	int rnd = rand() % 21 ;
	if(  rnd > 17 )
	{
		cout <<"throw string ";
		throw string( "Vah-vah-vah" );
	}
	else if( rnd > 8 )
	{
		int eee= 4456;
		//cout <<"throw int ";
		throw eee;	// int'��� ����������
	}
	else if( rnd > 6 )
	{
		const char * eee = "wertbhnfd5rgf";
		//cout <<"throw const char * ";
		throw eee;	// const char * '��� ����������
	}
	else if( rnd > 4 )
	{
		double qwer = 3456.2345;
		//cout <<"throw double ";
		throw qwer;		// double'��� ����������
	}

	return rnd;	// ������� "�������" ��������
}



void doSomething()
{
	for( int i = 0 ; i < 20 ; i++ )
	{
		cout <<'[' <<setw(2) <<i <<"] Calling doIt() ... ";


		try
		{
			int result = doIt(); // ����� doIt() ������� "�������" ��������, ��� ������ ����������

			// �� ���������� ���� ��� �������� ��������� doIt();
			cout <<"succesfully returned " <<result <<endl;
		}
		catch ( int e )
		{
			cout <<"in doSomething() catched int " <<e <<endl;
			throw ; // ��������� �������� �������� ���������� ������ throw ��� ���������  -- ��� ����� ������ ���� � catch
		}
		catch ( double e )
		{
			cout <<"in doSomething() catched double " <<e <<endl;
			throw ; //��������� �������� �������� ���������� ������ throw ��� ���������  -- ��� ����� ������ ���� � catch
		}
		catch ( const char * e )
		{
			cout <<"in doSomething() catched const char * '" <<e <<"'" <<endl;
			throw ; // ��������� �������� �������� ���������� ������ throw ��� ���������  -- ��� ����� ������ ���� � catch
		}


		cout <<endl;

	}

	cout <<"\ndoSomething() finished\n\n";

}





void main()
{
	srand( time(0) );

	try
	{
		doSomething();
	}
	catch ( string e )
	{
		cout <<"in main() catched string '" <<e <<"'" <<endl;
	}
	catch ( int e )
	{
		cout <<"in main() catched int " <<e <<endl;
		//cout <<"file opening error\n";
	}
	catch ( double e )
	{
		cout <<"in main() catched double " <<e <<endl;
		//cout <<"memory allocation error\n";
	}
	catch ( const char * e )
	{
		cout <<"in main() catched const char * '" <<e <<"'" <<endl;
		//cout <<"user input error\n";
	}


	cout <<endl <<endl <<endl;
	cout <<"main finished\n";
	cout <<endl <<endl <<endl;
}

