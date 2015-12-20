#include"Vector.h"
#include <cmath>  
Vector::Vector()
	{
		this->size=0;
		this->arr=new double[size];
	}
	Vector:: Vector (const int& size):arr(0)
	{
		if(this->arr)
			delete[]this->arr;
		this->size=size;
		this->arr=new double[size];
		for(int i(0);i<size;i++)
		{
			arr[i]=0.0;
		}
	}
	Vector::Vector ( const double * const d, const int & size ):arr(0)
	{
		if(this->arr)
			delete[]this->arr;
		this->size = size;
		this->arr=new double[size];
		for(int i(0);i<size;i++)
		{
			arr[i]=d[i];
		}

	}
	Vector::Vector( Vector & oSrc ):arr(0)
	{
		if(this->arr)
			delete[]this->arr;
		this->size = oSrc.size;
		arr = new double [oSrc.size];
		for(int i(0);i<oSrc.size;i++)
		{
			arr[i]=oSrc.arr[i];
		}
	}
	
	Vector::~Vector()
	{
		delete [] arr;
	}
	int Vector::getSize()
	{
		return this->size;
	}
	double Vector:: getElVector(const int&index)
	{
	
		return this->arr[index];
	}
	
	double* Vector:: getVector()
	{
		return this->arr;
	}
	ostream & operator << ( ostream & left, Vector & right ) // тут left -- це синонім cout'а //- Виведення вектора ( << );
{
	for(int i=0;i<right.size;i++)
	{
		left<<right.arr[i];
		left<<' ';
	}		
	return left; 				
}



istream & operator >> ( istream & left, Vector & right )
{
	cout<<"Enter size of vector =";
	left>>right.size;
	right.arr=new double[right.size];
	cout<<"Fill vector step by step"<<endl;
	for(int i(0);i<right.size;i++)
	{

		cout<<i+1<<"-Element is = ";
		left>>right.arr[i];
		/*left<<right.arr[i]*/
	}
	return left;
//- Введення вектора ( >> );
//спочатку запитує кількість елементів, тоді запитує значення кожного елемента (підказуючи його індекс чи номер)
}

Vector & operator++(Vector&left)
{
	for(int i(0);i<left.size;i++)
		{
				left.arr[i]+=1;
		}
		return left;
}


Vector Vector:: operator ++(int ignore)
	{
		for(int i(0);i<this->size;i++)
		{
				this->arr[i]+=1;
		}
		return *this;
	}  // постфіксний

	Vector Vector:: operator --(int ignore)
	{
		for(int i(0);i<this->size;i++)
		{
				this->arr[i]-=1;
		}
		return *this;
	} 

	Vector & operator -- (Vector & right)
	{
		for(int i(0);i<right.size;i++)
		{
				right.arr[i]-=1;
		}
		return right;
	} 
	
	double& Vector::operator[] ( int idx )
{
	if( idx < 0 || idx > this->size )
	{
		cout <<"\n\nERROR!!!!   XString::operator[] -- index out of range!!!\n\n";
		exit( EXIT_FAILURE );
	}

	return this->arr[idx];

}
	Vector Vector::operator +(const Vector right)
	{
		int xsize;
		xsize=this->size+right.size; 
	
			double* tarr=new double[xsize];
		for(int i=0;i<this->size;i++)
			tarr[i]=this->arr[i];
		for(int i=this->size;i<xsize;i++)
			tarr[i]=right.arr[i-this->size];
		/*for(int i=0;i<xsize;i++)
		{
			cout<<"Check"<<tarr[i]<<endl;
		}*/

		return Vector(tarr,xsize);
	}

	Vector Vector::operator +(const double doubl)
	{
			int tsize;
			tsize=this->size+1;
			double *Tarr=new double[tsize];
		for(int i=0;i<this->size;i++)
			Tarr[i]=this->arr[i];
		for(int i=this->size;i<tsize;i++)
			Tarr[i]=doubl;
		/*for(int i=0;i<tsize;i++)
		{
			cout<<"Check"<<Tarr[i]<<endl;
		}*/
	
		return Vector(Tarr,tsize);
	}

Vector Vector::operator +=(const Vector right)
	{
		int xsize;
		xsize=this->size+right.size; 
	
			double* tarr=new double[xsize];
		for(int i=0;i<this->size;i++)
			tarr[i]=this->arr[i];
		for(int i=this->size;i<xsize;i++)
			tarr[i]=right.arr[i-this->size];
		/*for(int i=0;i<xsize;i++)
		{
			cout<<"Check"<<tarr[i]<<endl;
		}*/
		*this=Vector(tarr,xsize);
		return *this;
	}

Vector Vector::operator +=(const double doubl)
{
	int tsize;
	tsize=this->size+1;
	double *Tarr=new double[tsize];
	for(int i=0;i<this->size;i++)
		Tarr[i]=this->arr[i];
	for(int i=this->size;i<tsize;i++)
		Tarr[i]=doubl;
	/*for(int i=0;i<tsize;i++)
	{
		cout<<"Check"<<Tarr[i]<<endl;
	}*/
	*this=Vector(Tarr,tsize);
	return *this;
}

	Vector Vector::operator -(const Vector right)
	{
		int tsize=0;
		int counter=0;
		double* tarr=new double[tsize];
		for(int i (0);i<this->size;i++)
		{
			for(int j (0);j<right.size;j++)
			{
				if(this->arr[i]!=right.arr[j])
				{	
				counter++;
				}
			}
			if(counter==right.size)
				{
					tsize++;
					tarr[tsize-1]=this->arr[i];
				}
			counter=0;
		}
		
		/*for (int i=0;i<tsize;i++)
		{
			cout<<"Check  ="<<tarr[i]<<endl;
		}*/
			
		return Vector(tarr,tsize);
	}

	Vector Vector::operator -(const double doubl)
	{
		int tsize=0;
		double* tarr=new double[tsize];
		for(int i (0);i<this->size;i++)
		{
				if(this->arr[i]!=doubl)
				{
					tsize++;
					tarr[tsize-1]=this->arr[i];
				}
		}
		
		/*for (int i=0;i<tsize;i++)
		{
			cout<<"Check  ="<<tarr[i]<<endl;
		}*/
			
		return Vector(tarr,tsize);
	}


	Vector Vector::operator -=(const Vector right)
	{
		int tsize=0;
		int counter=0;
		double* tarr=new double[tsize];
		for(int i (0);i<this->size;i++)
		{
			for(int j (0);j<right.size;j++)
			{
				if(this->arr[i]!=right.arr[j])
				{	
				counter++;
				}
			}
			if(counter==right.size)
				{
					tsize++;
					tarr[tsize-1]=this->arr[i];
				}
			counter=0;
		}
		
		/*for (int i=0;i<tsize;i++)
		{
			cout<<"Check  ="<<tarr[i]<<endl;
		}*/
			*this=Vector(tarr,tsize);
		return *this;
	}

	Vector Vector::operator -=(const double doubl)
	{
		int tsize=0;
		double* tarr=new double[tsize];
		for(int i (0);i<this->size;i++)
		{
				if(this->arr[i]!=doubl)
				{
					tsize++;
					tarr[tsize-1]=this->arr[i];
				}
		}
		
		/*for (int i=0;i<tsize;i++)
		{
			cout<<"Check  ="<<tarr[i]<<endl;
		}*/
			*this=Vector(tarr,tsize);
		return *this;
	}

	Vector Vector::operator *(const Vector right)
	{
		int xsize;
		int k(0);
		xsize=this->size*right.size; 
	
		double* tarr=new double[xsize];
		
		for(int i=0;i<right.size;i++)
		{
			for(int j=0;j<this->size;j++)
			{
				tarr[k]=this->arr[j]*right.arr[i];
				k++;
			}
		}
		return Vector(tarr,xsize);
	}
	
	Vector Vector::operator *(const double doubl)
	{
		double* tarr=new double[this->size];
		for(int i=0;i<this->size;i++)
		{
			tarr[i]=this->arr[i]*doubl;
		}
		return Vector(tarr,this->size);
	}

	
	Vector Vector::operator *=(const Vector right)
	{
		int xsize;
		int k(0);
		xsize=this->size*right.size; 
	
		double* tarr=new double[xsize];
		
		for(int i=0;i<right.size;i++)
		{
			for(int j=0;j<this->size;j++)
			{
				tarr[k]=this->arr[j]*right.arr[i];
				k++;
			}
		}
		*this=Vector(tarr,xsize);
		return *this;
	}
	
	Vector Vector::operator *=(const double doubl)
	{
		double* tarr=new double[this->size];
		for(int i=0;i<this->size;i++)
		{
			tarr[i]=this->arr[i]*doubl;
		}
		*this=Vector(tarr,this->size);
		return *this;
	}
	bool Vector:: operator ==(const Vector right)
	{
		int counter=0;
		if(this->size==right.size)
		{
			for(int i=0;i<this->size;i++)
			{
				if(this->arr[i]==right.arr[i])
				counter++;
			}
			if(counter==this->size)
				return true;			
		}
		else
			return false;
	}

	bool Vector:: operator >(const Vector right)
	{
		double ChSm1=0;
		double ChSm2=0;
		double ch=10;
	
		for(int i(0);i<this->size;i++)
		{
			ChSm1+=this->arr[i]* pow(ch,i);
		}
		
		for(int i(0);i<right.size;i++)
		{
			ChSm2+=right.arr[i]* pow(ch,i);
		}
		if(ChSm1>ChSm2)return true;
		else return false;
	}

		bool Vector:: operator <(const Vector right)
	{
		double ChSm1=0;
		double ChSm2=0;
		double ch=10;
	
		for(int i(0);i<this->size;i++)
		{
			ChSm1+=this->arr[i]* pow(ch,i);
		}
		
		for(int i(0);i<right.size;i++)
		{
			ChSm2+=right.arr[i]* pow(ch,i);
		}
		if(ChSm1<ChSm2)return true;
		else return false;
	}



	Vector& Vector:: operator =(const Vector&right)
	{

		delete [] this->arr;
		this->size=right.size;
		this->arr=new double[this->size];
		for (int i(0); i<this->size;i++)
		{
			this->arr[i]=right.arr[i];
		}

	   return *this;
	}
	
