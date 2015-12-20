#include<iostream>
using namespace std;

class String
{
public: 

	String()
	{ memset( content, 0, 222 ); }


	// щоб заборонити використаня конструктора для неявного приведення типів використовується explicit
	explicit String( const char * const value )
	{ 
		cout <<"\n\nConstructor String( const char * const value )\n\n";
		setContent( value );
	}
	// explicit використувуємо, коли приведення типів має робитися по іншому алгоритму, аніж працює конструктор.



	String & operator = ( const char * value )
	{
		cout <<"\n\nString & operator = ( const char * const value )\n\n";
		strcpy( this->content , value );
		return *this;
	}



	void setContent( const char * const value )
	{
		strcpy( content , value );
	}

	friend ostream & operator << ( ostream & left, String & right )
	{
		return left << right.content;
	}


	//дає "доступ" до будь-якого символа рядка
	char & operator [] ( int idx )
	{
		if( idx < 0 )
			idx = 0;

		if( idx > 221)
			idx = 221;

		return content[idx];

	}


	void operator () ( const char replace, int start, int len )
	{
		if( start + len > 221)
			start = start - len;

		if( start < 0 )
			start = 0;

		if( len > 221 )
			len = 221;


		for( int idx = start, cntr = 0 ; cntr < len ; idx++ , cntr++  )
		{
			content[idx] = replace;
		}

		content[221] = 0;
	}


	void operator () ( const char replace, int len )
	{
		this->operator()( replace, 0, len );
	}


private:
	char content[222];

};

