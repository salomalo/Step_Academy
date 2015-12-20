#include<iostream>
using namespace std;
class Matrix
{
public:
	Matrix();
	explicit Matrix(const int & Row,const int &  Col);
	Matrix (double **tarr,const int & Row,const int & Col);
	Matrix( Matrix & oSrc );
	~Matrix();
	void Show();

	Matrix & operator= ( const Matrix& right );
	Matrix  operator+ ( const Matrix& right );
	Matrix  operator- ( const Matrix& right );
	Matrix  operator* ( const Matrix& right );
	Matrix  operator! (  );
	double &  operator() ( int x, int y);
	
private:
	int Col;
	int Row;
	double **matrix;
};