#pragma once

#include "Hoofs.h"
#include "Horns.h"


// ���� Elk ������������� �� ���� ������� �����
class Elk : public Hoofs, public Horns // ������� ������� ����� ��� ������������ ������� ������ ��������� ����� ������������ (� ����������� �����)
{

public:


	Elk( const char * name, short hoofDiameter , short hornsWeight )
		: Hoofs( hoofDiameter )
		, Horns( hornsWeight )
		, Part( "dirty" )		// ���������� ������� ���� ����������� � ���� �������� ������������
	{
		this->name = new char [ strlen( name ) + 1 ];
		strcpy( this->name, name );
		cout <<"Elk (" <<name <<", " <<hoofDiameter <<", " <<hornsWeight <<") constructor.\n";
	}

	~Elk()
	{
		cout <<"Elk (" <<name <<", " <<diameter <<", " <<weight <<") constructor.\n";	// ����������� �� protected, ���� �������� �������
		delete [] name;
	}

	void Show()
	{
		cout <<"Hi! My name is " <<name <<endl
			 <<"I`m Elk. I have '" <<Horns::color <<"' horns. It`s weight " <<weight <<endl
			 <<"I have '" <<Hoofs::color <<"' hoofs too. It`s diameter " <<diameter <<endl
			 <<"And what you have ?\n"
			 <<"&Hoofs::color=" <<(int)Hoofs::color <<endl
			 <<"&Horns::color=" <<(int)Horns::color <<endl
			 <<endl;

	}



protected:
	char * name;

};

