/*
	�������� ���� "�����" (Point), ���� ���������� � ���� ���� ���� int: X �� Y. ��������� �����������: 
		������������ ����� �� ����� ������ ������� 80 � 25
		�������� ��������� ����� ������������ 
		���� ���������� ��� ����� �� ����� 
		��������� ���� ����-��� � ��������� �� ����� ����������� (X ��� Y) 
*/

#include <iostream>
using namespace std;


class Point{

public: // ����� ������� "�����"


	// ������ -- ������������ �������� 
	void setCoords( int newX, int newY ){
		x = newX;
		y = newY;
		checkPoint();
	}



	// ������ -- ������� �������� ���� �����
	int getX(){ return x; }
	int getY(){ return y; }



	void showPoint() {
		cout <<"Point at ( " <<x <<", " <<y <<" )\n";
	}



	void movePoint( const int offsetX, const int offsetY ) {
		x += offsetX;
		y += offsetY;
		checkPoint();
	}



private:

	int		x;
	int		y;
	


	// ����� ��������� ���� �������� ����� -- ���²��� ����ֲ�
	void checkPoint() {
		if( x <  0 ) x = 0;
		if( x > 79 ) x = 79;

		if( y <  0 ) y = 0;
		if( y > 24 ) y = 24;
	}


}; // class Point




void main() {
	Point pt1;
	//pt1.setCoords( 33, 22 );
	pt1.showPoint();


	Point pt2;
	pt2.setCoords( 55, 77 );
	pt2.showPoint();


	cout <<"\nAfter move :\n";

	pt1.movePoint( 33, -44 );
	pt2.movePoint( 33,  44 );

	pt1.showPoint();
	pt2.showPoint();

	cout <<"\nGeted x=" <<pt1.getX() <<", y=" <<pt1.getY() <<"\n";

	

}// void main()




