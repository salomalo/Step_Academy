#include <windows.h>
#include "resource.h"

HWND hButton, hEdit, hStatic;

BOOL CALLBACK DlgProc(HWND, UINT, WPARAM, LPARAM);

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInst, LPSTR lpszCmdLine, int nCmdShow)
{
	return DialogBox(hInstance, MAKEINTRESOURCE(IDD_DIALOG1), NULL, DlgProc); 
}

BOOL CALLBACK DlgProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch(message)
	{
		case WM_CLOSE:
			EndDialog(hWnd, 0);
			return TRUE;

		case WM_INITDIALOG:
			hButton = GetDlgItem(hWnd, IDC_BUTTON1);
			hEdit = GetDlgItem(hWnd, IDC_EDIT1);
			hStatic = GetDlgItem(hWnd, IDC_STATIC1);
			return TRUE;

		case WM_COMMAND:
			if(LOWORD(wParam) == IDC_BUTTON2)
			{
				LONG styles = GetWindowLong(hButton, GWL_STYLE);
				SetWindowLong(hButton, GWL_EXSTYLE, styles | WS_EX_CLIENTEDGE | WS_EX_DLGMODALFRAME);
				InvalidateRect(hButton, 0, 1);
			}
			else if(LOWORD(wParam) == IDC_BUTTON3)
			{
				LONG styles = GetWindowLong(hEdit, GWL_STYLE);
				SetWindowLong(hEdit, GWL_STYLE, styles | ES_RIGHT);
				InvalidateRect(hEdit, 0, 1);
			}
			else if(LOWORD(wParam) == IDC_BUTTON4)
			{
				LONG styles = GetWindowLong(hEdit, GWL_STYLE);
				SetWindowLong(hStatic, GWL_EXSTYLE, styles | WS_EX_CLIENTEDGE | WS_EX_DLGMODALFRAME);
				InvalidateRect(hStatic, 0, 1);
			}
			return TRUE;
	}
	return FALSE;
}