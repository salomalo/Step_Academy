
#include "Shop.h"



void CShop::show()
{
	for(int i=0; i<size; i++)
	{
		cout<<*arr[i];
	}

}



CShop::CShop():size(0)
{
	arr=new Magazine*[size];
}


CShop::~CShop()
{
	delete[]arr;
}

void CShop::add(Magazine & newSource)
{
	size++;
	Magazine **tmp=new Magazine*[size];
	for(int i=0; i<size-1; i++)
	{
		tmp[i]=arr[i];
	}
	tmp[size-1]=new Magazine(newSource);
	delete [] arr;
	arr=tmp;
}