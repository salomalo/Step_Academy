using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_Union_Intersect_Except
{
    class Program
    {
        class Employee
        {
            public int Id { set; get; }
            public string Name { set; get; }
        }

        static void Main(string[] args)
        {
            int[] nums1 = { 1, 2, 3, 4, 5 };
            int[] nums2 = { 1, 3, 6, 7, 8 };

            // var res = nums1.Union(nums2);
            // var res = nums1.Concat(nums2);
            // var res = nums1.Intersect(nums2);
            var res = nums1.Except(nums2);

            foreach (var e in res)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("-----------------------------------------");

            List<Employee> list1 = new List<Employee> { 
                new Employee { Id = 101, Name = "mike" },
                new Employee { Id = 102, Name = "todd" },
                new Employee { Id = 103, Name = "john" }
            };

            List<Employee> list2 = new List<Employee> { 
                new Employee { Id = 101, Name = "mike" },
                new Employee { Id = 104, Name = "sveta" },
            };

            // var res2 = list1.Union(list2);
            var res2 = list1.Select(x => new { x.Id, x.Name })
                .Concat(list2.Select(x => new { x.Id, x.Name}));

            foreach (var e in res2)
            {
                Console.WriteLine(e.Id + " " + e.Name);
            }
            Console.WriteLine("-----------------------------------------");


            // IEnumerable<int> res3 = Enumerable.Range(1, 10).Where(x => x % 2 == 0);
            // var res3 = Enumerable.Repeat("ГИ", 10);

            // var res3 = GetData() ?? Enumerable.Empty<int>();
            var res3 = GetData() == null ? Enumerable.Empty<int>() : GetData();

            foreach (var e in res3)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("-----------------------------------------");


            // 
            // string[] c1 = { "USA", "Ukraine", "UK" };
            // string[] c2 = { "USA", "Ukraine", "uk" };
            // 
            // Console.WriteLine(c1.SequenceEqual(c2, StringComparer.OrdinalIgnoreCase));

            string[] c1 = { "USA", "Ukraine", "UK" };
            string[] c2 = { "Ukraine", "USA", "uk" };

            Console.WriteLine(
                c1.OrderBy(c => c).SequenceEqual(
                c2.OrderBy(c => c), 
                StringComparer.OrdinalIgnoreCase
                ));


            int[] n = { 1, 2, 3, 4, 5, 100 };

            // var res4 = n.All(x => x < 10);
            var res4 = n.Any(x => x > 100);

            Console.WriteLine(res4);
        }

        public static IEnumerable<int> GetData()
        {
            // return new List<int> { 1, 2, 3 };
            return null;
        }
    }
}
