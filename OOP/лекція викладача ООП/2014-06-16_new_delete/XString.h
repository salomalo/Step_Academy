#include <iostream>
using namespace std;




class XString
{

public:

	XString();
	XString( const char* const str );
	XString( XString & oSrc );
	~XString();

	friend ostream & operator << ( ostream & left, XString & right );	// тут left -- це синонім cout'а
	friend istream & operator >> ( istream & left, XString & right );	// тут left -- це синонім cin'а

	char& operator[] ( int idx );	// повератає посилання на ОДИН символ XString'а по даному індексу
	void  operator() ( int idxStart, int length, char replace );	// хочемо, щоби замінило символом replace length символів, починаючи з idxStart'ового


	/////////////////////////////////// new, new[], delete, delete[]
	void * operator new ( size_t sizeInBytes );
	void * operator new ( size_t sizeInBytes, const char * str );
	void * operator new[] ( size_t sizeInBytes );
	void   operator delete( void * ptrMemoryToDelete );
	void   operator delete[]( void * ptrMemoryToDelete );


private:

	char * content;

};//class XString