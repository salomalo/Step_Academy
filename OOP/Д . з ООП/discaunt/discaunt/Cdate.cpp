

#include"Cdate.h"



//Cdate::Cdate() : day(1), month(1), year(1970) {}

Cdate::Cdate( short year, short month, short day )
	: day( day ), month( month ), year( year )
{



}


void Cdate::ShowDate()
{
	printf("%d-%02d-%02d", year, month, day );
}

//void Cdate::setDate()
//{
//
//
//
//
//}



