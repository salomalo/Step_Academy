#include "Odometr.h"
#include"FuelGauge.h"

void main()
{
	//cout<<"enter max capacity of your fuel - ";
	//int capacity;
	//cin>>capacity;
	//cout<<"enter how many fuel in your gauge now - ";
	//int Value;
	//cin>>Value;
	//FuelGauge a(capacity,Value);


	FuelGauge a(70,50);
	cout<<"enter how many km to ride - ";
	int km;
	cin>>km;

	cout<<"enter how many km yor car can ride using 1 litr of fuel - ";
	int wayToLiter;
	cin>>wayToLiter;
	Odometr od(km,a.getCurValue(),wayToLiter);

	cout<<"you have ride - "<<od.getcurKMage()<<" km"<<endl;
	cout<<"you burn - "<<od.burnLit()<<" l of fuel"<<endl;

	a.burn(od.burnLit());//спалене пальне
	od.wayLeft(a);//скыльки можна проъхати ще км до закынчення пального



}