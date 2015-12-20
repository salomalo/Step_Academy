#include"avtomat.h"

Avtomat::Avtomat() : countofPatr(0), pTop(nullptr) {} 

Avtomat::~Avtomat()
{
	patron * pDel=pTop;
	while(pDel)
	{
		patron * pPrev=pDel->pPrev;
		delete pDel;
		pDel=pPrev;
	}
}

bool Avtomat::pushInAvt (int value)
{
	patron*pNewPatron=new patron;
	if(!pNewPatron)
	{
		/*cout<<"Magazine is full"<<endl;*/
		return false;
	}

	pNewPatron->pPrev=pTop;  //  помилка була через те що вказывник не вказував на попередный патрон
	pNewPatron->value=value;

	pTop = pNewPatron;
	countofPatr++;
	return true;

}

bool Avtomat::popFromAvt (int & value)
{
	if( countofPatr == 0 )
	{
		/*cout<<"Magazine is empty ..."<<endl;*/
		return false;
	}

	countofPatr--;

	value = pTop->value;
	patron * pDel = pTop;
	pTop=pDel->pPrev;
	
	pDel=nullptr;
	
	//pTop->pPrev=nullptr

	delete 	pDel;
	return true;

}