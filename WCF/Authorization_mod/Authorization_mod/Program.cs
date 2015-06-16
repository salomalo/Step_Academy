//using Newtonsoft.Json;
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
         
            //   tmp.GetInfo("toc");
        }
    }


    public class User
    {
        public int Id;
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
                if (res.FirstOrDefault() != null) // якщо користувач з таким токеном є
                {
                 //Console.WriteLine(JsonConvert.SerializeObject(res.FirstOrDefault()));
             //           return JsonConvert.SerializeObject(res.FirstOrDefault());
                }

                if (res.FirstOrDefault() == null) // якщо користувача з таким токеном НЕМАє
                {
                    //Console.WriteLine(JsonConvert.SerializeObject(res.FirstOrDefault()));
             //       return JsonConvert.SerializeObject("wrong token");
                }

            }

            return null;
        } // GetInfo


        public string Token_Generator(int length)
        {
            Random random = new Random();
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
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
                    if (res.FirstOrDefault().ExpDate >= DateTime.Today) // якщо такий користувач з логыном ы пасвордом э ы токен в нього  дыючий
                    {
                        Console.WriteLine(res.FirstOrDefault().Name);
                //        return JsonConvert.SerializeObject(res.FirstOrDefault());
                    }
                    else // якщо такий користувач з логыном ы пасвордом э але ще немаэ токена (зареэстрований але ще не авторизований, або токен недыючий)
                    {
                        res.FirstOrDefault().ExpDate = DateTime.Now;
                        res.FirstOrDefault().Token = Token_Generator(15);
                        ctx.SaveChanges();
               //         return JsonConvert.SerializeObject(res.FirstOrDefault());
                    }
                }


                var res2 = from e in ctx.Users
                          where e.LoginName == LoginName && e.Pasword != Pasword
                          select e;

                if (res2.FirstOrDefault() != null)
                {
              //      return JsonConvert.SerializeObject("password inccorect");
                }


                var res3 = from e in ctx.Users
                           where e.LoginName != LoginName && e.Pasword == Pasword
                           select e;

                if (res3.FirstOrDefault() != null)
                {
              //      return JsonConvert.SerializeObject("login inccorect");
                }





                return null;
            }



        } // Authorize

    }

}