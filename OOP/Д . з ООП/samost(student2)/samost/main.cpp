#include<conio.h>
#include"Student.h"
#include"Group.h"

void main()
{
	char groupName[255],specialiti[255];
	int kurs;

	cout<<"Enter groupName  ";
	cin>>groupName;
	cout<<"Enter specialiti  ";
	cin>>specialiti;
	cout<<"Enter kurs  ";
	cin>>kurs;
	cout<<endl;


	Group gr(groupName,specialiti,kurs);


	int choice;
	while(true)
	{
		system("cls");
		cout<<"to add a student ................1"<<endl;
		cout<<"to delete a student..............2"<<endl;
		cout<<"to show .........................3"<<endl;
		cout<<"to remove .......................4"<<endl;
		cout<<"to edit .........................5"<<endl;
		cout<<"to save .........................6"<<endl;
		cout<<"to load .........................7"<<endl;

		cin>>choice;
		switch(choice)
		{
		case 1: 
			char name[255],surname[255];
			cout<<"Enter name  ";
			cin>>name;
			cout<<"Enter surname  ";
			cin>>surname;
			cout<<endl;
			gr.addStudent(name,surname);
			break;

		case 2:
			int index;
			cout<<"enter which student to delet - "; 
			cin>>index;
			gr.deleteStudent(index);
			break;

		case 3:
			gr.Show();
			getch();
			break;

		case 4:
			int ind;
			cout<<"Which stud to remove: ";
			cin>>ind;
			cout<<gr.getStudent(ind)<<endl;
			break;

		case 5:
			int index1;
			cout<<"Which stud to edit ";
			cin>>index1;
			char newName[255],newsurname[255];
			cout<<"Enter name  ";
			cin>>name;
			cout<<"Enter newsurname  ";
			cin>>surname;
			cout<<endl;
			gr.edit(index1,newName,newsurname);
			break;

		case 6:
			gr.Save();
			break;

		case 7:
			gr.Load();
			break;

		}
	}


}