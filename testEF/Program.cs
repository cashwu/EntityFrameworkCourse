using System;
using System.ComponentModel.DataAnnotations;
using testEF.Models;
using AppContext = testEF.Models.AppContext;

namespace testEF
{
    class Program
    {
        static void Main(string[] args)
        {
            AppContext.RegisterRoutie(typeof(Test), o =>
            {
                if (o is Test test)
                {
                    if (test.Name.Contains("123"))
                    {
                       return new ValidationException("name error"); 
                    }
                }

                return null;
            });
            
            var app = new AppContext();

            var t = new Test
            {
                Name = "ABC123"
            };

            app.Test.Add(t);
                   
            app.SaveChanges();

            Console.ReadLine();
        }
    }
}