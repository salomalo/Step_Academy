#ifndef pERSON_H
	#define pERSON_H

	#include <iostream>

	using namespace std;

	#include "Date.h"

	class Person 
	{
	public:

		Person(	  const char * const firstName	
				, const char * const surName
				, int age 
				, short year
				, short month
				, short day
				);

		~Person();


		void setFirstName( const char * const firstName );	// const береже нерви !!!!
		void setSurName( const char * const surName );	// const береже нерви !!!!

		int  getAge(){ return age; }	//компілятор може зробити її інлайновою

		void show() const;		// const береже нерви !!!


	private:
		char * firstName;
		char * surName;
		int    age;
		Date   birth;

	};//class Person 

#endif