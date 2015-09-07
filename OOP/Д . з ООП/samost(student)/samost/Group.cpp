#include"Group.h"

Group::Group(const char*newGroupName,const char*newSpecialiti,int newkurs)
		:GroupName(0),Specialiti(0),kurs(0),stud(0),size(0)
	{
		stud=new Student*[size];
		setGroupName(newGroupName);
		setSpecialiti(newSpecialiti);
		kurs=newkurs;
	}

	void Group::setGroupName(const char* const newGroupName)
	{
		if(GroupName)
			delete []GroupName;
		GroupName=new char[strlen(newGroupName)+1];
		strcpy(GroupName,newGroupName);
	}

	void Group::setSpecialiti(const char* const newSpecialiti)
	{
		if(Specialiti)
			delete []Specialiti;
		Specialiti=new char[strlen(newSpecialiti)+1];
		strcpy(Specialiti,newSpecialiti);
	}

	void Group::addStudent(const char*newName,const char*newSurname)
	{
			size++;
		Student** tmp=new Student*[size];
		for(int i=0; i<size-1; i++)
		{
			tmp[i]=stud[i];
		}
		tmp[size-1]=new Student(newName,newSurname);
		delete [] stud;
		stud=tmp;
	}

	void Group::deleteStudent(const int index)
	{
		size--;
		Student**tmp=new Student*[size];
			for(int i=0; i<index-1; i++)
				tmp[i]=stud[i];
			for(int i=index-1; i<size; i++)
				tmp[i]=stud[i+1];
			delete[]stud;
			stud=tmp;
	
	}
	
	
	Student * Group::getStudent( const int index )
	{
	
	for(int i=0; i<size; i++)
		return stud[index];
	}


	void Group::Show()
	{
		cout<<"GroupName - "<<GroupName<<endl;
		cout<<"Specialiti - "<<Specialiti<<endl;
		cout<<"Kurs - "<<kurs<<endl;
		int index=1;
		
		for(int i=0; i<size; i++)
		{
			cout<<index++<<". "<<stud[i]->getName()<<"  "<<stud[i]->getSurname()<<endl;
		}
	
	}


	void Group::edit(int index,const char*newName,const char*newsurname )
	{

			stud[index]->setName(newName);
			stud[index]->setSurname(newsurname);


	}