using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


// database for module
//create database Author_Mod
//go

//use Author_Mod

//create table [Users]
//(
//Id int identity primary key
//,Name nvarchar (512) not NULL
//,Surname nvarchar (512) not NULL
//,LoginName nvarchar (512) not NULL
//,Pasword nvarchar (512) not NULL
//,Token nvarchar (512) 
//,ExpDate DATETIME
//)

//INSERT INTO [Users] (Name, Surname, LoginName, Pasword)
//VALUES
//('Roman','Velihiy','romaska','1234test')
//,('Lesya','Gook','les','les123')

//select * from [Users]


namespace Authorization_mod
{
    class Program
    {
        static void Main(string[] args)
        {
            //ServiceHost sh = new ServiceHost(typeof(GetUserInfo), new Uri("http://localhost/GetUserInfo/"));
            //sh.Open();
            //Console.WriteLine("enter");
            //Console.ReadLine();

            GetUserInfo tmp = new GetUserInfo();
            tmp.Authorize("romaska", "1234test");
            tmp.GetInfo("toc");
        }
    }


    public class User
    {
        public int Name;
        public string Name;
        public string Surname;
        public string LoginName;
        public string Pasword;
        public string Token;
        public DateTime ExpDate;

    } // сереалізувати юзера в клас



    [ServiceContract]
    public interface IGetUserInfo
    {
        [OperationContract]
        string GetInfo(string token);
        [OperationContract]
        string Authorize(string LoginName, string Pasword);
    }


    public class GetUserInfo : IGetUserInfo
    {
        public string GetInfo(string token)
        {
            using (var ctx = new Author_ModEntities1())
            {
                var res = from e in ctx.Users
                          where e.Token == token
                          select e;
                if (res.FirstOrDefault() != null)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(res.FirstOrDefault()));
                        return JsonConvert.SerializeObject(res.FirstOrDefault());
                }

            }

            return null;
        } // GetInfo


        public void Token_Generator()
        {

        } // token creator


        public string Authorize(string LoginName, string Pasword)
        {
            using (var ctx = new Author_ModEntities1())
            {
                var res = from e in ctx.Users
                          where e.LoginName == LoginName && e.Pasword == Pasword
                          select e;

                if (res.FirstOrDefault() != null)
                {
                    if (res.FirstOrDefault().ExpDate >= DateTime.Today)
                    {
                        return JsonConvert.SerializeObject(res.FirstOrDefault());
                    }
                    else
                    {
                        res.FirstOrDefault().ExpDate = DateTime.Now;
                        res.FirstOrDefault().Token = "toc"; // Token_Generator()
                        ctx.SaveChanges();
                        return JsonConvert.SerializeObject(res.FirstOrDefault());
                    }
                }
                return null;
            }



        } // Authorize

    }

}