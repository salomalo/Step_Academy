#pragma once

class Patron
{
public:
	Patron(Patron * Prev = 0) : Prev(Prev) {LastNum++; Num=LastNum;}
	~Patron() {if(!Prev) return; delete Prev;}

	int      getNum () {return Num;}
	Patron * getPrev() {return Prev;}

	void     setPrev(Patron * Prev) 
	{this->Prev = Prev;}

private:

	static int	LastNum;
	int			Num;
	Patron *	Prev;

};

