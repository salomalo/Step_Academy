#include <Windows.h> 
#include <Windowsx.h> 
#include <tchar.h>

#define IDTIMER_MOUSE	1234
#define TIME_DELAY		600


LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM); 


int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR szCmdLine, int iCmdShow) 
{ 
	static TCHAR szAppName[] = _TEXT("MyWindowClass"); 

	WNDCLASSEX wndclass; 
	wndclass.cbSize			= sizeof(wndclass); 
	wndclass.style			= CS_HREDRAW | CS_VREDRAW /*| CS_DBLCLKS*/;		// CS_DBLCLKS ������, ���� ������� ���������� ����������� ��� �������� ��� WM_*BUTTONDBLCLK
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


	HWND hwnd;
	hwnd = CreateWindow( 
						szAppName, 
						_TEXT("����������� ����"), 
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

	TRACKMOUSEEVENT tme ;
	tme.cbSize		= sizeof( TRACKMOUSEEVENT );
	tme.dwFlags		= TME_LEAVE;
	tme.hwndTrack	= hwnd;
	tme.dwHoverTime	= 100;
	TrackMouseEvent( &tme );

	MSG msg;
	while( GetMessage(&msg, NULL, 0, 0) ) 
	{ 
		TranslateMessage(&msg); 
		DispatchMessage(&msg); 
	} 
//	SetWindowPos(
	return msg.wParam; 
} 


void Update( HWND hwnd, const LPCWSTR szText, const LPRECT lpRect )
{
	SetWindowText( hwnd, szText );			// ���������� ����� ��������� ����
	InvalidateRect( hwnd, lpRect, TRUE );	// ������ �������� ����������� � ��� -- � ������� WM_PAINT
	SetTimer( hwnd, IDTIMER_MOUSE, TIME_DELAY, NULL );
}



LRESULT CALLBACK WndProc(HWND hwnd, UINT iMsg, WPARAM wParam, LPARAM lParam) 
{ 
	static wchar_t szText [55];
	static RECT    rect;

	switch(iMsg) 
	{ 
	case WM_CREATE: 
		return 0; 
		 
	case WM_SIZE: 
	case WM_SIZING: 
		GetClientRect( hwnd, &rect );	// ����� �볺������ ������.
		return 0; 
		 
	case WM_PAINT: 
		{
			PAINTSTRUCT ps;
			HDC hdc = BeginPaint(hwnd, &ps); 
			GetClientRect(hwnd, &rect);
			DrawText(hdc, szText, -1, &rect, DT_SINGLELINE | DT_CENTER | DT_VCENTER); 
			EndPaint(hwnd, &ps); 
			return 0; 
		}




	case WM_LBUTTONDOWN:	
		wsprintf( szText, L" WM_LBUTTONDOWN:   at (%i, %i)", GET_X_LPARAM(lParam), GET_Y_LPARAM(lParam) );
		Update( hwnd, szText, &rect );
		return 0;

	case WM_LBUTTONUP:	
		wsprintf( szText, L" WM_LBUTTONUP:   at (%i, %i)", GET_X_LPARAM(lParam), GET_Y_LPARAM(lParam) );
		Update( hwnd, szText, &rect );
		return 0;

	case WM_LBUTTONDBLCLK:	// ���� ���� �� ���������� ������� �������� � ����� �������� ����� CS_DBLCLKS
		MessageBox( 0 , L"WM_LBUTTONDBLCLK", L"WM_LBUTTONDBLCLK" ,MB_OK );
		return 0;



	case WM_RBUTTONDOWN:	
		wsprintf( szText, L" WM_RBUTTONDOWN:   at (%i, %i)", GET_X_LPARAM(lParam), GET_Y_LPARAM(lParam) );
		Update( hwnd, szText, &rect );
		return 0;

	case WM_RBUTTONUP:	
		wsprintf( szText, L" WM_RBUTTONUP:   at (%i, %i)", GET_X_LPARAM(lParam), GET_Y_LPARAM(lParam) );
		Update( hwnd, szText, &rect );
		return 0;

	case WM_RBUTTONDBLCLK:	// ���� ���� �� ���������� ������� �������� � ����� �������� ����� CS_DBLCLKS	
		MessageBox( 0 , L"WM_RBUTTONDBLCLK", L"WM_RBUTTONDBLCLK" ,MB_OK );
		return 0;



	case WM_MBUTTONDOWN:	
		wsprintf( szText, L" WM_MBUTTONDOWN:   at (%i, %i)", GET_X_LPARAM(lParam), GET_Y_LPARAM(lParam) );
		Update( hwnd, szText, &rect );
		return 0;

	case WM_MBUTTONUP:	
		wsprintf( szText, L" WM_MBUTTONUP:   at (%i, %i)", GET_X_LPARAM(lParam), GET_Y_LPARAM(lParam) );
		Update( hwnd, szText, &rect );
		return 0;

	case WM_MBUTTONDBLCLK:	// ���� ���� �� ���������� ������� �������� � ����� �������� ����� CS_DBLCLKS	
		MessageBox( 0 , L"WM_MBUTTONDBLCLK", L"WM_MBUTTONDBLCLK" ,MB_OK );
		return 0;



	case WM_MOUSEWHEEL:	
		// � ��������� ���� wParam ������ �-�� "���" ������ (+/-), ������ 120 (� �������� WHEEL_DELTA )
		// HIWORD �� �����, �� ������� ����� ������ ��������
		wsprintf( szText, L" WM_MOUSEWHEEL:    delta=%i    at (%i, %i)", GET_WHEEL_DELTA_WPARAM(wParam) / WHEEL_DELTA, LOWORD(lParam), HIWORD(lParam) );
		//wsprintf( szText, L" WM_MOUSEWHEEL:    delta=%i    at (%i, %i)", HIWORD(wParam) / WHEEL_DELTA, LOWORD(lParam), HIWORD(lParam) );
		Update( hwnd, szText, &rect );
		return 0;



	case WM_MOUSEMOVE :	
		wsprintf( szText, L" WM_MOUSEMOVE:    at (%i, %i)", LOWORD(lParam), HIWORD(lParam) );
		Update( hwnd, szText, &rect );

		// ���� ���������� ����������� WM_MOUSEHOVER WM_MOUSELEAVE ����� ������ �������� ������
		//TRACKMOUSEEVENT tme ;	// ����������
		//tme.cbSize		= sizeof( TRACKMOUSEEVENT );
		//tme.dwFlags		= TME_LEAVE | TME_HOVER;		// ����������� �� ��� ���������
		//tme.hwndTrack	= hwnd;
		//tme.dwHoverTime	= 1000;
		//TrackMouseEvent( &tme );	// ������� ������

		return 0;

	case WM_MOUSEHOVER  :	//  ����������� ��� ���� ���� ��� �볺������ �����
		MessageBox( 0 , L"WM_MOUSEHOVER", L"WM_MOUSEHOVER" ,MB_OK );
		return 0;

	case WM_MOUSELEAVE  :	//  ����������� ��� ��������� ������
		MessageBox( 0 , L"WM_MOUSELEAVE", L"WM_MOUSELEAVE" ,MB_OK );
		return 0;





	case WM_TIMER:		// �����������, �������� �� �������
		KillTimer( hwnd, IDTIMER_MOUSE );		// ��������� ������
		*szText = 0;				// ������� szText
		SetWindowText( hwnd, szText );	// � ���������
		InvalidateRect( hwnd, &rect, TRUE );	// ������ ���������� WM_PAINT -- � ����
		return 0;

	case WM_DESTROY: 
		PostQuitMessage(0); 
		return 0; 
	} 

	return DefWindowProc(hwnd, iMsg, wParam, lParam); 
}


