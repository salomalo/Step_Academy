
#include"Fortress.h"



void main()
{
	//cout<<"________Shooter "<<endl;
	//Shooter a("arrows_Shooter",100);
	//a.show();
	//cout<<endl;
	//a.shot();
	////a.show();


	//cout<<"_________Archer "<<endl;
	//Archer b("arrows_Archer",50);
	//b.show();
	//cout<<endl;

	//cout<<"_________Ranger "<<endl;
	//Ranger c("arrows_Ranger",25);
	//b.show();
	//cout<<endl;


	//cout<<"_________Catapult "<<endl;
	//Ranger d("stones_Catapult",5);
	//b.show();
	//cout<<endl;



	//cout<<"_________ArcherTower "<<endl;
	//ArcherTower AT("arrows",4);
	//AT.show();
	//AT.shotArcher();
	//AT.shotRanger();

	//cout<<endl;
	//AT.show();


	Fortress fort(2,50);
	
	fort.shotArcher();
	cout<<endl<<endl;
	
	fort.shotArcher();
	cout<<endl<<endl;
	
	fort.shotArcher();
	cout<<endl<<endl;
	
	fort.shotRanger();
	cout<<endl<<endl;
	
	

	cout<<"shotCatapult"<<endl;
	fort.shotCatapult();



	cout<<endl;
}