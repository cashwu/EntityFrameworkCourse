using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using testEF.Models;
using AppContext = testEF.Models.AppContext;

namespace testEF
{
    class Program
    {
        static void Main(string[] args)
        {
            AppContext.RegisterRoutie(typeof(Test), CustomerValidation.Instance.Check);

            var app = new AppContext();

            var t = new Test
            {
                Id = 3,
                Name = "ABC123"
            };

            app.Test.Add(t);

            app.SaveChanges();

            Console.ReadLine();
        }
    }

    public class CustomerValidation
    {
        private static CustomerValidation _instance;

        public static CustomerValidation Instance
        {
            get
            {
                if (_instance == null)
                {
                   _instance = new CustomerValidation(); 
                }

                return _instance;
            }
        }
        
        public ValidationException Check(object obj)
        {
            if (obj is Test test)
            {
                if (test.Name.Contains("123"))
                {
                    return new ValidationException("name error");
                }
            }

            return null;
        }
    }
}