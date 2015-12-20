
#include <Windows.h>
#include <iostream>
using namespace std;



#define MYSTACK_SIZE 7


class Stack
{

public:
	Stack( short x, short y );

	bool push( int   value );
	bool pop(  int & value );

private:

	

	int		stack[ MYSTACK_SIZE ];
	int		quantity;

	static HANDLE	hCon;

	short	x;
	short	y;
	void	show();
	void	showPushing( int value );
	void	showPoping();


};