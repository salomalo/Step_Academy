//  About Keyboard Input  http://msdn.microsoft.com/en-us/library/windows/desktop/ms646267(v=vs.85).aspx

/*
	У заголовку вікна мають виводитися декілька останніх повідомлень клавіатури у тій послідовності, як надійшли
*/


#include <windows.h> 
#include <tchar.h>

#include <string>
using namespace std;

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

void ShowMsg( HWND hwnd, wstring & sMessages, wchar_t * szMsg )
{
	sMessages += L"\n";
	sMessages += szMsg;
	if( sMessages.length() > 500 )
		sMessages = sMessages.substr( sMessages.length() - 500 );
	SetWindowText( hwnd, sMessages.c_str() );	// міняємо текст заголовку вікна

	// примушуємо перемалювати вікно ( з новим вмістом стрінга sMessages )
	RECT rect;
	GetClientRect(hwnd, &rect);				// заповнює структуру rect координатами клієнтської зони
	InvalidateRect( hwnd, &rect, TRUE );	// оголошує клієнстку область недійсною і спричиняє надсилання повідомлення WM_PAINT
}


LRESULT CALLBACK WndProc(HWND hwnd, UINT iMsg, WPARAM wParam, LPARAM lParam) 
{ 
	static wstring sMessages;

	switch(iMsg) 
	{ 
	case WM_CREATE: 
		return 0; 
		 
	case WM_PAINT: 
		{
			RECT rect;
			GetClientRect(hwnd, &rect);			// заповнює структуру rect координатами клієнтської зони
			PAINTSTRUCT ps;
			HDC hdc = BeginPaint(hwnd, &ps);	// починає малювання у вікні (у клієнтській зоні) і повертає контекст пристою (device context)
			DrawText( hdc, sMessages.c_str(), -1, &rect, DT_LEFT ); 
			EndPaint(hwnd, &ps);				// завершує малювання
			return 0; 
		}


	case WM_KEYDOWN:
		{
			wchar_t szMsg [55];
			wsprintf( szMsg, L"WM_KEYDOWN : %i ( %c )", wParam, wParam );
			ShowMsg( hwnd, sMessages, szMsg );
		}
		return 0;


	case WM_KEYUP:
		{
			wchar_t szMsg [55];
			wsprintf( szMsg, L"WM_KEYUP : %i ( %c )", wParam, wParam );
			ShowMsg( hwnd, sMessages, szMsg );
		}
		return 0;


	case WM_CHAR:
		{
			wchar_t szMsg [55];
			wsprintf( szMsg, L"WM_CHAR : %i ( %c )", wParam, wParam );
			ShowMsg( hwnd, sMessages, szMsg );
		}
		return 0;


	case WM_SYSKEYDOWN:
		{
			wchar_t szMsg [55];
			wsprintf( szMsg, L"WM_SYSKEYDOWN : %i ( %c )", wParam, wParam );
			ShowMsg( hwnd, sMessages, szMsg );
		}
		return 0;


	case WM_SYSKEYUP:
		{
			wchar_t szMsg [55];
			wsprintf( szMsg, L"WM_SYSKEYUP : %i ( %c )", wParam, wParam );
			ShowMsg( hwnd, sMessages, szMsg );
		}
		return 0;


	case WM_SYSCHAR:
		{
			wchar_t szMsg [55];
			wsprintf( szMsg, L"WM_SYSCHAR : %i ( %c )", wParam, wParam );
			ShowMsg( hwnd, sMessages, szMsg );
		}
		return 0;


	case WM_DESTROY: 
		PostQuitMessage(0); 
		return 0; 
	} 

	return DefWindowProc(hwnd, iMsg, wParam, lParam); 
}


