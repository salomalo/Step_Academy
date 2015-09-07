#include"StupidEditor.h"

void StupidEditor::AddPar(string & tmp) 
{
	size_t idx=string::npos;
	if( idx > paragr.size())
		paragr.push_back(tmp);
	else
		paragr.insert(paragr.begin(),tmp);
}

void StupidEditor::Show()
{
	int num =1;
	deque <string>::const_iterator itCur=paragr.begin();
	deque <string>::const_iterator itEnd=paragr.end();

	size_t nlinex=0;
	while(itCur!=itEnd)
	{
		cout<<num++<<" "<<*itCur<<endl;
		nlinex+=((*itCur).length()/80+1);
		itCur++;
		if( itCur!=itEnd && nlinex+(*itCur).length()/80+1 > 24) 
		{
			nlinex=0;
			continue;
		}
	}
}

void StupidEditor::fileSave(char *name)
{
	ofstream fout ( name, ios::binary );
	deque <string>::iterator itCur = paragr.begin();
	deque <string>::iterator itEnd = paragr.end();
	while(itCur!=itEnd)
	{
		fout << *itCur <<endl;
		itCur++;
	}
}

void StupidEditor::fileRead(char *name)///////////додати виключенн€
{
	ifstream fin ( name, ios::binary );
	
	paragr.clear();

	while(!fin.eof())
	{
		string tmp;
		getline(fin, tmp);
		if(!fin.eof())
			paragr.push_back(tmp);
	}
}

void StupidEditor::ClearFile()
{
	paragr.clear();
}

void StupidEditor::edit(/*int ind*/)
{
	int ind;
	bool isErr = false;
	do{
		try
		{
			cout<<"which paragraf to edit"<<endl;
			cin>>ind;
			if(ind>=paragr.size())
			{
				throw ind;
			}
			isErr = false;
		}

		catch(int i)
		{
			cout<<"ERROR index "<<i<<endl;
			isErr = true;
		}
	}while(isErr);

	cout<<"Enter new paragr "<<endl;
	cin>>paragr[ind-1];
}

void StupidEditor::replace(string str, string newstr)
{
	int len=str.length();
	int lennewstr=newstr.length();
	deque <string>::iterator itCur = paragr.begin();	
	deque <string>::iterator itEnd = paragr.end();	
	size_t found = itCur->find(str);

	while(itCur!=itEnd)
	{
		while( (found = itCur->find(str)) != string::npos)
		{
			itCur->replace(found, len, newstr, 0, lennewstr);
		}
		itCur++;
	}
}

void StupidEditor::rotate()
{
	deque<string>::iterator itCur = paragr.begin();	// ≥тератор початку
	deque<string>::iterator itCur2 = paragr.begin();// ≥тератор к≥нц€
	
	Show();
	cout<<"\n Enter the line number: ";
	int line = 0;
	cin>>line;
	line--;

	cout<<"\n Where to insert?\n\n";
	int line2 = 0;
	cin>>line2;
	line2--;
	paragr.at(line);
	paragr.at(line2);
	itCur  += line;
	itCur2 += line2;
	if(line2 > line)
	{
		itCur2++;
	}
	paragr.insert(itCur2,paragr.at(line));
	
	deque<string>::iterator itCur3 = paragr.begin();		// ≥тератор к≥нц€
	if(line2 < line)
	{
		line++;
		itCur3+=line;
	}
	else
		itCur3+=line;

	paragr.erase(itCur3);
	Show();
}