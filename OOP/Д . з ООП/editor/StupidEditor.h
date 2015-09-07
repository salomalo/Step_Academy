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
	void AddPar(string & tmp);//  додати абзац

	//void fileCreate()
	//{
	//	ofstream fout ( "newFile", ios::binary );
	//}

	//void fileOpen() /////////////////////////////
	//{
	//	ofstream fout ( "newFile", ios::binary );
	//}

	void fileSave(char *name);// зберегти текст у файл 
	void fileRead(char *name);// відкрити існуючий файл 
	void ClearFile();//очистити текст
	void edit(/*int ind*/);//редагувати абзац 
	void replace(string str, string newstr);// знайти і замінити
	void rotate();


private:
	deque <string> paragr;
};