#include"xString.h"

xString::xString()
{
	string = new char[80];
	memset( string , '\0', 80 );
}

xString::xString(const char * const str)
{
	string = new char[strlen(str)+1];
	string=strcpy(string,str);
}

xString::xString( const xString & oSrc)
{
	string = new char[strlen(oSrc.string)+1];
	strcpy(string,oSrc.string);
}

xString::~xString()
{
	delete[]string;
}

ostream & operator<< (ostream & left, xString & right)
{
	left<<right.string;
	return left;
}

istream & operator>> (istream & left, xString & right)
{
	char buff[255];
	left.getline(buff,255);
	delete [] right.string;
	right.string=new char[strlen(buff)+1];
	strcpy(right.string,buff);
	return left;
}

void xString :: setStr( const char * const str) 
{
	/*if(string)
	delete[] this->string;*/
	
	this->string = new char [strlen(str)+1]; 
	strcpy(this->string,str);
}

char* xString :: getStr() 
{
return string;
}




//xString  xString :: operator ! ()
//{
//	xString tmp;
//	for(int i=0; i<strlen(string); i++)
//	{
//		tmp.string[i]=string[strlen(string)-i-1];
//	}
//	tmp.string[strlen(string)]=string[strlen(string)];
//	return tmp;
//}
//
//bool  xString :: operator > (xString & str)
//{
//	if(strcmp(string,str.string)<0)
//		return true;
//	else
//		return false;
//}
//
//bool  xString :: operator < (xString & str)
//{
//	if(strcmp(string,str.string)>0)
//		return true;
//	else
//		return false;
//}
//
//bool  xString :: operator != (xString & str)
//{
//	if(strcmp(string,str.string)!=0)
//		return true;
//	else 
//		return false;
//}
//
//bool  xString :: operator == (xString & str)
//{
//	if(strcmp(string,str.string)==0)
//		return true;
//	else
//		return false;
//}
//
//bool  xString :: operator <= (xString & str)
//{
//	if(strcmp(string,str.string)==0||strcmp(string,str.string)>0)
//		return true;
//	else
//		return false;
//}
//
//bool  xString :: operator >= (xString & str)
//{
//	if(strcmp(string,str.string)==0||strcmp(string,str.string)<0)
//		return true;
//	else
//		return false;
//
//}

xString ::operator char*()const
{
	return string;
}

//xString  xString :: operator + (xString & str)
//{
//	char* tmp=new char[strlen(str)+strlen(string)+1];
//	tmp=strcpy(tmp,string);
//	tmp=strcat(tmp,str.string);
//	return tmp;
//}
//
//xString  xString :: operator += (xString & str)
//{
//	char* tmp=new char[strlen(str)+strlen(string)+1];
//	tmp=strcpy(tmp,string);
//	tmp=strcat(tmp,str.string);
//	string=tmp;
//	return string;
//}
//
//xString xString :: operator * (xString & str)
//{
//	char* tmp=new char;
//	int u=0;
//	for(int i=0; i<strlen(string); i++)
//	{
//		if(strchr(string, str.string[i]))
//		{
//			tmp[u++]=str.string[i];
//		}
//	}
//	return tmp;
//}
//
//xString xString :: operator *= (xString & str)
//{
//	char* tmp=new char;
//	int u=0;
//	for(int i=0; i<strlen(string); i++)
//	{
//		if(strchr(string, str.string[i]))
//		{
//			tmp[u++]=str.string[i];
//		}
//	}
//	
//	string=strcpy(string,tmp);
//	return string;
//}
//
//xString xString :: operator / ( xString & str)
//{
//	char* tmp=new char;
//	int n=0;
//	int u=0;
//	for(int i=0; i<strlen(string); i++)
//	{
//		if(!strchr(string, str.string[i]))
//		{
//			n++;
//			tmp[u++]=string[i];
//		}
//	}
//	tmp[u]=0;
//	return tmp;
//}
//
//xString xString :: operator /= ( xString & str)
//{
//	char* tmp=new char;
//	int n=0;
//	int u=0;
//	for(int i=0; i<strlen(string); i++)
//	{
//		if(!strchr(string, str.string[i]))
//		{
//			n++;
//			tmp[u++]=string[i];
//		}
//	}
//	tmp[u]=0;
//	
//	string=strcpy(string,tmp);
//	return string;
//}

xString::operator int() const
{
	/*char* str=new char[80];
	str=(char*)this->content;*/
	int convert= atoi(this->string);
	return convert;/*}*/
//			char* str=new char[80];
//			str=i.content.toChar();
//			convert=atoi (str);
//			tmp=this->i+convert;
//			Var temp(tmp);
	
	
	
	/*else 
	{
		cout << "Not Valid conversion\n";
		exit(1);
	}*/
}

xString::operator double() const
{
	if (strtod(string,0))	return (strtod(string,0));
	else 
	{
		cout << "Not Valid conversion\n";
		exit(1);
	}
}


xString xString:: operator+ (const  int &number)					// обєднання рядків
{
	char *buffer = new char [7];
	itoa(number, buffer, 10);
	int size = strlen(this->string)+strlen(buffer);
	char * tmp = new char[size + 1];
	int counter = 0;
	strcpy(tmp,this->string);
	strcat(tmp,buffer);
	xString result(tmp);
	delete tmp;
	return result;
}

xString	xString::operator + (const double & number)
{
	char *buffer = new char [20];
	sprintf(buffer, "%f", number);
	int size = strlen(this->string)+strlen(buffer);
	char * tmp = new char[size + 1];
	strcpy(tmp,this->string);
	strcat(tmp,buffer);
	xString res(tmp);
	delete [] tmp;
	return res;
}


xString xString:: operator+ (const  xString &str)					// обєднання рядків
{

	int size = strlen(this->string)+strlen(str.string);
	char * tmp = new char[size + 1];
	int counter = 0;
	strcpy(tmp,this->string);
	strcat(tmp,str.string);
	xString result(tmp);
	delete tmp;
	return result;
}