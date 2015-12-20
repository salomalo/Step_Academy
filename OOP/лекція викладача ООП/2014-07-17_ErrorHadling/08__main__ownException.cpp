#include <iostream>
#include <string>
using namespace std;



// ���� ��� ��������������
class Monitor
{
public:

	Monitor( string value )
		: name( value )
	{ cout <<"Constructor for '" <<name <<"'\n"; }


	~Monitor()
	{ cout <<"Destructor for '" <<name <<"'\n"; }



private:
	string name;

};



class myException
{
public:
	myException( string msg )
		: txt( msg )
	{}


	myException( myException & eSrc )
	{
		this->txt = eSrc.txt;
		cout <<"\nCopying constructor myException\n\n";
	}


	void Show()
	{ cout <<txt ; }


protected:
	string txt;

};



class DerivedException : public myException
{
public:
	DerivedException( string msg )
		: myException( msg )
	{}


	DerivedException( DerivedException & eSrc )
		: myException( eSrc.txt )
	{
		cout <<"\nCopying constructor DerivedException\n\n";
	}


};







void doIt( string str )
{
	Monitor obj( str );

	if( str.length() > 25 )	// ���� ������� ����� ��������� �������� -- �������� ����������
	{
		cout <<"\nthrow myException( \"ERROR!\" )\n";
		throw myException( "ERROR!" );

		//cout <<"\nthrow DerivedException( \"ERROR!\" )\n";
		//throw DerivedException( "ERROR!" );
	}

	doIt( "___ "+str );
}






void main()
{
	try
	{
		doIt( "test" );
	}
	catch( DerivedException  e )	// ���� "������" ���������� ���� ��������� �����, catch �������� ����� �� ���� ������������ ϲ��� ��� catch �������� �����
	{
		cout <<"Catched DerivedException '";
		e.Show() ;
		cout <<"'\n";
	}
	catch( myException & e )	// catch �������� ����� "������" ���������� �������� �����
	{
		cout <<"Catched myException '";
		e.Show() ;
		cout <<"'\n";
	}
	//catch( DerivedException & e )	
	//{
	//	cout <<"Catched DerivedException '";
	//	e.Show() ;
	//	cout <<"'\n";
	//}


	cout <<"\n\n\n";
}
