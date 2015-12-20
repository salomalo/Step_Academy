#include<iostream>


using namespace std;
class Vector
{
private:
	int size;
	double* arr;
public:
	Vector();
	explicit Vector(const int& size);
	Vector ( const double * const d, const int & size );
	Vector( Vector & oSrc );
	~Vector();
	int getSize();
	double getElVector(const int&index);
	double* getVector(); 
	friend ostream & operator << ( ostream & left, Vector & right ) ;
	friend istream & operator >> ( istream & left, Vector & right ) ;
	friend Vector & operator ++ (Vector & left); // ����������
	Vector operator ++ (int ignore); // �����������

	Vector operator -- (int ignore); // ����������
	friend Vector & operator -- (Vector & right); // �����������
	double& operator[] ( int idx );
	Vector& operator =(const Vector&right);
	Vector operator +(const Vector right);
	Vector operator +(const double doub);
	Vector operator +=(const Vector right);
	Vector operator +=(const double doub);
	Vector operator -(const Vector right);
	Vector operator -(const double doubl);
	Vector operator -=(const Vector right);
	Vector operator -=(const double doubl);
	Vector operator *(const Vector right);
	Vector operator *(const double doubl);
	Vector operator *=(const Vector right);
	Vector operator *=(const double doubl);
	bool operator ==(const Vector right);
	bool operator >(const Vector right);
	bool operator <(const Vector right);
};


