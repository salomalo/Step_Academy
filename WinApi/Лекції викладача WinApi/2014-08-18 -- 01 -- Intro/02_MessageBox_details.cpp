#include <Windows.h>


// ��� -- ������� main()
int WINAPI WinMain(	
	 HINSTANCE	hInstance	// ����� �� ��������� ��������
	,HINSTANCE	hPrev		// �� ���������������, ��������� ��� ��������
	,LPSTR		szCmdLine	// ����� ������� ������ ��������� �����
	,int		iCmdShow	// ��� ������� �����, � ����� ���� �� ��������� ������ ����
	)
{
	// ���������� ���� :)
	//MessageBox( NULL, L"������ !!!!!", L"���-�-�-�-�!", MB_OK );
	//MessageBox( NULL, L"������ !!!!!", L"���-�-�-�-�!", MB_OK | MB_HELP );
	//MessageBox( NULL, L"������ !!!!!", L"���-�-�-�-�!", MB_OKCANCEL  );
	//MessageBox( NULL, L"������ !!!!!", L"���-�-�-�-�!", MB_RETRYCANCEL   );
	//MessageBox( NULL, L"������ !!!!!", L"���-�-�-�-�!", MB_YESNO   );
	//MessageBox( NULL, L"������ !!!!!", L"���-�-�-�-�!", MB_YESNO | MB_ICONWARNING  );
	//MessageBox( NULL, L"������ !!!!!", L"���-�-�-�-�!", MB_YESNO | MB_ICONHAND  );
	//MessageBox( NULL, L"������ !!!!!", L"���-�-�-�-�!", MB_YESNO | MB_ICONINFORMATION  );
	int iRes = MessageBox( NULL, L"������ !!!!!", L"���-�-�-�-�!", MB_ABORTRETRYIGNORE | MB_ICONINFORMATION  );
	
	wchar_t sRes[33];
	wsprintf( sRes, L"MessageBox �������� %i", iRes );
	MessageBox( NULL, sRes, L"���������", MB_OK  );

	switch (iRes)
	{
	case IDABORT:
		MessageBox( NULL, L"��������� Abort", L"������", MB_OK  );
		break;

	case IDIGNORE:
		MessageBox( NULL, L"��������� Ignore", L"������", MB_OK  );
		break;

	case IDCANCEL:
		MessageBox( NULL, L"��������� Cancel", L"������", MB_OK  );
		break;

	case IDRETRY:
		MessageBox( NULL, L"��������� Retry", L"������", MB_OK  );
		break;

	default:
		MessageBox( NULL, L"��������� �� ���� �� !!!", L"������", MB_OK  );
		break;

	}


	return 0;
}