#include <windows.h>
#include <ctime>
#include <tchar.h>
#include "resource.h"

HWND hStart, hDateTime, hShowSeconds;

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
			hStart = GetDlgItem(hWnd, IDC_START);
			hDateTime = GetDlgItem(hWnd, IDC_DATE_TIME);
			hShowSeconds = GetDlgItem(hWnd, IDC_SHOW_SECONDS);
			SendMessage(hShowSeconds, BM_SETCHECK, WPARAM(BST_CHECKED), 0);
			return TRUE;

		case WM_COMMAND:
			if(LOWORD(wParam) == IDC_START)
			{
				TCHAR str[10];
				GetWindowText(hStart, str, 10);
				if(!lstrcmp(str, TEXT("Start")))
				{
					SetTimer(hWnd, 1, 1000, 0);
					SetWindowText(hStart, TEXT("Stop"));
				}
				else if(!lstrcmp(str, TEXT("Stop")))
				{
					KillTimer(hWnd, 1);
					SetWindowText(hStart, TEXT("Start"));
					SetWindowText(hDateTime, 0);
				}
			}
			return TRUE;

		case WM_TIMER:
			{
				static time_t t;
				static TCHAR str[100];
				t = time(NULL);
				struct tm DateTime= *(localtime(&t));
				LRESULT lResult = SendMessage(hShowSeconds, BM_GETCHECK, 0, 0);
				if(lResult == BST_CHECKED)
					_tcsftime(str, 100, TEXT("%H:%M:%S  %d.%m.%Y  %A"), &DateTime);
				else
					_tcsftime(str, 100, TEXT("%H:%M  %d.%m.%Y  %A"), &DateTime);
				SetWindowText(hDateTime, str);
			}
			return TRUE;
	}
	return FALSE;
}