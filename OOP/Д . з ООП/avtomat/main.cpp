#include "avtomat.h"
#include <ctime>
#include <conio.h>

int main()
{
	srand(time(NULL));
	Avtomat a;
	int value=0;
	int limit=10;
	bool isSucsed;

	cout<<" charge "<<endl;
	do
	{
		value++;
		isSucsed=a.pushInAvt(value);
		cout<<"  patron  "<<value<< " is charge "<<endl;
	/*	getch();*/
	}
	while(isSucsed && limit--);

	cout<<" shot "<<endl;
	do
	{
		int	_shot = rand()%10+1;
		isSucsed=a.popFromAvt(value);
		cout<<"  patron   "<<value<< " is short ";
		if(_shot<7) cout<<" hit "<<endl;
		else cout<<" missed "<<endl;
	/*	getch();*/
	}
	while(isSucsed);


	return 0;
}