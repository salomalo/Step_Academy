#include <Windows.h>
#include <ctime>
using namespace std;

// �������� ������ ���������
LRESULT CALLBACK WindowProcedure( HWND, UINT, WPARAM, LPARAM );

// ����� ����� - WinMain(...)
int WINAPI WinMain(	 HINSTANCE	hInstance		// ����� ���������� ��������
	,HINSTANCE	hPrevInstance	// ����� ������������ ����������
	,PSTR		szCmdLine		// �������� �� ����� � ����������� ���������� �����
	,int		iCmdShow		// �������� ����������� ������ ���� (SW_...)
	)
{
	srand( time(0));
	wchar_t		szNameOfApplication[]	= L"�� ����� ������� ����";
	wchar_t		szNameOfWindowClass[]	= L"MyWindowClass";

	MessageBox( NULL, L"��� ������� ������� ������� ������ ���������� ������� ����������,\n� ����� - ��������� ����� � �������� �����.\n\n��� ������� ����� � �볺������ ��� ��������� ���� ��� ����", L"���������", MB_OK | MB_ICONINFORMATION );

	//////////////////////      I.   ������� ������� ����        ///////////////////////////
	WNDCLASSEX	wc;
	wc.cbSize		= sizeof( WNDCLASSEX );					// ����� ��������� � ������
	wc.style		= CS_VREDRAW | CS_HREDRAW;				// ����� ����
	wc.lpfnWndProc	= WindowProcedure;						// �������� �� ������ ���������
	wc.cbClsExtra	= 0;									// �-�� ����, �� ������������ ����� �� ���������� �����
	wc.cbWndExtra	= 0;									// �-�� ����, �� ������������ ����� �� ����������� ����
	wc.hInstance	= hInstance;							// ����� �������, �� ������� ���� (���� �����)
	wc.hIcon		= LoadIcon( NULL, IDI_APPLICATION );	// ������� ������ ����
	wc.hIconSm		= LoadIcon( NULL, IDI_APPLICATION );	// ������� ����� ������ ����
	wc.hCursor		= LoadCursor( NULL, IDC_ARROW );		// ������� ������ ������� ����
	wc.hbrBackground= (HBRUSH)GetStockObject( WHITE_BRUSH);	// ������� ��� ����
	wc.lpszMenuName	= NULL;									// ������� ���� ����
	wc.lpszClassName= szNameOfWindowClass;					// ������� ��'� �������� �����



	////////////////////       II.  �������� ������� ���� � �������������, ��������� � �������� wc   ///////////////////
	if( ! RegisterClassEx( &wc ) )
	{
		MessageBox( NULL, L"�� ������� ������������ ������� ����!", L"����!", MB_ICONERROR | MB_OK );
		return 0;
	}


	/////////////////////     III.   ��������� ���� �� ����� ���庺���������� �������� �����     /////////////////////
	HWND hWindow = CreateWindow( szNameOfWindowClass, szNameOfApplication, WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, NULL, NULL, hInstance, NULL );

	if( ! hWindow )
	{
		MessageBox( NULL, L"�� ������� �������� ����!", L"����!", MB_ICONERROR | MB_OK );
		return 0;
	}


	/////////////////////     IV.   ³��������� ����      ///////////////////////////////////
	ShowWindow( hWindow, iCmdShow );


	/////////////////////      V.   ���� ������� ����������      ///////////////////////////////////
	MSG msg;	// ���������� ��������� �����������
	while( GetMessage( &msg, NULL, 0, 0 ) )
	{
		TranslateMessage( &msg );
		DispatchMessage(  &msg );
	}
	MessageBox( NULL, L"�������� ����������� WM_QUIT:\n  -- GetMessage(...) ��������� false\n  -- ���� ������� ���������� ����������", L"WM_QUIT!", MB_ICONINFORMATION | MB_OK );



	return 0 ;
}//int WINAPI WinMain(...)




/////////////////////////////    ²����� ���������     ///////////////////////////////////////
LRESULT CALLBACK WindowProcedure
	(	HWND hWindow,	// ����� ����, ��� ������� ������� ������� (�����, ���� �� ���� ��������� ������� �������� ����?)
	UINT iMsg,		// ID �����������
	WPARAM wParam,	// �������� ���������� �����������
	LPARAM lParam	// �� ���� �������� ���������� �����������
	)
{// LRESULT CALLBACK WindowProcedure( HWND, UINT, WPARAM, LPARAM )

	static COLORREF colorBG;	// � ��� ����� ������������ ���� ��� (����) ���� �� ��������� ������ ���������
	
	// ��� ������� ���� ���������� - ���� �������
	switch( iMsg )
	{

	case WM_CREATE:		// ����������� ���� ������ ���� ���� ��������� �-�� CreateWindow
		MessageBox( NULL, L"����������� ����!", L"����� !", MB_ICONINFORMATION | MB_OK );
		colorBG	= RGB( 255, 255, 255 );
		break;			// ��� �� ����������� ���������� ����������� ������� ���������� DefWindowProc(...)


	case WM_CLOSE:		// ����������� ���� �������� �������� ���� �������� ������������ (Alt+F4,������� �� ����) ��� ��������� (����. ����������� �����)
		if( IDYES == MessageBox( hWindow, L"�� ������ ������ ������� ��� ����� ���� ?", L"����� ?", MB_ICONQUESTION | MB_YESNO ) )
			break;		// ��� �� ����������� ���������� ����������� ������� ���������� DefWindowProc(...)
		else
			return 0;	// � ���� - �� �� ����� �������� ����������� ���������� ������ �������� DefWindowProc(...)


	case WM_DESTROY:	// ����������� ���� ��� ������� ���� ����������� WM_CLOSE �-��� DefWindowProc(...)
		MessageBox( NULL, L"������������ ����������� WM_DESTROY", L"WM_DESTROY", MB_ICONINFORMATION | MB_OK );
		PostQuitMessage( 0 );	// ������� � ����� ����������� WM_QUIT, ��� �������� ���� ������� ����������. ���� ����� �� ������� - ��� ���� ������, ��� ���� ������� ���������� ��������� (�������� ����������� ��� ���� - ������� �� ���� � ����������� ������ )
		break;			// ��� �� ����������� ���������� ����������� ������� ���������� DefWindowProc(...)



	case WM_PAINT:		// ����������� ����, ���� ��������� ������������ (����� �������� - �� �������) ���� �볺������ ���� ��� �� ������� 
		{
			PAINTSTRUCT ps;
			HDC hdc = BeginPaint( hWindow, &ps );
			RECT rectClient;						// ��������� - ���������� ������������
			GetClientRect( hWindow, &rectClient );	// �������� ��������� rectClient ������������ �볺������ ������ ����
			SetBkColor( hdc, colorBG );				// ���������� ���� ��� (��� ��������� ������) ��������� � colorBG
			DrawText( hdc, L"���-�-�-�! � ��� ������ � ���!!!", -1, &rectClient, DT_CENTER | DT_VCENTER | DT_SINGLELINE );
			EndPaint( hWindow, &ps );
			break;			// ��� �� ����������� ���������� ����������� ������� ���������� DefWindowProc(...)
		}


	case WM_LBUTTONDOWN:	// ����������� ����, ���� � ���� �볺������ ��� ������� ���������� ��� ������ ���� (� ����� ����������� �� ����������, �������� ���, � ����� �� ����� � ������� ������)
		{
			colorBG = RGB( rand()%255, rand()%255, rand()%255 );	// �������� ���������� ����

			// ------ �̲�ު�� ²������ ����  --------
			SetClassLongPtr( hWindow					// ���� ��� ����� ����
				,GCL_HBRBACKGROUND						// � ����: ������� ��� (����) ���� ( Handle to BRush of BACKGROUND )
				,(LONG) CreateSolidBrush( colorBG )		// ����� ������ ������ (�������� ������� �������� � colorBG) ��������� �� LONG - ����� ��� ��������� �-�
				);	
			//RECT rect;								// ��������� - ���������� ������������
			//GetClientRect( hWindow, &rect );		// �������� ��������� rectClient ������������ �볺������ ������ ����
			InvalidateRect( hWindow, NULL, true );	// ��������� �� ������� (��������) ��� �볺������ ������� - ���� ����������� ����� � ����� ����������� WM_PAINT, �� ����� ���� ����� ���������� � ���� ��������
			break;		// ��� �� ����������� ���������� ����������� ������� ���������� DefWindowProc(...)
		}

	}// switch( iMsg )


	return DefWindowProc( hWindow, iMsg, wParam, lParam );	// ����'������ -- ��� ���������� ������ ��������� �������� � �����������, �� �� �������� �� !


}// LRESULT CALLBACK WindowProcedure( HWND, UINT, WPARAM, LPARAM )



