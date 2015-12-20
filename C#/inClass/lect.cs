using System;
namespace First_Program
{
	class Program
	{
		public static void Main( string [] args)
		{
		
	//1
			// int res;
			// if(Int32.TryParse(args[1],out res))
			// {
				// for(int i=0;i<res;i++)
				// {
					// Console.Write("Hello " + args[0] + "!\n");
					// Console.WriteLine();
				// }	
			// }
			// else
			// {
			// Console.WriteLine("ERROR");
			// }
			//Console.ReadLine();

	//2
			// Console.WriteLine("enter value");
			// int ires;
			// double dres;
			// string Res=Console.ReadLine();
			
			// if(Double.TryParse(Res,out dres))
			// {
				// ires = (int) dres;
				// double  RESULTAT = dres - ires;
				// Console.WriteLine("decimal"+RESULTAT);
				// Console.WriteLine("int"+ires);
			// }
			// else
			// {
				// Console.Write("Wrong value");
			// }
			// Console.ReadLine();

			
	//3 ?????? //int digit=1234;
	
	
	//	random	
			// Random r = new Random();
			// Random size = new Random();
			
			// int sizeArray=size.Next(1,7);
			// int [] arr = new int[sizeArray];
			
			
			// for(int i=0; i<sizeArray; i++)
			// {
				// arr[i]=r.Next(30);
				// Console.WriteLine(arr[i]);
			// }
	
	// matrix
			//int [,,]arr=new int[2,2,2];
			// int [,,] arr={{{1,1,4},{2,2,4},{3,3,4}},{{1,1,4},{2,2,4},{3,3,4}}};
			
			// for(int i=0; i<arr.GetLength(0); i++)
			// {
				// for(int j=0; j<arr.GetLength(1); j++)
				// {
					// for(int k=0; k<arr.GetLength(2); k++)
					// {
						// arr[i,j,k]=i+j+k;
						// Console.Write(arr[i,j,k]+" ");
					// }
					// Console.WriteLine();
				// }
				// Console.WriteLine();
			// }
			// Console.WriteLine();
	
	
	//	tree
			// int[][][]arr=new int[9][][];		
			// for( int i=0; i<9; i++)
			// {
				// arr[i]=new int[i+2][];
				
				// for(int j=0; j<arr[i].Length; j++)
				// {
					// arr[i][j] = new int[j+1];
					
					// for(int k=0; k<arr[i][j].Length; k++)
					// {
						// arr[i][j][k] = j+1;
						// Console.Write(arr[i][j][k]+" ");
					// }
					
					// Console.WriteLine();
				// }
				// Console.WriteLine();
			// }
			// Console.WriteLine();
	
	
	//		
			
			int [,]arr = new int [10,10];
			
			int k=0;
			
			for(int i=0; i<10; i++)
			{
				for(int j=0; j<10; j++)
				{
					k++;
					arr[i,j]=k;
					Console.Write(arr[i,j]+" ");
				}
				
				
				Console.WriteLine();
			}
			
			
			
			
			
			
			
			
		}
	}

}