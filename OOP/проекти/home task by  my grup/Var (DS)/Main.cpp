#include "Var.h"

int main()
{
	Var a, b, s;
	cout<<"Enter int = ";              //
	cin>>a;                            //
	cout<<a<<"\n";                     //
	                             
	cout<<"Enter double = ";           //
	cin>>b;                            //  перевантаження операторів "<<" і ">>"
	cout<<b<<"\n";                     //

	cout<<"Enter string = ";           //
	cin>>s;                            //
	cout<<s<<"\n\n";                   //

	int temp_int;
	double temp_double;
	char * temp_string;

	temp_int = a;                      //
	temp_double = b;                   // приведення до типів
	temp_string = s;                   //

	cout<<"Temp_int = "<< temp_int<<"\n";
	cout<<"Temp_double = "<<temp_double<<"\n";
	cout<<"Temp_string = "<<temp_string<<"\n\n";

	
	Var temp1 = a + b;                         //
	cout<<"int + double = "<<temp1<<"\n";      //

	Var temp2 = b + s;                         //
	cout<<"double + string = "<<temp2<<"\n";   //   "+"

	Var temp3 = s + b;                         //
	cout<<"string + double = "<<temp3<<"\n\n"; //


	temp1 = 0; temp2 = 0; temp3 = 0;
	temp1 = a - b;                             //
	cout<<"int - double = "<<temp1<<"\n";      //

	temp2 = b - s;                             //
	cout<<"double - string = "<<temp2<<"\n";   //   "-"

	temp3 = s - a;                             //
	cout<<"string - int = "<<temp3<<"\n\n";    //


	temp1 = 0; temp2 = 0; temp3 = 0;
	temp1 = a * b;                             //
	cout<<"int * double = "<<temp1<<"\n";      //

	temp2 = b * s;                             //   "*"
	cout<<"double * string = "<<temp2<<"\n";   //

	temp3 = s * a;                             //
	cout<<"string * int = "<<temp3<<"\n\n";    //
	 

	temp1 = 0; temp2 = 0; temp3 = 0;           //
	a *= b;                                    //
	cout<<"int *= double = "<<a<<"\n";         //

	b *= s;                                    //   "*="
	cout<<"double *= string = "<<b<<"\n";      //

	s *= a;                                    //
	cout<<"string *= int = "<<s<<"\n\n";       //


	
	temp1 = a / b;                             //
	cout<<"int / double = "<<temp1<<"\n";      //

	temp2 = b / s;                             //
	cout<<"double / string = "<<temp2<<"\n";   //  "/"

	temp3 = s / a;                             //
	cout<<"string / int = "<<temp3<<"\n\n";    //


	
	a /= b;                                    //
	cout<<"int /= double = "<<a<<"\n";         //

	b /= s;                                    //
	cout<<"double /= string = "<<b<<"\n";      //  "/="

	s /= a;                                    //
	cout<<"string /= int = "<<s<<"\n\n";       //


	
	a += b;                                    //
	cout<<"int += double = "<<a<<"\n";         //

	b += s;                                    //
	cout<<"double += string = "<<b<<"\n";      //  "+="
	s += a;                                    //
	cout<<"string += int = "<<s<<"\n\n";       //
	 
	a = 12; b = 26.8; s = "po12";  
	
	cout<<"int < double is "<<(a < b ? "true": "false")<<"\n";     
	cout<<"double < int is "<<(b < a ? "true": "false")<<"\n";
	cout<<"string < int is "<<(s < a ? "true": "false")<<"\n";
	cout<<"int < string is "<<(a < s ? "true": "false")<<"\n";
	cout<<"int == string is "<<(a == s ? "true": "false")<<"\n";
	cout<<"int != string is "<<(a != s ? "true": "false")<<"\n";

	
	return 0;
}