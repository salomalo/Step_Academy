#include "dictionary.h"


void main()
{
	//SetConsoleCP( 1251 );
	//SetConsoleOutputCP( 1251 );
	//setlocale(LC_ALL,"Russian");

	Dictionary AZ;
	string key;
	string word;

	AZ.add("word","᫮��");
	AZ.add("sky","����");
	AZ.add("sun","ᮭ�");
	AZ.add("rain","���");
	AZ.add("flag","�࠯��");
	AZ.add("friend","���");
	AZ.add("dog","ᮡ���");
	AZ.add("cat","�?�");
	AZ.add("hedgehog","����");
	AZ.add("chocolate","讪����");


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