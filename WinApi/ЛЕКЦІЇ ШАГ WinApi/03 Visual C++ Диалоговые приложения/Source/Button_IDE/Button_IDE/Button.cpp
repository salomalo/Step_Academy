#include <windows.h>
#include "resource.h"

HWND hStart, hStop, hPicture;
HBITMAP hBmp[5];

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
			hStop = GetDlgItem(hWnd, IDC_STOP);
			hPicture = GetDlgItem(hWnd, IDC_PICTURE);
			for(int i = 0; i < 5; i++)
				hBmp[i] = LoadBitmap(GetModuleHandle(0), MAKEINTRESOURCE(IDB_BITMAP1 + i));
			return TRUE;

		case WM_COMMAND:
			if(LOWORD(wParam) == IDC_START)
			{
				SetTimer(hWnd, 1, 1000, 0);
				EnableWindow(hStart, 0);
				EnableWindow(hStop, 1);
				SetFocus(hStop);
			}
			else if(LOWORD(wParam) == IDC_STOP)
			{
				KillTimer(hWnd, 1);
				EnableWindow(hStart, 1);
				EnableWindow(hStop, 0);
				SetFocus(hStart);
			}
			return TRUE;

		case WM_TIMER:
			static int index = 0;
			index++;
			if(index > 4)
				index = 0;
			SendMessage(hPicture, STM_SETIMAGE, WPARAM(IMAGE_BITMAP), LPARAM(hBmp[index]));
			return TRUE;
	}
	return FALSE;
}