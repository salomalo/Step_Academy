#include"functions.h"
#define MaxNo_Menu 9

void gotoxy(int xpos, int ypos)
{
	COORD scrn;
	HANDLE hOuput = GetStdHandle(STD_OUTPUT_HANDLE);
	scrn.X = xpos; 
	scrn.Y = ypos;
	SetConsoleCursorPosition(hOuput,scrn);
}

void Menu(source *& BOOKS,int & size)
{
	//ptrF FUNC[]={exit,Load,Add,Frame,Delete,Find,Sort,debtors};
	//   int choice;
	//
	//do
	//   {
	//	system("cls");
	//	cout<<"      "<<endl<<"**********************MAIN MENU*********************"<<endl<<endl;
	//	cout<<"                   Choose an action:"<<endl<<endl;
	//	cout<<"      "<<"Load base from file......................1"<<endl<<endl;
	//	cout<<"      "<<"Add source.......2"<<"      "<<"Delete...........4"<<endl<<endl;
	//	cout<<"      "<<"Print............3"<<"      "<<"Find.............5"<<endl<<endl;
	//	cout<<"      "<<"Sort.............6"<<"      "<<"debtors..........7"<<endl<<endl;
	//	cout<<"      "<<"Save.....................................8"<<endl<<endl;
	//	//cout<<"      "<<"EXIT.....................................esc"<<endl<<endl;//�� ��������
	//	/*int choice;*/
	//	cin>>choice;
	//       if (choice<8)
	//       FUNC[choice](BOOKS,size);

	//   }
	//   while(getch()!=27);



	//do
	//{
	//	system("cls");
	//	cout<<"      "<<endl<<"**********************MAIN MENU*********************"<<endl<<endl;
	//	cout<<"                   Choose an action:"<<endl<<endl;
	//	cout<<"      "<<"Load base from file......................1"<<endl<<endl;
	//	cout<<"      "<<"Add source.......2"<<"      "<<"Delete...........4"<<endl<<endl;
	//	cout<<"      "<<"Print............3"<<"      "<<"Find.............5"<<endl<<endl;
	//	cout<<"      "<<"Sort.............6"<<"      "<<"debtors..........7"<<endl<<endl;
	//	cout<<"      "<<"Save.....................................8"<<endl<<endl;
	//	cout<<"      "<<"EXIT.....................................0"<<endl<<endl;
	//	int choice;
	//	cin>>choice;
	//	switch(choice)
	//	{
	//	case 0:
	//		system("cls");
	//		exit(BOOKS,size);
	//		break;
	//	case 1:
	//		system("cls");
	//		Load(BOOKS,size);
	//		break;
	//	case 2:
	//		system("cls");
	//		Add(BOOKS,size);
	//		break;
	//	case 3: 
	//		system("cls");
	//		Frame(BOOKS,size);
	//		break;
	//	case 4:
	//		system("cls");
	//		Delete(BOOKS,size);
	//		break;
	//	case 5:
	//		system("cls");
	//		Find(BOOKS,size);
	//		break;
	//	case 6:
	//		system("cls");
	//		Sort(BOOKS,size);
	//		break;
	//	case 7:
	//		system("cls");
	//		debtors(BOOKS,size);
	//		break;
	//	case 8:
	//		system("cls");
	//		Save(BOOKS,size);
	//		break;
	//	}
	//}
	//while(getch()!=27);


	system("cls");
	HANDLE hndl=GetStdHandle(STD_OUTPUT_HANDLE);
	char *menu_list[MaxNo_Menu] = {"LOAD","ADD","PRINT","DELETE","FIND","SORT","DEBTORS","SAVE","exit"};
	int i, xpos = 10, ypos[MaxNo_Menu] = {3,6,9,12,15,18,21,24,27};

	for (i=0; i<MaxNo_Menu; ++i)// ����
	{
		gotoxy(xpos, ypos[i]);
		SetConsoleTextAttribute(hndl,FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE);    //���������� ������ ���� ���� �� �� ������� ����
		cprintf("%s",menu_list[i]);
	}

	i=0;// ����� ��� ������ �� ����
	while(true)
	{
		gotoxy(xpos, ypos[i]);
		SetConsoleTextAttribute(hndl, BACKGROUND_RED | BACKGROUND_GREEN | BACKGROUND_BLUE |  BACKGROUND_INTENSITY);//������ ���� ������� ����
		cprintf("%s",menu_list[i] );

		switch(getch()) /* 72-� ����, 75-� �����, 77-� ���, 80-� ��� */
		{
		case 72: // � ����
			if(i>0) 
			{
				gotoxy(xpos,ypos[i] );
				SetConsoleTextAttribute(hndl,FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE);//�� ������� �������� ������ ����� �����
				cprintf("%s", menu_list[i] );
				--i;
			}
			break;
		case 80: //� ���
			if(i< MaxNo_Menu-1 )
			{
				gotoxy(xpos,ypos[i] );
				SetConsoleTextAttribute(hndl,FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE);//�� ������� �������� ������ ����� �����
				cprintf("%s", menu_list[i] );
				++i;
			}
			break;
		case 13: 
			if(i==0) 
			{  
				system("cls");
				gotoxy (10,1); 
				Load(BOOKS,size);
				system("cls");
			}
			if(i==1) 
			{  
				system("cls");
				gotoxy (10,1); 
				Add(BOOKS,size);
				system("cls");
			}
			if(i==2) 
			{ 
				system("cls");
				gotoxy (10,1); 
				Frame(BOOKS,size);
				system("cls");
			}
			if(i==3)
			{ 
				system("cls");
				gotoxy (10,1); 
				Delete(BOOKS,size);
				system("cls");
			}
			if(i==4) 
			{  
				system("cls");
				gotoxy (10,1);  
				Find(BOOKS,size);
				system("cls");
			}
			if(i==5) 
			{  
				system("cls");
				gotoxy (10,1);  
				Sort(BOOKS,size);
				system("cls");
			}
			if(i==6)
			{
				system("cls");
				gotoxy (10,1);  
				debtors(BOOKS,size);
				system("cls");
			}
			if(i==7) 
			{  
				system("cls");
				gotoxy (10,1); 
				Save(BOOKS,size);
				system("cls");
			}
			if(i==8) 
			{  
				system("cls");
				gotoxy (10,1); 
				exit(BOOKS,size);
				system("cls");
			}
			break;
		}
	}



}

void Counter(source *& tmp, int n)
{
	int count=0;
	for(int i=0; i<n; i++)
	{
		count++;
	}
	cout<<"Total: "<<count<<endl;
}

void Fill(source & BOOKS)
{
	BOOKS.AUTHOR.Name=new char[50];
	BOOKS.AUTHOR.Surname=new char[50];
	BOOKS.PUBLICATION.Type=new char[50];
	BOOKS.PUBLICATION.Title=new char[50];
	BOOKS.PUBLICATION.Genre=new char[50];

	cout<<"Type - ";
	cin>>BOOKS.PUBLICATION.Type;
	if(strcmp(BOOKS.PUBLICATION.Type,"magazine")==0 || strcmp(BOOKS.PUBLICATION.Type,"newspaper")==0)
	{
		strcpy(BOOKS.AUTHOR.Name,"-");
		strcpy(BOOKS.AUTHOR.Surname,"-");
		strcpy(BOOKS.PUBLICATION.Genre,"-");
	}
	else
	{
		cout<<"Book genre - ";
		cin>>BOOKS.PUBLICATION.Genre;
		cout<<"Author's name - ";
		cin>>BOOKS.AUTHOR.Name;
		cout<<"Author's Surname - ";
		cin>>BOOKS.AUTHOR.Surname;
	}
	cout<<"Source title - ";
	cin>>BOOKS.PUBLICATION.Title;

	//gets(BOOKS.PUBLICATION.Title);//
	//cin.getline(BOOKS.PUBLICATION.Title,25,'\n');//

	cout<<"Year - ";
	cin>>BOOKS.PUBLICATION.year;
	cout<<"Is Source hear?(+/-)";
	cin>>BOOKS.INFO;
}

//void Print(source & BOOKS,int i)
//{
//	i++;
//	/*cout<<left<<char(186)<<setw(3)<<i<<char(179)<<setw(10)<<BOOKS.AUTHOR.Surname<<char(255)<<setw(10)<<BOOKS.AUTHOR.Name<<char(179)<<setw(11)<<BOOKS.PUBLICATION.Title<<char(179)<<setw(15)<<BOOKS.PUBLICATION.Genre<<char(179)<<setw(10)<<BOOKS.PUBLICATION.Type<<char(179)<<setw(5)<<BOOKS.PUBLICATION.year<<char(179)<<setw(5)<<BOOKS.INFO<<char(186)<<endl;
//*/
//	cout<<i<<" "<<BOOKS.AUTHOR.Surname<<" "<<BOOKS.AUTHOR.Name<<" "<<BOOKS.PUBLICATION.Genre<<" "<<BOOKS.PUBLICATION.Type<<" "<<BOOKS.PUBLICATION.year<<" "<<BOOKS.INFO<<" "<<BOOKS.PUBLICATION.Title<<endl;
//	/*cout<<endl;*/
//}
//
//void Frame(source *& BOOKS,int &size)
//{
//	//cout<<right<<char(201)<<setw(4)<<setfill(char(205))<<char(209)<<setw(22)<<setfill(char(205))<<char(209)<<setw(12)<<setfill(char(205))<<char(209)<<setw(16)<<setfill(char(205))<<char(209)<<setw(11)<<setfill(char(205))<<char(209)<<setw(6)<<setfill(char(205))<<char(209)<<setw(6)<<setfill(char(205))<<char(187)<<setfill(char(' '))<<endl;
//	//cout<<left<<char(186)<<setw(3)<<char(252)<<char(179)<<setw(21)<<"Author name"<<char(179)<<setw(11)<<"Book title"<<char(179)<<setw(15)<<"Genre of book"<<char(179)<<setw(10)<<"Type"<<char(179)<<setw(5)<<"Year"  <<char(179)<<setw(5)<<"Is"   <<char(186)<<endl;
//	for(int i=0; i<size; i++)
//	{
///*		cout<<right<<char(199)<<setw(4)<<setfill(char(196))<<char(197)<<setw(22)<<setfill(char(196))<<char(197)<<setw(12)<<setfill(char(196))<<char(197)<<setw(16)<<setfill(char(196))<<char(197)<<setw(11)<<setfill(char(196))<<char(197)<<setw(6)<<setfill(char(196))<<char(197)<<setw(6)<<setfill(char(196))<<char(182)<<setfill(char(' '))<<endl;
//	*/	Print(BOOKS[i],i);
//	}
//	
//	//cout<<right<<char(200)<<setw(4)<<setfill(char(205))<<char(207)<<setw(22)<<setfill(char(205))<<char(207)<<setw(12)<<setfill(char(205))<<char(207)<<setw(16)<<setfill(char(205))<<char(207)<<setw(11)<<setfill(char(205))<<char(207)<<setw(6)<<setfill(char(205))<<char(207)<<setw(6)<<setfill(char(205))<<char(188)<<setfill(char(' '))<<endl;
//
//}

void Print(source & BOOKS,int i)
{
	i++;
	cout<<left<<char(186)<<setw(3)<<i<<char(179)<<setw(10)<<BOOKS.AUTHOR.Surname<<char(255)<<setw(10)<<BOOKS.AUTHOR.Name<<char(179)<<setw(11)<<BOOKS.PUBLICATION.Title<<char(179)<<setw(15)<<BOOKS.PUBLICATION.Genre<<char(179)<<setw(10)<<BOOKS.PUBLICATION.Type<<char(179)<<setw(5)<<BOOKS.PUBLICATION.year<<char(179)<<setw(5)<<BOOKS.INFO<<char(186)<<endl;
}


void Frame(source *& BOOKS,int &size)
{
	do
	{
		cout<<endl;
		cout<<right<<char(201)<<setw(4)<<setfill(char(205))<<char(209)<<setw(22)<<setfill(char(205))<<char(209)<<setw(12)<<setfill(char(205))<<char(209)<<setw(16)<<setfill(char(205))<<char(209)<<setw(11)<<setfill(char(205))<<char(209)<<setw(6)<<setfill(char(205))<<char(209)<<setw(6)<<setfill(char(205))<<char(187)<<setfill(char(' '))<<endl;
		cout<<left<<char(186)<<setw(3)<<char(252)<<char(179)<<setw(21)<<"Author name"<<char(179)<<setw(11)<<"Book title"<<char(179)<<setw(15)<<"Genre of book"<<char(179)<<setw(10)<<"Type"<<char(179)<<setw(5)<<"Year"  <<char(179)<<setw(5)<<"Is"   <<char(186)<<endl;
		for(int i=0; i<size; i++)
		{
			cout<<right<<char(199)<<setw(4)<<setfill(char(196))<<char(197)<<setw(22)<<setfill(char(196))<<char(197)<<setw(12)<<setfill(char(196))<<char(197)<<setw(16)<<setfill(char(196))<<char(197)<<setw(11)<<setfill(char(196))<<char(197)<<setw(6)<<setfill(char(196))<<char(197)<<setw(6)<<setfill(char(196))<<char(182)<<setfill(char(' '))<<endl;
			Print(BOOKS[i],i);
		}
		cout<<right<<char(200)<<setw(4)<<setfill(char(205))<<char(207)<<setw(22)<<setfill(char(205))<<char(207)<<setw(12)<<setfill(char(205))<<char(207)<<setw(16)<<setfill(char(205))<<char(207)<<setw(11)<<setfill(char(205))<<char(207)<<setw(6)<<setfill(char(205))<<char(207)<<setw(6)<<setfill(char(205))<<char(188)<<setfill(char(' '))<<endl;
	}
	while(getch()!=27);

}




void Copy(source &tmp, source & BOOKS)
{
	tmp.AUTHOR.Name=new char[50];
	tmp.AUTHOR.Surname=new char[50];
	tmp.PUBLICATION.Genre=new char[50];
	tmp.PUBLICATION.Title=new char[50];
	tmp.PUBLICATION.Type=new char[50];
	strcpy(tmp.AUTHOR.Name, BOOKS.AUTHOR.Name);
	strcpy(tmp.AUTHOR.Surname, BOOKS.AUTHOR.Surname);
	strcpy(tmp.PUBLICATION.Genre, BOOKS.PUBLICATION.Genre);
	strcpy(tmp.PUBLICATION.Title, BOOKS.PUBLICATION.Title);
	strcpy(tmp.PUBLICATION.Type, BOOKS.PUBLICATION.Type);
	tmp.PUBLICATION.year=BOOKS.PUBLICATION.year;
	tmp.INFO=BOOKS.INFO;
}

void Add(source *& BOOKS,int & size)
{
	size++;
	source*tmp=new source[size];
	for(int i=0; i<size-1; i++)
	{
		Copy(tmp[i],BOOKS[i]);
	}
	Fill(tmp[size-1]);
	delete[]BOOKS;
	BOOKS=tmp;
}

void Delete(source *& BOOKS,int &size)
{
	do
	{
		system("cls");
		cout<<endl<<"**********************Delete Menu*********************"<<endl;
		cout<<"by number..........1"<<endl;
		cout<<"paper by year......2"<<endl;

		int choice;
		cin>>choice;
		source*tmp=new source[size];
		switch(choice)
		{
		case 1:
			/*system("cls");*/
			int delbook;
			cout<<"which book to delete:"<<endl;
			cin>>delbook;
			size--;
			for(int i=0; i<delbook-1; i++)
				tmp[i]=BOOKS[i];
			for(int i=delbook-1; i<size; i++)
				tmp[i]=BOOKS[i+1];
			delete[]BOOKS;
			BOOKS=tmp;
			Frame(BOOKS,size);
			break;

		case 2: 
			int delyear;
			cout<<"paper from what year to delet"<<endl;
			cin>>delyear;
			for(int i=0; i<size; i++)
			{
				if(strcmp(BOOKS[i].PUBLICATION.Type,"paper")==0 && BOOKS[i].PUBLICATION.year==delyear)
				{
					size--;
					for(int j=0; j<i; j++)
						tmp[j]=BOOKS[j];
					for(int j=i; j<size; j++)
						tmp[j]=BOOKS[j+1];
					delete[]BOOKS;
					BOOKS=tmp;
				}
			}
			break;
		}
	}
	while(getch()!=27);
}

void CreatArry(source *&tmp, source BOOKS, int &n)
{
	n++;
	source*tmp1=new source[n];
	for(int i=0; i<n-1; i++)
	{
		Copy(tmp1[i],tmp[i]);
	}
	Copy(tmp1[n-1],BOOKS);
	delete[]tmp;
	tmp=tmp1;
}

void Find(source *& BOOKS, int &size)
{
	do
	{
		system("cls");
		cout<<endl<<"**********************Finde Menu*********************"<<endl;
		cout<<"all source by  title..................1"<<endl;//�� ���� ����� ��� ������
		cout<<"all author's book ....................2"<<endl;// ����� �� ������
		cout<<"current book by author and title......3"<<endl;// ����� + �� ������ + �� ����
		cout<<"all book by  genre....................4"<<endl;// ����� �� �����
		cout<<"all magazine by title.................5"<<endl;
		cout<<"all magazine by title and year........6"<<endl;

		int choice,n=0;
		cin>>choice;
		source*tmp=new source[n];
		char*key=new char[25];
		char /*key[25],*/keytitle[20];
		bool chek;

		switch(choice)
		{
		case 1:
			system("cls");
			cout<<"Enter Title of source: ";
			cin>>key;

			//gets(key);//
			//cin.getline(key,25,'\n');//

			for(int i=0; i<size; i++)
			{
				if(strcmp(BOOKS[i].PUBLICATION.Title,key)==0)
				{
					chek=true;
					CreatArry(tmp,BOOKS[i],n);
				}
			}
			if(chek!=true)
				cout<<"UNKNOWN source"<<endl;
			system("cls");
			Frame(tmp,n);
			Counter(tmp,n);
			cout<<endl;
			break;

		case 2: 
			system("cls");
			cout<<"Enter Author's Surname of book: ";
			cin>>key;
			for(int i=0; i<size; i++)
			{
				if(strcmp(BOOKS[i].PUBLICATION.Type,"book")==0 && strcmp(BOOKS[i].AUTHOR.Surname,key)==0)
				{
					chek=true;
					CreatArry(tmp,BOOKS[i],n);
				}
			}
			if(chek!=true)
				cout<<"UNKNOWN source"<<endl;
			system("cls");
			Frame(tmp,n);
			Counter(tmp,n);
			cout<<endl;
			break;

		case 3:
			system("cls");
			char keysurname[20];
			cout<<"Enter Author's Surname: ";
			cin>>keysurname;
			cout<<"Enter book title: ";
			cin>>keytitle;
			for(int i=0; i<size; i++)
			{
				if(strcmp(BOOKS[i].PUBLICATION.Type,"book")==0 && strcmp(BOOKS[i].AUTHOR.Surname,keysurname)==0 && strcmp(BOOKS[i].PUBLICATION.Title,keytitle)==0)
				{
					chek=true;
					CreatArry(tmp,BOOKS[i],n);
				}
			}
			if(chek!=true)
				cout<<"UNKNOWN BOOK"<<endl;
			system("cls");	
			Frame(tmp,n);
			Counter(tmp,n);
			cout<<endl;
			break;

		case 4:
			system("cls");
			cout<<"Enter Genre of book: ";
			cin>>key;
			for(int i=0; i<size; i++)
			{
				if(strcmp(BOOKS[i].PUBLICATION.Type,"book")==0 && strcmp(BOOKS[i].PUBLICATION.Genre,key)==0)
				{
					chek=true;
					CreatArry(tmp,BOOKS[i],n);
				}
			}
			if(chek!=true)
				cout<<"UNKNOWN BOOK"<<endl;
			system("cls");
			Frame(tmp,n);
			Counter(tmp,n);
			cout<<endl;
			break;

		case 5:
			system("cls");
			cout<<"Enter magazine title: ";
			cin>>keytitle;
			for(int i=0; i<size; i++)
			{
				if(strcmp(BOOKS[i].PUBLICATION.Type,"magazine")==0 && strcmp(BOOKS[i].PUBLICATION.Title,keytitle)==0)
				{
					chek=true;
					CreatArry(tmp,BOOKS[i],n);
				}
			}
			if(chek!=true)
				cout<<"UNKNOWN source"<<endl;
			system("cls");	
			Frame(tmp,n);
			Counter(tmp,n);
			cout<<endl;
			break;

		case 6:
			system("cls");
			cout<<"Enter magazine title: ";
			cin>>keytitle;
			int key;
			cout<<"Enter year: ";
			cin>>key;
			for(int i=0; i<size; i++)
			{
				if(strcmp(BOOKS[i].PUBLICATION.Type,"magazine")==0 && strcmp(BOOKS[i].PUBLICATION.Title,keytitle)==0 && BOOKS[i].PUBLICATION.year==key)
				{
					chek=true;
					CreatArry(tmp,BOOKS[i],n);
				}
			}
			if(chek!=true)
				cout<<"UNKNOWN source"<<endl;
			system("cls");	
			Frame(tmp,n);
			Counter(tmp,n);
			cout<<endl;
			break;
		}

	}
	while(getch()!=27);
}

void Sort(source *& BOOKS, int &size)
{
	do
	{
		cout<<endl<<"**********************Sort Menu*********************"<<endl;
		cout<<"For sort by Type......1"<<endl;
		cout<<"For sort by Title.....2"<<endl;
		cout<<"return to main manu...........Tab"<<endl;
		int choice=getch();
		cin>>choice;
		source *tmp=new source[size];

		switch(choice)
		{
		case 1:
			for(int i=0; i<size; i++)
			{
				for(int j=i+1; j<size; j++)
				{
					if(strcmp(BOOKS[i].PUBLICATION.Type,BOOKS[j].PUBLICATION.Type)>0)
					{			
						Copy(tmp[i],BOOKS[i]);
						Copy(BOOKS[i],BOOKS[j]);
						Copy(BOOKS[j],tmp[i]);
					}
				}
			}
			Frame(BOOKS,size);
			break;

		case 2:
			for(int i=0;i<size;i++)
			{
				for(int j=i+1;j<size;j++)
				{
					if(strcmp(BOOKS[i].PUBLICATION.Title,BOOKS[j].PUBLICATION.Title)>0)
					{			
						Copy(tmp[i],BOOKS[i]);
						Copy(BOOKS[i],BOOKS[j]);
						Copy(BOOKS[j],tmp[i]);
					}
				}
			}

			Frame(BOOKS,size);
			break;
		case 3:
			break;
		default:
			cout<<"Wrong action"<<endl;
		}
	}
	while(getch()!=27);
}

void debtors(source *& BOOKS, int &size)
{
	do
	{
		system("cls");
		int n=0;
		source *tmp=new source[size];
		bool chek;
		cout<<"debtors of what Author's: ";
		char key[20];
		cin>>key;
		for(int i=0; i<size; i++)
		{
			if(strcmp(BOOKS[i].PUBLICATION.Type,"book")==0 && strcmp(BOOKS[i].AUTHOR.Surname,key)==0 && BOOKS[i].INFO=='-')
			{
				chek=true;
				CreatArry(tmp,BOOKS[i],n);
			}
		}
		if(chek!=true)
			cout<<"UNKNOWN BOOK"<<endl;
		system("cls");
		Frame(tmp,n);
		Counter(tmp,n);
		cout<<endl;
	}
	while(getch()!=27);
}

void CursorVisible()// ������� ��� �������� ������� (using namespace System;)
{
	//bool saveCursorVisibile;
	//int saveCursorSize;
	Console::CursorVisible = true; // Initialize the cursor to visible.
	//saveCursorVisibile = Console::CursorVisible;
	//saveCursorSize = Console::CursorSize;
	Console::CursorSize = 100; // ����� ������� ���� ���� � ����� 1-100
}


void Load(source*& BOOKS,int &size)
{
	do
	{
		cout<<"Library was download"<<endl;
		rewind(stdin);
		FILE*fp;
		fp=fopen("BASE.txt","r");//������� ��� �������
		if((fp=fopen("BASE.txt","r"))==NULL)
		{
			printf("ERROR\n");
			exit(1);
		}
		int tmpsize;
		fscanf(fp,"%d",&tmpsize);
		size=tmpsize;
		delete[]BOOKS;
		BOOKS=new source[size];
		for(int i=0; i<size; i++)
		{
			BOOKS[i].AUTHOR.Surname=new char[50];
			BOOKS[i].AUTHOR.Name=new char[50];
			BOOKS[i].PUBLICATION.Title=new char[50];
			BOOKS[i].PUBLICATION.Genre=new char[50];
			BOOKS[i].PUBLICATION.Type=new char[50];
			fscanf(fp,"%s %s %s %s %s %d %c",BOOKS[i].PUBLICATION.Title, BOOKS[i].AUTHOR.Surname, BOOKS[i].AUTHOR.Name,BOOKS[i].PUBLICATION.Genre, BOOKS[i].PUBLICATION.Type, &BOOKS[i].PUBLICATION.year, &BOOKS[i].INFO);
		}
		fclose(fp);

		/*FILE*fp1;
		fp=fopen("BASE-title.txt","r");
		if((fp1=fopen("BASE-title.txt","r"))==NULL)
		{
		printf("ERROR\n");
		exit(1);
		}

		for(int i=0; i<size; i++)
		{
		BOOKS[i].PUBLICATION.Title=new char[25];
		fgets(BOOKS[i].PUBLICATION.Title,25,fp1);
		}

		fclose(fp1);*/
	}
	while(getch()!=27);
}


void Save(source *&BOOKS, int &size)
{
	do
	{
		cout<<"Library was saved"<<endl;
		FILE*fp;
		fp=fopen("BASE.txt","w");//�������� ����
		if((fp=fopen("BASE.txt","w"))==NULL)
		{
			printf("ERROR\n");
			exit(1);
		}
		fprintf(fp,"%d\n",size);
		for(int i=0; i<size; i++)
		{
			fprintf(fp,"%s %s %s %s %s %d %c\n",BOOKS[i].PUBLICATION.Title,BOOKS[i].AUTHOR.Surname,BOOKS[i].AUTHOR.Name,BOOKS[i].PUBLICATION.Genre,BOOKS[i].PUBLICATION.Type,BOOKS[i].PUBLICATION.year,BOOKS[i].INFO);
		}
		fclose(fp);

		//FILE*fp1;
		//fp=fopen("BASE-title.txt","w");//�������� ����          ��� ��������� ���� ���� �� ������ ���� ��������
		//if((fp1=fopen("BASE-title.txt","w"))==NULL)
		//{
		//	printf("ERROR\n");
		//	exit(1);
		//}
		//for(int i=0; i<size; i++)
		//{
		//	fprintf(fp1,"%s\n",BOOKS[i].PUBLICATION.Title);
		//}
		//fclose(fp1);
	}
	while(getch()!=27);
}

void exit(source *& BOOKS,int &size)
{
	do
	{
		cout<<"Good bye!!!"<<endl;
	}
	while(getch()!=27);
}