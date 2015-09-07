#include <windows.h> 
#include <string>
using namespace std;






int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR szCmdLine, int iCmdShow) 
{ 
	// шукаємо вікно по заголовку --- http://msdn.microsoft.com/en-us/library/windows/desktop/ms633499(v=vs.85).aspx
	HWND hwnd = FindWindow( 
		NULL,			// ім'я віконного класу (NULL -- якщо не знаємо)	одержати клас вікна по hwnd можна GetClassName
		L"Calculator"	// ім'я вікна
		);


	if( !hwnd )
	{
		MessageBox( NULL, L"НЕ знайшли!", L":(", MB_OK | MB_ICONERROR );
		return 0;
	}
	
	SetWindowPos( hwnd, HWND_TOPMOST, 100, 100, 100, 100, SWP_SHOWWINDOW | SWP_NOSIZE );
	SetWindowText( hwnd, L"Арифмометр" );

	wchar_t szClassName[77];
	GetClassName( hwnd, szClassName, 77 );
	MessageBox( NULL, szClassName, L"Клас калькулятора", MB_OK | MB_ICONINFORMATION );


} 



