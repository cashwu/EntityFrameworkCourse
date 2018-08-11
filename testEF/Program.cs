using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using testEF.Models;

namespace testEF
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new MyDbContext();

            var t = new Test
            {
                Id = 5,
                Name = "ABC123",
                Age = 1123,
                TT = 123,
                QQ = 123
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