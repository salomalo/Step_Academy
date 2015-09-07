#include "StupidEditor.h"

void Show(StupidEditor &file)
{
	file.Show();
}

void Replace(StupidEditor &file)
{
	string str;
	cout << "enter text to find: "<<endl;
	cin >> str;
	int len=str.length();

	string newstr;
	cout << "enter text to replace: "<<endl;
	cin >> newstr;
	int lennewstr=newstr.length();

	file.replace(str, newstr);
}

void Edit(StupidEditor &file)
{
	file.edit();
}

void AddParagraph(StupidEditor &file)
{
	string tmp;
	cout<<"enter text : "<<endl;
	rewind(stdin);
	getline(cin,tmp);
	file.AddPar(tmp);
}

void Save(StupidEditor &file)
{
	char name[50];

	try
	{
		cout<<"Enter name of your file"<<endl;
		cin>>name;
		for(int i=0; i<strlen(name); i++)
		{
			if(name[i]=='*' || name[i]=='<'||name[i]=='>'||name[i]==':'||name[i]==';'||name[i]=='?')
			{
				throw name[i];
			}
		}
	}
	catch(char a)
	{
		cout<<"ERROR !!! Wrong signe "<< a <<endl;
		cout<<"Try again "<<endl;
		Save(file);
	}

	file.fileSave(name);
}

void Load(StupidEditor &file)
{
	char name[50];
		cout<<"Which file to open : "<<endl;
	cin>>name;
	file.fileRead(name);

}

void ClearFile(StupidEditor &file)
{
	file.ClearFile();
}

void rearranged(StupidEditor &file)
{
	file.rotate();
}

void main()
{
	StupidEditor file;
	while(true)
	{
		system("cls");
		cout<<"To Show...................1"<<endl;
		cout<<"To Add....................2"<<endl;
		cout<<"To Edit...................3"<<endl;
		cout<<"To Replace................4"<<endl;
		cout<<"To rearranged.............5"<<endl;
		cout<<"To ClearFile..............6"<<endl;
		cout<<"To Save...................7"<<endl;
		cout<<"To Load...................8"<<endl;
		int choice;
		//cout<<"choice is - ";
		cin>>choice;

		switch(choice)
		{
		case 1:
			Show(file);
			break;

		case 2:
			AddParagraph(file);
			break;

		case 3:
			Edit(file);
			break;

		case 4:
			Replace(file);
			break;

		case 5:
			rearranged(file);
			break;

		case 6:
			ClearFile(file);
			break;

		case 7:
			Save(file);
			break;

		case 8:
			Load(file);
			break;
		}
		getch();
	}

	cout << endl;
}