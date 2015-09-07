#include <windows.h>
#include "resource.h"

HWND hLogin, hPassword, hEntry;
TCHAR text[100], login[20], password[20];

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
			hLogin = GetDlgItem(hWnd, IDC_LOGIN);
			hPassword = GetDlgItem(hWnd, IDC_PASSWORD);
			hEntry = GetDlgItem(hWnd, IDC_ENTRY);
			return TRUE;

		case WM_COMMAND:
			if((LOWORD(wParam) == IDC_LOGIN || LOWORD(wParam) == IDC_PASSWORD) && HIWORD(wParam) == EN_CHANGE)
			{
				GetWindowText(hLogin, login, 20);
				GetWindowText(hPassword, password, 20);
				if(lstrlen(login) == 0 || lstrlen(password) < 6)
					EnableWindow(hEntry, 0);
				else
					EnableWindow(hEntry, 1);
			}
			if(LOWORD(wParam) == IDC_ENTRY)
			{
				wsprintf(text, TEXT("Логин: %s\nПароль: %s"), login, password);
				MessageBox(hWnd, text, TEXT("Авторизация"), MB_OK | MB_ICONINFORMATION);
				SetWindowText(hLogin, 0);
				SetWindowText(hPassword, 0);
				SetFocus(hLogin);
				EnableWindow(hEntry, 0);
			}
			return TRUE;
	}
	return FALSE;
}