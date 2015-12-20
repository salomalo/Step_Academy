#include <Windows.h>
#include <time.h>
#include <iostream>
using namespace std;


struct STIME
{
	time_t	X;
	time_t	Y;
};



class Fly
{

public:
	Fly();
	void move();

private:
	char	sym;		// ������, ���� ������������
	DWORD	attr;		// ���� ����
	COORD	pos;		// ��������� ����
	COORD	step;		// �������� ���� �� ����
	STIME	period;		// �������� ���� �� ���� 
	STIME	next;		// ������ ���������� ���� �� ����� ��


	static HANDLE	hCon;		// ����� ���� ���, �� ����� ����� ���� ��� !	��� -- ��� ��� ���� ����� ����� ! ���� static

};