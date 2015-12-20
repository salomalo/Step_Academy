#include"Var.h"
Var::Var()
{
	this->i=0;
	this->d=NULL;
	this->content=0;
	this->type='0';
}
Var::Var(const int i)
{
	this->i=i;
	this->d=NULL;
	this->content=0;
	this->type='i';
}
Var::Var (const double d)
{ 
	this->d=d;
	this->i=NULL;
	this->content=1;
	this->type='d';

}	
Var::Var (const char  *const str)
	:content(str)
{
	this->d=NULL;
	this->i=NULL;
	this->type='x';

}

Var::operator int()
{
	switch (type)
	{
	case 'i':
		return i;
		break;
	case 'd':
		return d;
		break;
	case 'x':
		return content;
		break;
	}

}

Var::operator double()
{
	switch (type)
	{
	case 'i':
		return i;
		break;
	case 'd':
		return d;
		break;
	case 'x':
		return content;
		break;
	}
}

Var Var:: operator+ (const Var& i) // коли const Var тоді не відбувається ковертація в double
{

	switch (type)	// визначаэмо тип повернення та змінну до якої додаємл
	{

	case 'i':

		switch (i.type)	//	визначаємо де зберігається змінна яку додаємо
		{
			 int temp;
		case 'i':

			temp = this->i + i.i;
			return Var(temp);


		case 'd':
			temp = this->i + i.d;		
			return Var (temp);
			break;
		case 'x':	
			temp = (this->i + (int)i.content);
			return Var (temp);
			break;
		}

	case 'd':

		switch (i.type)	
		{
			double temp;
		case 'i':
			temp = this->d + i.i;
			return Var (temp);

		case 'd':
			temp = d + i.d;		
			return Var (temp);
		case 'x':	
			temp = d +  (double) i.content;
			return Var (temp);

		}
	case 'x':
		XString temp;
		switch (i.type)	
		{

		case 'i':
			temp = this->content +  i.i; // написати перезагрузку для + в Xstring
			return Var ( (char *)temp);

		case 'd':
			temp = this->content + i.d;	
			return Var ( (char *) temp);
		case 'x':	
			temp = this->content + i.content;
			return Var ( (char *) temp);
		}
	}
}

Var Var:: operator- (const Var& i) // 
{

	switch (type)	// визначаэмо тип повернення та змінну до якої додаємл
	{

	case 'i':

		switch (i.type)	//	визначаємо де зберігається змінна яку додаємо
		{
			 int temp;
		case 'i':

			temp = this->i - i.i;
			return Var(temp);


		case 'd':
			temp = this->i - i.d;		
			return Var (temp);
			break;
		case 'x':	
			temp = (this->i - (int)i.content);
			return Var (temp);
			break;
		}

	case 'd':

		switch (i.type)	
		{
			double temp;
		case 'i':
			temp = this->d - i.i;
			return Var (temp);

		case 'd':
			temp = d - i.d;		
			return Var (temp);
		case 'x':	
			temp = d -  (double) i.content;
			return Var (temp);

		}
	case 'x':
		cout<<"Minus vid Var nemogluvo";
		break;
	}
}

Var Var:: operator* (const Var& i) // коли const Var тоді не відбувається ковертація в double
{

	switch (type)	// визначаэмо тип повернення та змінну до якої додаємл
	{

	case 'i':

		switch (i.type)	//	визначаємо де зберігається змінна яку додаємо
		{
			 int temp;
		case 'i':

			temp = this->i * i.i;
			return Var(temp);


		case 'd':
			temp = this->i * i.d;		
			return Var (temp);
			break;
		case 'x':	
			temp = (this->i * (int)i.content);
			return Var (temp);
			break;
		}

	case 'd':

		switch (i.type)	
		{
			double temp;
		case 'i':
			temp = this->d * i.i;
			return Var (temp);

		case 'd':
			temp = d * i.d;		
			return Var (temp);
		case 'x':	
			temp = d *  (double) i.content;
			return Var (temp);

		}
	case 'x':
		XString temp;
		switch (i.type)	
		{

		//case 'i':
		//	temp = this->content +  i.i; // написати перезагрузку для + в Xstring
		//	return Var ( (char *)temp);

		//case 'd':
		//	temp = this->content + i.d;	
		//	return Var ( (char *) temp);
		case 'x':	
			temp = this->content * i.content;
			return Var ( (char *) temp);
		}
	}
}

Var Var:: operator/ (const Var& i) // коли const Var тоді не відбувається ковертація в double
{

	switch (type)	// визначаэмо тип повернення та змінну до якої додаємл
	{

	case 'i':

		switch (i.type)	//	визначаємо де зберігається змінна яку додаємо
		{
			 int temp;
		case 'i':

			temp = this->i / i.i;
			return Var(temp);


		case 'd':
			temp = this->i / i.d;		
			return Var (temp);
			break;
		case 'x':	
			temp = (this->i / (int)i.content);
			return Var (temp);
			break;
		}

	case 'd':

		switch (i.type)	
		{
			double temp;
		case 'i':
			temp = this->d / i.i;
			return Var (temp);

		case 'd':
			temp = d / i.d;		
			return Var (temp);
		case 'x':	
			temp = d /  (double) i.content;
			return Var (temp);

		}
	case 'x':
		XString temp;
		switch (i.type)	
		{

		//case 'i':
		//	temp = this->content +  i.i; // написати перезагрузку для + в Xstring
		//	return Var ( (char *)temp);

		//case 'd':
		//	temp = this->content + i.d;	
		//	return Var ( (char *) temp);
		case 'x':	
			temp = this->content / i.content;
			return Var ( (char *) temp);
		}
	}
}

Var & Var::operator = (const Var &newVar)
{
	Var Temp;

	int temp;
	switch (type)
	{
	case 'i':
		switch (newVar.type)	//	визначаємо де зберігається змінна яку додаємо
		{
			int temp;
		case 'i':
			i = newVar.i;
			return *this;
		case 'd':
			i = newVar.d;
			return *this;
		case 'x':	
			i = (int) newVar.content;
			return *this;
		}

	case 'd':
		switch (newVar.type)	//	визначаємо де зберігається змінна яку додаємо
		{
			int temp;
		case 'i':
			d = newVar.i;
			return *this;
		case 'd':
			d= newVar.d;
			return *this;
		case 'x':	
			d = ( (double) newVar.content) ;
			return *this;
		}
	case 'x':
		content = newVar.content;
		return *this;
	}
}

bool Var::operator > (const Var &newVar) // коли const Var тоді не відбувається ковертація в double
{

	switch (type)	// визначаэмо тип повернення та змінну до якої додаємл
	{

	case 'i':

		switch (newVar.type)	//	визначаємо де зберігається змінна яку додаємо
		{

		case 'i':
			return (i > newVar.i);

		case 'd':
			return (i > newVar.d);

		case 'x':	
			return ( i > (int) newVar.content);
		}

	case 'd':

		switch (newVar.type)	
		{

		case 'i':
			return (d> newVar.i);

		case 'd':
			return (d > newVar.d);

		case 's':	
			return (d > (double) newVar.content);

		}
	case 'x':
		switch (newVar.type)	
		{

		case 'x':	
			return ( content > newVar.content);
		default:
			cout << "Incorrect type\n";
			exit(1);
		}
	}
}

bool Var::operator < (const Var &newVar) // коли const Var тоді не відбувається ковертація в double
{

	switch (type)	// визначаэмо тип повернення та змінну до якої додаємл
	{

	case 'i':

		switch (newVar.type)	//	визначаємо де зберігається змінна яку додаємо
		{

		case 'i':
			return (i < newVar.i);

		case 'd':
			return (i < newVar.d);

		case 'x':	
			return (i <(int) newVar.content);
		}

	case 'd':

		switch (newVar.type)	
		{

		case 'i':
			return (d< newVar.i);

		case 'd':
			return (d < newVar.d);

		case 's':	
			return (d < (double) newVar.content);

		}
	case 'x':
		switch (newVar.type)	
		{

		case 'x':	
			return ( content < newVar.content);
		default:
			cout << "Incorrect type\n";
			exit(1);
		}
	}
}

bool Var::operator >= (const Var &newVar) // коли const Var тоді не відбувається ковертація в double
{

	switch (type)	// визначаэмо тип повернення та змінну до якої додаємл
	{

	case 'i':

		switch (newVar.type)	//	визначаємо де зберігається змінна яку додаємо
		{

		case 'i':
			return (i >= newVar.i);

		case 'd':
			return (i >= newVar.d);

		case 'x':	
			return ( i >= (int) newVar.content);
		}

	case 'd':

		switch (newVar.type)	
		{

		case 'i':
			return (d>= newVar.i);

		case 'd':
			return (d >= newVar.d);

		case 's':	
			return (d >= (double) newVar.content);

		}
	case 'x':
		switch (newVar.type)	
		{

		case 'x':	
			return ( content >= newVar.content);
		default:
			cout << "Incorrect type\n";
			exit(1);
		}
	}
}

bool Var::operator <= (const Var &newVar) // коли const Var тоді не відбувається ковертація в double
{

	switch (type)	// визначаэмо тип повернення та змінну до якої додаємл
	{

	case 'i':

		switch (newVar.type)	//	визначаємо де зберігається змінна яку додаємо
		{

		case 'i':
			return (i <= newVar.i);

		case 'd':
			return (i <= newVar.d);

		case 'x':	
			return (i <=(int) newVar.content);
		}

	case 'd':

		switch (newVar.type)	
		{

		case 'i':
			return (d<= newVar.i);

		case 'd':
			return (d <= newVar.d);

		case 's':	
			return (d <= (double) newVar.content);

		}
	case 'x':
		switch (newVar.type)	
		{

		case 'x':	
			return ( content <= newVar.content);
		default:
			cout << "Incorrect type\n";
			exit(1);
		}
	}
}

bool Var::operator == (const Var &newVar) // коли const Var тоді не відбувається ковертація в double
{

	switch (type)	// визначаэмо тип повернення та змінну до якої додаємл
	{

	case 'i':

		switch (newVar.type)	//	визначаємо де зберігається змінна яку додаємо
		{

		case 'i':
			return (i == newVar.i);

		case 'd':
			return (i == newVar.d);

		case 'x':	
			return (i == (int) newVar.content);
		}

	case 'd':

		switch (newVar.type)	
		{

		case 'i':
			return (d == newVar.i);

		case 'd':
			return (d == newVar.d);

		case 'x':	
			return (d == (double) newVar.content);

		}
	case 'x':
		switch (newVar.type)	
		{

		case 'x':	
			return ( content == newVar.content);
		default:
			cout << "Incorrect type\n";
			exit(1);
		}
	}
}

bool Var::operator != (const Var &newVar) // коли const Var тоді не відбувається ковертація в double
{

	switch (type)	// визначаэмо тип повернення та змінну до якої додаємл
	{

	case 'i':

		switch (newVar.type)	//	визначаємо де зберігається змінна яку додаємо
		{

		case 'i':
			return (i != newVar.i);

		case 'd':
			return (i != newVar.d);

		case 'x':	
			return (i != (int) newVar.content);
		}

	case 'd':

		switch (newVar.type)	
		{

		case 'i':
			return (d != newVar.d);

		case 'd':
			return (d != newVar.d);

		case 'x':	
			return (d != (double) newVar.content);

		}
	case 'x':
		switch (newVar.type)	
		{

		case 'x':	
			return ( content != newVar.content);
		default:
			cout << "Incorrect type\n";
			exit(1);
		}
	}
}

ostream & operator << ( ostream & left, Var right ) // тут left -- це синонім cout'а
{
	switch (right.type)	//	визначаємо де зберігається змінна яку додаємо
	{

	case 'i':
		left << right.i;
		return left;
		break;

	case 'd':
		left << right.d;
		return left;
		break;

	case 'x':	
		left << right.content;
		return left;
		break;
	}
}

istream & operator >> ( istream & left, Var & right )
{
	switch (right.type)	//	визначаємо де зберігається змінна яку додаємо
	{

	case 'i':
		rewind(stdin);
		cin >> right.i;
		return left;
		break;

	case 'd':
		cin >> right.d;
		return left;
		break;

	case 'x':	
		char buff [ 255 ];
		left.getline( buff, 255 );
		right.content.setString(buff);
		return left;
	}
}

Var Var:: getVar()
{
	return *this;
}