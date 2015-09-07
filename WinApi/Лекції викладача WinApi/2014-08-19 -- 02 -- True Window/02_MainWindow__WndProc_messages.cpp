#include <windows.h> 
#include <tchar.h>

// ВІКОННА ПРОЦЕДУРА -- приймає і обробляє повідомлення вікна
LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM); 



int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR szCmdLine, int iCmdShow) 
{ 
	static TCHAR szClassName[] = _TEXT("MyWindowClass"); 


	///////////////////////
	//
	//	1. Створення віконного класу
	//

	WNDCLASSEX wndclass; // структура, у полях якої розписно (грубо) поведінку вікна	-- http://msdn.microsoft.com/en-us/library/windows/desktop/ms633577(v=vs.85).aspx
	wndclass.cbSize			= sizeof(wndclass);						// розмір  самої структури в байтах
	wndclass.style			= CS_HREDRAW | CS_VREDRAW /*| CS_NOCLOSE*/;				// стиль класу		-- 
	wndclass.lpfnWndProc	= WndProc;								// вказівник на віконну процедуру
	wndclass.cbClsExtra		= 0;									// розмір додаткової пам'яті слідом за блоком пам'яті для класу
	wndclass.cbWndExtra		= 0; 									// розмір додаткової пам'яті слідом за блоком пам'яті для вікна
	wndclass.hInstance		= hInstance;							// хендл екземляру програми

	// визначає вигляд ВЕЛИКОЇ іконки
//	wndclass.hIcon			= LoadIcon(NULL, IDI_APPLICATION);		// http://msdn.microsoft.com/en-us/library/windows/desktop/ms648072(v=vs.85).aspx
//	wndclass.hIcon			= LoadIcon(NULL, IDI_ASTERISK);
	wndclass.hIcon			= LoadIcon(NULL, IDI_QUESTION);

	// визначає вигляд МАЛОЇ іконки
//	wndclass.hIconSm		= LoadIcon(NULL, IDI_APPLICATION);		// http://msdn.microsoft.com/en-us/library/windows/desktop/ms648072(v=vs.85).aspx
//	wndclass.hIconSm		= LoadIcon(NULL, IDI_SHIELD); 
	wndclass.hIconSm		= LoadIcon(NULL, IDI_WARNING); 

	// визначає вигляд вказівника миші
//	wndclass.hCursor		= LoadCursor(NULL, IDC_ARROW);			// http://msdn.microsoft.com/en-us/library/windows/desktop/ms648391(v=vs.85).aspx
//	wndclass.hCursor		= LoadCursor(NULL, IDC_CROSS);
	wndclass.hCursor		= LoadCursor(NULL, IDC_HAND);

	// визначає пензель, яким буде замальований фон вікна
//	wndclass.hbrBackground	=(HBRUSH) GetStockObject(WHITE_BRUSH); // http://msdn.microsoft.com/en-us/library/windows/desktop/dd144925(v=vs.85).aspx
//	wndclass.hbrBackground	=(HBRUSH) GetStockObject(BLACK_BRUSH); 
//	wndclass.hbrBackground	=(HBRUSH) GetStockObject(GRAY_BRUSH); 
	wndclass.hbrBackground	=(HBRUSH) CreateSolidBrush( RGB( 255 , 150 , 55 ) ); 

	wndclass.lpszMenuName	= NULL;			// ім'я меню (або NULL)
	wndclass.lpszClassName	= szClassName;	// ім'я віконного класу - як його ідентифікуватиме система





	///////////////////////
	//
	//	2. Реєстрація віконного класу
	//

	if( !RegisterClassEx(&wndclass) )	// повертає false, якщо не вдалось зареєструвати
	{
		MessageBox( NULL, _TEXT("Не вдалося зареєструвати віконний клас!"), _TEXT("Помилка!"), MB_OK );
		return 0;
	}







	///////////////////////
	//
	//	3. Створення вікна по зареєстрованому віконному класі -- ВОНО ЩЕ НЕ ПОКАЗУЄТЬСЯ !!!!
	//
	HWND hwnd;
	hwnd = CreateWindow(	// http://msdn.microsoft.com/en-us/library/windows/desktop/ms632679(v=vs.85).aspx
		szClassName,								// ім'я зареєстрованого віконного класу
		_TEXT("Моє перше \"справжнє\" вікно "),		// заголовок вікна
		WS_OVERLAPPEDWINDOW,						// стиль вікна	--- http://msdn.microsoft.com/en-us/library/windows/desktop/ms632600(v=vs.85).aspx
		150 /*CW_USEDEFAULT*/,			// X лівого верхнього кута
		555 /*CW_USEDEFAULT*/,			// Y лівого верхнього кута
		222/*CW_USEDEFAULT*/,			// ширина
		88 /*CW_USEDEFAULT*/,			// висота
		NULL,							// хендл дочірнього вікна
		NULL,							// хендл меню
		hInstance,						// хендл екземпляру програми, що "відповідальна" за вікно
		NULL							// параметр, котрий передається у повідомленні WM_CREATE
		); 




	///////////////////////
	//
	//	4. Відображення вікна
	//
	ShowWindow(hwnd, iCmdShow); 
	//UpdateWindow(hwnd);				// надсилає вікнонній процедурі повідомлення WM_PAINT





	///////////////////////
	//
	//	5. Запускаємо цикл обробки повідомлень
	//
	MSG msg;	// структура для зберігання повідомлення	--	http://msdn.microsoft.com/en-us/library/windows/desktop/ms644958(v=vs.85).aspx
	while( GetMessage(&msg, NULL, 0, 0) )	// бере повідомлення з черги програми і кладе у структуру msg, якщо повідомлення не WM_QUIT -- повертає TRUE
	{ 
		TranslateMessage(&msg);		// "перекладає" апаратні повід-ня (WM_KEYDOWN, WM_KEYUP) клавіатури з урахуванням поточної розкладки і генерує повідомлення WM_CHAR з кодом символу 
		DispatchMessage(&msg);		// доставляє повідомлення до конкретного вікна (кладе у чергу вікна, хендл якого вказано  у msg.hwnd )
	} 
//	SetWindowPos(
	return msg.wParam;	// wParam повідомлення WM_QUIT


} // int WINAPI WinMain()






// ВІКОННА ПРОЦЕДУРА -- приймає і обробляє повідомлення вікна
LRESULT CALLBACK WndProc(HWND hwnd, UINT iMsg, WPARAM wParam, LPARAM lParam) 
{ 
	switch(iMsg) 
	{ 
	case WM_CREATE:	// перше повідомлення, яке надходить до вікна -- тут ми маємо проініціалізувати якісь змінні
		MessageBox( NULL, _TEXT("WM_CREATE"), _TEXT("Одержано повідомлення"), MB_OK );
		return 0;


	case WM_KEYDOWN:	// при НАТИСКАННІ будь-якої клавіші
	//	MessageBox( NULL, _TEXT("WM_KEYDOWN"), _TEXT("Одержано повідомлення"), MB_OK );
		return 0;


	case WM_KEYUP:	// при ВІДПУСКАННІ будь-якої клавіші
		{
			wchar_t szMsg [55];
			wsprintf( szMsg, L"WM_KEYUP \n код клавіші: %i", wParam );
			MessageBox( NULL, szMsg, _TEXT("Одержано повідомлення"), MB_OK );
			return 0;
		}
		 
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

	case WM_DESTROY: 
		PostQuitMessage(0); 
		return 0; 
	} 

	// для тих повідомлень, котрі ми НЕ обробляємо самі викликаємо DefWindowProc
	return DefWindowProc(hwnd, iMsg, wParam, lParam); 
}


