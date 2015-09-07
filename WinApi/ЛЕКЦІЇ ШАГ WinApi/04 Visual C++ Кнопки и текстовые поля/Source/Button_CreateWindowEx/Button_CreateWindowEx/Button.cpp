#include <windows.h>
#include "resource.h"

#define LEFT_START 52
#define TOP_START 100
#define WIDTH_START 76
#define HEIGHT_START 30

#define LEFT_STOP 168
#define TOP_STOP 100
#define WIDTH_STOP 76
#define HEIGHT_STOP 30

#define LEFT_PICTURE 100
#define TOP_PICTURE 5
#define WIDTH_PICTURE 86
#define HEIGHT_PICTURE 86

HWND hStart, hStop, hPicture;
HBITMAP hBmp[5];
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
			hStart = CreateWindowEx(WS_EX_DLGMODALFRAME, TEXT("BUTTON"), TEXT("Start"), WS_CHILD | WS_VISIBLE, 
									LEFT_START, TOP_START, WIDTH_START, HEIGHT_START, hWnd, 0, hInst, 0);
			hStop = CreateWindowEx(WS_EX_DLGMODALFRAME, TEXT("BUTTON"), TEXT("Stop"), WS_CHILD | WS_VISIBLE | WS_DISABLED, 
									LEFT_STOP, TOP_STOP, WIDTH_STOP, HEIGHT_STOP, hWnd, 0, hInst, 0);
			hPicture = CreateWindowEx(0, TEXT("BUTTON"), 0, WS_CHILD | WS_VISIBLE | BS_BITMAP, 
									LEFT_PICTURE, TOP_PICTURE, WIDTH_PICTURE, HEIGHT_PICTURE, hWnd, 0, hInst, 0);
			for(int i = 0; i < 5; i++)
				hBmp[i] = LoadBitmap(hInst, MAKEINTRESOURCE(IDB_BITMAP1 + i));
			SendMessage(hPicture, BM_SETIMAGE, WPARAM(IMAGE_BITMAP), LPARAM(hBmp[0]));
			return TRUE;

		case WM_COMMAND:
			{
				HWND h = GetFocus();
				TCHAR text[10];
				GetWindowText(h, text, 10);
				if(!lstrcmp(text, TEXT("Start")))
				{
					SetTimer(hWnd, 1, 1000, 0);
					EnableWindow(hStart, 0);
					EnableWindow(hStop, 1);
					SetFocus(hStop);
				}
				else if(!lstrcmp(text, TEXT("Stop")))
				{
					KillTimer(hWnd, 1);
					EnableWindow(hStart, 1);
					EnableWindow(hStop, 0);
					SetFocus(hStart);
				}
			}
			return TRUE;

		case WM_TIMER:
			static int index = 0;
			index++;
			if(index > 4)
				index = 0;
			SendMessage(hPicture, BM_SETIMAGE, WPARAM(IMAGE_BITMAP), LPARAM(hBmp[index]));
			return TRUE;
	}
	return FALSE;
}