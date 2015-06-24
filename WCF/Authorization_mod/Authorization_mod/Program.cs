using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
//,Hash nvarchar (512) 
//,Sult nvarchar (512) 
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
            ServiceHost sh = new ServiceHost(typeof(GetUserInfo), new Uri("http://localhost/GetUserInfo/"));
            sh.Open();
            Console.WriteLine("enter");
            Console.ReadLine();

          // GetUserInfo tmp = new GetUserInfo();
          // tmp.Authorize("romaska", "1234test");     
    
           // tmp.GetInfo("toc");
        }
    }

    public class User
    {
        public string Name;      
        public string LoginName;
        
        public string Surname;
        public string Pasword;
        public string Token;

        public string Hash;
        public string Sult;

        public DateTime ExpDate;
    }

    [ServiceContract]
    public interface IGetUserInfo
    {
        [OperationContract]
        string GetInfo(string token);
        [OperationContract]
        string Authorize(string LoginName, string Pasword );
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
                 //   Sult = res.FirstOrDefault().Sult;
                 //Console.WriteLine(JsonConvert.SerializeObject(res.FirstOrDefault()));
                       return JsonConvert.SerializeObject(res.FirstOrDefault());
                }

                if (res.FirstOrDefault() == null) // якщо користувача з таким токеном НЕМАє
                {
                    //Console.WriteLine(JsonConvert.SerializeObject(res.FirstOrDefault()));
                   return JsonConvert.SerializeObject("wrong token");
                }
            }
            return null;
        } // GetInfo

        public string Token_Generator(int length) //make sult
        {
            Random random = new Random();
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        } //Token_Generator


                public string MakeHash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }


                    public string Hash_Sult(string input)
        {
            string has_sul = MakeHash(input) + Token_Generator(10);
            return has_sul;     
        }


        public User Registration(string LoginName, string Pasword,string name,string surname)
        {
            User tmp = new User();
            using (var ctx = new Author_ModEntities1())
            {
                var res = from e in ctx.Users
                          where e.LoginName == LoginName && e.Pasword == Pasword
                          select e;

                if (res.FirstOrDefault() == null)
                {
                    res.FirstOrDefault().LoginName = LoginName;
                    res.FirstOrDefault().Pasword = Pasword;
                    res.FirstOrDefault().Name = name;
                    res.FirstOrDefault().Surname = surname;

                   tmp.LoginName = res.FirstOrDefault().LoginName;
                   tmp.Pasword = res.FirstOrDefault().Pasword;
                   tmp.Name = res.FirstOrDefault().Name;
                   tmp.Name =res.FirstOrDefault().Surname;
                  
                    

                    return tmp;
                }
            
            }

            return null;
        }



        public string Authorize(string LoginName, string Pasword, string name, string surname)
        {
            User tmp = new User();
         
            using (var ctx = new Author_ModEntities1())
            {
                var res = from e in ctx.Users
                          where e.LoginName == LoginName && e.Pasword == Pasword
                          select e;

                if (res.FirstOrDefault() != null)
                {
                    if (res.FirstOrDefault().ExpDate >= DateTime.Now) // якщо такий користувач з логыном ы пасвордом э ы токен в нього  дыючий
                    {
                        tmp.Name = res.FirstOrDefault().Name;
                        tmp.LoginName = res.FirstOrDefault().LoginName;
                    



                        // Console.WriteLine(tmp.Name);
                        return JsonConvert.SerializeObject(tmp);

                    }
                    else if (res.FirstOrDefault().ExpDate < DateTime.Now || res.FirstOrDefault().Token == null)
                    {
                        res.FirstOrDefault().ExpDate = DateTime.Now;
                        res.FirstOrDefault().Token = Token_Generator(15);
                        ctx.SaveChanges();
                        //return JsonConvert.SerializeObject(res.FirstOrDefault());

                        tmp.Name = res.FirstOrDefault().Name;
                        tmp.LoginName = res.FirstOrDefault().LoginName;
                        tmp.Token = res.FirstOrDefault().Token;
                      //  Console.WriteLine(tmp.Name);

                        return JsonConvert.SerializeObject(tmp);
                    }
                }

                if(res.FirstOrDefault().LoginName != LoginName && res.FirstOrDefault().Pasword != Pasword)
                {
                  tmp = Registration(LoginName, Pasword, name, surname);
                  return  JsonConvert.SerializeObject(tmp);
                }


                return "login error";
            }



        } // Authorize

    }

}