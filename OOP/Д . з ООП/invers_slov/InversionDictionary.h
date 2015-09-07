#include <iostream>  
#include <set>
#include <string>
#include <iomanip>
#include <fstream>
#include <conio.h>

using namespace std;

class MyFunctor
{
public:

	bool operator () ( string First, string Second )
	{
		string revFr, revSec;
		
		char* newFirst=new char [First.length()+1];
		char* newSecond=new char [Second.length()+1];

		strcpy(newFirst,First.c_str());
		strcpy(newSecond,Second.c_str());

		revFr += strrev(newFirst);
		revSec += strrev(newSecond);

		return (revFr.compare(revSec)<0);
	}
};

class InversionDictionary
 {
 public:
	 void Add();
	 void Save(char *name);
	 void Load(char *name);
	 void Show();

 private:
	 set <string,MyFunctor> word;
};