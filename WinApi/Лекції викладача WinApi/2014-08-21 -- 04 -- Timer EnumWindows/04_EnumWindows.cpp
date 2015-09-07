#include <windows.h> 
#include <tchar.h>



// �������� �������, ����� ����������� EnumWindows ��� ������� ���� � ������� TRUE, ���� ����� ���������� ������ ����
BOOL CALLBACK MyWindowEnumProc( HWND hwnd, LPARAM lParam );



int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR szCmdLine, int iCmdShow) 
{ 
	// ���������� (��������) ���� � ������� MyWindowEnumProc, ��������� hwnd,
	//���� MyWindowEnumProc �� ������� FALSE, ��� �� ���������� ����
	EnumWindows(
		MyWindowEnumProc,	//	�������� �� ������-������� (��������)
		NULL				//  ��������, ������ ����������� �������-��������� MyWindowEnumProc � ������� ��������
		);

} 



// �������, ����� ����������� EnumWindows ��� ������� ���� � ������� TRUE, ���� ����� ���������� ������ ����
BOOL CALLBACK MyWindowEnumProc( HWND hwnd, LPARAM lParam )
{
	static int nCount;
	nCount++;
	wchar_t szText [555];
	wchar_t szTitle [555];
	wsprintf( szTitle, L"��������� %i-�� ����", nCount );
	GetWindowText( hwnd, szText, 555 );	// ����� � ����� szText ��������� ���� hwnd
	if( IDOK == MessageBox( NULL, szText, szTitle, MB_ICONINFORMATION | MB_OKCANCEL ) )
		return TRUE;	// ��� ����������� �������� ����
	else
		return FALSE;	// ��� ��������� ������� ����
}



