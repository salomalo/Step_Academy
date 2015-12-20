#include<iostream>
#include<ctime>
using namespace std;

class Drum
{
public:
	Drum();
	~Drum();
	void rotate();
	void rotate(char a);
	void rotate(char a,char b);
	void enqueue();
	void dequeue();
	void dequeueRing();
	char getChar();
private:
	char* arr;
	int		 idxTail;	// ������ ���������� �������� � ���� ( -1 -- ����� ����� )
	int		 size;		// ����� (�������) �����
	char value;
};