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
		int value;     //�������� �������(���� ����� �����)
		patron * pPrev;//��������� �� ���������� ������
	};

	int countofPatr; //��������� ���� � �����
	patron *pTop;    //��������� �� ������ ���� � �����

};
