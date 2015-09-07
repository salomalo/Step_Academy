#include <windows.h> 
#include <tchar.h>



// Прототип функції, котра викликається EnumWindows для кожного вікна і повертає TRUE, якщо треба продовжити перебір вікон
BOOL CALLBACK MyWindowEnumProc( HWND hwnd, LPARAM lParam );



int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR szCmdLine, int iCmdShow) 
{ 
	// пререаховує (перебирає) вікна і викликає MyWindowEnumProc, передаючи hwnd,
	//поки MyWindowEnumProc не поверне FALSE, або не закінчаться вікна
	EnumWindows(
		MyWindowEnumProc,	//	вказівник на колбек-функцію (предикат)
		NULL				//  параметр, котрий передасться функції-предикату MyWindowEnumProc у другому параметрі
		);

} 



// Функція, котра викликається EnumWindows для кожного вікна і повертає TRUE, якщо треба продовжити перебір вікон
BOOL CALLBACK MyWindowEnumProc( HWND hwnd, LPARAM lParam )
{
	static int nCount;
	nCount++;
	wchar_t szText [555];
	wchar_t szTitle [555];
	wsprintf( szTitle, L"Заголовок %i-го вікна", nCount );
	GetWindowText( hwnd, szText, 555 );	// кладе у буфер szText заголовок вікна hwnd
	if( IDOK == MessageBox( NULL, szText, szTitle, MB_ICONINFORMATION | MB_OKCANCEL ) )
		return TRUE;	// для продовження перебору вікон
	else
		return FALSE;	// щоб припинити перебор вікон
}



