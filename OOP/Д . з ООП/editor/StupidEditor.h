#pragma once
#include <deque>
#include <conio.h>
#include <iostream>
#include <string>
#include <fstream>	
#include <sstream>
using namespace std;



class StupidEditor
{
public:
	StupidEditor (){}

	void Show();
	void AddPar(string & tmp);//  ������ �����

	//void fileCreate()
	//{
	//	ofstream fout ( "newFile", ios::binary );
	//}

	//void fileOpen() /////////////////////////////
	//{
	//	ofstream fout ( "newFile", ios::binary );
	//}

	void fileSave(char *name);// �������� ����� � ���� 
	void fileRead(char *name);// ������� �������� ���� 
	void ClearFile();//�������� �����
	void edit(/*int ind*/);//���������� ����� 
	void replace(string str, string newstr);// ������ � �������
	void rotate();


private:
	deque <string> paragr;
};