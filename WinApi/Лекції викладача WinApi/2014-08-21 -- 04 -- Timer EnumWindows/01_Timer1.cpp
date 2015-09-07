/*
	Написати прогу, котра щосекунди змінює значення якоїсь змінної:
		- якщо натиснено "стрілка вгору"  -- то збільшує
		- якщо натиснено "стрілка донизу" -- то зменшує
		- якщо натиснено "пробєл"		  -- то зупиняється зміна
	і виводить це значення у заголовок віна і посередині вікна

	Відео: http://www.ex.ua/load/121960242

*/


#include <windows.h> 
#include <tchar.h>

#define MYTIMER_UP		184132
#define MYTIMER_DOWN	123456

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
						555,
						222,
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



// ф-я, котра поновлює заголовк і вміст вікна після зміни iVal
void UpdateVal( HWND hwnd, int iVal, wchar_t * szVal )
{
	wsprintf( szVal, L"Поточне значення: %i", iVal );
	SetWindowText( hwnd, szVal );	// кладемо текст у заголовок вікна 

	// кладемо текст у саме вікно 
	RECT rect;
	GetClientRect( hwnd, &rect );
	InvalidateRect( hwnd, &rect, TRUE );

}
//void UpdateVal( HWND hwnd, int iVal, wchar_t szVal )




LRESULT CALLBACK WndProc(HWND hwnd, UINT iMsg, WPARAM wParam, LPARAM lParam) 
{ 
	static int iVal = rand() % 1001 - 500;
	static wchar_t szVal[55] = L"Натисніть стрілочку вгору, або стрілочку донизу";

	switch(iMsg) 
	{ 
	case WM_CREATE: 
		SetWindowText( hwnd, szVal );	// кладемо текст у заголовок вікна одразу після створення
		return 0; 
		 
	case WM_PAINT: 
		{
			PAINTSTRUCT ps;
			RECT rect;
			HDC hdc = BeginPaint(hwnd, &ps); 
			GetClientRect(hwnd, &rect);
			DrawText(hdc, szVal, -1, &rect, DT_SINGLELINE | DT_CENTER | DT_VCENTER ); 
			EndPaint(hwnd, &ps); 
			return 0; 
		}

	case WM_DESTROY: 
		PostQuitMessage(0); 
		return 0; 

	case WM_KEYDOWN:
		switch( wParam )
		{
		case VK_UP:		//якщо натиснено "стрілка вгору"  -- то збільшує
			KillTimer( hwnd, MYTIMER_DOWN );
			SetTimer( hwnd, MYTIMER_UP, 300, NULL );
			break;

		case VK_DOWN:	// якщо натиснено "стрілка донизу" -- то зменшує
			KillTimer( hwnd, MYTIMER_UP );
			SetTimer( hwnd, MYTIMER_DOWN, 300, NULL );
			break;

		case VK_SPACE:	//  якщо натиснено "пробєл"		  -- то зупиняється зміна
			KillTimer( hwnd, MYTIMER_DOWN );
			KillTimer( hwnd, MYTIMER_UP );
			break;

		}// switch( wParam )
		return 0;


	case WM_TIMER:
		switch( wParam )
		{
		case MYTIMER_UP:
			iVal++;
			UpdateVal( hwnd, iVal, szVal );
			break;

		case MYTIMER_DOWN:
			iVal--;
			UpdateVal( hwnd, iVal, szVal );
			break;

		}
		return 0;

	}// switch(iMsg)

	return DefWindowProc(hwnd, iMsg, wParam, lParam); 

}// LRESULT CALLBACK WndProc(HWND hwnd, UINT iMsg, WPARAM wParam, LPARAM lParam) 


