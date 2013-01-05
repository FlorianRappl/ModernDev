using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 
 * (c) Florian Rappl, 2012-2013.
 * 
 * This work is a demonstration for training purposes and may be used freely for private purposes.
 * Usage for business training / workshops is prohibited without explicit permission from the author.
 * 
 */

namespace ModernDev
{
    static class DB
    {
        static List<Customer> customers = new List<Customer>(new[] {
            new Customer
            {
                Account = 1000.0,
                Name = "Sepp Maier",
                Age = 61,
                Premium = true
            },
            new Customer
            {
                Account = 10.0,
                Name = "Jacqueline Sackers",
                Age = 32,
                Premium = true
            },
            new Customer
            {
                Account = 10000.0,
                Name = "Josef Mustermann",
                Age = 29,
                Premium = false
            },
            new Customer
            {
                Account = 500.0,
                Name = "Hans Hinterberger",
                Age = 23,
                Premium = false
            },
            new Customer
            {
                Account = 100000000.0,
                Name = "Bill Gates",
                Age = 59,
                Premium = true
            }
        });

        public static IEnumerable<Customer> Customers
        {
            get
            {
                foreach (var customer in customers)
                    yield return customer;
            }
        }

        public static void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public static void RemoveCustomer(Customer customer)
        {
            customers.Remove(customer);
        }
    }

    class Customer
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public double Account { get; set; }

        public bool Premium { get; set; }
    }
}
