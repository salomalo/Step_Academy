#include <windows.h>

LRESULT CALLBACK WindowProc(HWND, UINT, WPARAM, LPARAM);

TCHAR szClassWindow[] = TEXT("��������� ����������");	

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
	hWnd = CreateWindowEx(0, szClassWindow, TEXT("������������ �������� ����"), WS_OVERLAPPEDWINDOW,	
		CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, NULL, NULL, hInst, NULL);
	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd);
	MessageBox(hWnd, TEXT("��������, ����������, \"�����������\", � ������� <CTRL>"), TEXT("������������ �������� ����"), MB_OK | MB_ICONINFORMATION);
	while(GetMessage(&lpMsg, NULL, 0, 0))
	{
		TranslateMessage(&lpMsg);	
		DispatchMessage(&lpMsg);	
	}
	return lpMsg.wParam;
}	

BOOL CALLBACK EnumChildProc(HWND hWnd, LPARAM lParam)
{
	HWND hWindow = (HWND) lParam; // ���������� ���� ������ ����������
	TCHAR caption[MAX_PATH] = {0}, classname[100] = {0}, text[500] = {0};
	GetWindowText(hWnd, caption, 100); // �������� ����� ��������� �������� ��������� ����
	GetClassName(hWnd, classname, 100); // �������� ��� ������ �������� ��������� ����
	if(lstrlen(caption))
	{
		lstrcat(text, TEXT("��������� ����: "));
		lstrcat(text, caption);
		lstrcat(text, TEXT("\n"));
	}
	lstrcat(text, TEXT("����� ����: "));
	lstrcat(text, classname);
	MessageBox(hWindow, text, TEXT("������������ �������� ����"), MB_OK | MB_ICONINFORMATION);
	return TRUE; // ���������� ������������ �������� ����
}

LRESULT CALLBACK WindowProc (HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch(message)
	{
		case WM_DESTROY: 
			PostQuitMessage(0);
			break;
		case WM_KEYDOWN:
			if(wParam == VK_CONTROL)
			{
				HWND h = FindWindow(TEXT("SciCalc"), TEXT("�����������")); // ������� ���������� "������������"
				if(!h)
					MessageBox(hWnd, TEXT("���������� ������� \"�����������\""), TEXT("������!!!"), MB_OK | MB_ICONSTOP);
				else
					EnumChildWindows(h, EnumChildProc, (LPARAM) hWnd); // �������� ������������ �������� ���� "������������"
			}
			break;	
		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}

