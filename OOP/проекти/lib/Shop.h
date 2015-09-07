#pragma once
#include "Magazine.h"
#include "Book.h"

template <typename TYPE>
class CShop
{
public:
	CShop <TYPE> ();
	~CShop <TYPE> ();

	void add (TYPE & newSource);
	void del (const int index);
	void show ();

	///////////////////////// find шукає обєкт і пропонує подальшу дію змінити обєкт або видалити його
	void findYaer(int tmp);
	void findTitle(string tmp);
	void findMonth(string tmp);
	//void findGanre(string tmp); // only for looking books



	///////////////////////// sort
	void sortTitle(); // через перевантажений оператор порівняння
	void sortMonth(); // через гетер
	void sortYear();




	//friend  ostream & operator << (ostream & left, CShop <TYPE> & right ); // не працює

private:
	TYPE **arr;
	int size;
};


template <typename TYPE>
void CShop<TYPE>::findYaer(int tmp)
{
	int sizArr=0, g=1;
	for (int i=0; i<size; i++)
	{
		if((*arr[i]).getYear()==tmp)
		{
			sizArr++;
			g+=i;
			cout<<*arr[i];
		}
	}

	cout<<endl;
	cout<<sizArr<<" resalts "<<endl;

	if(sizArr>0)
	{
		cout<<" nothing to do..........1"<<endl;
		cout<<" to make change.........2"<<endl;

		int cho;    cin>>cho;
		switch(cho)
		{
		case 1: 
			show();
			break;
		case 2: 
			for (int i=0; i<size; i++)
			{
				if((*arr[i]).getYear()==tmp)
				{
					cout<<" You want to change: "<<endl;
					cout<<"     "<<*arr[i];
					cout<<" to edit ...1"<<endl;////////////////////////////////////////////////////////////
					cout<<" to del  ...2"<<endl;
					cout<<" skip    ...3"<<endl;
					int choice;     cin>>choice;
					switch(choice)
					{
					case 1:
						arr[i]->edit();
						show();
						break;
					case 2:
						del(g);
						show();
						break;
					case 3:
						break;
					}
				}
			}
			break;
		}
	}
}

template <typename TYPE>
void CShop<TYPE>::findTitle(string tmp)
{
	int sizArr=0,g=1;
	for (int i=0; i<size; i++)
	{
		if((*arr[i]).getTitle().compare(tmp)==0)
		{
			sizArr++;
			g+=i;
			cout<<*arr[i];
		}
	}
	cout<<endl;
	cout<<"   "<<sizArr<<"   resalts "<<endl;
	if(sizArr>0)
	{
		cout<<"nothing to do..........1"<<endl;
		cout<<"to make change.........2"<<endl;

		int cho;    cin>>cho;
		switch(cho)
		{
		case 1: 
			show();
			break;
		case 2: 
			for (int i=0; i<size; i++)
			{
				if((*arr[i]).getTitle().compare(tmp)==0)
				{
					cout<<" You want to change: "<<endl;
					cout<<"     "<<*arr[i];
					cout<<" edit    ...1"<<endl;////////////////////////////////////////////////////////////
					cout<<" del     ...2"<<endl;
					cout<<" skip    ...3"<<endl;

					int choice;     cin>>choice;
					switch(choice)
					{
					case 1:
						arr[i]->edit();
						show();
						break;
					case 2:
						del(g);
						show();
						break;
					case 3:
						break;
					}
				}
			}
			break;
		}
	}
}

template <typename TYPE>
void CShop<TYPE>::findMonth(string tmp)
{
	int sizArr=0, g=1;

	for (int i=0; i<size; i++)
	{
		if((*arr[i]).getMonth().compare(tmp)==0)
		{
			sizArr++;
			g+=i;
			cout<<*arr[i];
		}
	}

	cout<<endl;
	cout<<"   "<<sizArr<<"    resalts "<<endl;

	cout<<"/////////////////////////////////////"<<endl;
	if(sizArr>0)
	{
		cout<<" nothing to do..........1"<<endl;
		cout<<" to make change.........2"<<endl;

		int cho;    cin>>cho;
		switch(cho)
		{
		case 1: 
			show();
			break;
		case 2: 
			for (int i=0; i<size; i++)
			{
				if((*arr[i]).getMonth().compare(tmp)==0)
				{
					cout<<" You want to change: "<<endl;
					cout<<"     "<<*arr[i];
					cout<<" edit    ...1"<<endl;////////////////////////////////////////////////////////////
					cout<<" del     ...2"<<endl;
					cout<<" skip    ...3"<<endl;

					int choice;     cin>>choice;
					switch(choice)
					{
					case 1:
						arr[i]->edit();
						show();
						break;
					case 2:
						del(g);
						show();
						break;
					case 3:
						break;
					}
				}
			}
			break;
		}
	}
}



//template <typename TYPE>
//void CShop<TYPE>::findGanre(string tmp)
//{
//	int sizArr=0, g=1;
//
//	for (int i=0; i<size; i++)
//	{
//		if((*arr[i]).getGanre().compare(tmp)==0)
//		{
//			sizArr++;
//			g+=i;
//			cout<<*arr[i];
//		}
//	}
//
//	cout<<endl;
//	cout<<sizArr<<" resalts "<<endl;
//
//	if(sizArr>0)
//{
//	cout<<"nothing to do..........1"<<endl;
//	cout<<"to make change.........2"<<endl;
//
//	int cho;    cin>>cho;
//	switch(cho)
//	{
//	case 1: 
//		show();
//		break;
//	case 2: 
//		for (int i=0; i<size; i++)
//		{
//			if((*arr[i]).getGanre().compare(tmp)==0)
//			{
//				cout<<" You want to change: "<<endl;
//				cout<<"     "<<*arr[i];
//				cout<<" edit    ...1"<<endl;////////////////////////////////////////////////////////////
//				cout<<" del     ...2"<<endl;
//				cout<<" skip    ...3"<<endl;
//				int choice;     cin>>choice;
//				switch(choice)
//				{
//				case 1:
//					arr[i]->edit();
//					show();
//					break;
//				case 2:
//					del(g);
//					show();
//					break;
//				case 3:
//					break;
//				}
//			}
//		}
//		break;
//	}
//}
//}



template <typename TYPE>
void CShop<TYPE>::del(const int index)
{
	if(index==0||index>size)
	{
		throw index;
	}
	else
	{
		size--;
		TYPE**tmp=new TYPE*[size];
		for(int i=0; i<index-1; i++)
			tmp[i]=arr[i];
		for(int i=index-1; i<size; i++)
			tmp[i]=arr[i+1];
		delete[]arr;
		arr=tmp;
	}
}

template <typename TYPE>
void CShop<TYPE>::sortMonth()
{
	TYPE *tmp;
	for (int i=0; i<size; i++)
	{
		for(int j=size-1; j>i; j--)
		{
			if((*arr[j]).getMonth().compare((*arr[j-1]).getMonth())<0)
			{
				tmp=arr[j-1];
				arr[j-1]=arr[j];
				arr[j]=tmp;
			}
		}
	}
}

template <typename TYPE>
CShop<TYPE>::CShop():size(0)
{
	arr=new TYPE*[size];
}

template <typename TYPE>
CShop<TYPE>::~CShop()
{
	delete[]arr;
}

template <typename TYPE>
void CShop<TYPE>::add(TYPE & newSource)
{
	size++;
	TYPE **tmp=new TYPE*[size];
	for(int i=0; i<size-1; i++)
	{
		tmp[i]=arr[i];
	}
	tmp[size-1]=new TYPE(newSource);
	delete [] arr;
	arr=tmp;
}

template <typename TYPE>
void CShop<TYPE>::sortTitle()
{
		TYPE *tmp;
	for (int i=0; i<size; i++)
	{
		for(int j=size-1; j>i; j--)
		{
			if((*arr[j]).getTitle().compare((*arr[j-1]).getTitle())<0)
			{
				tmp=arr[j-1];
				arr[j-1]=arr[j];
				arr[j]=tmp;
			}
		}
	}
}


template <typename TYPE>
void CShop<TYPE>::sortYear()
{
	TYPE *tmp;

	for (int i=0; i<size; i++)
	{
		for(int j=size-1; j>i; j--)
		{
			if((*arr[j]).getYear() < ((*arr[j-1]).getYear()))
			{
				tmp=arr[j-1];
				arr[j-1]=arr[j];
				arr[j]=tmp;
			}
		}

	}
}



template <typename TYPE>
void CShop<TYPE>::show()
{
	for(int i=0; i<size; i++)
	{
		cout<<*arr[i];
	}
}

//template <typename TYPE>
//ostream & operator << (ostream & left, CShop <TYPE> & right )
//{
//	for(int i=0; i<right.size; i++)
//		cout<<(*right)->arr[i];
//	return left;
//}