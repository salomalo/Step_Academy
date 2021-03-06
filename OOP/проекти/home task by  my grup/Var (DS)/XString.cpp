#include"XString.h"


XString::XString()
{
	str = new char [80];
	memset( str , '\0', 80 );
}

XString::XString(const char* const strX)
{
	str = new char [ strlen( strX ) + 1 ];
	strcpy( str, strX );
}



XString::XString( XString & obj )
{
	str = new char [ strlen( obj.str ) + 1 ];
	strcpy( str, obj.str );
}


XString::~XString()
{
	delete [] str;
}

void XString::show()const
{
	cout<<str<<endl;
}

XString XString::operator * (XString& String2)
{
	XString temp;
	int i = 0;
	char * ptr = strpbrk (this->str, String2.str);
	
     while (ptr != NULL)                                        
	 {
		 temp.str[i] = *ptr;
		 ptr = strpbrk (ptr+1,String2.str);   
		 i++;
     }
	return temp;
}

XString XString::operator / (XString& String2)
{
	XString temp;
	int j = 0;
	char * ptr;
	int i = 0;
	int s = strlen(str);

     while (s != 0)                                        
	 {
		 ptr = strchr (String2.str,str[i]);   
		 if(ptr == NULL)
		 {
			 temp.str[j] = str[i];
			 j++;
		 }
		 i++;
		 s--;
     }
	 return temp;
}


XString XString::operator + (XString& String2)
{

	XString temp;
	strcat(temp.str,str);
	strcat(temp.str,String2.str);
	return temp;
}


XString XString::operator += (XString& String2)
{

	XString temp;
	strcat(temp.str,str);
	strcat(temp.str,String2.str);
	delete [] this->str;
	this->str = new char [strlen(temp.str)+1];
	strcpy(str, temp.str);
	
	return *this;
}


XString XString::operator /= (XString& String2)
{
	char * ptr;
	int i = 0;
	int s = strlen(str);
	XString temp;
	int j = 0;
     while (s != 0)                                        
	 {
		 ptr = strchr (String2.str,str[i]);   
		 if(ptr == NULL)
		 {
			 
			 temp.str[j] = str[i];
			 j++;
		 }
		 i++;
		 s--;
     }
	 strcpy(str,temp.str);
	return *this; 
}


XString XString::operator *= (XString& String2)
{
	int j = 0;
	char * ptr = strpbrk (this->str, String2.str);
	XString temp;
     while (ptr != NULL)                                        
	 {
		  temp.str[j] = *ptr;
		 ptr = strpbrk (ptr+1,String2.str);   
		 j++;
     }
	 strcpy(str,temp.str);
	return *this;
}

bool XString::operator >  ( XString& String2 )
{
	int temp = strcmp(this->str,String2.str);
	if(temp > 0)
		return true;

	return false;
}

bool XString::operator >=  ( XString& String2 )
{
	int temp = strcmp(this->str,String2.str);
	
	if(temp > 0 || temp == 0)
		return true;

	return false;
}

bool XString::operator <  ( XString& String2 )
{
	int temp = strcmp(this->str,String2.str);
	
	if(temp < 0)
		return true;

	return false;
}

bool XString::operator <=  ( XString& String2 )
{
	int temp = strcmp(this->str,String2.str);

	if(temp < 0 || temp == 0)
		return true;

	return false;
}

bool XString::operator ==  ( XString& String2 )
{
	int temp = strcmp(this->str,String2.str);

	if(temp == 0)
		return true;

	return false;
}
bool XString::operator !=  ( XString& String2 )
{
	int temp = strcmp(this->str,String2.str);

	if(temp != 0)
		return true;

	return false;
}

XString XString::operator ! ()
{
	XString temp;
	strcpy(temp.str,str);
	strrev(temp.str);
	return temp;
}

XString::operator char*()
{
	char * temp = new char [55];
	sprintf( temp, "%s", str );
	return temp;

}                                                                                                                                                                                                                                                                                                                                   