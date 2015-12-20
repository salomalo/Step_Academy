#include "XString.h"



XString::XString( const char* const str )
{
	content = new char [ strlen( str ) + 1 ];
	strcpy( content, str );
}

XString::XString()
{
	const char * src = "Created by default";
	content = new char [ strlen( src ) + 1 ];
	strcpy( content, src );
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




void * XString::operator new ( size_t sizeInBytes, const char * str )
{
	cout <<"\n\nIt`s my operator new !!!!  I`m COOL!!!!\n";
	cout <<"Passed string is: '" <<str <<"\n\n";

	return malloc( sizeInBytes );
}




void * XString::operator new ( size_t sizeInBytes )	// sizeInBytes визначає компілятор
{
	cout <<"\n\nIt`s my operator new !!!!  I`m COOL!!!!\n\n";
	return malloc( sizeInBytes );
}




void * XString::operator new[] ( size_t sizeInBytes )	// sizeInBytes визначає компілятор
{
	cout <<"\n\nIt`s my operator new[] !!!!  I`m COOL!!!!\n\n";
	return malloc( sizeInBytes );
}



void XString::operator delete( void * ptrMemoryToDelete )
{
	cout <<"\n\nIt`s my operator delete !!!!  I`m COOL!!!!\n\n";
	free( ptrMemoryToDelete );
}



void XString::operator delete[]( void * ptrMemoryToDelete )
{
	cout <<"\n\nIt`s my operator delete[] !!!!  I`m COOL!!!!\n\n";
	free( ptrMemoryToDelete );
}


