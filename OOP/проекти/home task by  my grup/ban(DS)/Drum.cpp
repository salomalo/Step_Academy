#include"Drum.h"


Drum::Drum():size(5),idxTail(4)
{
	arr = new char[size];
	for(int i = 0; i<size ;i++)
	{
		arr[i] = i+1;
	}
}
		
Drum::~Drum()
{
	delete [] arr;
}
void Drum::rotate()
{
	dequeueRing();
	
	cout<<"\n";
	cout<<"\t   ______        ______        ______\n";
	cout<<"\t  |      |      |      |      |      |\n";
	cout<<"\t _|      |______|      |______|      |_\n";
	cout<<"\t|_|  "<<arr[0]<<"   |______|  "<<' '<<"   |______|  "<<' '<<"   |_|\n";
	cout<<"\t  |      |      |      |      |      |\n";
	cout<<"\t  |______|      |______|      |______|\n";
	
	
};
void Drum::rotate(char a)
{
	dequeueRing();
	
	cout<<"\n";
	cout<<"\t   ______        ______        ______\n";
	cout<<"\t  |      |      |      |      |      |\n";
	cout<<"\t _|      |______|      |______|      |_\n";
	cout<<"\t|_|  "<<a<<"   |______|  "<<arr[0]<<"   |______|  "<<' '<<"   |_|\n";
	cout<<"\t  |      |      |      |      |      |\n";
	cout<<"\t  |______|      |______|      |______|\n";
	
	
};
void Drum::rotate(char a,char b)
{
	dequeueRing();
	
	cout<<"\n";
	cout<<"\t   ______        ______        ______\n";
	cout<<"\t  |      |      |      |      |      |\n";
	cout<<"\t _|      |______|      |______|      |_\n";
	cout<<"\t|_|  "<<a<<"   |______|  "<<b<<"   |______|  "<<arr[0]<<"   |_|\n";
	cout<<"\t  |      |      |      |      |      |\n";
	cout<<"\t  |______|      |______|      |______|\n";
	
	
};


void Drum::enqueue()
{
	
	idxTail++;
	arr[ idxTail ] = value;
	
}



void Drum::dequeue()
{
	value = arr[0];
	for( int i = 0 ; i < idxTail ; i++ )
		arr[i] = arr[ i+1 ];
	idxTail--;
	
}


void Drum::dequeueRing()
{
	dequeue();
	// якщо черга була не пустою -- то треба поставити це значення у хвіст
	enqueue();

}
char Drum::getChar()
{
	return arr[0];
}