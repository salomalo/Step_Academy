#include "InversionDictionary.h"

void main()
{
	InversionDictionary a;

	while(true)
	{
		cout<<"To Show...................1"<<endl;
		cout<<"To Add....................2"<<endl;
		cout<<"To Save...................3"<<endl;
		cout<<"To Load...................4"<<endl;

		int choice;
		cin>>choice;

		switch(choice)
		{
		case 1:			
			a.Show();
			break;

		case 2:
			try
			{
				a.Add();
			}
			catch(int q)
			{
				cout<<"wrong char \n try again"<<endl;
				a.Add();
			}
			break;

		case 3:
			char name[55];
			try
			{
				cout<<"enter file name"<<endl;
				cin>>name;
				for(int i=0; i<strlen(name); i++)
				{
					if(name[i]=='*' || name[i]=='<'||name[i]=='>'||name[i]==':'||name[i]==';'||name[i]=='?')
					{
						throw name[i];
					}
				}
			}
			catch(char t)
			{
				cout<<"ERROR !!! Wrong signe "<< t <<endl;
				cout<<"Try again "<<endl;
				a.Save(name);
			}
			a.Save(name);
			break;

		case 4:
			char Name[50];
			cout<<"Which file to open : "<<endl;
			cin>>Name;
			a.Load(Name);
			break;
		}
	}

	cout<<endl;
}