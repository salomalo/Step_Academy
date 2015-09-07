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

ofstream & operator << ( ofstream & file, Student & obj )
{
	int sizeName = strlen( obj.Name ) +1 ;
	file.write( (const char *) & sizeName , sizeof( sizeName ) );
	file.write( obj.Name , sizeName );						

	int sizeSurname = strlen( obj.Surname ) +1 ; 
	file.write( (const char *) & sizeSurname , sizeof( sizeSurname ) );	
	file.write( obj.Surname , sizeSurname );						

	return file;
}

ifstream & operator >> ( ifstream & file, Student & obj )
{						
	int sizeName = 0;
	file.read( (char *) & sizeName , sizeof( sizeName ) );	
	delete [] obj.Name;		
	obj.Name = new char [ sizeName ];	
	file.read( obj.Name , sizeName );		


	int sizeSurname = 0;
	file.read( (char *) & sizeSurname , sizeof( sizeSurname ) );	
	delete [] obj.Surname;
	obj.Surname = new char [ sizeSurname ];		
	file.read( obj.Surname , sizeSurname );		

	return file;
}