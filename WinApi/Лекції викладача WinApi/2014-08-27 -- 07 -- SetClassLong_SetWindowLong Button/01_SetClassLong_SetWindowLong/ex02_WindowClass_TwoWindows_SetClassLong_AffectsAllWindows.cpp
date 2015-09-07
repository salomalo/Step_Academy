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

	MessageBox( NULL, L"��� ������� ������� ������� ������ ���������� ������� ����������,\n��������� ����� � �������� �����.\n\n� �� - �� ���� �������� ����� ������ �� ����, ������� �� ���� �����\n\n��� ������� ����� � �볺������ ��� ��������� ���� ��� ����", L"���������", MB_OK | MB_ICONINFORMATION );

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

	static COLORREF colorBG;			// � ��� ����� ������������ ���� ��� (����) ���� �� ��������� ������ ���������
	static bool		isWindowClassChanged;		// � ��� ����� ������������ ������, �� �������� ���� �������� ����� (� ����: ������� ���)

	// ��� ������� ���� ���������� - ���� �������
	switch( iMsg )
	{

	case WM_CREATE:		// ����������� ���� ������ ���� ���� ��������� �-�� CreateWindow
		//MessageBox( NULL, L"����������� ����!", L"����� !", MB_ICONINFORMATION | MB_OK );
		colorBG			= RGB( 255, 255, 255 );		// �������� - ���� ����
		isWindowClassChanged	= false;					// �������� - ���� �� ���������
		break;			// ��� �� ����������� ���������� ����������� ������� ���������� DefWindowProc(...)


	case WM_CLOSE:		// ����������� ���� �������� �������� ���� �������� ������������ (Alt+F4,������� �� ����) ��� ��������� (����. ����������� �����)
		if( IDYES == MessageBox( hWindow, L"�� ������ ������ ������� ��� ����� ���� ?", L"����� ?", MB_ICONQUESTION | MB_YESNO ) )
			break;		// ��� �� ����������� ���������� ����������� ������� ���������� DefWindowProc(...)
		else
			return 0;	// � ���� - �� �� ����� �������� ����������� ���������� ������ �������� DefWindowProc(...)


	case WM_DESTROY:	// ����������� ���� ��� ������� ���� ����������� WM_CLOSE �-��� DefWindowProc(...)
		//MessageBox( NULL, L"������������ ����������� WM_DESTROY", L"WM_DESTROY", MB_ICONINFORMATION | MB_OK );
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

			// ������� ������� ����
			SetClassLongPtr( hWindow								// ���� ��� ����� ����
				,GCL_HBRBACKGROUND						// � ����: ������� ��� (����) ���� ( Handle to BRush of BACKGROUND )
				,(LONG) CreateSolidBrush( colorBG )	// ����� ������ ������ (�������� ������� �������� � colorBG) ��������� �� LONG - ����� ��� ��������� �-�
				);	
			isWindowClassChanged = true;	// ������� ������� ����

			RECT rect;								// ��������� - ���������� ������������
			GetClientRect( hWindow, &rect );		// �������� ��������� rectClient ������������ �볺������ ������ ����
			InvalidateRect( hWindow, &rect, true );	// ��������� �� ������� (��������) ��� �볺������ ������� - ���� ����������� ����� � ����� ����������� WM_PAINT, �� ����� ���� ����� ���������� � ���� ��������
			//MessageBox( NULL, L"�� �������� �� ����� ���� - � ���� ������ ������ ���� ���\n� ����� - ����� ������ ������ ���� (��� ���� ��������������)", L"�������������!", MB_ICONINFORMATION | MB_OK );
			//MessageBox( NULL, L"������� ����� �� ��� ������� ����  --  �� ������������� ���� MessageBox'���\n\n� �� ����� - ��������� ��� MessageBox ����� ��� ����� ������!", L"�� ����!", MB_ICONINFORMATION | MB_OK );
			break;		// ��� �� ����������� ���������� ����������� ������� ���������� DefWindowProc(...)
		}


	case WM_SIZE :		// ����������� ����, ���� ���� ����� �������
		if( isWindowClassChanged )
		{
			//MessageBox( NULL, L"�� ������, ������� ���� ������� ������ �Ѳ� ����, ��������� �� �����!\n\n�� �, ��� ����, -  �� ����� ������ �������� ����� ����� �������� ������� ����!", L"������������ ?", MB_ICONQUESTION | MB_OK );
			isWindowClassChanged	= false;					// ���� ����� �������� - ����� ��� ���� �� ���������
		}
		break;	// ��� �� ����������� ���������� ����������� ������� ���������� DefWindowProc(...)

	}// switch( iMsg )


	return DefWindowProc( hWindow, iMsg, wParam, lParam );	// ����'������ -- ��� ���������� ������ ��������� �������� � �����������, �� �� �������� �� !


}// LRESULT CALLBACK WindowProcedure( HWND, UINT, WPARAM, LPARAM )



