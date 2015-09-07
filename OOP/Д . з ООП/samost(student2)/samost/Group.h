#include"Student.h"

class Group
{
public:

	Group(const char*newGroupName,const char*newSpecialiti,int kurs);

	Group(Group & src)
	{
		setGroupName(src.GroupName);
		setSpecialiti(src.Specialiti);
	}

	~Group()
	{
		delete GroupName;	
		delete Specialiti;
	}

	void setGroupName(const char* const newGroupName);
	void setSpecialiti(const char* const newSpecialiti);
	void addStudent(const char*newName,const char*newSurname);
	void deleteStudent(const int index);
	Student * getStudent( const int index );
	void edit(int index,const char*newName,const char*newsurname);
	void Show();

	void Save();
	friend ofstream & operator << ( ofstream & file, Group & obj );

	void Load();
	friend ifstream & operator >> ( ifstream & file, Group & obj );


private:
	int size;
	char*GroupName;
	char*Specialiti;
	int kurs;
	Student**stud;
};