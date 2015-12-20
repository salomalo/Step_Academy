#include <Windows.h>
#include <stdio.h>

int WINAPI WinMain(	
	HINSTANCE	hInstance	// хендл на екземпляр програми
	,HINSTANCE	hPrev		// не використовується, зберігають для сумісності
	,LPSTR		szCmdLine	// сюдою система передає командний рядок
	,int		iCmdShow	// ним система вказує, в якому стані має відкритися гловне вікно
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
		MessageBox( NULL, L"Загадайте число", L"Гра!",  MB_OK  );

		do
		{
			wsprintf(sRES,L"Ви загадали = %i ?", (start+end)/2);
			res = MessageBox( NULL, sRES, L"Гра!",  MB_YESNO  );
			count++;
			switch(res)
			{
			case IDYES:
				MessageBox( NULL, L"Я так зразу думав", L"Гра!",  MB_OK  );
				win=true;  //////
				break;

			case IDNO:
				wsprintf(sRES,L"Ваше число більше за %i ?", (start+end)/2);
				res = MessageBox( NULL, sRES, L"Гра!",  MB_YESNO  );
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

		wsprintf(sRES,L"кількість спроб %i ", count);
		MessageBox( NULL, sRES , L"Гра!",  MB_OK   );
		chek =	MessageBox( NULL, L"Граємо ще?", L"Гра!",  MB_YESNO   );

	}while(chek==IDNO);


	return 0;
}