//������� ���� XString, ���� ����� �����. ���� ������� ������ ������� ������������:
//
//����������� �� ������������, ���� �������� �������� ����� �������� 80 �������;
//�����������, ���� ������� ����� �� �������� ���� ������, ��������� � ����� ���������;
//����������� ����.
//��� ����, ����� ���� ������� ������ ���� �������������� �������� ��� ������ � XString-���:
//�������� *: ������� ��������� ����� �����, ���� ����������� ������ �������� ���� �����, 
//����� �� ����� �������. ���������, ����������� �������� ����� "Microsoft" �� "Windows" ���� ����� "ioso".


//�������� /: ������� ��������� ����� �����, ���� ����������� ������ ������ ������� ������� �����, ���� ���� � �������. ���������, ����������� ������ ����� "Microsoft" �� "Windows" ���� ����� "Mcrft".
//�������� +, �� �������� ������ ��� ����� (������������ �����). ���������, ����������� ��������� ���� ����� "Microsoft" �� "Windows" ���� ����� "MicrosoftWindows".
//�������� *=, /= �� +=, �� ���� �� ������������� ��������. 
//��������� ���������: <, >, <=, >=, ==, != ��� ��������� ��������� ���� �����
//��������� ! (NOT), �� ��������� �������� ������ �����. ���������, ����������� ������� ����� "Windows" ���� ����� "swodniW".
//���������� �� ���� char*.
#include "XString.h"
#include "Var.h"



int main()
{
	//XString str( "My first XString object!  I`m exalted!!!!" );
	//cout <<"Look at this:   '" <<str <<"'\n\n\n";		// ��� ������� �������������� �������� << ( ����� 27)

	//cout <<"Enter new value for XString : ";
	//cin  >>str;		// ������ �������������� �������� >>
	//cout <<"Look at this:   '" <<str <<"'\n\n\n";		// ��� ������� �������������� �������� << ( ����� 27)

	//str[2] = '#';
	//str[12] = '#';
	//str[22] = '#';
	//cout <<"Look at this:   '" <<str <<"'\n\n\n";		// ��� ������� �������������� �������� << ( ����� 27)


	//str( 5, 5, '$' );
	//cout <<"Look at this:   '" <<str <<"'\n\n\n";		// ��� ������� �������������� �������� << ( ����� 27)

	//int s=2;
	//XString abr("Look at me");
	//XString bora("Lppok qz");
	//
	//(abr*bora).Show();
	//cout<<endl;
	//(abr/bora).Show();
	//cout<<endl;
	//(abr+bora).Show();
	//cout<<endl;
	//cout<<"Nezminulos"<<endl;
	//abr.Show();
	//cout<<endl;
	//cout<<boolalpha <<(abr>bora)<<endl;
	//cout<<boolalpha <<(abr<=bora)<<endl;                                         //-���� ������??????? �������
	//
	//(!abr).Show();
	//cout<<endl;
	//cout<<bora.toChar();
	//char *result=(char*)bora;
	
	Var a(1);
	Var b(1.5);
	Var c("a32");
	Var d("345");
	Var resI(0);
	Var resD(0.0);
	Var resX("0");

	cout<<"a+b="<<(a+b)<<endl;
	resI=a+b;
	cout<<a<<"+"<<b<<" = " <<resI<<endl;
	resX=c+d;
	cout<<c<<"+"<<d<<" = " <<resX<<endl;
    resD=b-a;
	cout<<b<<"-"<<a<<" = " <<resD<<endl;
    resX=c*d;
	cout<<c<<"*"<<d<<" = " <<resX<<endl;
	resX=c/d;
	cout<<c<<"/"<<d<<" = " <<resX<<endl;
	
	cout<<a<<">"<<b<<boolalpha<<"\t" <<(a>b)<<endl;
	cout<<a<<"<"<<b<<boolalpha<<"\t" <<(a<b)<<endl;
	cout<<a<<"=="<<b<<boolalpha<<"\t" <<(a==b)<<endl;
	cout<<a<<"!="<<b<<boolalpha<<"\t" <<(a!=b)<<endl;
	cout<<c<<">"<<d<<boolalpha<<"\t" <<(c==d)<<endl;
	cout<<c<<"=="<<d<<boolalpha<<"\t" <<(c==d)<<endl;
	cout<<c<<"!="<<d<<boolalpha<<"\t" <<(c!=d)<<endl;
	//cout<<b.toInt();

	return 0;

}



