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
	static int iRes;


	switch(iMsg) 
	{ 
	case WM_CREATE: 
		{
			iRes=-1;
			return 0; 
		}

	case WM_KEYDOWN:	// при НАТИСКАННІ будь-якої клавіші
		{
			iRes=0;
			
			if(IDNO == MessageBox( NULL, _TEXT("sky is red?"), L"your choice:", MB_YESNO ))
			{
			iRes++;
			}
			
			if(IDYES == MessageBox( NULL, _TEXT("3+3 = 6 ?"), L"your choice:", MB_YESNO ))
			{
			iRes++;
			}

			if(IDYES == MessageBox( NULL, _TEXT("do you speek english? ?"), L"your choice:", MB_YESNO ))
			{
			iRes++;
			}


			RECT rect;
			GetClientRect(hwnd,& rect); //щоб заставити перемалювати
			InvalidateRect(hwnd,&rect,TRUE ); //стираємо вікно
			return 0;
		}

	case WM_PAINT: 
		{
			PAINTSTRUCT ps;
			RECT rect;
			HDC hdc = BeginPaint(hwnd, &ps); 
			GetClientRect(hwnd, &rect);

			if(iRes<0)
			{
				DrawText(hdc, _TEXT("Натисніть будь-яку клавішу, щоб почати !"), -1, &rect, DT_SINGLELINE | DT_CENTER | DT_VCENTER); 
			}
			else
			{
				wchar_t tmp[255];
				wsprintf( tmp, L"You Res is : %i", iRes );
				DrawText(hdc, tmp, -1, &rect, DT_SINGLELINE | DT_CENTER | DT_VCENTER); 
			}

			EndPaint(hwnd, &ps);
			return 0; 
		}

	case WM_DESTROY: 
		PostQuitMessage(0); 
		return 0; 
	} 

	return DefWindowProc(hwnd, iMsg, wParam, lParam); 
}


