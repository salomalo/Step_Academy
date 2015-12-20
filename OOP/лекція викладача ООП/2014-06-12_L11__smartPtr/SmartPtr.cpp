#include "SmartPtr.h"



SmartPtr::SmartPtr( XString * pXString )
{
	pStr = pXString;
	pCnt = new int(1);
	cout <<"\n   Constructor SmartPtr for '" <<(*pXString) <<"' at " <<(int)pXString <<"   (*pCnt) = " <<(*pCnt) <<endl;
}


SmartPtr::SmartPtr( SmartPtr & oSrc )
{
	pStr = oSrc.pStr;
	pCnt = oSrc.pCnt;
	(*pCnt)++;			// так ми зб≥льшимо «Ќј„≈ЌЌя по вказ≥внику pCnt
	// pCnt++;			// а так ми зб≥льшимо —јћ ¬ ј«≤¬Ќ» , а не значенн€, на €к в≥н вказуЇ

	cout <<"\n   Copy constructor SmartPtr for '" <<(*pStr) <<"' at " <<(int)pStr <<"   (*pCnt) = " <<(*pCnt) <<endl;
}



SmartPtr::~SmartPtr()
{
	(*pCnt)--;		// к≥льк≥сть вказ≥вник≥в зменшуЇтьс€ на 1

	cout <<"\n   Destructor SmartPtr for '" <<(*pStr) <<"' at " <<(int)pStr <<"   (*pCnt) = " <<(*pCnt) <<endl;

	if( *pCnt )
		return;		// €кщо лишивс€ хоч один -- н≥чого не робимо

	// зв≥льн€Їмо пам'€ть
	delete pStr;
	delete pCnt;

	cout <<"     Memory cleaned\n";

}




SmartPtr & SmartPtr::operator = ( SmartPtr & oRight )
{
	// у л≥вому об'Їкт≥ (this) уже щось могло бути !
	(*(this->pCnt) )--;			// зменшуЇмо к≥льк≥сть вказ≥вник≥в

	cout <<"\n   operator = SmartPtr for '" <<(*pStr) <<"' at " <<(int)pStr <<"   (*pCnt) = " <<(*pCnt) <<endl;

	if( !( *(this->pCnt) ) )	// €кщо це був останн≥й вказ≥вник
	{
		// очищаЇмо пам'€ть
		delete pStr;
		delete pCnt;
		cout <<"     Memory cleaned\n";

	}

	// тепер це буде ще один екземпл€р правого "розумного вказ≥вника"
	pStr = oRight.pStr;
	pCnt = oRight.pCnt;
	(*pCnt)++;			// так ми зб≥льшимо «Ќј„≈ЌЌя по вказ≥внику pCnt
	// pCnt++;			// а так ми зб≥льшимо —јћ ¬ ј«≤¬Ќ» , а не значенн€, на €к в≥н вказуЇ

	cout <<"\n   operator = SmartPtr for '" <<(*pStr) <<"' at " <<(int)pStr <<"   (*pCnt) = " <<(*pCnt) <<endl;

	return *this;
}


