using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Form
{
    public class Member
    {
        public string Name{ get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
      
    }

    public class StaticLab
    {
        public int InstanceCount;  // 實體屬性的變數
        public static int StaticCount;  // 靜態屬性的變數, 全域變數
    }

    public enum Role: long
    {
        Admin = 10 ,
        User = 20,
        User01
    }

    public struct Product
    {
        //public string Name;
        //public decimal Price;

        public Product(string ProductName , string ProductPrice)
        {
            Name = ProductName;
            Price = decimal.Parse(  ProductPrice);
        }

        public Product(string ProductName, decimal ProductPrice)
        {
            Name = ProductName;
            Price = ProductPrice;
        }


        public string Name { get; set; }
        public decimal Price { get; set; }

        //public string Dev = "default";
    }

    public class Employee
    {
        public string Name;

        public int Age;
    }





}
