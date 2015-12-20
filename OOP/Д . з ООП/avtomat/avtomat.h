#include <iostream>
using namespace std;


class Avtomat
{
public:
	Avtomat();
	~Avtomat();

	bool pushInAvt (int value);
	bool popFromAvt (int & value);

private:
	struct patron
	{
		int value;     //значення патрона(його номер нехай)
		patron * pPrev;//вказывник на попередный патрон
	};

	int countofPatr; //кылькысть елем у стеку
	patron *pTop;    //вказывник на патрон який з верху

};
