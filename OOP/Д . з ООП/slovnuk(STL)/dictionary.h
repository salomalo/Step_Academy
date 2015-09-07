#include <iostream>
#include <locale>
#include <conio.h>
#include <windows.h>
#include <map>
#include <string>
using namespace std;

class Dictionary
{

public:
	
	void Show();
	bool add( string key, string  text );
	bool find( string  keyToFind );
	void removeByKey( string keyRemove );
	bool edit(string keyToFind);
	
private:
	 map <string, string> word;
};