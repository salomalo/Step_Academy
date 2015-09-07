#include "CMessageCrackersDlg.h"

CMessageCrackersDlg* CMessageCrackersDlg::ptr = NULL;

CMessageCrackersDlg::CMessageCrackersDlg(void)
{
	ptr = this;
}

void CMessageCrackersDlg::Cls_OnClose(HWND hwnd)
{
	EndDialog(hwnd, 0);
}

BOOL CMessageCrackersDlg::Cls_OnInitDialog(HWND hwnd, HWND hwndFocus, LPARAM lParam) 
{
	hDialog = hwnd;
	hStart = GetDlgItem(hDialog, IDC_START);
	hStop = GetDlgItem(hDialog, IDC_STOP);
	hPicture = GetDlgItem(hDialog, IDC_PICTURE);
	for(int i = 0; i < 5; i++)
		hBmp[i] = LoadBitmap(GetModuleHandle(0), MAKEINTRESOURCE(IDB_BITMAP1 + i));
	return TRUE;
}

void CMessageCrackersDlg::Cls_OnCommand(HWND hwnd, int id, HWND hwndCtl, UINT codeNotify)
{
	if(id == IDC_START)
	{
		SetTimer(hDialog, 1, 1000, 0);
		EnableWindow(hStart, 0);
		EnableWindow(hStop, 1);
		SetFocus(hStop);
	}
	else if(id == IDC_STOP)
	{
		KillTimer(hDialog, 1);
		EnableWindow(hStart, 1);
		EnableWindow(hStop, 0);
		SetFocus(hStart);
	}
}

void CMessageCrackersDlg::Cls_OnTimer(HWND hwnd, UINT id)
{
	static int index = 0;
	index++;
	if(index > 4)
		index = 0;
	SendMessage(hPicture, STM_SETIMAGE, WPARAM(IMAGE_BITMAP), LPARAM(hBmp[index]));
}

BOOL CALLBACK CMessageCrackersDlg::DlgProc(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch(message)
	{
		HANDLE_MSG(hwnd, WM_CLOSE, ptr->Cls_OnClose);
		HANDLE_MSG(hwnd, WM_INITDIALOG, ptr->Cls_OnInitDialog);
		HANDLE_MSG(hwnd, WM_COMMAND, ptr->Cls_OnCommand);
		HANDLE_MSG(hwnd, WM_TIMER, ptr->Cls_OnTimer);
	}
	return FALSE;
}
