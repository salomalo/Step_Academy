#include"Matrix.h"

void main()
{
	Matrix M1(5,5);
	Matrix M2(4,4);
	Matrix M3;
	
	cout<<"     =      "<<endl;
	cout<<"   M1  before = "<<endl;
	M1.Show();
	M1=M2;
	cout<<endl;
	cout<<"   M1  after = "<<endl;
	M1.Show();

	cout<<"////////////////////////////////////////////////////////////////////////////////"<<endl;
	cout<<"     +      "<<endl;
	cout<<" M1 "<<endl;
	M1.Show();
	cout<<" M2 "<<endl;
	M2.Show();
	M3=M2+M1;
	cout<<" RES "<<endl;
	M3.Show();

	cout<<"////////////////////////////////////////////////////////////////////////////////"<<endl;
	cout<<"     *      "<<endl;
	cout<<" M1 "<<endl;
	M1.Show();
	cout<<" M2 "<<endl;
	M2.Show();
	Matrix M4;
	M4=M1*M2;
	cout<<" RES "<<endl;
	M4.Show();

	cout<<"////////////////////////////////////////////////////////////////////////////////"<<endl;
	cout<<"     !      "<<endl;
	Matrix M5;
	M5=!M2;
	cout<<"   M2    "<<endl;
	M2.Show();
	cout<<" RES "<<endl;
	M5.Show();
	

	cout<<"////////////////////////////////////////////////////////////////////////////////"<<endl;
	cout<<"     -      "<<endl;
	Matrix M6;
	cout<<" M1 = "<<endl;
	M1.Show();
	cout<<" M2 = "<<endl;
	M2.Show();
	M6=M1-M2;
	cout<<" RES "<<endl;
	M6.Show();


	cout<<"////////////////////////////////////////////////////////////////////////////////"<<endl;
	cout<<"     ()    "<<endl;
	M1.Show();




	char YN='N';
	int x,y;
	cout<<"Enter index of element of matrix"<<endl;
	cout<<"X= ";
	cin>>x;
	cout<<"Y= ";
	cin>>y;
	
	cout<<"Element with indexes "<<x<<','<<y<<"="<<M1(x,y)<<endl;
	cout<<"enter new value : ";
	cin>>M1(x,y);
	M1.Show();
	
}