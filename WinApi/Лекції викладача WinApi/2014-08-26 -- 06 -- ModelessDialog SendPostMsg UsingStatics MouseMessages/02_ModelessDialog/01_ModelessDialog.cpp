#include <Windows.h>
#include "01_ModelessDialog.h"

INT_PTR CALLBACK DlgProc( HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam );


int CALLBACK WinMain( HINSTANCE hInstance, HINSTANCE hPrev, LPSTR szCmdLine, int iCmdShow )
{
	HWND hwndDlg = CreateDialog( hInstance, MAKEINTRESOURCE( IDD_DIALOG1 ), NULL, DlgProc );
	ShowWindow( hwndDlg, SW_SHOW );

	SetWindowText( hwndDlg, L"���-����, �� ����������� ����� -- SetWindowText() ���������� ! " );

	// ����������� ���� ������� ����������
	MSG msg;
	while ( GetMessage( &msg, NULL, NULL, NULL ) )
	{
		TranslateMessage( &msg );
		DispatchMessage( &msg );
	}

}




INT_PTR CALLBACK DlgProc( HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam )
{
	switch ( uMsg )
	{
	default:
		return FALSE;	// ��� ����������, �� �� ��������

	case WM_CLOSE:	
		DestroyWindow( hwnd );
		PostQuitMessage( 0 );
		break;

	// �� ����������� ������������ �������� ������ ����� ������������ ����
	// � ������ ������� �� ������ ���������� ������ Ok i Cancel
	case WM_COMMAND:
		switch ( LOWORD(wParam) )	//	-- �� ID ������, ����� ������� �����������
		{
		default:
			break;

		case IDOK:
			MessageBox( 0, L"IDOK", L"IDOK", MB_OK | MB_ICONINFORMATION );
			break;

		case IDCANCEL:
			MessageBox( 0, L"IDCANCEL", L"IDCANCEL", MB_OK | MB_ICONINFORMATION );
			DestroyWindow( hwnd );
			PostQuitMessage( 0 );
			break;

		}
		


	}// switch ( uMsg )

}