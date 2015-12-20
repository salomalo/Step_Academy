#include "XString.h"



XString::XString( const char* const str )
{
	content = new char [ strlen( str ) + 1 ];
	strcpy( content, str );
}


XString::XString( XString & oSrc )
{
	content = new char [ strlen( oSrc.content ) + 1 ];
	strcpy( content, oSrc.content );
}


XString::~XString()
{
	delete [] content;
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



