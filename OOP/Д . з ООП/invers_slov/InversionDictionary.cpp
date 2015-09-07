#include "InversionDictionary.h";

void InversionDictionary::Show()
{
	int num =1;
	set <string, MyFunctor> :: iterator itCur=word.begin();
	set <string, MyFunctor> :: iterator itEnd=word.end();

	while(itCur!=itEnd)
	{
		cout<<num++<<setw(20)<<right<<*itCur<<endl;
		++itCur;
	}
}

void InversionDictionary::Add()
{
	string a;
	cout<<"enter word"<<endl;
	rewind(stdin);
	getline(cin,a);
	
	size_t  error=a.find_first_of("123456789<>?!@#$%^&*()_+ ");

	if( string::npos != error)
	{
		throw 1;
	}
	else
		word.insert(word.begin(),a);
}

void InversionDictionary::Save(char *name)
{
	ofstream fout(name,ios::binary);
	//ofstream fout("newFile",ios::binary);
	if(!fout)
	{
		cout<<"ERROR wrong char"<<endl;
	}

	set <string, MyFunctor> :: iterator itCur=word.begin();
	set <string, MyFunctor> :: iterator itEnd=word.end();
	
	while(itCur!=itEnd)
	{
		fout << *itCur <<endl;
		itCur++;
	}
}

void InversionDictionary::Load(char *name)
{
	ifstream  fin(name,ios::binary);
	//ifstream  fin("NEW",ios::binary);
	if(!fin)
	{
		cout<<"ERROR"<<endl;
	}

	while(fin)
	{
		string tmp;
		getline(fin,tmp);
		if(!fin.eof())
			word.insert(tmp);
	}

}