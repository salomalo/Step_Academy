//  About Keyboard Input  http://msdn.microsoft.com/en-us/library/windows/desktop/ms646267(v=vs.85).aspx

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
			DrawText(hdc, _TEXT("Hello, Windows !"), -1, &rect, DT_SINGLELINE | DT_CENTER | DT_VCENTER); 
			EndPaint(hwnd, &ps); 
			return 0; 
		}


	case WM_KEYDOWN:
		{
			wchar_t szMsg [55];
			wsprintf( szMsg, L"WM_KEYDOWN : %i ( %c )", wParam, wParam );
			SetWindowText( hwnd, szMsg );	// міняємо текст заголовку вікна
			GetWindowRect();
		}
		return 0;


	case WM_KEYUP:
		{
			wchar_t szMsg [55];
			wsprintf( szMsg, L"WM_KEYUP : %i ( %c )", wParam, wParam );
			SetWindowText( hwnd, szMsg );	// міняємо текст заголовку вікна

		}
		return 0;


	case WM_SYSKEYDOWN:
		{
			wchar_t szMsg [55];
			wsprintf( szMsg, L"WM_SYSKEYDOWN : %i ( %c )", wParam, wParam );
			SetWindowText( hwnd, szMsg );	// міняємо текст заголовку вікна
		}
		return 0;


	case WM_SYSKEYUP:
		{
			wchar_t szMsg [55];
			wsprintf( szMsg, L"WM_SYSKEYUP : %i ( %c )", wParam, wParam );
			SetWindowText( hwnd, szMsg );	// міняємо текст заголовку вікна
		}
		return 0;


	case WM_DESTROY: 
		PostQuitMessage(0); 
		return 0; 
	} 

	return DefWindowProc(hwnd, iMsg, wParam, lParam); 
}


