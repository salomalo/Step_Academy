#include <windows.h> 
#include <string>
using namespace std;






int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR szCmdLine, int iCmdShow) 
{ 
	// ������ ���� �� ��������� --- http://msdn.microsoft.com/en-us/library/windows/desktop/ms633499(v=vs.85).aspx
	HWND hwnd = FindWindow( 
		NULL,			// ��'� �������� ����� (NULL -- ���� �� �����)	�������� ���� ���� �� hwnd ����� GetClassName
		L"Calculator"	// ��'� ����
		);


	if( !hwnd )
	{
		MessageBox( NULL, L"�� �������!", L":(", MB_OK | MB_ICONERROR );
		return 0;
	}
	
	SetWindowPos( hwnd, HWND_TOPMOST, 100, 100, 100, 100, SWP_SHOWWINDOW | SWP_NOSIZE );
	SetWindowText( hwnd, L"����������" );

	wchar_t szClassName[77];
	GetClassName( hwnd, szClassName, 77 );
	MessageBox( NULL, szClassName, L"���� ������������", MB_OK | MB_ICONINFORMATION );


} 



