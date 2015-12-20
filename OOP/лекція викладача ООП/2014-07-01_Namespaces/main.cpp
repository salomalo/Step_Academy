#include <iostream>
#include <iomanip>

//using namespace std;
using std::cout;	// ми оголосили імя cout з простору std, як глобальне


// хедери з одним і тим же простором імен
#include "MyClass.h"
#include "MyClass1.h"


// ми можемо оголисити власне ім'я cout, котре є чимось ЗОВСІМ іншим, ніж std::cout
//const char * cout = "This is cout !";	// але для цього нам потрібно "незайняте" ім'я


const char * text = "This is global variable!";


// оголошуємо власні namespase'и

namespace MyNamespace1
{

	const char * text = "This is variable from 'MyNamespace1' !";


	// простори імен можуть бути вкладеними
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


// так ми зараз зробити не можемо -- бо text з простору імен конфліктує з глобальним іменем text
//
// using namespace MyNamespace1::NestedNamespace2::SuperNestedNamespace;
// using MyNamespace1::NestedNamespace2::SuperNestedNamespace::text;


// псевдонім простору імен
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


	// створюємо об'єкт класу, розташованого у просторі імен
	NamespaceFromHeader::MyClass  obj;
	NamespaceFromHeader::MyClass1 obj1;

	cout <<"\n\n___________ ARRAY ____________\n\n";
	NamespaceFromHeader::MyClass arr [5];

	// оголосивши приватними оператор присвоєння та конструктор копій
	// ми забороняємо їх використання
	// тоді компілятор вкаже нам, коли він не зможе без них обійтися
	//
	//func( obj );
	//arr[3] = obj;

	std::cout <<"\n\n\n";

	
}

