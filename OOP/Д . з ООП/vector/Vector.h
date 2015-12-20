#include<iostream>
using namespace std;
#include<math.h>

class Vector
{

public:
	Vector();
	explicit Vector(int tmp);
	Vector(int tmp, double * arr);
	~Vector();
	Vector(Vector & obj);
	void show();

	int getSize();

	operator double *()const ;
	
	friend ostream & operator << (ostream & left, Vector & right);
	
	Vector  operator +  (const Vector & tmp);
	Vector  operator += (Vector & tmp);//---
	Vector  operator + (double tmp);
	Vector  operator += (double tmp);//----
	
	Vector& operator =(const Vector & tmp);

	Vector  operator * (Vector & tmp);
	Vector  operator *= (Vector & tmp);//------

	Vector  operator * (double tmp);
	Vector  operator *= (double tmp);
	bool operator>(Vector & tmp);
	bool operator<(Vector & tmp);
	friend Vector & operator ++ (Vector & left); // ����������
	friend Vector & operator -- (Vector & right); // �����������
	Vector operator ++ (int ignore); // �����������
	Vector operator -- (int ignore); // ����������
	double& operator[] ( int idx );

	Vector  operator -  ( double tmp);
	Vector operator -=  ( double tmp);

	Vector  operator -  ( Vector & tmp);//----------------

private:
	double * Vec;
	int size;
};