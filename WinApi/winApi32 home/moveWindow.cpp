//  About Keyboard Input  http://msdn.microsoft.com/en-us/library/windows/desktop/ms646267(v=vs.85).aspx

#include <windows.h> 
#include <tchar.h>

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

#define MYTIMER 12345

int x;
int y;


int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR szCmdLine, int iCmdShow)
{
	static TCHAR szAppName[] = _TEXT("MyWindowClass");

	WNDCLASSEX wndclass;
	wndclass.cbSize = sizeof(wndclass);
	wndclass.style = CS_HREDRAW | CS_VREDRAW;
	wndclass.lpfnWndProc = WndProc;
	wndclass.cbClsExtra = 0;
	wndclass.cbWndExtra = 0;
	wndclass.hInstance = hInstance;
	wndclass.hIcon = LoadIcon(NULL, IDI_APPLICATION);
	wndclass.hCursor = LoadCursor(NULL, IDC_ARROW);
	wndclass.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);
	wndclass.lpszMenuName = NULL;
	wndclass.lpszClassName = szAppName;
	wndclass.hIconSm = LoadIcon(NULL, IDI_APPLICATION);

	if (!RegisterClassEx(&wndclass))
	{
		MessageBox(NULL, _TEXT("Не вдалося зареєструвати віконний клас!"), _TEXT("Помилка!"), MB_OK);
		return 0;
	}

	HWND hwnd;
	hwnd = CreateWindow(
		szAppName,
		_TEXT("Моє перше \"справжнє\" вікно "),
		WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT,
		CW_USEDEFAULT,
		150,
		150,
		NULL,
		NULL,
		hInstance,
		NULL
		);

	ShowWindow(hwnd, iCmdShow);
	UpdateWindow(hwnd);

	x = GetSystemMetrics(SM_CXSCREEN); //возвращает размер экрана
	y = GetSystemMetrics(SM_CYSCREEN);

	MSG msg;
	while (GetMessage(&msg, NULL, 0, 0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
	
	return msg.wParam;
}


LRESULT CALLBACK WndProc(HWND hwnd, UINT iMsg, WPARAM wParam, LPARAM lParam)
{
	static TCHAR szTime[55];

	RECT rect;
	GetWindowRect(hwnd, &rect); // позволяет получить размеры прямоугольника окна:
	int lr = rect.left;
	int tr = rect.top;

	switch (iMsg)
	{
	case WM_CREATE:
		SetWindowText(hwnd, szTime);
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
		{
			wchar_t szMsg[55];
			wsprintf(szMsg, L"WM_KEYDOWN : %i ( %c )", wParam, wParam);
			SetWindowText(hwnd, szMsg);

			if (wParam == VK_RETURN)
			{
				SetTimer(hwnd, MYTIMER, 100, NULL);
				SetWindowPos(hwnd, HWND_TOPMOST, lr, tr, 150, 150, SWP_SHOWWINDOW);
			}

			if (wParam == VK_ESCAPE)
			{
				KillTimer(hwnd, MYTIMER);	
				SetWindowPos(hwnd, HWND_TOPMOST, lr, tr, 150, 150, SWP_SHOWWINDOW);
			}

			if (wParam == VK_UP)
			{
				SetWindowPos(hwnd, HWND_TOPMOST, lr, tr - 1, 150, 150, SWP_SHOWWINDOW);//изменить положение окна
			}

			if (wParam == VK_DOWN)
			{
				SetWindowPos(hwnd, HWND_TOPMOST, lr, tr + 1, 150, 150, SWP_SHOWWINDOW);
			}

			if (wParam == VK_LEFT)
			{
				SetWindowPos(hwnd, HWND_TOPMOST, lr - 1, tr, 150, 150, SWP_SHOWWINDOW);
			}

			if (wParam == VK_RIGHT)
			{
				SetWindowPos(hwnd, HWND_TOPMOST, lr + 1, tr, 150, 150, SWP_SHOWWINDOW);
			}
		}
		return 0;

	case WM_SYSKEYDOWN:
		return 0;

	case WM_KEYUP:
		{
			wchar_t szMsg[55];
			wsprintf(szMsg, L"WM_KEYUP: %i ( %c )", wParam, wParam);
			SetWindowText(hwnd, szMsg);	// міняємо текст заголовку вікна
		}
		return 0;

	case WM_TIMER:// обробляємо повідомлення, яке надсилається вікну таймером кожні 100 мілісекунд
		{
			while (true)
			{
				if (lr != x - 150)
					SetWindowPos(hwnd, HWND_TOPMOST, lr++, tr, 150, 150, SWP_SHOWWINDOW);
				else
					if (tr != y - 150)
						SetWindowPos(hwnd, HWND_TOPMOST, lr, tr++, 150, 150, SWP_SHOWWINDOW);
				//else 
				//	if (lr != x - 150)
				//	SetWindowPos(hwnd, HWND_TOPMOST, lr, tr--, 150, 150, SWP_SHOWWINDOW);
			}

			RECT rect;// примушуємо перемалювати вікно -- посилаємо повідомлення WM_PAINT
			GetClientRect(hwnd, &rect);
			InvalidateRect(hwnd, &rect, TRUE);
		}
		break;

	case WM_DESTROY:
		PostQuitMessage(0);
		return 0;
	}

	return DefWindowProc(hwnd, iMsg, wParam, lParam);
}