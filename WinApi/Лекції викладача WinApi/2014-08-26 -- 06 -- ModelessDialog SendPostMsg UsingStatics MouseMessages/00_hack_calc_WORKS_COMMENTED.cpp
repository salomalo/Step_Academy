#include <windows.h>
#include <vector>
#include <iostream>
#include <time.h>

using namespace std;
void RandPos(int& x, int& y);

BOOL CALLBACK EnumChildProc(HWND hWnd, LPARAM lParam);
VOID CALLBACK TimerProc(HWND hwnd, UINT uMsg, UINT_PTR idEvent, DWORD dwTime);
vector <HWND> buttons;		// вектор для накопичення hwnd кнопок калькулятора
size_t x = 1;
HDC hDCScreen = GetDC(NULL);
int Horres = GetDeviceCaps(hDCScreen, HORZRES);
int Vertres = GetDeviceCaps(hDCScreen, VERTRES);



int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPSTR lpszCmdLine, int nCmdShow)
{
	MSG lpMsg;
	srand((unsigned)time(0));
	static HWND hWnd;

	// Шукаємо калькулятор по назві класу
	HWND hCalc = FindWindow(TEXT("CalcFrame"), NULL);
	while (!hCalc)
	{
		Sleep(5000);
		hCalc = FindWindow(TEXT("CalcFrame"), NULL);
	}
	if (x == 1 && hCalc)
	{
		MessageBox(hWnd, TEXT("Калькулятор зявився!"), TEXT("Info"), MB_OK | MB_ICONINFORMATION);
		//шукаємо кнопки - дочірні вікна калькулятора
		EnumChildWindows(hCalc, EnumChildProc, (LPARAM)hWnd);		// EnumChildWindows викликає EnumChildProc для кожного дочірнього вікна, щоразу передаючи їй його hwnd
		x++;
	}

	// запускаємо таймер для "спецефектів"
	SetTimer(hWnd, 1, 500, TimerProc);	// TimerProc -- таймерна процедура, котра обробляє повідомлення WM_TIMER від таймера (у нас немає вікна і немає віконної процедури)
	
	// стандартний цикл доставки повідомлень -- повинен у будь-якій програмі для Windows, котра обробляє повідомлення.
	// нам він потрібен для доставки повідомлень від таймера до TimerProc
	while (GetMessage(&lpMsg, NULL, 0, 0))
	{
		TranslateMessage(&lpMsg);
		DispatchMessage(&lpMsg);
	}
	return lpMsg.wParam;
}


// EnumChildWindows викликає EnumChildProc для кожного дочірнього вікна (всього - 37 разів), щоразу передаючи їй його hwnd
BOOL CALLBACK EnumChildProc(HWND hWnd, LPARAM lParam)
{
	// визначаємо ім'я класу дочірнього вікна у classname
	TCHAR classname[100] = { 0 };
	GetClassName(hWnd, classname, 100); 

	// якщо клас дочірного вікна "Button" (тобто, це - кнопка) -- додаємо його до вектора buttons
	if (!lstrcmpi(classname, TEXT("Button")))
	{
		buttons.push_back(hWnd);
	}
	return TRUE;	// для продовження перебору дочірніх вікон EnumChildWindows
}



void RandPos(int& x, int& y)
{
	x = rand() % Horres - 200;		// 200 -- ширина вікна калькулятора (краще взяти розмір за допомогою GetWindowRect)
	if (x < 0)
		x = 0;
	y = rand() % Vertres - 300;		// 300 -- висота вікна калькулятора (краще взяти розмір за допомогою GetWindowRect)
	if (y < 0)
		y = 0;
}


// таймерна процедура -- викликається щоразу, коли спрацьовує таймер
VOID CALLBACK TimerProc(HWND hwnd, UINT uMsg, UINT_PTR idEvent, DWORD dwTime)
{
	static bool flag = true;
	const LPWSTR buff = L"             Калькулятор збожеволів!             ";
	static LPTSTR text = buff;
	static int count;
	int x = 0, y = 0;
	RandPos(x, y);	// рандомна позиція калькулятора
	count++;
	text++;
	if (count == 37)
	{
		count = 0;
		text = buff;
	}
	
	HWND h_kalk = FindWindow(TEXT("CalcFrame"), NULL);		// шукаємо калькулятор, щоби змінити заголовок, позицію.....
	if (!h_kalk && flag)
	{
		flag = false;	// щоби був лише один MessageBox, а не на кожне спрацювання таймера (можна KillTimer )
		MessageBox(hwnd, TEXT("Калькулятор зник!"), TEXT("Info"), MB_OK | MB_ICONERROR);
		PostQuitMessage(0);		// завершення програми -- розриває цикл доставки повідомлень у WinMain ( GetMessage  повертає FALSE, одержавши WM_QUIT )
	}
	SetWindowText(h_kalk, text);	
	
	// змінюємо текст заголовку Калькулятора
	//SetWindowPos(h_kalk, NULL, x, y, NULL, NULL, true);
	
	
	// показуємо раніше заховану кнопку ( індекс її хендла у векторі лежить у prew)
	size_t j = rand() % buttons.size();				// випадковий індекс вектора кнопок (визначає кнопу, котру сховаємо зараз )
	//static size_t prew = -1;						// size_t це синонім для unsigned int і не може бути від'ємним, тому if завжди спрацює -- і видасть помилку за межами розміру вектора
	static int prew = -1;							// індекс захованої раніше кнопки -- щоби її потім відновити
	vector <HWND> ::iterator i = buttons.begin();	// і - ітератор на перший елемент вектора (першу кнопку)
	if (prew >= 0 )
	{
		//ShowWindow( *(i + prew), SHUTDOWN_RESTART);
		ShowWindow( *(i + prew), SW_SHOW);
		//InvalidateRect(*(i + j), NULL, TRUE);
		//UpdateWindow(*(i + j));
	}
	
	ShowWindow(*(i + j), SW_HIDE);
	prew = j;	// цю кнопку заховали -- зберігаємо її індекс
	InvalidateRect(h_kalk, NULL, TRUE);				// примушуємо Калькулятор перемалювати свою клієнтську зону
}

