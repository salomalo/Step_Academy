#include "Var.h"

Var Var:: operator= (const int right)
{
	this->intNumber = right;
	return *this;
}



Var Var:: operator= (const double right)
{
	this->doubleNumber = right;
	return *this;
}



Var Var:: operator= (const char * right)
{
	this->strNumber.setStr(right);
	return *this;
}



ostream & operator << (ostream & left, Var & right)
{
	if(right.doubleNumber == 0)
		if(right.intNumber == 0)
		{
			left << right.strNumber;
		}	
		else
			left << right.intNumber;
	
	else left << right.doubleNumber;

	return left;
}


istream & operator >> (istream & left, Var & right)
{
	char buff[255];
	left.getline(buff,255);
	
	int count = 0, num_i=0;
	double num_d=0;

	for(int i=0; i<strlen(buff); i++)
	{
		if(buff[i] == '.') count +=301;	
		else if(buff[i] < '0' || buff[i] > '9') count++;
	}

	switch(count)
	{

	case 0: 
		cout<<"int ";
		num_i = atoi(buff);
		right.intNumber = num_i;
		break;

	case 301:
		cout<<"double ";
		num_d = atof(buff);
		right.doubleNumber = num_d;
		break;

	default:
		cout<<"string ";
		right.strNumber.setStr(buff);
		break;

	}
	
	return left;
}


Var:: operator int ()
{
	int res;
	
	if(this->doubleNumber == 0)
		if(this->intNumber == 0)
			res = atoi(this->strNumber);
			
		else
			res = this->intNumber;
	
	else res = this->doubleNumber;

	return res;
}



Var:: operator double ()
{
	double res;

	if(this->doubleNumber == 0)
		if(this->intNumber == 0)
			res = atof(this->strNumber);
			
		else
			res = this->intNumber;
	
	else res = this->doubleNumber;

	return res;
}



Var:: operator char * ()
{
	char * res, temp[80];

	if(this->doubleNumber == 0)
		if(this->intNumber == 0)
		{
			strcpy(temp,this->strNumber);
			
			res = new char [strlen(temp)+1];
			
			for(int i=0; i<strlen(temp); i++)
			res[i] = temp[i];
			
			res[strlen(temp)] = '\0';

		}
			
		else
		{
			itoa(this->intNumber,temp,10);

			res = new char [strlen(temp)+1];
			
			for(int i=0; i<strlen(temp); i++)
			res[i] = temp[i];
			
			res[strlen(temp)] = '\0';
		}
	
	else
	{
		sprintf(temp, "%.2f", this->doubleNumber);

		res = new char [strlen(temp)+1];
			
		for(int i=0; i<strlen(temp); i++)
		res[i] = temp[i];
		
		res[strlen(temp)] = '\0';
	}

	return res;
}



Var Var:: operator+ (Var & right)
{
	Var res, temp;
	char * ryad = new char [40];

	if(this->doubleNumber == 0)
		if(this->intNumber == 0)
		{
			ryad = right;
			res = this->strNumber + ryad;
		}	
		else
		{
			temp.intNumber = right;
			res = this->intNumber + temp.intNumber;
		}
	
	else 
	{
		temp.doubleNumber = right;
		res = this->doubleNumber + temp.doubleNumber;
	}

	return res;
}



Var Var:: operator- (Var & right)
{
	Var res, temp;
	char * ryad = new char [40];

	if(this->doubleNumber == 0)
		if(this->intNumber == 0)
		{
			ryad = right;
			res = this->strNumber / ryad;
		}	
		else
		{
			temp.intNumber = right;
			res = this->intNumber - temp.intNumber;
		}
	
	else 
	{
		temp.doubleNumber = right;
		res = this->doubleNumber - temp.doubleNumber;
	}

	return res;
}



Var Var:: operator* (Var & right)
{
	Var res, temp;
	char * ryad = new char [40];

	if(this->doubleNumber == 0)
		if(this->intNumber == 0)
		{
			ryad = right;
			res = this->strNumber * ryad;
			if(strlen(res)==0) res.strNumber.setStr("\"error\"");
		}	
		else
		{
			temp.intNumber = right;
			if(temp.intNumber == 0) res.strNumber.setStr("0");
			else res = this->intNumber * temp.intNumber;
			
		}
	
	else 
	{
		temp.doubleNumber = right;
		if(temp.doubleNumber==0) res.strNumber.setStr("0");
		else res = this->doubleNumber * temp.doubleNumber;
	}

	return res;
}



Var Var:: operator/ (Var & right)
{
	Var res, temp;
	char * ryad = new char [40];

	if(this->doubleNumber == 0)
		if(this->intNumber == 0)
		{
			ryad = right;
			res = this->strNumber / ryad;
		}	
		else
		{
			temp.intNumber = right;
			if(temp.intNumber == 0) res.strNumber.setStr("error");
			else res = this->intNumber / temp.intNumber;
			
		}
	
	else 
	{
		temp.doubleNumber = right;
		if(temp.doubleNumber==0) res.strNumber.setStr("error");
		else res = this->doubleNumber / temp.doubleNumber;
	}

	return res;
}



Var Var:: operator+= (Var & right)
{
	Var temp;
	char * ryad = new char [40];

	if(this->doubleNumber == 0)
		if(this->intNumber == 0)
		{
			ryad = right;
		    this->strNumber += ryad;
		}	
		else
		{
			temp.intNumber = right;
			this->intNumber += temp.intNumber;
		}
	
	else 
	{
		temp.doubleNumber = right;
		this->doubleNumber += temp.doubleNumber;
	}

	return *this;
}


Var Var:: operator-= (Var & right)
{
	Var temp;
	char * ryad = new char [40];

	if(this->doubleNumber == 0)
		if(this->intNumber == 0)
		{
			ryad = right;
			this->strNumber /= ryad;
		}	
		else
		{
			temp.intNumber = right;
			this->intNumber -= temp.intNumber;
		}
	
	else 
	{
		temp.doubleNumber = right;
		this->doubleNumber -= temp.doubleNumber;
	}

	return *this;
}



Var Var:: operator*= (Var & right)
{
	Var temp;
	char * ryad = new char [40];

	if(this->doubleNumber == 0)
		if(this->intNumber == 0)
		{
			ryad = right;
			this->strNumber *= ryad;
			if(strlen(this->strNumber)==0) this->strNumber.setStr("\"error\"");
		}	
		else
		{
			temp.intNumber = right;
			if(temp.intNumber == 0) {this->intNumber = 0; this->strNumber.setStr("0");}
			else 
			this->intNumber *= temp.intNumber;
			
		}
	
	else 
	{
		temp.doubleNumber = right;
		if(temp.doubleNumber==0) {this->doubleNumber = 0; this->strNumber.setStr("0");}
		else 
			this->doubleNumber *= temp.doubleNumber;
	}

	return *this;
}



Var Var:: operator/= (Var & right)
{
	Var temp;
	char * ryad = new char [40];

	if(this->doubleNumber == 0)
		if(this->intNumber == 0)
		{
			ryad = right;
			this->strNumber /= ryad;
		}	
		else
		{
			temp.intNumber = right;
			if(temp.intNumber == 0) {this->intNumber = 0; this->strNumber.setStr("error");}
			else 
				this->intNumber /= temp.intNumber;
		}
	
	else 
	{
		temp.doubleNumber = right;
		if(temp.doubleNumber==0) {this->doubleNumber = 0; this->strNumber.setStr("error");}
		else 
			this->doubleNumber /= temp.doubleNumber;
	}

	return *this;
}



bool Var:: operator< (Var & right)
{
	Var temp;
	char * ryad = new char [40];

	if(this->doubleNumber == 0)
		if(this->intNumber == 0)
		{
			ryad = right;
			temp.strNumber = ryad;
			if(this->strNumber < temp.strNumber) return true;
			return false;
		}	
		else
		{
			temp.intNumber = right;
			if(this->intNumber < temp.intNumber) return true;
			return false;
		}
	
	else 
	{
		temp.doubleNumber = right;
		if(this->doubleNumber < temp.doubleNumber) return true;
		return false;
	}
		
}



bool Var:: operator> (Var & right)
{
	Var temp;
	char * ryad = new char [40];

	if(this->doubleNumber == 0)
		if(this->intNumber == 0)
		{
			ryad = right;
			temp.strNumber = ryad;
			if(this->strNumber > temp.strNumber) return true;
			return false;
		}	
		else
		{
			temp.intNumber = right;
			if(this->intNumber > temp.intNumber) return true;
			return false;
		}
	
	else 
	{
		temp.doubleNumber = right;
		if(this->doubleNumber > temp.doubleNumber) return true;
		return false;
	}
		
}


bool Var:: operator<= (Var & right)
{
	Var temp;
	char * ryad = new char [40];

	if(this->doubleNumber == 0)
		if(this->intNumber == 0)
		{
			ryad = right;
			temp.strNumber = ryad;
			if(this->strNumber <= temp.strNumber) return true;
			return false;
		}	
		else
		{
			temp.intNumber = right;
			if(this->intNumber <= temp.intNumber) return true;
			return false;
		}
	
	else 
	{
		temp.doubleNumber = right;
		if(this->doubleNumber <= temp.doubleNumber) return true;
		return false;
	}
		
}


bool Var:: operator>= (Var & right)
{
	Var temp;
	char * ryad = new char [40];

	if(this->doubleNumber == 0)
		if(this->intNumber == 0)
		{
			ryad = right;
			temp.strNumber = ryad;
			if(this->strNumber >= temp.strNumber) return true;
			return false;
		}	
		else
		{
			temp.intNumber = right;
			if(this->intNumber >= temp.intNumber) return true;
			return false;
		}
	
	else 
	{
		temp.doubleNumber = right;
		if(this->doubleNumber >= temp.doubleNumber) return true;
		return false;
	}
		
}



bool Var:: operator== (Var & right)
{
	Var temp;
	char * ryad = new char [40];

	if(this->doubleNumber == 0)
		if(this->intNumber == 0)
		{
			ryad = right;
			temp.strNumber = ryad;
			if(this->strNumber == temp.strNumber) return true;
			return false;
		}	
		else
		{
			temp.intNumber = right;
			if(this->intNumber == temp.intNumber) return true;
			return false;
		}
	
	else 
	{
		temp.doubleNumber = right;
		if(this->doubleNumber == temp.doubleNumber) return true;
		return false;
	}
		
}



bool Var:: operator!= (Var & right)
{
	Var temp;
	char * ryad = new char [40];

	if(this->doubleNumber == 0)
		if(this->intNumber == 0)
		{
			ryad = right;
			temp.strNumber = ryad;
			if(this->strNumber != temp.strNumber) return true;
			return false;
		}	
		else
		{
			temp.intNumber = right;
			if(this->intNumber != temp.intNumber) return true;
			return false;
		}
	
	else 
	{
		temp.doubleNumber = right;
		if(this->doubleNumber != temp.doubleNumber) return true;
		return false;
	}
		
}