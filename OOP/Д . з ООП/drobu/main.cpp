#include"Fraction.h"



void main()
{
Fraction drib1(2,2),drib2(4,9), res;
int a=3;

//cout<<"Fraction and Fraction"<<endl;
//cout<<"   +     "<<endl;
//res=drib1+drib2;
//res.normalize();
//res.show();
//
//cout<<"   -     "<<endl;
//res=drib1-drib2;
//res.normalize();
//res.show();
//
//cout<<"   *     "<<endl;
//res=drib1*drib2;
//res.normalize();
//res.show();
//
//cout<<"   /     "<<endl;
//res=drib1/drib2;
//res.normalize();
//res.show();

//cout<<"Fraction and Int"<<endl;
//cout<<"   +     "<<endl;
//res=drib1+a;
//res.normalize();
//res.show();
//
//cout<<"   -     "<<endl;
//res=drib1-a;
//res.normalize();
//res.show();
//
//cout<<"   *     "<<endl;
//res=drib1*a;
//res.normalize();
//res.show();
//
//cout<<"   /     "<<endl;
//res=drib1/a;
//res.normalize();
//res.show();
//
//cout<<"Int and  Fraction"<<endl;
//cout<<"   +     "<<endl;
//res=a+drib1;
//res.normalize();
//res.show();
//
//cout<<"   -     "<<endl;
//res=a-drib1;
//res.normalize();
//res.show();
//
//cout<<"   *     "<<endl;
//res=a*drib1;
//res.normalize();
//res.show();
//
//cout<<"   /     "<<endl;
//res=a/drib1;
//res.normalize();
//res.show();


//cout<<"   drib1++    "<<endl;
//res=drib1++;
//res.normalize();
//res.show();

//cout<<"   ++drib1    "<<endl;
//res=++drib1;
//res.normalize();
//res.show();

//cout<<"   drib1--    "<<endl;
//res=drib1--;
//res.normalize();
//res.show();
//
//cout<<"   --drib1    "<<endl;
//res=--drib1;
//res.normalize();
//res.show();


cout<<"   Fraction = Fraction "<<endl;
drib1=drib2;
drib1.normalize();
drib1.show();

cout<<"   Fraction = int "<<endl;
drib1=a;
drib1.normalize();
drib1.show();

cout<<"   Fraction = int "<<endl;
a=drib1;
drib1.normalize();
drib1.show();


}