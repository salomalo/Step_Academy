#include <Windows.h>
#include <stdio.h>

int WINAPI WinMain(	
	HINSTANCE	hInstance	// ����� �� ��������� ��������
	,HINSTANCE	hPrev		// �� ���������������, ��������� ��� ��������
	,LPSTR		szCmdLine	// ����� ������� ������ ��������� �����
	,int		iCmdShow	// ��� ������� �����, � ����� ���� �� ��������� ������ ����
	)
{
	bool win;
	int start, end, res, count;
	wchar_t sRES[255];
	int chek;
	do
	{
		start = 0;
		end = 100;
		count = 0;
		win = false;
		MessageBox( NULL, L"��������� �����", L"���!",  MB_OK  );

		do
		{
			wsprintf(sRES,L"�� �������� = %i ?", (start+end)/2);
			res = MessageBox( NULL, sRES, L"���!",  MB_YESNO  );
			count++;
			switch(res)
			{
			case IDYES:
				MessageBox( NULL, L"� ��� ����� �����", L"���!",  MB_OK  );
				win=true;  //////
				break;

			case IDNO:
				wsprintf(sRES,L"���� ����� ����� �� %i ?", (start+end)/2);
				res = MessageBox( NULL, sRES, L"���!",  MB_YESNO  );
				count++;
				switch(res)
				{
				case IDYES:
					start = (start+end)/2;
					break;
				case IDNO:
					end = (start+end)/2;
					break;
				}
				break;
			}

		}while( !win );

		wsprintf(sRES,L"������� ����� %i ", count);
		MessageBox( NULL, sRES , L"���!",  MB_OK   );
		chek =	MessageBox( NULL, L"����� ��?", L"���!",  MB_YESNO   );

	}while(chek==IDNO);


	return 0;
}