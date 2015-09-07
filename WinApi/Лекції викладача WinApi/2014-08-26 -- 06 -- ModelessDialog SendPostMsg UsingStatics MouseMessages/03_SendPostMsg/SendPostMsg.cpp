#include <windows.h> 
#include <tchar.h>
#include <string>
using namespace std;

#include "SendPostMsg.h"

// �� ������ ��������� ����� ����������� � ��������:
// WM_USER -- 16383 ���� � ������� �� 0x4000 �� 0x7fff
// WM_APP  -- 16383 ���� � ������� �� 0x8000 �� 0xBfff
// 
#define WM_TestSendMessage	0x4444	
#define WM_TestPostMessage	0x8555 

BOOL CALLBACK DlgProc(HWND, UINT, WPARAM, LPARAM); 

wstring	sMessages;	// � ��� ���� �������� �����������



int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR szCmdLine, int iCmdShow) 
{ 

	HWND hwndDialog;
	hwndDialog = CreateDialog( hInstance, MAKEINTRESOURCE( IDD_ModelessDialog ), 0, DlgProc );

	ShowWindow(hwndDialog, iCmdShow); 
	SetWindowText( hwndDialog, L"�������� ������������" );

	MSG msg;
	while( GetMessage(&msg, NULL, 0, 0) ) 
	{ 
		TranslateMessage(&msg); 
		DispatchMessage(&msg); 
	} 

	MessageBox( 0, sMessages.c_str(), L"���������", MB_OK );

	return msg.wParam; 
} 






BOOL CALLBACK DlgProc(HWND hwnd, UINT iMsg, WPARAM wParam, LPARAM lParam) 
{ 
	static UINT		uLevel;			// �������� �-�� ������� DlgProc ��� ���������� ������
	static BOOL		isContinue;

	wstring sMargin;	// ������
	for( int i = uLevel; i > 0; i-- )
		sMargin += L"    ";

	switch(iMsg) 
	{ 
	case WM_CREATE:
		sMessages.clear();
		break;

	case WM_PAINT: 
		{
			PAINTSTRUCT ps;
			RECT rect;
			HDC hdc = BeginPaint(hwnd, &ps); 
			GetClientRect(hwnd, &rect);
			DrawText(hdc, _TEXT("Hello, Windows !"), -1, &rect, DT_SINGLELINE | DT_CENTER | DT_VCENTER); 
			EndPaint(hwnd, &ps); 
			break;
		}

	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case IDOK:
			sMessages += L"\n\nSendMessage\n";
			isContinue = TRUE;
			//SendMessage �� ������� ���������, ���� �� ����������� ������� �����������
			SendMessage( hwnd, WM_TestSendMessage, 0, 0 );	// ����� ��������� DlgProc � ������������ WM_TestSendMessage
			MessageBox( 0, sMessages.c_str(), L"��������� ���� SendMessage", MB_OK );
			break;

		case IDCANCEL:
			sMessages += L"\n\nPostMessage\n";
			isContinue = TRUE;
			PostMessage( hwnd, WM_TestPostMessage, 0, 0 );	// ����� ����������� � ����� -- � ������ ������� ���������
			MessageBox( 0, sMessages.c_str(), L"��������� ���� nPostMessage", MB_OK );
			break;

		}
		break;


	case WM_TestSendMessage:
		{
			UINT uLevelOld = uLevel;
			wchar_t szBuff[55];
			wsprintf( szBuff, L"started  WM_TestSendMessage level %i handler \n", uLevelOld );
			sMessages += sMargin + szBuff;
			if( uLevel >= 5 )
				isContinue = FALSE;
			if( isContinue )
			{
				uLevel++;
				SendMessage( hwnd, WM_TestSendMessage, 0, 0 ); 	// ����� ��������� DlgProc � ������������ WM_TestSendMessage -- �������� ���������� �������
			}
			else
			{
				uLevel--;
			}
			wsprintf( szBuff, L"finished WM_TestSendMessage level %i handler \n", uLevelOld );
			sMessages += sMargin + szBuff;
		}
		break;

	case WM_TestPostMessage:
		{
			UINT uLevelOld = uLevel;
			wchar_t szBuff[55];
			wsprintf( szBuff, L"started  WM_TestPostMessage level %i handler \n", uLevelOld );
			sMessages += sMargin + szBuff;
			if( uLevel >= 5 )
				isContinue = FALSE;
			if( isContinue )
			{
				uLevel++;
				PostMessage( hwnd, WM_TestPostMessage, 0, 0 );
			}
			else
			{
				uLevel--;
			}
			wsprintf( szBuff, L"finished WM_TestPostMessage level %i handler \n", uLevelOld );
			sMessages += sMargin + szBuff;
		}
		break;

	case WM_CLOSE:
		DestroyWindow( hwnd );
		break;

	case WM_DESTROY: 
		PostQuitMessage(0); 
		break;

	default:
		return DefWindowProc(hwnd, iMsg, wParam, lParam); 
	} 


	return 0;
}


