#include <windows.h> 
#include <tchar.h>

// ²����� ��������� -- ������ � �������� ����������� ����
LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM); 



int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR szCmdLine, int iCmdShow) 
{ 
	static TCHAR szClassName[] = _TEXT("MyWindowClass"); 


	///////////////////////
	//
	//	1. ��������� �������� �����
	//

	WNDCLASSEX wndclass; // ���������, � ����� ��� �������� (�����) �������� ����	-- http://msdn.microsoft.com/en-us/library/windows/desktop/ms633577(v=vs.85).aspx
	wndclass.cbSize			= sizeof(wndclass);						// �����  ���� ��������� � ������
	wndclass.style			= CS_HREDRAW | CS_VREDRAW /*| CS_NOCLOSE*/;				// ����� �����		-- 
	wndclass.lpfnWndProc	= WndProc;								// �������� �� ������ ���������
	wndclass.cbClsExtra		= 0;									// ����� ��������� ���'�� ����� �� ������ ���'�� ��� �����
	wndclass.cbWndExtra		= 0; 									// ����� ��������� ���'�� ����� �� ������ ���'�� ��� ����
	wndclass.hInstance		= hInstance;							// ����� ��������� ��������

	// ������� ������ �����ί ������
//	wndclass.hIcon			= LoadIcon(NULL, IDI_APPLICATION);		// http://msdn.microsoft.com/en-us/library/windows/desktop/ms648072(v=vs.85).aspx
//	wndclass.hIcon			= LoadIcon(NULL, IDI_ASTERISK);
	wndclass.hIcon			= LoadIcon(NULL, IDI_QUESTION);

	// ������� ������ ���ί ������
//	wndclass.hIconSm		= LoadIcon(NULL, IDI_APPLICATION);		// http://msdn.microsoft.com/en-us/library/windows/desktop/ms648072(v=vs.85).aspx
//	wndclass.hIconSm		= LoadIcon(NULL, IDI_SHIELD); 
	wndclass.hIconSm		= LoadIcon(NULL, IDI_WARNING); 

	// ������� ������ ��������� ����
//	wndclass.hCursor		= LoadCursor(NULL, IDC_ARROW);			// http://msdn.microsoft.com/en-us/library/windows/desktop/ms648391(v=vs.85).aspx
//	wndclass.hCursor		= LoadCursor(NULL, IDC_CROSS);
	wndclass.hCursor		= LoadCursor(NULL, IDC_HAND);

	// ������� �������, ���� ���� ������������ ��� ����
//	wndclass.hbrBackground	=(HBRUSH) GetStockObject(WHITE_BRUSH); // http://msdn.microsoft.com/en-us/library/windows/desktop/dd144925(v=vs.85).aspx
//	wndclass.hbrBackground	=(HBRUSH) GetStockObject(BLACK_BRUSH); 
//	wndclass.hbrBackground	=(HBRUSH) GetStockObject(GRAY_BRUSH); 
	wndclass.hbrBackground	=(HBRUSH) CreateSolidBrush( RGB( 255 , 150 , 55 ) ); 

	wndclass.lpszMenuName	= NULL;			// ��'� ���� (��� NULL)
	wndclass.lpszClassName	= szClassName;	// ��'� �������� ����� - �� ���� ���������������� �������





	///////////////////////
	//
	//	2. ��������� �������� �����
	//

	if( !RegisterClassEx(&wndclass) )	// ������� false, ���� �� ������� ������������
	{
		MessageBox( NULL, _TEXT("�� ������� ������������ ������� ����!"), _TEXT("�������!"), MB_OK );
		return 0;
	}







	///////////////////////
	//
	//	3. ��������� ���� �� �������������� �������� ���� -- ���� �� �� �����Ӫ���� !!!!
	//
	HWND hwnd;
	hwnd = CreateWindow(	// http://msdn.microsoft.com/en-us/library/windows/desktop/ms632679(v=vs.85).aspx
		szClassName,								// ��'� �������������� �������� �����
		_TEXT("�� ����� \"�������\" ���� "),		// ��������� ����
		WS_OVERLAPPEDWINDOW,						// ����� ����	--- http://msdn.microsoft.com/en-us/library/windows/desktop/ms632600(v=vs.85).aspx
		150 /*CW_USEDEFAULT*/,			// X ����� ��������� ����
		555 /*CW_USEDEFAULT*/,			// Y ����� ��������� ����
		222/*CW_USEDEFAULT*/,			// ������
		88 /*CW_USEDEFAULT*/,			// ������
		NULL,							// ����� ���������� ����
		NULL,							// ����� ����
		hInstance,						// ����� ���������� ��������, �� "�����������" �� ����
		NULL							// ��������, ������ ���������� � ���������� WM_CREATE
		); 




	///////////////////////
	//
	//	4. ³���������� ����
	//
	ShowWindow(hwnd, iCmdShow); 
	//UpdateWindow(hwnd);				// ������� ������� �������� ����������� WM_PAINT





	///////////////////////
	//
	//	5. ��������� ���� ������� ����������
	//
	MSG msg;	// ��������� ��� ��������� �����������	--	http://msdn.microsoft.com/en-us/library/windows/desktop/ms644958(v=vs.85).aspx
	while( GetMessage(&msg, NULL, 0, 0) )	// ���� ����������� � ����� �������� � ����� � ��������� msg, ���� ����������� �� WM_QUIT -- ������� TRUE
	{ 
		TranslateMessage(&msg);		// "���������" ������� ����-�� (WM_KEYDOWN, WM_KEYUP) ��������� � ����������� ������� ��������� � ������ ����������� WM_CHAR � ����� ������� 
		DispatchMessage(&msg);		// ��������� ����������� �� ����������� ���� (����� � ����� ����, ����� ����� �������  � msg.hwnd )
	} 
//	SetWindowPos(
	return msg.wParam;	// wParam ����������� WM_QUIT


} // int WINAPI WinMain()






// ²����� ��������� -- ������ � �������� ����������� ����
LRESULT CALLBACK WndProc(HWND hwnd, UINT iMsg, WPARAM wParam, LPARAM lParam) 
{ 
	switch(iMsg) 
	{ 
	case WM_CREATE:	// ����� �����������, ��� ��������� �� ���� -- ��� �� ���� �������������� ���� ����
		MessageBox( NULL, _TEXT("WM_CREATE"), _TEXT("�������� �����������"), MB_OK );
		return 0;


	case WM_KEYDOWN:	// ��� ��������Ͳ ����-��� ������
	//	MessageBox( NULL, _TEXT("WM_KEYDOWN"), _TEXT("�������� �����������"), MB_OK );
		return 0;


	case WM_KEYUP:	// ��� ²�������Ͳ ����-��� ������
		{
			wchar_t szMsg [55];
			wsprintf( szMsg, L"WM_KEYUP \n ��� ������: %i", wParam );
			MessageBox( NULL, szMsg, _TEXT("�������� �����������"), MB_OK );
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

	// ��� ��� ����������, ���� �� �� ���������� ��� ��������� DefWindowProc
	return DefWindowProc(hwnd, iMsg, wParam, lParam); 
}


