#include "XString.h"


void main()

{
	// ��������� ������, ��� ��������������� ���������
	XString * ptr = new XString( "dast ist fantastishe !!!" );
	cout <<"ptr: " <<ptr <<"   '" <<(*ptr) <<"'"<<endl;
	delete ptr;

	// �������� ���������� �������� ��������������� ������ ��� ��������� new
	ptr = new ("___Hello, world!____") XString("Neymovirno!!!!");
	cout <<"ptr: " <<ptr <<"   '" <<(*ptr) <<"'"<<endl;
	delete ptr;

	cout <<"\n\n-------------------- new[] -----------\n";
	XString * arr = new XString [2];
	cout <<"arr[0]: '" <<arr[0] <<"'"<<endl;
	cout <<"arr[1]: '" <<arr[1] <<"'"<<endl;
	delete[] arr;

}
