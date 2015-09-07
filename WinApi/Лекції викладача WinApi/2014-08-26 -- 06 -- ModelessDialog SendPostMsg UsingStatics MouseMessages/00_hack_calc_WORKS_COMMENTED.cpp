#include <windows.h>
#include <vector>
#include <iostream>
#include <time.h>

using namespace std;
void RandPos(int& x, int& y);

BOOL CALLBACK EnumChildProc(HWND hWnd, LPARAM lParam);
VOID CALLBACK TimerProc(HWND hwnd, UINT uMsg, UINT_PTR idEvent, DWORD dwTime);
vector <HWND> buttons;		// ������ ��� ����������� hwnd ������ ������������
size_t x = 1;
HDC hDCScreen = GetDC(NULL);
int Horres = GetDeviceCaps(hDCScreen, HORZRES);
int Vertres = GetDeviceCaps(hDCScreen, VERTRES);



int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPSTR lpszCmdLine, int nCmdShow)
{
	MSG lpMsg;
	srand((unsigned)time(0));
	static HWND hWnd;

	// ������ ����������� �� ���� �����
	HWND hCalc = FindWindow(TEXT("CalcFrame"), NULL);
	while (!hCalc)
	{
		Sleep(5000);
		hCalc = FindWindow(TEXT("CalcFrame"), NULL);
	}
	if (x == 1 && hCalc)
	{
		MessageBox(hWnd, TEXT("����������� �������!"), TEXT("Info"), MB_OK | MB_ICONINFORMATION);
		//������ ������ - ������ ���� ������������
		EnumChildWindows(hCalc, EnumChildProc, (LPARAM)hWnd);		// EnumChildWindows ������� EnumChildProc ��� ������� ���������� ����, ������ ��������� �� ���� hwnd
		x++;
	}

	// ��������� ������ ��� "����������"
	SetTimer(hWnd, 1, 500, TimerProc);	// TimerProc -- �������� ���������, ����� �������� ����������� WM_TIMER �� ������� (� ��� ���� ���� � ���� ������ ���������)
	
	// ����������� ���� �������� ���������� -- ������� � ����-��� ������� ��� Windows, ����� �������� �����������.
	// ��� �� ������� ��� �������� ���������� �� ������� �� TimerProc
	while (GetMessage(&lpMsg, NULL, 0, 0))
	{
		TranslateMessage(&lpMsg);
		DispatchMessage(&lpMsg);
	}
	return lpMsg.wParam;
}


// EnumChildWindows ������� EnumChildProc ��� ������� ���������� ���� (������ - 37 ����), ������ ��������� �� ���� hwnd
BOOL CALLBACK EnumChildProc(HWND hWnd, LPARAM lParam)
{
	// ��������� ��'� ����� ���������� ���� � classname
	TCHAR classname[100] = { 0 };
	GetClassName(hWnd, classname, 100); 

	// ���� ���� ��������� ���� "Button" (�����, �� - ������) -- ������ ���� �� ������� buttons
	if (!lstrcmpi(classname, TEXT("Button")))
	{
		buttons.push_back(hWnd);
	}
	return TRUE;	// ��� ����������� �������� ������� ���� EnumChildWindows
}



void RandPos(int& x, int& y)
{
	x = rand() % Horres - 200;		// 200 -- ������ ���� ������������ (����� ����� ����� �� ��������� GetWindowRect)
	if (x < 0)
		x = 0;
	y = rand() % Vertres - 300;		// 300 -- ������ ���� ������������ (����� ����� ����� �� ��������� GetWindowRect)
	if (y < 0)
		y = 0;
}


// �������� ��������� -- ����������� ������, ���� ��������� ������
VOID CALLBACK TimerProc(HWND hwnd, UINT uMsg, UINT_PTR idEvent, DWORD dwTime)
{
	static bool flag = true;
	const LPWSTR buff = L"             ����������� ���������!             ";
	static LPTSTR text = buff;
	static int count;
	int x = 0, y = 0;
	RandPos(x, y);	// �������� ������� ������������
	count++;
	text++;
	if (count == 37)
	{
		count = 0;
		text = buff;
	}
	
	HWND h_kalk = FindWindow(TEXT("CalcFrame"), NULL);		// ������ �����������, ���� ������ ���������, �������.....
	if (!h_kalk && flag)
	{
		flag = false;	// ���� ��� ���� ���� MessageBox, � �� �� ����� ����������� ������� (����� KillTimer )
		MessageBox(hwnd, TEXT("����������� ����!"), TEXT("Info"), MB_OK | MB_ICONERROR);
		PostQuitMessage(0);		// ���������� �������� -- ������� ���� �������� ���������� � WinMain ( GetMessage  ������� FALSE, ��������� WM_QUIT )
	}
	SetWindowText(h_kalk, text);	
	
	// ������� ����� ��������� ������������
	//SetWindowPos(h_kalk, NULL, x, y, NULL, NULL, true);
	
	
	// �������� ����� �������� ������ ( ������ �� ������ � ������ ������ � prew)
	size_t j = rand() % buttons.size();				// ���������� ������ ������� ������ (������� �����, ����� ������� ����� )
	//static size_t prew = -1;						// size_t �� ������ ��� unsigned int � �� ���� ���� ��'�����, ���� if ������ ������� -- � ������� ������� �� ������ ������ �������
	static int prew = -1;							// ������ �������� ����� ������ -- ���� �� ���� ��������
	vector <HWND> ::iterator i = buttons.begin();	// � - �������� �� ������ ������� ������� (����� ������)
	if (prew >= 0 )
	{
		//ShowWindow( *(i + prew), SHUTDOWN_RESTART);
		ShowWindow( *(i + prew), SW_SHOW);
		//InvalidateRect(*(i + j), NULL, TRUE);
		//UpdateWindow(*(i + j));
	}
	
	ShowWindow(*(i + j), SW_HIDE);
	prew = j;	// �� ������ �������� -- �������� �� ������
	InvalidateRect(h_kalk, NULL, TRUE);				// ��������� ����������� ������������ ���� �볺������ ����
}

