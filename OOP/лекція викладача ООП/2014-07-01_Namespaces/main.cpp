#include <iostream>
#include <iomanip>

//using namespace std;
using std::cout;	// �� ��������� ��� cout � �������� std, �� ���������


// ������ � ����� � ��� �� ��������� ����
#include "MyClass.h"
#include "MyClass1.h"


// �� ������ ��������� ������ ��'� cout, ����� � ������ ���Ѳ� �����, �� std::cout
//const char * cout = "This is cout !";	// ��� ��� ����� ��� ������� "���������" ��'�


const char * text = "This is global variable!";


// ��������� ����� namespase'�

namespace MyNamespace1
{

	const char * text = "This is variable from 'MyNamespace1' !";


	// �������� ���� ������ ���� ����������
	namespace NestedNamespace
	{
		const char * text = "This is variable from 'NestedNamespace' !";

	}// namespace NestedNamespace

	namespace NestedNamespace2
	{
		const char * text = "This is variable from 'NestedNamespace2' !";

		namespace SuperNestedNamespace
		{
			const char * text = "This is variable from 'SuperNestedNamespace' !";

		}// namespace SuperNestedNamespace

	}// namespace NestedNamespace




}// namespace MyNamespace1


// ��� �� ����� ������� �� ������ -- �� text � �������� ���� �������� � ���������� ������ text
//
// using namespace MyNamespace1::NestedNamespace2::SuperNestedNamespace;
// using MyNamespace1::NestedNamespace2::SuperNestedNamespace::text;


// �������� �������� ����
namespace Short = MyNamespace1::NestedNamespace2::SuperNestedNamespace;

void func( NamespaceFromHeader::MyClass obj )
{

}



void main()
{
	//std::cout <<"Hello, world !\n";
	cout <<"Hello, world !\n";
	std::cout <<cout;		

	std::cout <<"\n\n\n";

	cout <<"Global text = '" <<text <<"'\n";
	cout <<"MyNamespace1`s text = '" <<MyNamespace1::text <<"'\n";
	cout <<"NestedNamespace`s text = '" <<MyNamespace1::NestedNamespace::text <<"'\n";
	cout <<"NestedNamespace2`s text = '" <<MyNamespace1::NestedNamespace2::text<<"'\n";
	cout <<"SuperNestedNamespace`s text = '" <<MyNamespace1::NestedNamespace2::SuperNestedNamespace::text <<"'\n";
	cout <<"Short::text = '" <<Short::text <<"'\n";

	std::cout <<"\n\n\n";


	// ��������� ��'��� �����, ������������� � ������� ����
	NamespaceFromHeader::MyClass  obj;
	NamespaceFromHeader::MyClass1 obj1;

	cout <<"\n\n___________ ARRAY ____________\n\n";
	NamespaceFromHeader::MyClass arr [5];

	// ���������� ���������� �������� ��������� �� ����������� ����
	// �� ����������� �� ������������
	// ��� ��������� ����� ���, ���� �� �� ����� ��� ��� �������
	//
	//func( obj );
	//arr[3] = obj;

	std::cout <<"\n\n\n";

	
}

