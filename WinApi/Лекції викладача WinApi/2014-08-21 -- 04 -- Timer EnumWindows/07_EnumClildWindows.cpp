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
	// ������ ���� �� ��������� --- http://msdn.microsoft.com/en-us/library/windows/desktop/ms633499(v=vs.85).aspx
	HWND hwnd = FindWindow( 
		NULL,			// ��'� �������� ����� (NULL -- ���� �� �����)	�������� ���� ���� �� hwnd ����� GetClassName
		L"Calculator"	// ��'� ����
		//L"����������"	// ��'� ����
		);


	if( !hwnd )
	{
		MessageBox( NULL, L"�� �������!", L":(", MB_OK | MB_ICONERROR );
		return 0;
	}
	
	//SetWindowPos( hwnd, HWND_TOPMOST, 100, 100, 100, 100, SWP_SHOWWINDOW );
	SetWindowText( hwnd, L"����������" );
	//SetWindowText( hwnd, L"Calculator" );

	wchar_t szClassName[77];
	GetClassName( hwnd, szClassName, 77 );
	MessageBox( NULL, szClassName, L"���� ������������", MB_OK | MB_ICONINFORMATION );


	/////////////////////////////////////////
	// 
	// ���������� ������ ���� ������������
	//
	MyStruct Data;
	Data.num = 0;

	// ���������� (��������) ��ײ�Ͳ ���� hwnd ���� MyWindowEnumProc �� ������� FALSE, ��� �� ���������� ����
	EnumChildWindows(
		hwnd,					//  ����� ������������ ���� (������������)
		MyWindowEnumProc,		//	�������� �� ������-������� (��������)
		(LPARAM)&Data			//  ��������, ������ ����������� �������-��������� MyWindowEnumProc � ������� �������� -- �������� �������� �� ��������, ���������� �� LPARAM
		);

	wchar_t szTile [555];
	wsprintf( szTile, L"����� � ������������ � %i ������� ���� �� ������ �����������", Data.num );
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

	SetWindowPos( hwnd, HWND_BOTTOM, 0, 0, 0, 0, SWP_HIDEWINDOW | SWP_NOMOVE | SWP_NOOWNERZORDER | SWP_NOSIZE );

	return TRUE;	// ��� ����������� �������� ����
}


