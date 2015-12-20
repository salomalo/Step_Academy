using System;

namespace First_Program
{
	class Program
	{
		/*public static void Main()
		{
			Console.Write("Hello, world!\n");
			Console.WriteLine();
			Console.ReadLine();
		}*/
	// csc /t:exe /out:D:\FileName.exe D:\first.cs
		public static void Main(string [] args)
		{
		//	int index = Convert.ToInt32(args[0]);// клас для приведення типів
			int result; 
			if(Int32.TryParse(args[0], out result)) // out - передаємо не проініціалізовану зміннуref
			{
				for(int i = 0; i < result; i++)
				{
					Console.Write("Hello, world!\n");
					Console.WriteLine();
				}
					
			}			
			else 
			{
				Console.WriteLine("Not correct data");
			}
			
		/*	for(int i = 0; i < index; i++)
			{
				Console.Write("Hello, world!\n");
				Console.WriteLine();
			}*/
			Console.ReadLine();
			
			int @int = 5; //Так можна, але так не робіть
			string a = "D:\\Hello.cs";			
			string a = @"D:\Hello.cs"; // без екранації
			string variable;            // ТАК НЕ МОЖНА
		//	Console.WriteLine(variable); // ТАК НЕ МОЖНА
			
			variable = Console.ReadLine();
			
			var i = 1;
			var f = 1.0F;
			var d = 1.0;
			
			decimal money = 1.0M;
						
			foreach (var str in args)   //readonly
			{
				Console.WriteLine(str); 
			}
			
			
			
		}
	}

}