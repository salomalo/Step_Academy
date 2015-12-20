#include "String.h"

void main()
{
	String str ("qwertyuiop[]asdfghjkkll;;''\\zxcvbnm,./");
	cout <<"content: '" << str <<"'\n";
	cout <<"content[5]: '" <<str[5] <<"'\n";
	str[5] = '#';
	cout <<"content[5]: '" <<str[5] <<"'\n";
	cout <<"content: '" << str <<"'\n";

	cout <<"\n\n-------------- operator ( char, int, int ) --------------\n";
	str( '_', 3, 12 );
	cout <<"content: '" << str <<"'\n";
	str( '$', 5 );
	cout <<"content: '" << str <<"'\n";
	String str2;
	str2 = "dgdfgsdfgfhdsf";	// якщо немає оператора присвоєння такого типу, а є конструктор з одним параметром, то конструктор буде використаний для неявного приведення типів. explicit забороняє використання конструктора для неявного приведення типів
}