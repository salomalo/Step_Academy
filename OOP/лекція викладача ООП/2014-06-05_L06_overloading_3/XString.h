#include <iostream>
using namespace std;




class XString
{

public:

	XString( const char* const str );
	XString( XString & oSrc );
	~XString();

	friend ostream & operator << ( ostream & left, XString & right );	// ��� left -- �� ������ cout'�
	friend istream & operator >> ( istream & left, XString & right );	// ��� left -- �� ������ cin'�

	char& operator[] ( int idx );	// �������� ��������� �� ���� ������ XString'� �� ������ �������
	void  operator() ( int idxStart, int length, char replace );	// ������, ���� ������� �������� replace length �������, ��������� � idxStart'�����


private:

	char * content;

};//class XString