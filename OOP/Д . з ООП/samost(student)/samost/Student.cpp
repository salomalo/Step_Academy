#include <iostream>
using namespace std;
#include"Student.h"


	Student::Student(const char*newName, const char*newSurname)
		:Name(0),Surname(0)
	{
		setName(newName);
		setSurname(newSurname);
	}


	void Student::setName(const char* const newName)
	{
		if(Name)
			delete []Name;
		Name=new char[strlen(newName)+1];
		strcpy(Name,newName);
	}

	void Student::setSurname(const char* const newSurname)
	{
		if(Surname)
			delete []Surname;
		Surname=new char[strlen(newSurname)+1];
		strcpy(Surname,newSurname);
	}

	const char*const Student::getName()const
	{
		return Name;
	}

	const char*const Student::getSurname()const
	{
		return Surname;
	}