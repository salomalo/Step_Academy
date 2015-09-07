#include "dictionary.h"


void main()
{
	SetConsoleCP( 1251 );
	SetConsoleOutputCP( 1251 );
	//setlocale(LC_ALL,"Russian");
	Dictionary AZ;
	char word[50];
	char translation[50];
	int choise;
	do
	{
		system("cls");
		
		cout<<AZ<<endl;
		cout<<"Which word to translate ? "<<endl;
		cin>>word;
		AZ.find(word);
		if(AZ.find(word)==0)
		{
			cout<<" Add translation : "<<endl;
			cin>>translation;
			AZ.add(word,translation);
		}
		
		cout<<"to delete it?.........1 "<<endl;
		cout<<"to change it?.........2 "<<endl;
		cout<<"to show dictionary....3"<<endl;

		cin>>choise;
		switch(choise)
		{
		case 1:
			AZ.removeByKey(word);
			break;

		case 2:
			AZ.edit(word);
			break;

		case 3:
			cout<<AZ;
			break;
		}

	}while (getch()!=27);


}