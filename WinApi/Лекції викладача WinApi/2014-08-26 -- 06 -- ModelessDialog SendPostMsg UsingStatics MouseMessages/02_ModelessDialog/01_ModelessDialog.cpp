#include <Windows.h>
#include "01_ModelessDialog.h"

INT_PTR CALLBACK DlgProc( HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam );


int CALLBACK WinMain( HINSTANCE hInstance, HINSTANCE hPrev, LPSTR szCmdLine, int iCmdShow )
{
	HWND hwndDlg = CreateDialog( hInstance, MAKEINTRESOURCE( IDD_DIALOG1 ), NULL, DlgProc );
	ShowWindow( hwndDlg, SW_SHOW );

	SetWindowText( hwndDlg, L"Все-таки, це НЕМОДАЛЬНИЙ діалог -- SetWindowText() виконалася ! " );

	// стандартний цикл обробки повідомлень
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
		return FALSE;	// для повідомлень, які НЕ обробляє

	case WM_CLOSE:	
		DestroyWindow( hwnd );
		PostQuitMessage( 0 );
		break;

	// ці повідомлення надсилаються дочірніми вікнами своєму батьківському вікну
	// в даному випадку їх діалогу надсилають кнопки Ok i Cancel
	case WM_COMMAND:
		switch ( LOWORD(wParam) )	//	-- по ID кнопки, котра послала повідомлення
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