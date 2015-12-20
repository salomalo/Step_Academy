#include "XString.h"


XString::XString( ) // кнструктор по замовчюванню
{
	content = new char [ 80 ];
	memset( content, '0', 80 );

}

XString::XString( const char* const str ):content(0) //контруктор з стрінгом
{
	if ( this->content) 
		delete [] content;
	content = new char [ strlen( str ) + 1 ];
	strcpy( content, str );
}


XString::XString( XString & oSrc )// констркктор копіювання
{
	content = new char [ strlen( oSrc.content ) + 1 ];
	strcpy( content, oSrc.content );
}


XString::~XString() // деструктор
{
	delete [] content;
}
bool HasChar(char c, const char * str){
	int size = strlen(str);
	for(int i = 0; i < size; i++){
		if(str[i] == c)
			return true;
	}
	return false;
}
XString XString::operator*(const XString &str)			// * спыльны символи
{

	int size = strlen(this->content);
	char * tmp = new char[size + 1];
	int counter = 0;
	for(int i = 0; i < size; i++)
	{
		if(HasChar(this->content[i], str.content))
		{
			tmp[counter++] = this->content[i];
			tmp[counter] = '\0';
		}
	}
	XString result(tmp);
	delete tmp;
	return result;
}

XString XString::operator*=(const XString &str)          // спільні символи і заміна першого рядка символами
{
	//XString temp;
	//temp.content=strpbrk(this->content,str.content);
	int size = strlen(this->content);
	char * tmp = new char[size + 1];
	int counter = 0;
	for(int i = 0; i < size; i++)
	{
		if(HasChar(this->content[i], str.content))
		{
			tmp[counter++] = this->content[i];
			tmp[counter] = '\0';
		}
	}
	XString result(tmp);
	delete tmp;
	strcpy(this->content,result.content);
	return *this;
}

XString XString:: operator/ (const XString &str)    // рядок з ссимволами які не співпадають
{
	int size = strlen(this->content);
	char * tmp = new char[size + 1];
	int counter = 0;
	for(int i = 0; i < size; i++)
	{
		if(!HasChar(this->content[i], str.content))
		{
			tmp[counter++] = this->content[i];
			tmp[counter] = '\0';
		}
	}
	XString result(tmp);
	delete tmp;
	return result;
}

XString XString:: operator/= (const  XString &str)    // перший рядок заміняємо символами які не співпадають
{
	int size = strlen(this->content);
	char * tmp = new char[size + 1];
	int counter = 0;
	for(int i = 0; i < size; i++)
	{
		if(!HasChar(this->content[i], str.content))
		{
			tmp[counter++] = this->content[i];
			tmp[counter] = '\0';
		}
	}
	XString result(tmp);
	delete tmp;
	strcpy(this->content,result.content);
	return *this;
}
XString XString:: operator+ (const  XString &str)					// обєднання рядків
{

	int size = strlen(this->content)+strlen(str.content);
	char * tmp = new char[size + 1];
	int counter = 0;
	strcpy(tmp,this->content);
	strcat(tmp,str.content);
	XString result(tmp);
	delete tmp;
	return result;
}

XString XString:: operator+ (const  int &number)					// обєднання рядків
{
	char *buffer = new char [7];
	itoa(number, buffer, 10);
	int size = strlen(this->content)+strlen(buffer);
	char * tmp = new char[size + 1];
	int counter = 0;
	strcpy(tmp,this->content);
	strcat(tmp,buffer);
	XString result(tmp);
	delete tmp;
	return result;
}

XString	XString::operator + (const double & number)
{
	char *buffer = new char [20];
	sprintf(buffer, "%f", number);
	int size = strlen(this->content)+strlen(buffer);
	char * tmp = new char[size + 1];
	strcpy(tmp,this->content);
	strcat(tmp,buffer);
	XString res(tmp);
	delete [] tmp;
	return res;
}

XString XString:: operator+= ( XString &str)				// обєднання + заміна першого
{
	int size = strlen(this->content)+strlen(str.content);
	char * tmp = new char[size + 1];
	strcpy(tmp,this->content);
	strcat(tmp,str.content);
	XString result(tmp);
	this->content = new char [ strlen( tmp ) + 1 ];//запитати чи вырно присвоъв память
	delete[] tmp;
	strcpy(this->content,result.content);
	return *this;
}

XString	&XString::operator += (const int & number)
{
	char *buffer = new char [7];
	itoa(number, buffer, 10);
	int size = strlen(this->content)+strlen(buffer);
	char * tmp = new char[size + 1];
	int counter = 0;
	strcpy(tmp,this->content);
	strcat(tmp,buffer);
	delete []buffer;
	this->content = new char [ strlen( tmp ) + 1 ];
	strcpy (this->content, tmp);
	return *this;
}

XString	&XString::operator += (const double & number)
{
	char *buffer = new char [20];
	sprintf(buffer, "%f", number);
	int size = strlen(this->content)+strlen(buffer);
	char * tmp = new char[size + 1];
	strcpy (tmp, this->content);
	strcat (tmp, buffer);
	delete [] buffer;
	this->content = new char [ strlen( tmp ) + 1 ];
	strcpy (this->content, tmp);
	return *this;
}

bool XString::operator> (const XString &str)						// порівняння більше
{
	if(strcmp ( this->content, str.content)>0)
		return true;
	else 
		return false;

}

bool XString::operator< (const XString &str)					// порівняння меньше
{
	if(strcmp ( this->content, str.content)<0)
		return true;
	else 
		return false;

}

bool XString::operator>= (const XString &str)				// порівняння >=
{
	if(strcmp ( this->content, str.content)>=0)
		return true;
	else 
		return false;

}

bool XString::operator<= (const XString &str)				//порівняння <=
{
	if(strcmp ( this->content, str.content)<=0)
		return true;
	else 
		return false;
}

bool XString::operator== (const XString &str)
{
	if(strcmp ( this->content, str.content)==0)
		return true;
	else 
		return false;
}

bool XString::operator!= (const XString &str)
{
	if(strcmp ( this->content, str.content)!=0)
		return true;
	else 
		return false;
}

bool XString::operator!= (const int i)
{
	char  str [10];

	if(strcmp ( this->content, itoa( i,str,10))!=0)
		return true;
	else 
		return false;
}

bool XString::operator== (const int &i)
{
	char *  str = new char [10];
	if(strcmp ( this->content, itoa( i,str,10))==0)
		return true;
	else 
		return false;
}

XString XString::operator!()
{
	int size =strlen(this->content);
	char * tmp = new char[size + 1];
	strcpy(tmp,this->content);
	char swap;
	for(int i=0;i<size/2;i++)
	{
		swap=tmp[i];
		tmp[i]=tmp[size-1-i];
		tmp[size-1-i]=swap;
	}
	XString result(tmp);
	delete tmp;
	return result;

}

XString::operator char *()    const                // приведення до типу char*;
{
	return this->content;
}

XString XString::operator= ( const XString & oSrc )// констркктор копіювання
{
	content = new char [ strlen( oSrc.content ) + 1 ];
	return strcpy( content, oSrc.content );
}

XString XString::operator= (const int i )
{
	char str[10];
	itoa( i,str,10);
	XString temp(str);
	strcpy(this->content,temp.content);
	return *this;
}

XString::operator int() const
{
	int convert= atoi(this->content);
	return convert;
}

XString::operator double() const
{
	if (strtod(content,0))	return (strtod(content,0));
	else 
	{
		cout << "Not Valid conversion\n";
		exit(1);
	}
}

void XString::setString (const char *const newstring)
{
	if ( this->content ) 
		delete [] content;
	content = new char [ strlen(newstring) + 1];
	strcpy( content, newstring);
}







ostream & operator << ( ostream & left, XString & right ) // тут left -- це синонім cout'а
{
	left << right.content;
	return left;
}



istream & operator >> ( istream & left, XString & right )
{
	char buff [ 255 ];
	left.getline( buff, 255 );
	delete [] right.content;
	right.content = new char [ strlen( buff ) + 1 ];
	strcpy( right.content, buff );
	return left;
}


// повератає посилання на ОДИН символ XString'а по даному індексу
char& XString::operator[] ( int idx )
{
	if( idx < 0 || idx > strlen( content ) )
	{
		cout <<"\n\nERROR!!!!   XString::operator[] -- index out of range!!!\n\n";
		exit( EXIT_FAILURE );
	}

	return content[idx];

}



// хочемо, щоби замінило символом replace length символів, починаючи з idxStart'ового
void XString::operator() ( int idxStart, int length, char replace )
{
	if( idxStart < 0 || idxStart + length > strlen( content ) || length < 0 )
	{
		cout <<"\n\nERROR!!!!   XString::operator() -- index out of range!!!\n\n";
		exit( EXIT_FAILURE );
	}

	memset( content + idxStart, replace, length );
}


void XString:: Show()
{
	printf("%s",this->content);
}
