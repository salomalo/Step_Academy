/*
	Зобразити на екрані рух деякого символа(наприклад "*") вниз відносно деякої стартової позиції. 
	Стартову позицію задавати випадковим числом.
*/

#include <iostream>
#include <time.h>
#include <conio.h>
#include <Windows.h>

using namespace std;

int main()
{
	const HANDLE	hCon = GetStdHandle( STD_OUTPUT_HANDLE );
	const clock_t	period = 80;

	COORD	position;
	clock_t	nextMoment = clock();	// повертає к-ть мілісекунд від початку роботи програми	
	char	keyPressed;

	srand(time(0));

	do
	{
		// початкове положення зірочки
		position.X = rand() % 80;
		position.Y = 0;

		do
		{
			// показуємо зірочку
			SetConsoleCursorPosition( hCon, position );
			cout <<'*';

			nextMoment += period;	// момент наступного показу

			// sleep( period ) ; тупо зупиняє виконання програми на periodю.
			do { Beep( rand() % 10000, 5);  } while( nextMoment > clock() );	// а тут, поки чекаємо, робимо щось корисне -- біпаємо!!! ;)

			// гасимо зірочку (на старому місці)
			SetConsoleCursorPosition( hCon, position );
			cout <<' ';

			position.Y++;	// змінюємо позицію зірочки

			keyPressed =  kbhit() ? getch() : 0;		// чи була натиснена клавіша ?
			

		}while( position.Y < 25 && ! keyPressed );	// зірочка падає, поки не вийде за межі екрану

		Beep( 8443, 3);
		Beep( 9443, 3);
		Beep( 443, 7);
		Beep( 1443, 13);
		Beep( 124, 30);
		Beep( 10443, 3);
		Beep( 1443, 7);

	}while( ! keyPressed );
}