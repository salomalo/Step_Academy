#include <windows.h> 
#include <tchar.h>

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM); 

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
		MessageBox( NULL, _TEXT("Не вдалося зареєструвати віконний клас!"), _TEXT("Помилка!"), MB_OK );
		return 0;
	}


	HWND hwnd;
	hwnd = CreateWindow( 
						szAppName, 
						_TEXT("Моє перше \"справжнє\" вікно "), 
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
//	SetWindowPos(
	return msg.wParam; 
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
		GetClientRect( hwnd, &rect );
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

	case WM_KEYDOWN:
		wsprintf( szText, L" WM_KEYDOWN:    wParam=%i  lParam=%i", wParam, lParam );
		SetWindowText( hwnd, szText );
		InvalidateRect( hwnd, &rect, TRUE );
		SetTimer( hwnd, 111, 500, NULL );
		break;

	case WM_KEYUP:
		wsprintf( szText, L" WM_KEYUP:    wParam=%i  lParam=%i", wParam, lParam );
		SetWindowText( hwnd, szText );
		InvalidateRect( hwnd, &rect, TRUE );
		SetTimer( hwnd, 111, 500, NULL );
		break;

	case WM_SYSKEYDOWN:
		wsprintf( szText, L" WM_SYSKEYDOWN:    wParam=%i  lParam=%i", wParam, lParam );
		SetWindowText( hwnd, szText );
		InvalidateRect( hwnd, &rect, TRUE );
		SetTimer( hwnd, 111, 500, NULL );
		break;

	case WM_SYSKEYUP:
		wsprintf( szText, L" WM_SYSKEYUP:    wParam=%i  lParam=%i", wParam, lParam );
		SetWindowText( hwnd, szText );
		InvalidateRect( hwnd, &rect, TRUE );
		SetTimer( hwnd, 111, 500, NULL );		// по таймеру рядок робиться порожнім
		break;

	case WM_TIMER: 
		KillTimer( hwnd, 111 );					// зупиняємо таймер
		*szText = 0;							// "очищуємо" рядок
		SetWindowText( hwnd, szText );			// виводимо пустий рядок у заголовок
		InvalidateRect( hwnd, &rect, TRUE );	// виводимо пустий рядок у вікно
		break;

	case WM_DESTROY: 
		PostQuitMessage(0); 
		return 0; 
	} 

	return DefWindowProc(hwnd, iMsg, wParam, lParam); 
}


