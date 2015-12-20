#include"Vector.h"

void main()
{
	const int size = 4;
	double mas [size] = {2.2, 3.3, 4.4, 5.5};
	
	Vector a (size, mas);
	
	cout <<"\n\nA:" <<a <<"\n\n";

	const int size1 = 3;
	double mas1 [size1]={2.2, 7.7, 3.3};
	Vector b (size1, mas1);
	double m = 4.4;

	Vector Res;
	cout<<"   Vector +=  Vector  "<<endl;
	a+b;
	a+=b;
	cout<<"   Vector +=  mas  "<<endl;
	a+m;
	a+=m;
	cout<<"   Vector *=  Vector  "<<endl;
	a*b;
	a*=b;
	cout<<"   Vector *=  mas  "<<endl;
	a*m;
	a*=m;
	cout<<"   Vector -=  m   "<<endl;
	cout <<"\n\nA:" <<a <<"\n\n";

	a-m;
	cout <<"\n\nA:" <<a <<"\n\n";
	a-=m;
	cout <<"\n\nA:" <<a <<"\n\n";

	cout<<"          ><      "<<endl;
	cout <<"a <  b is " <<( a <  b ? "true" : "false" ) <<"\n";
	cout <<"a >  b is " <<( a >  b ? "true" : "false" ) <<"\n";
	cout<<"            ++      --      "<<endl;
	
	cout<<a;
	a++;
	cout<<"a++ = "<<a<<endl;
	++a;
	cout<<"++a = "<<a<<endl;
	a--;
	cout<<"a-- = "<<a<<endl;
	--a;
	cout<<"--a = "<<a<<endl;
	cout<<"          =     "<<endl;
	Res=a;
	cout<<Res;	
	cout<<"         Res[1]    "<<endl;
	cout<<"Res[1] = " <<Res[1]<<endl;
	cout<<Res;

    
}