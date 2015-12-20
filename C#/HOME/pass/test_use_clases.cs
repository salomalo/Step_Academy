using System;
namespace First_Program
{
    class Program
    {
        public static void Main(string[] args)
        {
            //string[,] arr ={{"first language from C family","1. C#","2. C","3. C++","2"},
            //{"What is MISL","1. Microsoft intermidiate Language","2. Microsoft Internet Soft","3. Microsoft.CSharp","1"},
            //{"Advantages of .NET Framework","1. It is from  Microsoft","2. Managed Code","3. No benefits","2"},
            //{"Disadvantage of .NET Framework","1. Only for windows OS","2. It is from  Microsoft","3. Slowly execution aplications","3"},
            //{"CLR - is?","1. Common Intermediate Language","2. Color Library of Runtime","3. Class Library Random","1"},
            //{"Common type system","1. references","2. value","3. references and value","3"},
            //{"For input in to console use:","1. cout","2. Console.WriteLine()","3. Console.ReadLine() ","2"},
            //{"For read from console","1. Console.ReadLine()","2. Console.WriteLine()","3. cin","1"},

            //{"How to compile the file","1. csc /t:exe /out:E\test.exe E\test.cs","2. csc /t:exe /out:E\test.cs E\test.exe","3. csc /t:exe /E\test.exe E\test.cs","1"},
            //{"what version is inccorect","1. int[]arr","2. int arr=new int[2]","3 arr={7,9,8}","3"},};
            //int res = 0;
            //Console.WriteLine("enter right answer ");
            //for (int i = 0; i < arr.GetLength(0); i++)
            //{
            //    for (int j = 0; j < arr.GetLength(1) - 1; j++)
            //    {
            //        Console.WriteLine(arr[i, j] + " ");
            //    }
            //    string ans = Console.ReadLine();
            //    if (ans == arr[i, 4])
            //    {
            //        res++;
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine("Your re is " + res);
            //Console.WriteLine();


            Console.WriteLine("enter right answer ");

            Test q1 = new Test("first language from C family", "2");
            q1.VariantAdd("C#");
            q1.VariantAdd("C");
            q1.VariantAdd("C++");
            // q1.Print();
            Test q2 = new Test("What is MISL", "1");
            q2.VariantAdd("Microsoft intermidiate Language");
            q2.VariantAdd("Microsoft Internet Soft");
            q2.VariantAdd("Microsoft.CSharp");

            Test q3 = new Test("Advantages of .NET Framework", "2");
            q3.VariantAdd("It is from  Microsoft");
            q3.VariantAdd("Managed Code");
            q3.VariantAdd("No benefits");

            Test q4 = new Test("Disadvantage of .NET Framework", "3");
            q4.VariantAdd("Only for windows OS");
            q4.VariantAdd("It is from  Microsoft");
            q4.VariantAdd("Slowly execution aplications");

            Test q5 = new Test("CLR - is?", "1");
            q5.VariantAdd("Common Intermediate Language");
            q5.VariantAdd("Color Library of Runtime");
            q5.VariantAdd("Class Library Random");

            Test q6 = new Test("Common type system", "3");
            q6.VariantAdd("references");
            q6.VariantAdd("value");
            q6.VariantAdd("references and value");

            Test q7 = new Test("For input in to console use:", "2");
            q7.VariantAdd("cout");
            q7.VariantAdd("Console.WriteLine()");
            q7.VariantAdd("Console.ReadLine()");

            Test q8 = new Test("For read from console", "1");
            q8.VariantAdd("Console.ReadLine()");
            q8.VariantAdd("Console.WriteLine()");
            q8.VariantAdd("cin");

            Test q9 = new Test("How to compile the file", "1");
            q9.VariantAdd("csc /t:exe /out:E\test.exe E\test.cs");
            q9.VariantAdd("csc /t:exe /out:E\test.cs E\test.exe");
            q9.VariantAdd("csc /t:exe /E\test.exe E\test.cs");

            Test q10 = new Test("what version is inccorect", "3");
            q10.VariantAdd("int[]arr");
            q10.VariantAdd("int arr=new int[2]");
            q10.VariantAdd("arr={7,9,8}");


            // string ans = Console.ReadLine();


            FullTest te = new FullTest();
            te.QuestAdd(q1);
            te.QuestAdd(q2);
            te.QuestAdd(q3);
            te.QuestAdd(q4);
            te.QuestAdd(q5);
            te.QuestAdd(q6);
            te.QuestAdd(q7);
            te.QuestAdd(q8);
            te.QuestAdd(q9);
            te.QuestAdd(q10);

            te.Start_Test();

        }

        public class FullTest
        {
            protected Test[] test;
            protected int res;

            public int Res
            {
                get { return res; }
                set { res = value; }
            }

            public Test[] Test
            {
                get { return test; }
                set { test = value; }
            }


            public void QuestAdd(Test quest)
            {

                Array.Resize(ref test, test.Length + 1);
                test[test.Length - 1] = quest;
            }


            public void Start_Test()
            {
                int count = 0;
                for (int i = 0; i < test.Length; i++)
                {
                    count++;
                    Console.WriteLine(count);
                    this.test[i].Print();
                    string ans = Console.ReadLine();
                    if (ans == test[i].Right)
                    {
                        res++;
                    }
                    Console.WriteLine(" ");
                }

                Console.WriteLine(" your res is {0}", Res);

            }



            public FullTest()
            {
                res = 0;
                test = new Test[0];
            }

        }



        public class Test
        {
            protected String question;
            protected String[] variants;
            protected String right;

            public String Question
            {
                get { return question; }
                set { question = value; }
            }

            public String[] Variants
            {
                get { return variants; }
                set { variants = value; }
            }

            public String Right
            {
                get { return right; }
                set { right = value; }
            }

            public Test(String question, String right)
            {
                this.variants = new String[0];
                this.question = question;
                this.right = right;
            }

            public void VariantAdd(String quest)
            {
                Array.Resize(ref variants, variants.Length + 1);
                variants[variants.Length - 1] = quest;
            }

            public void Print()
            {
                Console.WriteLine(Question);
                int count = 0;
                for (int i = 0; i < variants.Length; i++)
                {
                    count++;
                    Console.WriteLine("{0}. {1}", count, variants[i]);
                }
            }

        }

    }
}