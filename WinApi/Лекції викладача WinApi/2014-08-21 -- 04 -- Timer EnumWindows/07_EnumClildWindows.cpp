#include <windows.h> 
#include <string>
using namespace std;




// Прототип функції, котра викликається EnumWindows для кожного вікна і повертає TRUE, якщо треба продовжити перебір вікон
BOOL CALLBACK MyWindowEnumProc( HWND hwnd, LPARAM lParam );


struct MyStruct
{
	UINT	 num;		// лічильник вікон
	wstring  titles;	// список заголовків вікон
};





int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR szCmdLine, int iCmdShow) 
{ 
	// шукаємо вікно по заголовку --- http://msdn.microsoft.com/en-us/library/windows/desktop/ms633499(v=vs.85).aspx
	HWND hwnd = FindWindow( 
		NULL,			// ім'я віконного класу (NULL -- якщо не знаємо)	одержати клас вікна по hwnd можна GetClassName
		L"Calculator"	// ім'я вікна
		//L"Арифмометр"	// ім'я вікна
		);


	if( !hwnd )
	{
		MessageBox( NULL, L"НЕ знайшли!", L":(", MB_OK | MB_ICONERROR );
		return 0;
	}
	
	//SetWindowPos( hwnd, HWND_TOPMOST, 100, 100, 100, 100, SWP_SHOWWINDOW );
	SetWindowText( hwnd, L"Арифмометр" );
	//SetWindowText( hwnd, L"Calculator" );

	wchar_t szClassName[77];
	GetClassName( hwnd, szClassName, 77 );
	MessageBox( NULL, szClassName, L"Клас калькулятора", MB_OK | MB_ICONINFORMATION );


	/////////////////////////////////////////
	// 
	// перебираємо дочірні вікна калькулятора
	//
	MyStruct Data;
	Data.num = 0;

	// пререаховує (перебирає) ДОЧІРНІ вікна hwnd поки MyWindowEnumProc не поверне FALSE, або не закінчаться вікна
	EnumChildWindows(
		hwnd,					//  хендл батьківського вікна (калькулятора)
		MyWindowEnumProc,		//	вказівник на колбек-функцію (предикат)
		(LPARAM)&Data			//  параметр, котрий передасться функції-предикату MyWindowEnumProc у другому параметрі -- передаємо вказівник на струтуру, приведений до LPARAM
		);

	wchar_t szTile [555];
	wsprintf( szTile, L"Зараз у Калькулятора є %i дочірніх вікон із такими заголовками", Data.num );
	MessageBox( NULL, Data.titles.c_str(), szTile, MB_OK );




} 





// Функція, котра викликається EnumWindows для кожного вікна і повертає TRUE, якщо треба продовжити перебір вікон
BOOL CALLBACK MyWindowEnumProc( HWND hwnd, LPARAM lParam )
{

	MyStruct * pData = (MyStruct *) lParam;		// відновлюємо справжній тип 
	pData->num++;	// кожен виклик MyWindowEnumProc -- це ще одне вікно, тому збільшуємо лічильник вікон	

	wchar_t szTile [555];
	GetWindowText( hwnd, szTile, 555 );
	if( pData->titles.length() )
		pData->titles += L", ";
	pData->titles += L"'";
	pData->titles += szTile;
	pData->titles += L"'";

	SetWindowPos( hwnd, HWND_BOTTOM, 0, 0, 0, 0, SWP_HIDEWINDOW | SWP_NOMOVE | SWP_NOOWNERZORDER | SWP_NOSIZE );

	return TRUE;	// для продовження перебору вікон
}


