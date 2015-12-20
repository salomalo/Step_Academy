using System;
namespace First_Program
{
	class Program
	{
		public static void Main( string [] args)
		{
			string [,] arr={{"first language from C family","1. C#","2. C","3. C++","2"},
			{"What is MISL","1. Microsoft intermidiate Language","2. Microsoft Internet Soft","3. Microsoft.CSharp","1"},
			{"Advantages of .NET Framework","1. It is from  Microsoft","2. Managed Code","3. No benefits","2"},
			{"Disadvantage of .NET Framework","1. Only for windows OS","2. It is from  Microsoft","3. Slowly execution aplications","3"},
			{"CLR - is?","1. Common Intermediate Language","2. Color Library of Runtime","3. Class Library Random","1"},
			{"Common type system","1. references","2. value","3. references and value","3"},
			{"For input in to console use:","1. cout","2. Console.WriteLine()","3. Console.ReadLine() ","2"},
			{"For read from console","1. Console.ReadLine()","2. Console.WriteLine()","3. cin","1"},
			{"How to compile the file","1. csc /t:exe /out:E\test.exe E\test.cs","2. csc /t:exe /out:E\test.cs E\test.exe","3. csc /t:exe /E\test.exe E\test.cs","1"},
			{"what version is inccorect","1. int[]arr","2. int arr=new int[2]","3 arr={7,9,8}","3"},};
			int res=0;
			Console.WriteLine("enter right answer ");			
			for(int i=0; i<arr.GetLength(0); i++)
			{
				for(int j=0; j<arr.GetLength(1)-1; j++)
				{
					Console.WriteLine(arr[i,j]+ " ");
				}
				string ans = Console.ReadLine();
				if(ans==arr[i,4])
				{
					res++;
				}
				Console.WriteLine();
			}		
			Console.WriteLine("Your re is "+res);
			Console.WriteLine();
		}
	}

}