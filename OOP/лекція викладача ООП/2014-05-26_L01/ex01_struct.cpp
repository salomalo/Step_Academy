/*
	Створити клас "Точка" (Point), який складається з двох полів типу int: X та Y. Необхідно забезпечити: 
		розташування точки на екрані консолі розміром 80 х 25
		Введення координат точки користувачем 
		Вивід інформації про точку на екран 
		Можливість зміни будь-якої з координат на запит користувача (X або Y) 
*/

#include <iostream>
using namespace std;


struct Point{
	int x;
	int y;
};



void showPoint( Point * pt ) {
	cout <<"Point at ( " <<pt->x <<", " <<pt->y <<" )\n";
}


void checkPoint( Point * pt ) {
	if( pt->x <  0 ) pt->x = 0;
	if( pt->x > 79 ) pt->x = 79;

	if( pt->y <  0 ) pt->y = 0;
	if( pt->y > 24 ) pt->y = 24;
}


void movePoint( Point * pt, const int offsetX, const int offsetY ) {
	pt->x += offsetX;
	pt->y += offsetY;
	checkPoint( pt );
}


void main() {
	Point pt1;
	pt1.x = 33;
	pt1.y = 22;
	checkPoint( &pt1 );
	showPoint( &pt1 );


	Point pt2;
	pt2.x = 55;
	pt2.y = 77;
	checkPoint( &pt2 );
	showPoint( &pt2 );


	cout <<"\nAfter move :\n";

	movePoint( &pt1, 33, -44 );
	movePoint( &pt2, 33, -44 );
	showPoint( &pt1 );
	showPoint( &pt2 );

}// void main()



