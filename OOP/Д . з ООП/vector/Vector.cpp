#include"Vector.h"

Vector::Vector() : Vec(0), size(0) {}

Vector::Vector(int tmp) : size(tmp)
{	
	Vec=new double[size];
	for(int i=0; i<size; i++)
		Vec[i]=0;
}

Vector::Vector(int tmp, double*arr) : size(tmp),Vec(arr)
{
	Vec=new double[size];
	for(int i=0; i<size; i++)
		Vec[i]=arr[i];
}

Vector::~Vector()
{
	delete[]Vec;
}

Vector::Vector(Vector & obj)
{
	Vec=new double[obj.size];

	for(int i=0; i<obj.size; i++)
		Vec[i]=obj.Vec[i];
}

int Vector::getSize()
{
	return size;
}

void Vector::show()
{
	for(int i=0; i<size; i++)
		cout<<Vec[i]<<' ';
	cout<<endl;
}

ostream & operator << (ostream & left, Vector & right)
{
	for(int i=0; i<right.size; i++)
		left<<' '<<right.Vec[i];
	cout<<endl;
	return left;
}

Vector::operator double *()    const 
{
	return this->Vec;
}

Vector  Vector::operator+(const Vector & tmp)
{
	Vector RES;
	RES.size=size+tmp.size;
	RES.Vec=new double[RES.size];

	int k=0;
	for(int i=0; i<size; i++)     RES.Vec[k++]=Vec[i];
	for(int i=0; i<tmp.size; i++) RES.Vec[k++]=tmp.Vec[i];

	for(int i=0; i<RES.size; i++)
	{
		cout<<' '<<RES.Vec[i];
	}
	cout<<endl;

	return RES;
}

Vector  Vector::operator+=(Vector & tmp)
{
	Vector RES;
	RES.size=size+tmp.size;
	RES.Vec=new double[RES.size];
	
	int k=0;
	for(int i=0; i<size; i++)     RES.Vec[k++]=Vec[i];
	for(int i=0; i<tmp.size; i++) RES.Vec[k++]=tmp.Vec[i];

	delete [] Vec;////////////////////////////////////////////////////////////
	Vec=new double[RES.size];
	for(int i=0; i<RES.size; i++)
	{
		this->Vec[i]=RES.Vec[i];
	}

	for(int i=0; i<RES.size; i++)
	{
		cout<<' '<<Vec[i];
	}
	cout<<endl;

	return RES;

}

Vector  Vector::operator + (double tmp)
{
	Vector RES;
	RES.Vec=new double[size+1];

	int k=0;
	for(int i=0; i<size; i++)    
		RES.Vec[k++]=Vec[i];
	for(int i=0; i<1; i++)   
		RES.Vec[k++]=tmp;

	for(int i=0; i<size+1; i++)
	{
		cout<<' '<<RES.Vec[i];
	}
	cout<<endl;
	return RES;

}

Vector  Vector::operator += (double tmp)
{
	Vector RES;
	RES.Vec=new double[size+1];

	int k=0;
	for(int i=0; i<size; i++)    
		RES.Vec[k++]=Vec[i];
	for(int i=0; i<1; i++)   
		RES.Vec[k++]=tmp;

	delete [] Vec;
	Vec=new double[size+1];

	for(int i=0; i<size+1; i++)
	{
		Vec[i]=RES.Vec[i];
	}

	for(int i=0; i<size+1; i++)
	{
		cout<<' '<<Vec[i];
	}
	cout<<endl;
	return RES;
}

Vector  Vector::operator-(Vector & tmp)/////////////////////////////////////////
{
	int n=0;
	Vector RES;
	RES.size=size-n;
	RES.Vec=new double[RES.size];
	
	int l=0;

	for(int i=0; i<size; i++)
	{
		for(int j=0; j<size; j++)
		{
			if(Vec[i]==tmp.Vec[j])
			{
				n++;
				RES.Vec[l]=Vec[i+1];
			}
		}
	}

	for(int i=0; i<RES.size; i++)
	{
		cout<<' '<<RES.Vec[i];
	}
	cout<<endl;

return RES;
}

Vector Vector:: operator -  ( double tmp)
{
	Vector RES;
	RES.size=size-1;
	RES.Vec=new double[RES.size];
	int k=0;
	for(int i=0; i<size; i++)
	{
		if(Vec[i]==tmp)
		{
			k=i;
		}
	}

	for(int i=0; i<size-1; i++)
	{
	RES.Vec[i]=Vec[i];
	}

	for(int i=k; i<RES.size; i++)
	{
	RES.Vec[i]=Vec[i+1];
	}


	for(int i=0; i<RES.size; i++)
	{
		cout<<' '<<RES.Vec[i];
	}
	cout<<endl;

return RES;
}


Vector Vector:: operator -=  (double tmp)
{
	Vector RES;
	RES.size=size-1;
	RES.Vec=new double[RES.size];
	int k=0;
	for(int i=0; i<size; i++)
	{
		if(Vec[i]==tmp)
		{
			k=i;
		}
	}

	for(int i=0; i<size-1; i++)
	{
	RES.Vec[i]=Vec[i];
	}

	for(int i=k; i<RES.size; i++)
	{
	RES.Vec[i]=Vec[i+1];
	}

	delete[]Vec;
	Vec=new double[RES.size];
	this->size=RES.size;

	for(int i=0; i<RES.size; i++)
	{
		Vec[i]=RES.Vec[i];
	}

	for(int i=0; i<RES.size; i++)
	{
		cout<<' '<<Vec[i];
	}
	cout<<endl;

return RES;
}

Vector& Vector:: operator =(const Vector & tmp)
{
	delete [] this->Vec;
	this->size=tmp.size;
	this->Vec=new double[this->size];
	for (int i(0); i<this->size; i++)
	{
		this->Vec[i]=tmp.Vec[i];
	}
	return *this;
}

Vector Vector:: operator * (Vector & tmp)
{

	Vector RES;
	RES.size=size*tmp.size;
	RES.Vec=new double[RES.size];

	int k=0;
	for(int i=0; i<tmp.size; i++)
	{
		for(int j=0; j<size; j++)
		{
			RES.Vec[k]=Vec[j]*tmp.Vec[i];
			k++;
		}
	}

	for(int i=0; i<RES.size; i++)
	{
		cout<<' '<<RES.Vec[i];
	}
	cout<<endl;

	return RES;
}

Vector Vector:: operator *= (Vector & tmp)
{

	Vector RES;
	RES.size=size*tmp.size;
	RES.Vec=new double[RES.size];

	int k=0;
	for(int i=0; i<tmp.size; i++)
	{
		for(int j=0; j<size; j++)
		{
			RES.Vec[k]=Vec[j]*tmp.Vec[i];
			k++;
		}
	}

	delete [] Vec;
	Vec=new double[size*tmp.size];
	for(int i=0; i<size*tmp.size; i++)
	{
		Vec[i]=RES.Vec[i];
	}

	for(int i=0; i<RES.size; i++)
	{
		cout<<' '<<Vec[i];
	}
	cout<<endl;

	return RES;
}


Vector Vector:: operator * (double tmp)
{
	Vector RES;
	RES.Vec=new double[size];
	int k=0;
	for(int i=0; i<size; i++)
	{
		RES.Vec[k]=Vec[i]*tmp;
		k++;
	}
	for(int i=0; i<size; i++)
	{
		cout<<' '<<RES.Vec[i];
	}
	cout<<endl;
	return RES;
}

Vector Vector:: operator *= (double tmp)

{
	Vector RES;
	RES.Vec=new double[size];

	int k=0;
	for(int i=0; i<size; i++)
	{
		RES.Vec[k]=Vec[i]*tmp;
		k++;
	}


	delete [] Vec;
	Vec=new double[size];

	for(int i=0; i<size; i++)
	{
		Vec[i]=RES.Vec[i];
	}


	for(int i=0; i<size; i++)
	{
		cout<<' '<<RES.Vec[i];
	}
	cout<<endl;

	return RES;

}

bool Vector:: operator>(Vector & tmp)
{
	double sum1=0;
	double sum2=0;
	for(int i=0; i<size; i++)
	{
		sum1+=Vec[i]*pow(10.0,i);
	}
	for(int i=0; i<tmp.size; i++)
	{
		sum2+=Vec[i]*pow(10.0,i);
	}
	if(sum1>sum2) return true;
	else return false;
}

bool Vector:: operator<(Vector & tmp)
{
	double sum1=0;
	double sum2=0;
	for(int i=0; i<size; i++)
	{
		sum1+=Vec[i]*pow(10.0,i);
	}
	for(int i=0; i<tmp.size; i++)
	{
		sum2+=Vec[i]*pow(10.0,i);
	}
	if(sum1<sum2) return true;
	else return false;
}

Vector & operator++(Vector & tmp)
{
	for(int i=0; i<tmp.size; i++)
	{
		tmp.Vec[i]+=1;
	}
	return tmp;
}

Vector & operator -- (Vector & tmp)
{
	for(int i=0; i<tmp.size; i++)
	{
		tmp.Vec[i]-=1;
	}
	return tmp;
} 

Vector Vector:: operator ++(int ignore)
{
	for(int i=0; i<size; i++)
	{
		Vec[i]+=1;
	}
	return *this;
} 

Vector Vector:: operator --(int ignore)
{
	for(int i=0; i<size; i++)
	{
		Vec[i]-=1;
	}
	return *this;
} 

double & Vector::operator[] ( int idx )
{
	if( idx < 0 || idx > this->size )
	{
		cout <<"\n\nERROR!!!!   Vector::operator[] -- index out of range!!!\n\n";
		exit( EXIT_FAILURE );
	}

	return Vec[idx];

}