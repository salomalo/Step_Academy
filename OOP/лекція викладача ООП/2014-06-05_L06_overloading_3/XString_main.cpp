#include "XString.h"


void main()
{
	XString str( "My first XString object!  I`m exalted!!!!" );
	cout <<"Look at this:   '" <<str <<"'\n\n\n";		// ��� ������� �������������� �������� << ( ����� 27)

	cout <<"Enter new value for XString : ";
	cin  >>str;		// ������ �������������� �������� >>
	cout <<"Look at this:   '" <<str <<"'\n\n\n";		// ��� ������� �������������� �������� << ( ����� 27)

	str[2] = '#';
	str[12] = '#';
	str[22] = '#';
	cout <<"Look at this:   '" <<str <<"'\n\n\n";		// ��� ������� �������������� �������� << ( ����� 27)


	str( 5, 5, '$' );
	cout <<"Look at this:   '" <<str <<"'\n\n\n";		// ��� ������� �������������� �������� << ( ����� 27)


}



