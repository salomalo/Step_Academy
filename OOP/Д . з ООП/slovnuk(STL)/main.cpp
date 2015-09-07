#include "dictionary.h"


void main()
{
	//SetConsoleCP( 1251 );
	//SetConsoleOutputCP( 1251 );
	//setlocale(LC_ALL,"Russian");

	Dictionary AZ;
	string key;
	string word;

	AZ.add("word","слово");
	AZ.add("sky","небо");
	AZ.add("sun","сонце");
	AZ.add("rain","дощ");
	AZ.add("flag","прапор");
	AZ.add("friend","друг");
	AZ.add("dog","собака");
	AZ.add("cat","к?т");
	AZ.add("hedgehog","їжак");
	AZ.add("chocolate","шоколад");


	int choise;
	do
	{
		AZ.Show();
		cout<<"Which word to translate ? "<<endl;
		cin>>key;
		AZ.find(key);

		cout<<"to delete it?.........1 "<<endl;
		cout<<"to change it?.........2 "<<endl;
		cout<<"to show dictionary....3"<<endl;

		cin>>choise;
		switch(choise)
		{
		case 1:
			{
				AZ.removeByKey(key);
			}
			break;

		case 2:
			{
				AZ.edit(key);
			}
			break;

		case 3:
			AZ.Show();
			break;
		}

	}while (getch()!=27);


}