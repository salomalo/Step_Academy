/*
	Створити клас "Точка" (Point), який складається з двох полів типу int: X та Y. Необхідно забезпечити: 
		розташування точки на екрані консолі розміром 80 х 25
		Введення координат точки користувачем 
		Вивід інформації про точку на екран 
		Можливість зміни будь-якої з координат на запит користувача (X або Y) 
*/

#include <iostream>
using namespace std;


class Point{

public: // члени доступні "ззовні"

	// конструктор без параметрів
	Point() 
		: x(0), y(0) 	// ініціалізатори
		 , name(0)		// ініціалізуємо name нулем, щоби точно знати, що не виділена пам'ять
	{
		//cout <<"Constructor  Point()\n";

		// такі прості дії -- у ініціалізатори
		//x = 0;
		//y = 0;
		setName( "<unnamed>" );
	}


	// конструктор з параметрами
	Point( int newX, int newY )
		: x( newX ), y( newY )
	 	  , name(0)		// ініціалізуємо name нулем, щоби точно знати, що не виділена пам'ять
	{
		//cout <<"Constructor  Point( int newX, int newY )\n";
		checkPoint();
		setName( "<unnamed>" );
	}



	// конструктор з параметрами
	Point( 
			  int newX
			, int newY
			, const char * const newName 
			)
		: x( newX ), y( newY )
	 	  , name(0)		// ініціалізуємо name нулем, щоби точно знати, що не виділена пам'ять
	{
		//cout <<"Constructor  Point( int newX, int newY )\n";
		checkPoint();
		setName( newName );
	}


	// Деструктор
	~Point() {
		//cout <<"Destructor for point '" <<name <<"'\n";
		delete [] name;
	}



	// сетери -- встановлюють значення 
	void setCoords( const int newX, const int newY ){
		x = newX;
		y = newY;
		checkPoint();
	}


	void setName( const char * const newName ) {
		
		// уникаємо "втрат пам'яті"
		if( name )
			delete [] name;

		name = new char[ strlen( newName ) +1 ];
		strcpy( name, newName );
	}



	// гетери -- видають значення полів класу
	int getX(){ return x; }
	int getY(){ return y; }

	char * getName() { return name; }



	void showPoint() {
		cout <<"Point '" <<name <<"' at ( " <<x <<", " <<y <<" )\n";
	}



	void movePoint( const int offsetX, const int offsetY ) {
		x += offsetX;
		y += offsetY;
		checkPoint();
	}



private:

	int		 x;
	int		 y;
	char	*name;


	// можна викликати лише всередині класу -- СЕРВІСНА ФУНКЦІЯ
	void checkPoint() {
		if( x <  0 ) x = 0;
		if( x > 79 ) x = 79;

		if( y <  0 ) y = 0;
		if( y > 24 ) y = 24;
	}


}; // class Point


char * testMem () {
	Point pt( 33, 22, "Point into testMem ()" );	// створюється новий об'єкт pt
	pt.showPoint();
	return pt.getName();	// повертається вказівник на динамічну пам'ять з іменем
}// об'єкт pt перестає існувати



void main() {
	Point pt1;
	//pt1.setCoords( 33, 22 );
	pt1.showPoint();	// pt1.setCoords() не викликали, але поля проініціалізовані -- конструктором 


	Point pt2;
	pt2.setCoords( 55, 77 );
	pt2.showPoint();


	cout <<"\nAfter move :\n";

	pt1.movePoint( 33, -44 );
	pt2.movePoint( 33,  44 );
	pt1.setName( "Point 1" );

	pt1.showPoint();
	pt2.showPoint();

	cout <<"\nGeted x=" <<pt1.getX() <<", y=" <<pt1.getY() 
		 <<", name='" <<pt1.getName() <<"'"
		 <<"\n";

	Point pt3( 15, 55 );
	pt3.showPoint();
	

	char * name = testMem();
	cout <<"\n Name of unexisting point is '" <<name <<"'\n";


}// void main()




