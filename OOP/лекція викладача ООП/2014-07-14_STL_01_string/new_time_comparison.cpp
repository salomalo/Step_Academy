#include <iostream>
#include <ctime>
using namespace std;






void main()
{
	const int REPEATS = 2222;
	char * ptr1 = 0;
	char * ptr2 = 0;
	char * ptr0 = 0;

	clock_t start1 = clock();
	for( int i = REPEATS ; i >= 0 ; i-- )
	{
		//ptr0 = ptr1;
		ptr1 = new char [10000];
		//delete [] ptr0;
	}
	clock_t end1 = clock();

	clock_t start2 = clock();
	for( int i = REPEATS ; i >= 0 ; i-- )
	{
		//ptr0 = ptr2;
		ptr2 = new char [100000];
		//delete [] ptr0;
	}
	clock_t end2 = clock();

	cout <<"start1=" <<start1 <<endl
		 <<"  end1=" <<end1   <<endl
		 <<"differ=" <<end1-start1 <<endl
		 <<"averge=" <<(double)(end1-start1) / REPEATS <<endl
		 <<endl;

	cout <<"start2=" <<start2 <<endl
		 <<"  end2=" <<end2   <<endl
		 <<"differ=" <<end2-start2 <<endl
		 <<"averge=" <<(double)(end2-start2) / REPEATS <<endl
		 <<endl;

}

