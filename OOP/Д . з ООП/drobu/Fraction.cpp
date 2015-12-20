#include"Fraction.h"

Fraction::Fraction():up(0),down(0){}	
Fraction::Fraction(int up,int down):up(up),down(down){}

void Fraction::show()
{
	printf("%d / %d\n",up,down);
}

void Fraction::normalize()
{
	if(down==0)
	{
		cout<<"down can't be 0 !!!"<<endl;
		exit(ERROR);
	}

	else
	{
		if(down % up == 0) // 2/4
		{
			Fraction tmp;
			tmp.up=up/up;
			tmp.down=down/up;
			up=tmp.up;
			down=tmp.down;
		}
		else
		{
			if(up % down == 0) // 4/2
			{
				Fraction tmp;
				tmp.up=up/down;
				tmp.down=down/down;
				up=tmp.up;
				down=tmp.down;
			}
		}











	}


}

Fraction Fraction::operator + (Fraction &drib2)
{
	Fraction tmp;
	if(down!=drib2.down)
	{
		up=up*drib2.down;
		drib2.up=drib2.up*down;
		tmp.down=down*drib2.down;
		tmp.up=up+drib2.up;
		return tmp;
	}
	else
	{
		tmp.up=up+drib2.up;
		tmp.down=down;
		return tmp;
	}
}

Fraction Fraction::operator - (Fraction &drib2)
{
	Fraction tmp;
	if(down!=drib2.down)
	{
		up=up*drib2.down;
		drib2.up=drib2.up*down;
		tmp.down=down*drib2.down;
		tmp.up=up-drib2.up;
		return tmp;
	}
	else
	{
		tmp.up=up-drib2.up;
		tmp.down=down;
		return tmp;
	}
}

Fraction Fraction::operator * (Fraction &drib2)
{
	Fraction tmp;
	tmp.up=up*drib2.up;
	tmp.down=down*drib2.down;
	return tmp;
}

Fraction Fraction::operator / (Fraction &drib2)
{
	Fraction tmp;
	tmp.up=up*drib2.down;
	tmp.down=down*drib2.up;
	return tmp;
}

///////////////////////////////////////////////////////////////////////////////

Fraction Fraction::operator + (int &a)
{
	Fraction tmp;
	tmp.up=up+(a*down);
	tmp.down=down;
	return tmp;
}

Fraction Fraction::operator - (int &a)
{
	Fraction tmp;
	tmp.up=up-(a*down);
	tmp.down=down;
	return tmp;
}

Fraction Fraction::operator * (int &a)
{
	Fraction tmp;
	tmp.up=up*a;
	tmp.down=down;
	return tmp;
}

Fraction Fraction::operator / (int &a)
{
	Fraction tmp;
	tmp.up=up;
	tmp.down=down*a;
	return tmp;
}

///////////////////////////////////////////////////////////////////////////////

Fraction operator + (int &a, Fraction drib2)
{
	Fraction tmp;
	tmp.up=drib2.up+(a*drib2.down);
	tmp.down=drib2.down;
	return tmp;
}

Fraction operator - (int &a,Fraction &drib2)
{
	Fraction tmp;
	tmp.up=(a*drib2.down)-drib2.down;
	tmp.down=drib2.down;
	return tmp;
}

Fraction operator * (int &a,Fraction &drib2)
{
	Fraction tmp;
	tmp.up=drib2.up*a;
	tmp.down=drib2.down;
	return tmp;
}

Fraction operator / (int &a,Fraction &drib2)
{
	Fraction tmp;
	tmp.up=drib2.up;
	tmp.down=drib2.down*a;
	return tmp;
}

///////////////////////////////////////////////////////////////////////////////

Fraction Fraction::operator++()
{
	up++;
	return *this;
}

Fraction Fraction::operator++(int ignore)
{
	up++;
	return *this;
}

Fraction Fraction::operator--()
{
	up--;
	return *this;
}

Fraction Fraction::operator--(int ignore)
{
	up--;
	return *this;
}


	void  Fraction::operator = (Fraction &drib2)
	{
	up=drib2.up;
	down=drib2.down;
	}

	
	void  Fraction::operator = (int &a)
	{
	up=a;
	down=1;
	}

//	operator =
//
//встановлює значення лівого int відповідно до
//правого Fraction (округлює до ближчого цілого -- ceil() )