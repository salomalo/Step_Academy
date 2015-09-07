#include <windows.h>
#include <tchar.h>
#include <time.h>

LRESULT CALLBACK WindowProc(HWND, UINT, WPARAM, LPARAM);

char szClassWindow[] = TEXT("��������� ����������");	

int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPSTR lpszCmdLine, int nCmdShow)
{
	HWND hWnd;
	MSG lpMsg;
	WNDCLASSEX wcl;
	wcl.cbSize = sizeof(wcl);	
	wcl.style = CS_HREDRAW | CS_VREDRAW;	
	wcl.lpfnWndProc = WindowProc;	
	wcl.cbClsExtra = 0;	
	wcl.cbWndExtra = 0; 	
	wcl.hInstance = hInst;	
	wcl.hIcon = LoadIcon(NULL, IDI_APPLICATION);	
	wcl.hCursor = LoadCursor(NULL, IDC_ARROW);	
	wcl.hbrBackground = (HBRUSH) GetStockObject(WHITE_BRUSH); 
	wcl.lpszMenuName = NULL;	
	wcl.lpszClassName = szClassWindow;	
	wcl.hIconSm = NULL;	
	if (!RegisterClassEx(&wcl))
		return 0;
	hWnd = CreateWindowEx(0, szClassWindow, TEXT("������ � ��������"), WS_OVERLAPPEDWINDOW,	
		CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, NULL, NULL, hInst, NULL);
	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd);
	while(GetMessage(&lpMsg, NULL, 0, 0))
	{
		TranslateMessage(&lpMsg);	
		DispatchMessage(&lpMsg);	
	}
	return lpMsg.wParam;
}

VOID CALLBACK TimerProc(HWND hwnd, UINT uMsg, UINT_PTR idEvent, DWORD dwTime)
{
	static time_t t;
	static TCHAR str[100];
	t = time(NULL);	// ���������� ������, ��������� � 01.01.1970
	lstrcpy(str, _tctime(&t));	// ������������ ������ ���������� �������:  ���� ����� ����� ����:������:������� ���
	str[lstrlen(str) - 1] = '\0';
	SetWindowText(hwnd, str);	// ����� ���� � ������� � ��������� ����
}

LRESULT CALLBACK WindowProc (HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch(message)
	{
		case WM_DESTROY: 
			PostQuitMessage(0);
			break;
		case WM_KEYDOWN:
			if(wParam == VK_RETURN)
				SetTimer(hWnd, 1, 1000, TimerProc);	// ��������� ������� �� ������� ������� <ENTER>
			else if(wParam == VK_ESCAPE)
				KillTimer(hWnd, 1);	// ����������� ������� �� ������� ������� <ESC>
			break;	
		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}

