/*
	���������� �-�� ���� � ������� �� ��������� ����� MessageBox
*/


#include <windows.h> 
#include <string>
using namespace std;



// �������� �������, ����� ����������� EnumWindows ��� ������� ���� � ������� TRUE, ���� ����� ���������� ������ ����
BOOL CALLBACK MyWindowEnumProc( HWND hwnd, LPARAM lParam );


struct MyStruct
{
	UINT	 num;		// �������� ����
	wstring  titles;	// ������ ��������� ����
};


int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR szCmdLine, int iCmdShow) 
{ 
	MyStruct Data;
	Data.num = 0;

	// ���������� (��������) ���� ���� MyWindowEnumProc �� ������� FALSE, ��� �� ���������� ����
	EnumWindows(
		MyWindowEnumProc,		//	�������� �� ������-������� (��������)
		(LPARAM)&Data			//  ��������, ������ ����������� �������-��������� MyWindowEnumProc � ������� �������� -- �������� �������� �� ��������, ���������� �� LPARAM
		);

	wchar_t szTile [555];
	wsprintf( szTile, L"����� � ������ � %i ���� �� ������ �����������", Data.num );
	MessageBox( NULL, Data.titles.c_str(), szTile, MB_OK );

} 



// �������, ����� ����������� EnumWindows ��� ������� ���� � ������� TRUE, ���� ����� ���������� ������ ����
BOOL CALLBACK MyWindowEnumProc( HWND hwnd, LPARAM lParam )
{

	MyStruct * pData = (MyStruct *) lParam;		// ���������� �������� ��� 
	pData->num++;	// ����� ������ MyWindowEnumProc -- �� �� ���� ����, ���� �������� �������� ����	

	wchar_t szTile [555];
	GetWindowText( hwnd, szTile, 555 );
	if( pData->titles.length() )
		pData->titles += L", ";
	pData->titles += L"'";
	pData->titles += szTile;
	pData->titles += L"'";

	return TRUE;	// ��� ����������� �������� ����
}



