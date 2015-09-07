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

ofstream & operator << ( ofstream & file, Group & obj )/////////////////////////////запис у файл
{
	file.write( (const char *) & obj.kurs , sizeof( obj.kurs ));
	// збережемо розм≥р р¤дка перед самим р¤дком
	int sizeGroupName = strlen( obj.GroupName ) +1 ; // +1 -- щоби автоматично записавс¤ нуль-символ у файл, а пот≥м - ≥ зчитавс¤
	file.write( (const char *) & sizeGroupName , sizeof( sizeGroupName ) );	// збер≥гаЇмо у файл розм≥р р¤дка
	file.write( obj.GroupName , sizeGroupName );							// збер≥гаЇмо у файл сам р¤док

	int sizeSpecialiti = strlen( obj.Specialiti ) +1 ; // +1 -- щоби автоматично записавс¤ нуль-символ у файл, а пот≥м - ≥ зчитавс¤
	file.write( (const char *) & sizeSpecialiti , sizeof( sizeSpecialiti ) );	// збер≥гаЇмо у файл розм≥р р¤дка
	file.write( obj.Specialiti , sizeSpecialiti );							// збер≥гаЇмо у файл сам р¤док

	file.write( (const char *) & obj.size , sizeof( obj.size));
	for(int i=0; i<obj.size; i++)
	{
		file << *(obj.stud[i]);
	}

	return file;
}

void Group::Save()
{
	const char * FileName = "student.txt";
	ofstream fout ( FileName, ios::binary);	// створюЇмо файл ≥ пов'¤зуЇмо з потоком виводу у файл
	fout << *this;
	fout.close();
}


ifstream & operator >> ( ifstream & file, Group & obj )
{
	file.read( (char *) & obj.kurs  , sizeof( obj.kurs  ) );

	int sizeGRName = 0;
	file.read( (char *) & sizeGRName , sizeof( sizeGRName ) );	
	delete [] obj.GroupName;
	obj.GroupName = new char [ sizeGRName ];		 
	file.read( obj.GroupName , sizeGRName );		

	int sizeSpec = 0;
	file.read( (char *) & sizeSpec , sizeof( sizeSpec ) );	
	delete [] obj.Specialiti;
	obj.Specialiti = new char [ sizeSpec ];		
	file.read( obj.Specialiti , sizeSpec );		

	file.read( (char *) & obj.size  , sizeof( obj.size  ) );

	obj.stud = new Student*[obj.size];

	int size;
	char tmpName[255],tmpSurname[255];

	for(int i=0; i<obj.size; i++)
	{
		file.read((char*)&size,sizeof(size));
		file.read( tmpName, size );
		file.read((char*)&size,sizeof(size));
		file.read( tmpSurname, size );
		obj.stud[i] = new Student (tmpName,tmpSurname);
	}

	return file;
}


void Group::Load()
{
	const char * FileName = "student.txt";
	ifstream fin ( FileName, ios::binary);
	fin >> *this;
	fin. close();
}