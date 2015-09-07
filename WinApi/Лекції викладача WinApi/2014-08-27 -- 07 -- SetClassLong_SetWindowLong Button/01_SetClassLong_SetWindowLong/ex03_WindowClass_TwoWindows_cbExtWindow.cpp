#include <Windows.h>
#include <ctime>
using namespace std;

// �������� ������ ���������
LRESULT CALLBACK WindowProcedure( HWND, UINT, WPARAM, LPARAM );

struct USERDATA
{
	LONG colorBG;		// ��� ������������ ���� ��� (����) ���� 
	LONG colorTxt;		// ��� ������������ ���� ������
};


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

	MessageBox( NULL, L"��� ������� ������� ������������ ��������� ���'�� ����,\n��� ��������� ����� ��� ���� ��� � ������.\n\n� �� - �� ���� �������� ����� ������ �� ����, ������� �� ���� �����,\n�� �� �������� �� ����������� ��������� �����.\n\n��� ������� ����� � �볺������ ��� ��������� ���� ������ � ��� ����", L"���������", MB_OK | MB_ICONINFORMATION );

	wchar_t		szSizesMessage[255];
	wsprintf( szSizesMessage, L"sizeof( LONG ) = %d\nsizeof( COLORREF ) = %d\n sizeof( bool ) = %d", sizeof( LONG ), sizeof( COLORREF ), sizeof( bool ) );
	MessageBox( NULL, szSizesMessage, L"������ ����", MB_OK | MB_ICONINFORMATION );
	wsprintf( szSizesMessage, L"sizeof( LONG ) = %d\nsizeof( COLORREF ) = %d\n sizeof( BOOL ) = %d\n sizeof( USERDATA ) = %d", sizeof( LONG ), sizeof( COLORREF ), sizeof( BOOL ), sizeof( USERDATA ) );
	MessageBox( NULL, szSizesMessage, L"������ ����", MB_OK | MB_ICONINFORMATION );

	//////////////////////      I.   ������� ������� ����        ///////////////////////////
	WNDCLASSEX	wc;
	wc.cbSize		= sizeof( WNDCLASSEX );					// ����� ��������� � ������
	wc.style		= CS_VREDRAW | CS_HREDRAW;				// ����� ����
	wc.lpfnWndProc	= WindowProcedure;						// �������� �� ������ ���������
	wc.cbClsExtra	= 0;									// �-�� ����, �� ������������ ����� �� ���������� �����
	wc.cbWndExtra	= sizeof( USERDATA );					// �-�� ����, �� ������������ ����� �� ����������� ����
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
	// ��� ����� ���� - ��� ��� ���� � ����� ������� ��������� � ������ �������
	HWND hWindow1 = CreateWindow( szNameOfWindowClass, szNameOfApplication, WS_OVERLAPPEDWINDOW, 10, 10, 500, 500, NULL, NULL, hInstance, NULL );
	HWND hWindow2 = CreateWindow( szNameOfWindowClass, szNameOfApplication, WS_OVERLAPPEDWINDOW, 600, 10, 500, 500, NULL, NULL, hInstance, NULL );

	if( ! ( hWindow1 && hWindow2 ) )
	{
		MessageBox( NULL, L"�� ������� �������� ����!", L"����!", MB_ICONERROR | MB_OK );
		return 0;
	}


	/////////////////////     IV.   ³��������� ����      ///////////////////////////////////
	ShowWindow( hWindow1, iCmdShow );
	ShowWindow( hWindow2, iCmdShow );


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


	// ��� ������� ���� ���������� - ���� �������
	switch( iMsg )
	{

	case WM_CREATE:		// ����������� ���� ������ ���� ���� ��������� �-�� CreateWindow
	{
		MessageBox( NULL, L"����������� ����!", L"����� !", MB_ICONASTERISK | MB_OK );

		USERDATA ud;
		ud.colorBG	= RGB( 255, 255, 255 );		// �������� - ���� ���� ���
		ud.colorTxt	= RGB(   0,   0,   0 );		// �������� - ������ ���� ������
		
		// �������� ������������ ��� � ��������� ������ ���'�� ����
		SetWindowLongPtr( hWindow, 0 * sizeof(LONG), (LONG) ud.colorBG );	// �������� ������������ ��� ���� � �������� 0 (����� colorBG );
		SetWindowLongPtr( hWindow, 1 * sizeof(LONG), (LONG) ud.colorTxt );	// �������� ������������ ��� ���� � �������� 1 (����� colorText );

		//RECT rectWindow;
		//GetWindowRect( hWindow, &rectWindow );
		//SetWindowPos( hWindow, HWND_TOP, rectWindow.left, rectWindow.top, rectWindow.right - rectWindow.left, rectWindow.bottom - rectWindow.top, SWP_SHOWWINDOW );

		break;			// ��� �� ����������� ���������� ����������� ������� ���������� DefWindowProc(...)
	}

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

			// ������ ������������ ��� ���� 
			USERDATA ud;
			ud.colorBG	= (COLORREF) GetWindowLongPtr( hWindow, 0 );	//� �������� 0 (����� colorBG );
			ud.colorTxt	= (COLORREF) GetWindowLongPtr( hWindow, sizeof(LONG) );	//� �������� 0 (����� colorBG );

			// ������� ������� ����
			SetClassLongPtr ( hWindow					// ���� ����� ����
				,GCL_HBRBACKGROUND						// � ����: ������� ��� (����) ���� ( Handle to BRush of BACKGROUND )
				,(LONG) CreateSolidBrush( ud.colorBG )	// ����� ������ ������ (�������� ������� �������� � colorBG) ��������� �� LONG - ����� ��� ��������� �-�
				);	

			PAINTSTRUCT ps;
			HDC hdc = BeginPaint( hWindow, &ps );
			RECT rectClient;						// ��������� - ���������� ������������
			GetClientRect( hWindow, &rectClient );	// �������� ��������� rectClient ������������ �볺������ ������ ����

			//FillRect( hdc, &rectClient, CreateSolidBrush( ud.colorBG ) );	// ������������ ��� ���� (� ���� - �������� ���)


			// ������������ ���� ��� � ������ ��������� � ��������� ���'�� ����
			SetBkColor( hdc, ud.colorBG );				
			SetTextColor( hdc, ud.colorTxt );

			// ������������ �����
			DrawText( hdc, L"���-�-�-�! � ��� ������ � ���!!!", -1, &rectClient, DT_CENTER | DT_VCENTER | DT_SINGLELINE );

			EndPaint( hWindow, &ps );	// ��������� ��������

			break;			// ��� �� ����������� ���������� ����������� ������� ���������� DefWindowProc(...)
		}


	case WM_LBUTTONDOWN:	// ����������� ����, ���� � ���� �볺������ ��� ������� ���������� ��� ������ ���� (� ����� ����������� �� ����������, �������� ���, � ����� �� ����� � ������� ������)
		{
			USERDATA ud;
			ud.colorBG	= RGB( rand()%255, rand()%255, rand()%255 );	// �������� ���������� ����
			ud.colorTxt	= RGB( rand()%255, rand()%255, rand()%255 );	// �������� ���������� ����

			// �������� ������������ ��� � ��������� ������ ���'�� ����
			SetWindowLongPtr( hWindow, 0 * sizeof(LONG), (LONG) ud.colorBG );	// �������� ������������ ��� ���� � �������� 0 (����� colorBG );
			SetWindowLongPtr( hWindow, 1 * sizeof(LONG), (LONG) ud.colorTxt );	// �������� ������������ ��� ���� � �������� 1 (����� colorText );

			//// ������� ������� ����
			//SetClassLongPtr ( hWindow					// ���� ����� ����
			//	,GCL_HBRBACKGROUND						// � ����: ������� ��� (����) ���� ( Handle to BRush of BACKGROUND )
			//	,(LONG) CreateSolidBrush( ud.colorBG )	// ����� ������ ������ (�������� ������� �������� � colorBG) ��������� �� LONG - ����� ��� ��������� �-�
			//	);	

			RECT rect;								// ��������� - ���������� ������������
			GetClientRect( hWindow, &rect );		// �������� ��������� rectClient ������������ �볺������ ������ ����
			InvalidateRect( hWindow, &rect,  true );	// ��������� �� ������� (��������) ��� �볺������ ������� - ���� ����������� ����� � ����� ����������� WM_PAINT, �� ����� ���� ����� ���������� � ���� ��������

			break;		// ��� �� ����������� ���������� ����������� ������� ���������� DefWindowProc(...)
		}


	//case  WM_SIZING:
	//	{
	//		// ������ ������������ ��� ���� 
	//		COLORREF colorBG = (COLORREF) GetWindowLongPtr( hWindow, 0 );	//� �������� 0 (����� colorBG );

	//		// ������� ������� ����
	//		SetClassLongPtr ( hWindow					// ���� ����� ����
	//			,GCL_HBRBACKGROUND						// � ����: ������� ��� (����) ���� ( Handle to BRush of BACKGROUND )
	//			,(LONG) CreateSolidBrush( colorBG )	// ����� ������ ������ (�������� ������� �������� � colorBG) ��������� �� LONG - ����� ��� ��������� �-�
	//			);	

	//		break;		// ��� �� ����������� ���������� ����������� ������� ���������� DefWindowProc(...)
	//	}

	}// switch( iMsg )


	return DefWindowProc( hWindow, iMsg, wParam, lParam );	// ����'������ -- ��� ���������� ������ ��������� �������� � �����������, �� �� �������� �� !


}// LRESULT CALLBACK WindowProcedure( HWND, UINT, WPARAM, LPARAM )



