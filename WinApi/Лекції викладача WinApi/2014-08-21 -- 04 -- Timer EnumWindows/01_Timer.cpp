/*
	Вивести у заголовок вікна "живий" годинник. 
	Запускається по ENTER
	Зупиняється ESC

*/



// TOOLS > Spy++

#include <windows.h> 
#include <tchar.h>


#define MYTIMER 12345

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
	static TCHAR szTime[55] = _TEXT("Час іще не визначений");

	switch(iMsg) 
	{ 
	case WM_CREATE: 
		SetWindowText( hwnd, szTime );
		return 0; 
		 
	case WM_PAINT: 
		{
			PAINTSTRUCT ps;
			RECT rect;
			HDC hdc = BeginPaint(hwnd, &ps); 
			GetClientRect(hwnd, &rect);
			DrawText(hdc, szTime, -1, &rect, DT_SINGLELINE | DT_CENTER | DT_VCENTER); 
			EndPaint(hwnd, &ps); 
			return 0; 
		}


	case WM_KEYDOWN:
		switch( wParam )
		{
		case VK_RETURN:
			SetTimer( hwnd, MYTIMER, 100, NULL );	// запускаємо таймер
			break;

		case VK_ESCAPE:
			KillTimer( hwnd, MYTIMER );				// вбиваємо таймер
			break;

		}


	// обробляємо повідомлення, яке надсилається вікну таймером кожні 100 мілісекунд
	case WM_TIMER:
		{
			SYSTEMTIME st;						// структура для зберігання часу 
			//GetSystemTime( &st );				// -- по Грінвічу
			GetLocalTime( &st );				// -- той, що на годинниау
			wsprintf( szTime, L"%02i:%02i:%02i ", st.wHour, st.wMinute, st.wSecond );
			SetWindowText( hwnd, szTime );		// в заголовок вікна

			// примушуємо перемалювати вікно -- посилаємо повідомлення WM_PAINT
			RECT rect;
			GetClientRect( hwnd, &rect );
			InvalidateRect( hwnd, &rect, TRUE );	
		}
		break;






	case WM_DESTROY: 
		PostQuitMessage(0); 
		return 0; 
	} 

	return DefWindowProc(hwnd, iMsg, wParam, lParam); 
}


