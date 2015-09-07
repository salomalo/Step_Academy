#include <windows.h>
#include "resource.h"

HWND hEdit1, hEdit2, hButton;
HINSTANCE hInst;

BOOL CALLBACK DlgProc(HWND, UINT, WPARAM, LPARAM);

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInst, LPSTR lpszCmdLine, int nCmdShow)
{
	hInst = hInstance;
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
			hEdit1 = CreateWindowEx(WS_EX_CLIENTEDGE, TEXT("EDIT"), 0, WS_CHILD | WS_VISIBLE | WS_VSCROLL | WS_TABSTOP | ES_WANTRETURN | ES_MULTILINE | ES_AUTOVSCROLL, 10, 7, 150, 100, hWnd, 0, hInst, 0);
			hEdit2 = CreateWindowEx(WS_EX_CLIENTEDGE, TEXT("EDIT"), 0, WS_CHILD | WS_VISIBLE | WS_VSCROLL | ES_WANTRETURN | ES_MULTILINE | ES_AUTOVSCROLL | ES_READONLY, 170, 7, 150, 100, hWnd, 0, hInst, 0);
			hButton = CreateWindowEx(WS_EX_CLIENTEDGE | WS_EX_DLGMODALFRAME, TEXT("BUTTON"), TEXT("Click Me!"), WS_CHILD | WS_VISIBLE | WS_TABSTOP, 10, 110, 310, 40, hWnd, 0, hInst, 0);
			return TRUE;

		case WM_COMMAND:
			{
				HWND h = (HWND) lParam;
				if(h == hButton)
				{
					int length = SendMessage(hEdit1, WM_GETTEXTLENGTH, 0, 0);
					TCHAR *buffer = new TCHAR[length + 1];
					memset(buffer, 0, length + 1);
					GetWindowText(hEdit1, buffer, length + 1);
					SetWindowText(hEdit2, buffer);
					delete [] buffer;
				}
			}
			return TRUE;
	}
	return FALSE;
}