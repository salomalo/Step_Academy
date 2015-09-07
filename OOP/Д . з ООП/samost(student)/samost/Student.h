#ifndef sTUDENT_H
	#define sTUDENT_H
#include <iostream>
using namespace std;

class Student
{
public:
	Student(const char*newName, const char*newSurname);
	
	Student(Student &src):Name(0),Surname(0)
	{
		setName(src.Name);
		setSurname(src.Surname);
	}

	~Student()
	{
	delete Name;
	delete Surname;
	}

	void setName(const char* const newName);
	void setSurname(const char* const newSurname);
	const char*const getName()const;
	const char*const getSurname()const;

private:
	char*Name;
	char*Surname;
};

#endif