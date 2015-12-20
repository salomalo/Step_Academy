using System;
namespace First_Program
{
	class Program
	{
		public static void Main( string [] args)
		{
			 string Res;
			 int dres;
			 int [] arr = new int[3];
			
			// Console.WriteLine("enter A= "); 
			// int A = Console.ReadLine();
			
			// Console.WriteLine("enter B= "); 
			// int B = Console.ReadLine();
			
			// Console.WriteLine("enter C= "); 
			// int C = Console.ReadLine();
			
			// Console.WriteLine("A "+A+"B "+B+"C "+C); 
			// Console.ReadLine();
			
			for(int i=0; i<3; i++)
			{
				Console.WriteLine("enter value = ");
				Res=Console.ReadLine();

				if(Int32.TryParse(Res,out dres))
					{
						arr[i] = dres;
					}
				else
					{
						Console.Write("Wrong value");
					}
				Console.ReadLine();
			}
			
			// for(int i=0; i<3; i++)
			// {
			// Console.Write(arr[i]+" ");
			// }
			 
			int A = arr[0];
			int B = arr[1];
			int C = arr[2];
			
			
			int S=A*B;
			
			if( C>A || C>B )
			{
				Console.Write("ERROR - C > A");
			}
			
			else
			{
			int CinA = A/C;
			
			int CinB = B/C;
			
			int count = CinA*CinB;
				Console.WriteLine("count - {0} ",count);
			
			int Sblank = S -(C*C*count);
				Console.WriteLine("Sblank - {0} ",Sblank);
		
			}
			
			
			//3
			//int digit=1234;
				
		}
	}

}