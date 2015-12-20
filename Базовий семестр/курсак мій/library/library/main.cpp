#include"functions.h"

void main()
{
	Console::Title = "Library";//зміна заголовку	
	CursorVisible();
	system("mode con cols=150 lines=80");
	int size=0;
	source*BOOKS=new source[size];
	Menu(BOOKS,size);
}