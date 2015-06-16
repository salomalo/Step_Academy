using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            My r = new My();
            r.intA = 5;
            r.str = "test";
            r.arr = new int[2]{1,2};

            //{"intA":5,"str":"test","arr":[1,2],"test":null}
                      
            Console.WriteLine(JsonConvert.SerializeObject(r));
            
            var obj = JsonConvert.DeserializeObject<RootObject>(JsonConvert.SerializeObject(r));
          
            Console.WriteLine(obj.intA);
        }
    }

	
    class My
    {
        public int intA { set; get; }
       // [JsonProperty(PropertyName = "test")]
        [JsonProperty("test")]
        public string str { set; get; }
        public int[] arr { set; get; }
        public My test { set; get; }
        public int pr { set; get; }
    }


    public class RootObject
    {
        public int intA { get; set; }
        [JsonProperty("test")]
        public string str { get; set; }
        public List<int> arr { get; set; }
        public object test { get; set; }
    }








}
