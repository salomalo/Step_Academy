#include <windows.h> 
#include "resource.h"

INT_PTR CALLBACK DlgProc(HWND, UINT, WPARAM, LPARAM); 

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR szCmdLine, int iCmdShow) 
{ 
	int iRes = DialogBox( hInstance, MAKEINTRESOURCE( IDD_DIALOG1 ), 0, DlgProc );
	wchar_t sRes[55];
	wsprintf( sRes, L"DialogBox повернув %i", iRes );
	MessageBox(0, sRes, L"The End!", MB_OK );
}


INT_PTR CALLBACK DlgProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam )
{
	switch( uMsg )
	{
	default:
		return FALSE;

	case WM_CLOSE:
		EndDialog( hwnd, 79522489 );

	case WM_COMMAND:
		switch( LOWORD(wParam) )
		{
		case IDOK:
			MessageBox(0, L"IDOK", L"IDOK", MB_OK );
			break;

		case IDCANCEL:
			MessageBox(0, L"IDCANCEL", L"IDCANCEL", MB_OK );
			break;

		}
		break;

	}

	return TRUE;
}
