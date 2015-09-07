#include <windows.h>
#include "resource.h"

HWND hLogin, hPassword;

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
			return TRUE;

		case WM_COMMAND:
			if(LOWORD(wParam) == IDC_ENTRY)
			{
				TCHAR text[100], login[20], password[20];
				GetWindowText(hLogin, login, 20);
				GetWindowText(hPassword, password, 20);
				if(lstrlen(login) == 0 || lstrlen(password) == 0)
					MessageBox(hWnd, TEXT("Не введён логин или пароль!"), TEXT("Авторизация"), MB_OK | MB_ICONSTOP);
				else
				{
					wsprintf(text, TEXT("Логин: %s\nПароль: %s"), login, password);
					MessageBox(hWnd, text, TEXT("Авторизация"), MB_OK | MB_ICONINFORMATION);
				}
				SetWindowText(hLogin, 0);
				SetWindowText(hPassword, 0);
				SetFocus(hLogin);
			}
			return TRUE;
	}
	return FALSE;
}