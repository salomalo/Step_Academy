#include"Matrix.h"

Matrix::Matrix()
{
	Row=0;
	Col=0;
	matrix = new double *[Row];
	for (int i=0; i<Row; i++) 
		matrix[i] = new double [Col];
}

Matrix::Matrix(const int & Row, const int & Col)
{
	this->Row=Row;
	this->Col=Col;
	this->matrix = new double *[this->Row];
	for (int i=0; i<this->Row; i++) 
		this->matrix[i] = new double [this->Col];

	for(int i=0; i<this->Row; i++)
		for(int j=0; j<this->Col; j++)
			this->matrix[i][j]=i;
}

Matrix::Matrix (double ** tmp, const int & Row, const int & Col)
{
	this->Row = Row;
	this->Col = Col;
	this->matrix = new double *[Row];
	for (int i = 0; i < Row; i++) 
		this->matrix[i] = new double [Col];

	for(int i=0; i<Row; i++)
		for(int j=0; j<Col; j++)
			this->matrix[i][j]=tmp[i][j];
}

Matrix::Matrix( Matrix & oSrc )
{
	if(this->matrix)
		for (int i = 0; i < Row; i++) 
			delete []matrix[i];
		delete []matrix;

		Row = oSrc.Row;
		Col = oSrc.Col;
		matrix = new double *[Row];
		for (int i=0; i<Row; i++) 
			matrix[i] = new double [Col];
	
		for(int i=0; i<Row; i++)
			for(int j=0; j<Col; j++)
				matrix[i][j]=oSrc.matrix[i][j];
}

Matrix::~Matrix()
{
	for (int i = 0; i < Row; i++) 
	{
		delete []matrix[i];
	}
	delete []matrix;
}

void Matrix::Show()
{
	for(int i(0);i<Row;i++)
	{
		for(int j=0;j<Col;j++)
		{
			cout<<matrix[i][j]<<" ";
		}
		cout<<endl;
	}
}

Matrix & Matrix:: operator= ( const Matrix& right )
{
	if(this->matrix)
		for (int i = 0; i < Row; i++) 
			delete []matrix[i];
		delete []matrix;

		Row = right.Row;
		Col = right.Col;
		matrix = new double *[Row];
		for (int i = 0; i < Row; i++) 
			matrix[i] = new double [Col];
		
		for(int i=0; i<Row; i++)
			for(int j=0; j<Col; j++)
				matrix[i][j]=right.matrix[i][j];

		return *this;
}

Matrix Matrix::operator+ ( const Matrix& right )
{
	double** tmp = new double *[Row];
	for (int i=0; i < Row; i++) 
		tmp[i] = new double [Col];

	for(int i=0; i<Row; i++)
		for(int j=0; j<Col; j++)
			tmp[i][j]=matrix[i][j]+right.matrix[i][j];

	return Matrix(tmp,Row,Col);
}

Matrix Matrix::operator - ( const Matrix& right )
{
	double** tmp = new double *[this->Row];
	for (int i=0; i<Row; i++) 
		tmp[i]=new double[Col];

	for(int i=0; i<Row; i++)
	{
		for(int j=0; j<Col; j++)
		{
			tmp[i][j]=matrix[i][j]-right.matrix[i][j];
		}
	}
	return Matrix(tmp,Row,Col);
}

Matrix Matrix::operator* ( const Matrix& right )
{
	int counter=0;
	if(Row!=right.Col)
	{
		cout<<"This->Rows != right.Col "<<endl;
		return *this;
	}
	double** tmp = new double *[this->Row];
	for (int i = 0; i < this->Row; i++) 
		tmp[i] = new double [this->Col];

	for (int i=0; i < this->Row; i++)
		for (int j=0; j < right.Col; j++)
			for (int k=0; k<right.Row; k++)
			{
				if(counter==0)
					tmp[i][j]=this->matrix[i][k]*right.matrix[k][j];
				else
					tmp[i][j]+=this->matrix[i][k]*right.matrix[k][j];
			}

			return Matrix(tmp,Row,Col);
}


Matrix Matrix::operator! (  )
{
	double** tmp = new double *[Col];
	for (int i=0; i <Col; i++) 
		tmp[i] = new double [Row];

	for (int i=0; i<Col; i++)
	{	
		for (int j=0; j<Row; j++)
		{
			tmp[i][j]=matrix[j][i];
		}
	}

	return Matrix(tmp,Row,Col);
}


double & Matrix::operator() (int x, int y)
{
	return matrix[x][y];

}