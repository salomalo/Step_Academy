#include"Var.h"

Var::Var()
{
	check='0';
	this->iVar=NULL;
	this->dVar=NULL;
	this->sVar=NULL;
}

Var::Var( const int tmp)
{
	check='i';
	this->iVar=tmp;
}

Var::Var( const double tmp)
{
	check='d';
	this->dVar=tmp;
}

Var::Var(const char * const tmp) :sVar(tmp)
{
	check='s';
	//sVar.setStr(tmp);
}


/////////////////////////////////////////////////////////////////////

ostream & operator << (ostream & left, Var  right)
{
	switch (right.check)
	{

	case 'i':
		left << right.iVar;
		return left;
		break;

	case 'd':
		left << right.dVar;
		return left;
		break;

	case 's':	
		left << right.sVar;
		return left;
		break;
	}
}


//istream & operator >> ( istream & left, Var & right )
//{
//	switch (right.check)	//	визначаємо де зберігається змінна яку додаємо
//	{
//
//	case 'i':
//		rewind(stdin);
//		cin >> right.iVar;
//	/*	return left;*/
//		break;
//
//	case 'd':
//		cin >> right.dVar;
//		/*return left;*/
//		break;
//
//	case 's':	
//		char buff [ 255 ];
//		left.getline( buff, 255 );
//		right.sVar.setStr(buff);
//		/*return left;*/
//		break;
//	}
//	return left;
//}

//////////////////////////////////////////////////







Var::operator int()
{
	switch (check)
	{
	case 'i':
		return iVar;
		break;

	case 'd':
		return dVar;
		break;

	case 's':
		return /*sVar*/   atoi(this->sVar);
		break;
	}
}

Var::operator double()
{
	switch (check)
	{
	case 'i':
		return iVar;
		break;
	case 'd':
		return dVar;
		break;
	case 's':
		return /*sVar*/   atof(this->sVar);
		break;
	}
}


//////////////////////////////////////////////////////////////////////////////////

Var Var:: operator + (Var & right)
{
	switch (check)
	{
	case 'i':
		switch (right.check)
		{
			int temp;
		case 'i':
			temp = this->iVar + right.iVar;
			return Var(temp);
			break;

		case 'd':
			temp = this->iVar + right.dVar;		
			return Var (temp);
			break;

		case 's':	
			temp = (this->iVar + (int)right.sVar);
			return Var (temp);
			break;
		}

	case 'd':

		switch (right.check)	
		{
			double temp;
		case 'i':
			temp = this->dVar + right.iVar;
			return Var (temp);
			break;

		case 'd':
			temp = dVar + right.dVar;		
			return Var (temp);
			break;

		case 's':	
			temp = dVar +  (double) right.sVar;
			return Var (temp);
			break;
		}

	case 's':
		xString temp;
		switch (right.check)	
		{
		case 'i':
			temp = this->sVar +  right.iVar;
			return Var ( (char *)temp);
			break;

		case 'd':
			temp = this->sVar +right.dVar;	
			return Var ( (char *) temp);
			break;

		case 's':	
			temp = this->sVar + right.sVar;
			return Var ( (char *) temp);
			break;
		}
	}
}