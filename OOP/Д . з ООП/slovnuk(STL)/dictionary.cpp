#include "dictionary.h"

void Dictionary::Show()
{
	map < string , string >::iterator itCur, itEnd;
	itCur = word.begin();
	itEnd = word.end();
	while( itCur != itEnd )
	{
		cout <<itCur->first <<" : " <<itCur->second <<endl;
		++itCur;
	}
	cout <<"\n\n\n";
}

bool Dictionary::add( string key, string  text )
{
	word.insert(pair<string,string>(key,text));
	return true;
}

bool Dictionary:: find( string  keyToFind )
{
	map < string , string >::iterator itCur;
	map < string , string >::iterator itEnd=word.end();

	if((itCur=word.find(keyToFind))!=itEnd )
	{
		cout<<itCur->second<<endl;;
		return true;
	}
	else
	{
		string trans;
		cout<<"enter transletion"<<endl;
		cin>>trans;
		add(keyToFind,trans);
	}
	return true;
}

void Dictionary:: removeByKey( string keyRemove )
{
	word.erase(keyRemove);
}

bool Dictionary:: edit(string keyToFind)
{
	cout<<"Enter new translation"<<endl;
	cin>>word[keyToFind];
	return true;
}