#include <windows.h>
#include "resource.h"

BOOL CALLBACK DlgProc(HWND, UINT, WPARAM, LPARAM);

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInst, LPSTR lpszCmdLine, int nCmdShow)
{
	return DialogBox(hInstance, MAKEINTRESOURCE(IDD_DIALOG1), NULL, DlgProc); 
}

BOOL CALLBACK DlgProc(HWND hWnd, UINT message, WPARAM wp, LPARAM lp)
{
	switch(message)
	{
		case WM_CLOSE:
			EndDialog(hWnd, 0);
			return TRUE;

		case  WM_INITDIALOG:
			SendDlgItemMessage(hWnd, IDC_RADIO2, BM_SETCHECK, WPARAM(BST_CHECKED), 0);
			SendDlgItemMessage(hWnd, IDC_RADIO5, BM_SETCHECK, WPARAM(BST_CHECKED), 0);
			return TRUE;

		case WM_COMMAND:
			if(LOWORD(wp) >= IDC_RADIO1 && LOWORD(wp) <= IDC_RADIO6)
			{
				TCHAR str[20];
				wsprintf(str, TEXT("������������� %d"),LOWORD(wp) - IDC_RADIO1 + 1);
				SetWindowText(hWnd, str);
			}
			else if(LOWORD(wp)==IDC_BUTTON1)
			{
				TCHAR str[100] = TEXT("������� ��������� �������������:\n");

				// ����������� ������ ������ ��������������
				LRESULT result = SendDlgItemMessage(hWnd, IDC_RADIO1, BM_GETCHECK, 0, 0);
				if(result == BST_CHECKED)
					lstrcat(str, TEXT("����� �1\n"));
				else
				{
					result = SendDlgItemMessage(hWnd, IDC_RADIO2, BM_GETCHECK, 0, 0);
					if(result == BST_CHECKED)
						lstrcat(str, TEXT("����� �2\n"));
					else
					{
						result = SendDlgItemMessage(hWnd, IDC_RADIO3, BM_GETCHECK, 0, 0);
						if(result == BST_CHECKED)
							lstrcat(str, TEXT("����� �3\n"));
					}
				}

				// ����������� ������ ������ ��������������
				result = SendDlgItemMessage(hWnd, IDC_RADIO4, BM_GETCHECK, 0, 0);
				if(result == BST_CHECKED)
					lstrcat(str, TEXT("����� �4\n"));
				else
				{
					result = SendDlgItemMessage(hWnd, IDC_RADIO5, BM_GETCHECK, 0, 0);
					if(result == BST_CHECKED)
						lstrcat(str, TEXT("����� �5\n"));
					else
					{
						result = SendDlgItemMessage(hWnd, IDC_RADIO6, BM_GETCHECK, 0, 0);
						if(result == BST_CHECKED)
							lstrcat(str, TEXT("����� �6\n"));
					}
				}

				MessageBox(hWnd, str, TEXT("Radio Button"), MB_OK | MB_ICONINFORMATION);
			}
			return TRUE;
	}
	return FALSE;
}