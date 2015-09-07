/*
	ϳ��� �������� ���� ������� MessageBox'�� ������ � ������� ��������� ����� ���������� (����)
*/


#include <windows.h> 
#include <tchar.h>

#include <string>
using namespace std;

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM); 


wstring sMessages; // ���� ������ "��������" �����������
UINT	nMessages; // ��� ������ ������������ �����������


int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR szCmdLine, int iCmdShow) 
{ 
	static TCHAR szAppName[] = _TEXT("MyWindowClass"); 

	WNDCLASSEX wndclass; 
	wndclass.cbSize			= sizeof(wndclass); 
	wndclass.style			= CS_HREDRAW | CS_VREDRAW; 
	wndclass.lpfnWndProc	= WndProc; 
	wndclass.cbClsExtra		= 0; 
	wndclass.cbWndExtra		= 0; 
	wndclass.hInstance		= hInstance; 
	wndclass.hIcon			= LoadIcon(NULL, IDI_APPLICATION); 
	wndclass.hCursor		= LoadCursor(NULL, IDC_ARROW); 
	wndclass.hbrBackground	=(HBRUSH) GetStockObject(WHITE_BRUSH); 
	wndclass.lpszMenuName	= NULL; 
	wndclass.lpszClassName	= szAppName; 
	wndclass.hIconSm		= LoadIcon(NULL, IDI_APPLICATION); 

	if( !RegisterClassEx(&wndclass) )
	{
		MessageBox( NULL, _TEXT("�� ������� ������������ ������� ����!"), _TEXT("�������!"), MB_OK );
		return 0;
	}

	// ���� �� �� ���������� -- � �� �������� ������� �����������
	nMessages = 0;	
	sMessages.clear();

	HWND hwnd;
	hwnd = CreateWindow( 
						szAppName, 
						_TEXT("�� ����� \"�������\" ���� "), 
						WS_OVERLAPPEDWINDOW, 
						CW_USEDEFAULT,
						CW_USEDEFAULT,
						CW_USEDEFAULT,
						CW_USEDEFAULT,
						NULL, 
						NULL, 
						hInstance, 
						NULL 
						); 

	ShowWindow(hwnd, iCmdShow); 
	UpdateWindow(hwnd); 

	MSG msg;
	while( GetMessage(&msg, NULL, 0, 0) ) 
	{ 
		TranslateMessage(&msg); 
		DispatchMessage(&msg);
	} 


	////////////////////
	//  �������� ������ ��������� ����������
	//
	wchar_t szNum[55];
	wsprintf( szNum, L"�������� %i ����������", nMessages );
	MessageBox( 0, sMessages.c_str(), szNum , MB_ICONINFORMATION | MB_OK );

	return msg.wParam; 
} 
// int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR szCmdLine, int iCmdShow) 




LRESULT CALLBACK WndProc( HWND hwnd, UINT iMsg, WPARAM wParam, LPARAM lParam ) 
{ 
	nMessages++;	// �������� �� ���� �����������

	if( sMessages.length() > 0 )
		sMessages += L", ";			// ����������� ��������� �� ��������� ������

	wchar_t szMsg [55];
	wsprintf( szMsg, L"%i", iMsg );
	sMessages += szMsg;		// ����������� �����  - ��� �����������

	switch(iMsg) 
	{ 
	case WM_CREATE: 
		return 0; 
		 
	case WM_PAINT: 
		{
			PAINTSTRUCT ps;
			RECT rect;
			HDC hdc = BeginPaint(hwnd, &ps); 
			GetClientRect(hwnd, &rect);
			DrawText(hdc, _TEXT("Hello,\n Windows !"), -1, &rect, /**/DT_SINGLELINE |/**/ DT_CENTER | DT_VCENTER); 
			EndPaint(hwnd, &ps); 
			return 0; 
		}

	case WM_DESTROY: 
		PostQuitMessage(0); 
		return 0; 
	} 

	return DefWindowProc(hwnd, iMsg, wParam, lParam); 
}


