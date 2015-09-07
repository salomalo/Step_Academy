/*
	Порахувати к-ть вікон і вивести їх заголовки одним MessageBox
*/


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
	MyStruct Data;
	Data.num = 0;

	// пререаховує (перебирає) вікна поки MyWindowEnumProc не поверне FALSE, або не закінчаться вікна
	EnumWindows(
		MyWindowEnumProc,		//	вказівник на колбек-функцію (предикат)
		(LPARAM)&Data			//  параметр, котрий передасться функції-предикату MyWindowEnumProc у другому параметрі -- передаємо вказівник на струтуру, приведений до LPARAM
		);

	wchar_t szTile [555];
	wsprintf( szTile, L"Зараз у системі є %i вікон із такими заголовками", Data.num );
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

	return TRUE;	// для продовження перебору вікон
}



