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
	int		 idxTail;	// індекс останнього елемента у черзі ( -1 -- черга пуста )
	int		 size;		// розмір (місткість) черги
	char value;
};