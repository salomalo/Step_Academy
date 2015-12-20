#include "MyClass1.h"

#include <iostream>



// реалізація методу класу поза класом ( в файлі *.cpp )
NamespaceFromHeader::MyClass1::MyClass1()
{
	std::cout <<"\n\nConstructor MyClass1 !!!\n\n";
}


