#include <Windows.h>


// оце -- віндовий main()
int WINAPI WinMain(	
	 HINSTANCE	hInstance	// хендл на екземпляр програми
	,HINSTANCE	hPrev		// не використовується, зберігають для сумісності
	,LPSTR		szCmdLine	// сюдою система передає командний рядок
	,int		iCmdShow	// ним система вказує, в якому стані має відкритися гловне вікно
	)
{
	// найпростіше вікно :)
	//MessageBox( NULL, L"Працює !!!!!", L"Уря-я-а-а-а!", MB_OK );
	//MessageBox( NULL, L"Працює !!!!!", L"Уря-я-а-а-а!", MB_OK | MB_HELP );
	//MessageBox( NULL, L"Працює !!!!!", L"Уря-я-а-а-а!", MB_OKCANCEL  );
	//MessageBox( NULL, L"Працює !!!!!", L"Уря-я-а-а-а!", MB_RETRYCANCEL   );
	//MessageBox( NULL, L"Працює !!!!!", L"Уря-я-а-а-а!", MB_YESNO   );
	//MessageBox( NULL, L"Працює !!!!!", L"Уря-я-а-а-а!", MB_YESNO | MB_ICONWARNING  );
	//MessageBox( NULL, L"Працює !!!!!", L"Уря-я-а-а-а!", MB_YESNO | MB_ICONHAND  );
	//MessageBox( NULL, L"Працює !!!!!", L"Уря-я-а-а-а!", MB_YESNO | MB_ICONINFORMATION  );
	int iRes = MessageBox( NULL, L"Працює !!!!!", L"Уря-я-а-а-а!", MB_ABORTRETRYIGNORE | MB_ICONINFORMATION  );
	
	wchar_t sRes[33];
	wsprintf( sRes, L"MessageBox повернув %i", iRes );
	MessageBox( NULL, sRes, L"Результат", MB_OK  );

	switch (iRes)
	{
	case IDABORT:
		MessageBox( NULL, L"Натиснуто Abort", L"Кнопка", MB_OK  );
		break;

	case IDIGNORE:
		MessageBox( NULL, L"Натиснуто Ignore", L"Кнопка", MB_OK  );
		break;

	case IDCANCEL:
		MessageBox( NULL, L"Натиснуто Cancel", L"Кнопка", MB_OK  );
		break;

	case IDRETRY:
		MessageBox( NULL, L"Натиснуто Retry", L"Кнопка", MB_OK  );
		break;

	default:
		MessageBox( NULL, L"Натиснуто НЕ ЗНАЮ ЩО !!!", L"Кнопка", MB_OK  );
		break;

	}


	return 0;
}