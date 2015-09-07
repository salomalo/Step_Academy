//#include"CShop.h"
//
//template <typename TYPE>
//CShop<TYPE>::CShop():size(0)
//{
//	arr=new TYPE*[size];
//}
//
//template <typename TYPE>
//CShop<TYPE>::~CShop()
//{
//	delete[]arr;
//}
//
//template <typename TYPE>
//void CShop<TYPE>::show()
//{
//	for(int i=0; i<size; i++)
//	{
//		cout<<*arr[i];
//	}
//}
//
//template <typename TYPE>
//void CShop<TYPE>::add(TYPE & newBook)
//{
//	size++;
//	TYPE **tmp=new TYPE*[size];
//	for(int i=0; i<size-1; i++)
//	{
//		tmp[i]=arr[i];
//	}
//	tmp[size-1]=new TYPE(newBook);
//	delete [] arr;
//	arr=tmp;
//}
//
//template <typename TYPE>
//void  CShop<TYPE>::MaxPrice()
//{
//	int ind=0;
//	int max=0;
//	for (int i=0; i<size; i++)
//	{
//		if((*arr[i]) > max)
//		{
//			max=(*arr[i]).getPrice();/////////////////////////////
//			ind=i;
//		}
//	}
//	//cout<<" max price - "<<max<<endl;
//	cout<<" book with max price - "<<(*arr[ind]);
//}
//
//template <typename TYPE>
//void  CShop<TYPE>::MinPrice()
//{
//	int ind=0;
//	int min=(*arr[0]).getPrice();
//	for (int i=0; i<size; i++)
//	{
//		if((*arr[i]) < min)
//		{
//			min=(*arr[i]).getPrice();////////////////////////////
//			ind=i;
//		}
//	}
//	//cout<<" min price - "<<min<<endl;;
//	cout<<" book with min price - "<<(*arr[ind]);
//}
//
//template <typename TYPE>
//void CShop<TYPE>::AveragePrice()
//{
//	int sum=0;
//	for(int i=0;i<size;i++)
//	{
//		sum+=(*arr[i]).getPrice();//////////////////////////////
//	}
//	cout<<""<<sum/this->size;
//}
//
//template <typename TYPE>
//void CShop<TYPE>::showIsNew()
//{
//	int newSize=0;
//	for(int i=0; i<size; i++)
//	{
//		if((*arr[i]).getIsNew()==true)////////////////////////////
//		{
//			newSize++;
//		}
//	}
//
//	TYPE **newArr=new TYPE*[newSize];
//	cout<<"count of new book is - "<<newSize<<endl;
//
//	for(int i=0; i<size; i++)
//	{
//		if((*arr[i]).getIsNew()==true)
//		{
//			newArr[i]=arr[i];
//		}
//	}
//
//	cout<<" New item "<<endl;
//	for(int i=0; i<newSize; i++)
//	{
//		cout<<*newArr[i];
//	}
//
//}
//
//template <typename TYPE>
//TYPE & CShop<TYPE>::operator[] (int idx)
//{
//	if( idx<0 || idx> size )
//	{
//		cout <<"\n\nERROR!!!!   CShop::operator[] -- index out of range!!!\n\n";
//		exit( EXIT_FAILURE );
//	}
//	cout<<"element "<<idx<<"is "<<endl;
//	return (*arr[idx]);
//}
//
//
//template <typename TYPE>
//void CShop<TYPE>::sort()
//{
//TYPE *tmp;
//
//for (int i=0; i<size; i++)
//{
//	for(int j=size-1; j>i; j--)
//	{
//		if((*arr[j]) < (*arr[j-1]))
//		{
//			tmp=arr[j-1];
//			arr[j-1]=arr[j];
//			arr[j]=tmp;
//		}
//	}
//
//}
//
//cout<<"sort by price"<<endl;
//for(int i=0; i<size; i++)
//{
//	cout<<' '<<(*arr[i]);
//}
//cout<<endl;
//
//}
//
//
//template <typename TYPE>
//ostream & operator << (ostream & left, CShop <TYPE>& right )
//{
//	for(int i=0;i<right.size; i++)
//		cout<<(*right.arr[i]);
//	return left;
//}