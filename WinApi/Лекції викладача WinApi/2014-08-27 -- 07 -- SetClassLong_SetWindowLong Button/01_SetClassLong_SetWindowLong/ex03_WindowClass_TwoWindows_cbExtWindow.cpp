#include <Windows.h>
#include <ctime>
using namespace std;

// прототип віконної процедури
LRESULT CALLBACK WindowProcedure( HWND, UINT, WPARAM, LPARAM );

struct USERDATA
{
	LONG colorBG;		// тут зберігатимемо колір тла (фону) вікна 
	LONG colorTxt;		// тут зберігатимемо колір тексту
};


// точка входу - WinMain(...)
int WINAPI WinMain(	 HINSTANCE	hInstance		// хендл екземпляра програми
	,HINSTANCE	hPrevInstance	// хендл попереднього екземпляра
	,PSTR		szCmdLine		// вказівник на рядок з параметрами командного рядка
	,int		iCmdShow		// параметр початкового розміру вікна (SW_...)
	)
{
	srand( time(0));
	wchar_t		szNameOfApplication[]	= L"Моє перше справжнє вікно";
	wchar_t		szNameOfWindowClass[]	= L"MyWindowClass";

	MessageBox( NULL, L"Цей приклад ілюструє використання розширеної пам'яті вікна,\nдля зберігання даних про колір тла і тексту.\n\nА ще - як зміна віконного класу впливає на вікна, створені на його основі,\nта як боротися із негативними наслідками цього.\n\nПри клацанні мишею у клієнтській зоні змінюється колір тексту і тла вікна", L"Пояснення", MB_OK | MB_ICONINFORMATION );

	wchar_t		szSizesMessage[255];
	wsprintf( szSizesMessage, L"sizeof( LONG ) = %d\nsizeof( COLORREF ) = %d\n sizeof( bool ) = %d", sizeof( LONG ), sizeof( COLORREF ), sizeof( bool ) );
	MessageBox( NULL, szSizesMessage, L"Розміри типів", MB_OK | MB_ICONINFORMATION );
	wsprintf( szSizesMessage, L"sizeof( LONG ) = %d\nsizeof( COLORREF ) = %d\n sizeof( BOOL ) = %d\n sizeof( USERDATA ) = %d", sizeof( LONG ), sizeof( COLORREF ), sizeof( BOOL ), sizeof( USERDATA ) );
	MessageBox( NULL, szSizesMessage, L"Розміри типів", MB_OK | MB_ICONINFORMATION );

	//////////////////////      I.   описуємо віконний клас        ///////////////////////////
	WNDCLASSEX	wc;
	wc.cbSize		= sizeof( WNDCLASSEX );					// розмір структури у байтах
	wc.style		= CS_VREDRAW | CS_HREDRAW;				// стиль вікна
	wc.lpfnWndProc	= WindowProcedure;						// вказівник на віконну процедуру
	wc.cbClsExtra	= 0;									// к-ть байт, що резервуються слідом за структурою класу
	wc.cbWndExtra	= sizeof( USERDATA );					// к-ть байт, що резервуються слідом за екземпляном вікна
	wc.hInstance	= hInstance;							// хендл додатку, що створив вікно (нашої проги)
	wc.hIcon		= LoadIcon( NULL, IDI_APPLICATION );	// визначає значок вікна
	wc.hIconSm		= LoadIcon( NULL, IDI_APPLICATION );	// визначає малий значок вікна
	wc.hCursor		= LoadCursor( NULL, IDC_ARROW );		// визначає вигляд курсора миші
	wc.hbrBackground= (HBRUSH)GetStockObject( WHITE_BRUSH);	// визначає тло вікна
	wc.lpszMenuName	= NULL;									// визначає меню вікна
	wc.lpszClassName= szNameOfWindowClass;					// визначає ім'я віконного класу



	////////////////////       II.  реєструємо віконний клас зі властивостями, описаними в структурі wc   ///////////////////
	if( ! RegisterClassEx( &wc ) )
	{
		MessageBox( NULL, L"Не вдалося зареєструвати віконний клас!", L"Хана!", MB_ICONERROR | MB_OK );
		return 0;
	}


	/////////////////////     III.   Створюємо вікно на основі зареєєстрованого віконного класу     /////////////////////
	// але цього разу - уже два вікна і чітко вказуємо положення і розміри кожного
	HWND hWindow1 = CreateWindow( szNameOfWindowClass, szNameOfApplication, WS_OVERLAPPEDWINDOW, 10, 10, 500, 500, NULL, NULL, hInstance, NULL );
	HWND hWindow2 = CreateWindow( szNameOfWindowClass, szNameOfApplication, WS_OVERLAPPEDWINDOW, 600, 10, 500, 500, NULL, NULL, hInstance, NULL );

	if( ! ( hWindow1 && hWindow2 ) )
	{
		MessageBox( NULL, L"Не вдалося створити вікно!", L"Хана!", MB_ICONERROR | MB_OK );
		return 0;
	}


	/////////////////////     IV.   Відображаємо вікно      ///////////////////////////////////
	ShowWindow( hWindow1, iCmdShow );
	ShowWindow( hWindow2, iCmdShow );


	/////////////////////      V.   Цикл обробки повідомлень      ///////////////////////////////////
	MSG msg;	// ексземпляр структури повідомлення
	while( GetMessage( &msg, NULL, 0, 0 ) )
	{
		TranslateMessage( &msg );
		DispatchMessage(  &msg );
	}
	MessageBox( NULL, L"Одержано повідомлення WM_QUIT:\n  -- GetMessage(...) повернула false\n  -- цикл обробки повідомлень перервався", L"WM_QUIT!", MB_ICONINFORMATION | MB_OK );


	return 0 ;
}//int WINAPI WinMain(...)




/////////////////////////////    ВІКОННА ПРОЦЕДУРА     ///////////////////////////////////////
LRESULT CALLBACK WindowProcedure
	(	HWND hWindow,	// хендл вікна, для котрого надійшла мессага (тобто, одна ВП може обробляти мессаги декількох вікон?)
		UINT iMsg,		// ID повідомлення
		WPARAM wParam,	// параметр одержаного повідомлення
		LPARAM lParam	// ще один параметр одержаного повідомлення
	)
{// LRESULT CALLBACK WindowProcedure( HWND, UINT, WPARAM, LPARAM )


	// для кожного виду повідомлень - своя обробка
	switch( iMsg )
	{

	case WM_CREATE:		// надсилається вікну одразу після його створення ф-єю CreateWindow
	{
		MessageBox( NULL, L"Створюється вікно!", L"УВАГА !", MB_ICONASTERISK | MB_OK );

		USERDATA ud;
		ud.colorBG	= RGB( 255, 255, 255 );		// спочатку - білий колір тла
		ud.colorTxt	= RGB(   0,   0,   0 );		// спочатку - чорний колір тексту
		
		// зберігаємо користувацькі дані у додатковій області пам'яті вікна
		SetWindowLongPtr( hWindow, 0 * sizeof(LONG), (LONG) ud.colorBG );	// зберігаємо користувацькі дані вікна зі зміщенням 0 (тобто colorBG );
		SetWindowLongPtr( hWindow, 1 * sizeof(LONG), (LONG) ud.colorTxt );	// зберігаємо користувацькі дані вікна зі зміщенням 1 (тобто colorText );

		//RECT rectWindow;
		//GetWindowRect( hWindow, &rectWindow );
		//SetWindowPos( hWindow, HWND_TOP, rectWindow.left, rectWindow.top, rectWindow.right - rectWindow.left, rectWindow.bottom - rectWindow.top, SWP_SHOWWINDOW );

		break;			// далі це повідомлення обробиться стандартною віконною процедурою DefWindowProc(...)
	}

	case WM_CLOSE:		// надсилається вікну внаслідок ініціації його закриття користувачем (Alt+F4,кнопкою чи меню) або програмно (напр. Диспетчером задач)
		if( IDYES == MessageBox( hWindow, L"Ви справді хочете закрити своє перше вікно ?", L"Невже ?", MB_ICONQUESTION | MB_YESNO ) )
			break;		// далі це повідомлення обробиться стандартною віконною процедурою DefWindowProc(...)
		else
			return 0;	// а отут - ми НЕ ДАЄМО обробити повідомлення стандартній віконній процедурі DefWindowProc(...)


	case WM_DESTROY:	// надсилається вікну при обробці його повідомлення WM_CLOSE ф-ією DefWindowProc(...)
		MessageBox( NULL, L"Обробляється повідомлення WM_DESTROY", L"WM_DESTROY", MB_ICONINFORMATION | MB_OK );
		PostQuitMessage( 0 );	// ставить у чергу повідомлення WM_QUIT, яке перериває цикл обробки повідомлень. Якщо цього не зробити - хоч вікно зникне, але цикл обробки повідомлент триватиме (програма працюватиме без вікна - прибити її лише з «Диспетчера задач» )
		break;			// далі це повідомлення обробиться стандартною віконною процедурою DefWindowProc(...)



	case WM_PAINT:		// надсилається вікну, коли необхідно перемалювати (стала недійсною - не валідною) його клієнтську зону або її частину 
		{

			// дістаємо користувацькі дані вікна 
			USERDATA ud;
			ud.colorBG	= (COLORREF) GetWindowLongPtr( hWindow, 0 );	//зі зміщенням 0 (тобто colorBG );
			ud.colorTxt	= (COLORREF) GetWindowLongPtr( hWindow, sizeof(LONG) );	//зі зміщенням 0 (тобто colorBG );

			// змінюємо віконний клас
			SetClassLongPtr ( hWindow					// клас цього вікна
				,GCL_HBRBACKGROUND						// а саме: пензель тла (фону) вікна ( Handle to BRush of BACKGROUND )
				,(LONG) CreateSolidBrush( ud.colorBG )	// хендл нового пензля (суцільна заливка кольором з colorBG) приводимо до LONG - такий тип параметра ф-ї
				);	

			PAINTSTRUCT ps;
			HDC hdc = BeginPaint( hWindow, &ps );
			RECT rectClient;						// структура - координати прямокутника
			GetClientRect( hWindow, &rectClient );	// заповнює структуру rectClient координатами клієнтської області вікна

			//FillRect( hdc, &rectClient, CreateSolidBrush( ud.colorBG ) );	// промальовуємо тло вікна (у класі - лишилось біле)


			// встановлюємо колір тла і тексту значенням з додаткової пам'яті вікна
			SetBkColor( hdc, ud.colorBG );				
			SetTextColor( hdc, ud.colorTxt );

			// промальовуємо текст
			DrawText( hdc, L"Уря-а-а-а! Я вмію писати у вікні!!!", -1, &rectClient, DT_CENTER | DT_VCENTER | DT_SINGLELINE );

			EndPaint( hWindow, &ps );	// звільняємо контекст

			break;			// далі це повідомлення обробиться стандартною віконною процедурою DefWindowProc(...)
		}


	case WM_LBUTTONDOWN:	// надсилається вікну, коли в його клієнтській зоні сталося натискання лівої кнопки миші (є також повідомлення на відпускання, подвійний клік, а також на праву і середню кнопки)
		{
			USERDATA ud;
			ud.colorBG	= RGB( rand()%255, rand()%255, rand()%255 );	// генеруємо випадковий колір
			ud.colorTxt	= RGB( rand()%255, rand()%255, rand()%255 );	// генеруємо випадковий колір

			// зберігаємо користувацькі дані у додатковій області пам'яті вікна
			SetWindowLongPtr( hWindow, 0 * sizeof(LONG), (LONG) ud.colorBG );	// зберігаємо користувацькі дані вікна зі зміщенням 0 (тобто colorBG );
			SetWindowLongPtr( hWindow, 1 * sizeof(LONG), (LONG) ud.colorTxt );	// зберігаємо користувацькі дані вікна зі зміщенням 1 (тобто colorText );

			//// змінюємо віконний клас
			//SetClassLongPtr ( hWindow					// клас цього вікна
			//	,GCL_HBRBACKGROUND						// а саме: пензель тла (фону) вікна ( Handle to BRush of BACKGROUND )
			//	,(LONG) CreateSolidBrush( ud.colorBG )	// хендл нового пензля (суцільна заливка кольором з colorBG) приводимо до LONG - такий тип параметра ф-ї
			//	);	

			RECT rect;								// структура - координати прямокутника
			GetClientRect( hWindow, &rect );		// заповнює структуру rectClient координатами клієнтської області вікна
			InvalidateRect( hWindow, &rect,  true );	// позначаємо як недійсну (невалідну) усю клієнтську область - вінда автоматично кладе у чергу повідомлення WM_PAINT, як тільки нема інших повідомлень у черзі програми

			break;		// далі це повідомлення обробиться стандартною віконною процедурою DefWindowProc(...)
		}


	//case  WM_SIZING:
	//	{
	//		// дістаємо користувацькі дані вікна 
	//		COLORREF colorBG = (COLORREF) GetWindowLongPtr( hWindow, 0 );	//зі зміщенням 0 (тобто colorBG );

	//		// змінюємо віконний клас
	//		SetClassLongPtr ( hWindow					// клас цього вікна
	//			,GCL_HBRBACKGROUND						// а саме: пензель тла (фону) вікна ( Handle to BRush of BACKGROUND )
	//			,(LONG) CreateSolidBrush( colorBG )	// хендл нового пензля (суцільна заливка кольором з colorBG) приводимо до LONG - такий тип параметра ф-ї
	//			);	

	//		break;		// далі це повідомлення обробиться стандартною віконною процедурою DefWindowProc(...)
	//	}

	}// switch( iMsg )


	return DefWindowProc( hWindow, iMsg, wParam, lParam );	// ОБОВ'ЯЗКОВО -- хай стандартна віконна процедура обробить ті повідомлення, які не обробили ми !


}// LRESULT CALLBACK WindowProcedure( HWND, UINT, WPARAM, LPARAM )



