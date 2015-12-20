using System;
namespace First_Program
{
	class Program
	{
		public static void Main( string [] args)
		{
			int deposit = 1000;
			int P;
			Console.WriteLine("enter procent");
			string tmp=Console.ReadLine();
			int month=0;
			int res=0;
			if(Int32.TryParse(tmp,out P))
			{
				if(P>0 && P<25)
				{
					int sum=(deposit/100)*P;
					for(int i=0;i<100;i++)
					{
						i+=sum;
						month++;
					}
					res = ( month*sum)+deposit;
					Console.WriteLine("month {0}",month);
					Console.WriteLine("res {0}",res);
				}
				else
				{
					Console.WriteLine("Error 1");
				}
			}
			else
			{
					Console.WriteLine("Error 2");
			}
			Console.ReadLine();
		
		}
	}

}