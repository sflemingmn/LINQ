using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();

            //Exercise1();
            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise5();
            //Exercise6();
            //Exercise7();
            //Exercise8();
            //Exercise9();
            //Exercise10();
            //Exercise11();
            //Exercise12();
            //Exercise13();
            //Exercise14();
            //Exercise15();
            //Exercise16();
            //Exercise17();
            //Exercise18();
            //Exercise19();
            //Exercise20();
            //Exercise21();
            //Exercise22();
            //Exercise23();
            //Exercise24();
            Exercise25();
            //Exercise26();
            //Exercise27();
            //Exercise28();
            //Exercise29();
            //Exercise30();
            //Exercise31();

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"

        /// Sample, load and print all the product objects
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// This will print a nicely formatted list of products
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category, product.UnitPrice, product.UnitsInStock);
            }
        }

        /// Sample, load and print all the customer objects and their orders
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// This will print a nicely formatted list of customers
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }

        #endregion

        /// Print all products that are out of stock.
        static void Exercise1()
        {
            List<Product> products = DataLoader.LoadProducts();
            var filtered = products.Where(p => p.UnitsInStock == 0);
            PrintProductInformation(filtered);
        }

        /// Print all products that are in stock and cost more than 3.00 per unit.
        static void Exercise2()
        {
            List<Product> products = DataLoader.LoadProducts();
            var filtered = products.Where(p => p.UnitPrice > 3 && p.UnitsInStock > 0);
            PrintProductInformation(filtered);
        }

        /// Print all customer and their order information for the Washington (WA) region.
        static void Exercise3()
        {
            List<Customer> customers = DataLoader.LoadCustomers();
            var filtered = customers.Where(c => c.Region == "WA");
            PrintCustomerInformation(filtered);
        }

        /// Create and print an anonymous type with just the ProductName
        static void Exercise4()
        {
            List<Product> products = DataLoader.LoadProducts();
            var filtered = products.Select(p => new { ProductName = p.ProductName });

            foreach (var item in filtered)
                Console.WriteLine(item.ProductName);
        }

        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        static void Exercise5()
        {
            List<Product> products = DataLoader.LoadProducts();
            var filtered = products.Select(p => new { ID = p.ProductID, Name = p.ProductName, Category = p.Category, NewPrice = p.UnitPrice * 1.25M, UnitsInStock = p.UnitsInStock });

            string line = "{0,-5} {1,-35} {2,-20} {3,12:c} {4,9}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("=====================================================================================");

            foreach (var item in filtered)
                Console.WriteLine(line, item.ID, item.Name, item.Category, item.NewPrice, item.UnitsInStock);
        }

        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        static void Exercise6()
        {
            List<Product> products = DataLoader.LoadProducts();
            var filtered = products.Select(p => new { Name = p.ProductName.ToUpper(), Category = p.Category.ToUpper() });

            string line = "{0,-35} {1,-15}";
            Console.WriteLine(line, "PRODUCT NAME", "CATEGORY");
            Console.WriteLine("==========================================================");

            foreach (var item in filtered)
                Console.WriteLine(line, item.Name, item.Category);
        }

        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// Hint: use a ternary expression
        static void Exercise7()
        {
            List<Product> products = DataLoader.LoadProducts();
            var filtered = products.Select(p => new { ID = p.ProductID, Name = p.ProductName, Category = p.Category, UnitPrice = p.UnitPrice, UnitsInStock = p.UnitsInStock, ReOrder = p.UnitsInStock < 3 ? true : false });

            string line = "{0,-5} {1,-35} {2,-20} {3,12:c} {4,9} {5,9}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "ReOrder");
            Console.WriteLine("===============================================================================================");

            foreach (var item in filtered)
                Console.WriteLine(line, item.ID, item.Name, item.Category, item.UnitPrice, item.UnitsInStock, item.ReOrder);
        }

        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        static void Exercise8()
        {
            List<Product> products = DataLoader.LoadProducts();
            var filtered = products.Select(p => new { ID = p.ProductID, Name = p.ProductName, Category = p.Category, UnitPrice = p.UnitPrice, UnitsInStock = p.UnitsInStock, StockValue = (p.UnitPrice + p.UnitsInStock) });

            string line = "{0,-5} {1,-35} {2,-20} {3,12:c} {4,9} {5,15:c}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "Stock Value");
            Console.WriteLine("=====================================================================================================");

            foreach (var item in filtered)
                Console.WriteLine(line, item.ID, item.Name, item.Category, item.UnitPrice, item.UnitsInStock, item.StockValue);
        }

        /// Print only the even numbers in NumbersA
        static void Exercise9()
        {
            var evens = from numbers in DataLoader.NumbersA
                        where numbers % 2 == 0
                        select numbers;

            foreach (var numbers in evens)
                Console.WriteLine(numbers);
        }

        /// Print only customers that have an order who's total is less than $500
        static void Exercise10()
        {
            List<Customer> customers = DataLoader.LoadCustomers();
            var filtered = customers.Where(c => c.Orders.Any(ordervalue => ordervalue.Total < 500));
            PrintCustomerInformation(filtered);
        }

        /// Print only the first 3 odd numbers from NumbersC
        static void Exercise11()
        {
            var threeodds = from numbers in DataLoader.NumbersC
                            where numbers % 2 != 0
                            select numbers;

            foreach (var numbers in threeodds.Take(3))
                Console.WriteLine(numbers);
        }

        /// Print the numbers from NumbersB except the first 3
        static void Exercise12()
        {
            var skip3 = DataLoader.NumbersB.Skip(3);

            foreach (var numbers in skip3)
                Console.WriteLine(numbers);
        }

        /// Print the Company Name and most recent order for each customer in Washington
        static void Exercise13()
        {
            List<Customer> customers = DataLoader.LoadCustomers();
            var filtered = customers.Where(c => c.Region == "WA");

            foreach (var customer in filtered)
            {
                foreach (var order in customer.Orders.OrderByDescending(p => p.OrderDate).Take(1))
                {
                    Console.WriteLine(customer.CompanyName);
                    Console.WriteLine("Last Order ID: {0} \nLast Order Date: {1:MM-dd-yyyy} \nLast Order Total: {2,7:c}", order.OrderID, order.OrderDate, order.Total);
                    Console.WriteLine();
                }
            }
        }

        /// Print all the numbers in NumbersC until a number is >= 6
        static void Exercise14()
        {
            var filtered = DataLoader.NumbersC.TakeWhile(numbers => numbers != 6);

            foreach (var numbers in filtered)
                Console.WriteLine(numbers);
        }

        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        static void Exercise15()
        {
            var filtered = DataLoader.NumbersC.SkipWhile(numbers => numbers % 3 != 0).Skip(1);

            foreach (var numbers in filtered)
                Console.WriteLine(numbers);
        }

        /// Print the products alphabetically by name
        static void Exercise16()
        {
            List<Product> products = DataLoader.LoadProducts();
            var filtered = DataLoader.LoadProducts().OrderBy(p => p.ProductName);
            PrintProductInformation(filtered);
        }

        /// Print the products in descending order by units in stock
        static void Exercise17()
        {
            List<Product> products = DataLoader.LoadProducts();
            var filtered = products.OrderByDescending(p => p.UnitsInStock);
            PrintProductInformation(filtered);
        }

        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        static void Exercise18()
        {
            foreach (var distinct in DataLoader.LoadProducts().
                                     Select(p => p.Category).
                                     Distinct())
                Console.WriteLine(distinct);
        }

        /// Print NumbersB in reverse order
        static void Exercise19()
        {
            var filtered = DataLoader.NumbersB.Reverse();

            foreach (var item in filtered)
                Console.WriteLine(item);
        }

        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        static void Exercise20()
        {
            var filtered = DataLoader.LoadProducts().GroupBy(p => p.Category);

            foreach (var group in filtered)
            {
                string line = "{0,-35} ";
                Console.WriteLine(group.Key);
                Console.WriteLine("================================");

                foreach (var product in group)
                    Console.WriteLine(line, product.ProductName);
                Console.WriteLine();
            }
        }

        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        static void Exercise21()
        {
            var customers = DataLoader.LoadCustomers();

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine("===============================");
                foreach (var orderGroup in customer.Orders.GroupBy(o => o.OrderDate.Year))
                {
                    Console.WriteLine(orderGroup.Key);
                    foreach (var order in orderGroup)
                        Console.WriteLine("\t{0} - {1,6:c}", order.OrderDate.Month, order.Total);
                }
                Console.WriteLine();
            }
        }

        /// Print the unique list of product categories
        static void Exercise22()
        {
            var categories = DataLoader.LoadProducts().Select(c => c.Category).Distinct();

            foreach (var unique in categories)
                Console.WriteLine(unique);
        }

        /// Write code to check to see if Product 789 exists
        static void Exercise23()
        {
            var products = DataLoader.LoadProducts().Exists(p => p.ProductID == 789);
                Console.WriteLine(products);
        }

        /// Print a list of categories that have at least one product out of stock
        static void Exercise24()
        {
            var products = DataLoader.LoadProducts();

            var result = from p in products
                         where p.UnitsInStock < 1
                         select p;

            foreach (var nostock in result)
                Console.WriteLine(nostock.Category);
        }

        /// Print a list of categories that have no products out of stock
        static void Exercise25()
        {
            var products = DataLoader.LoadProducts();

            var result = from p in products
                         group p by p.Category
                         into g where g.All(p => p.UnitsInStock != 0)
                         select g.Key;

            foreach (var nostock in result)
                Console.WriteLine(nostock);
        }

        /// Count the number of odd numbers in NumbersA
        static void Exercise26()
        {
            var filtered = DataLoader.NumbersA.Count(p => p % 2 != 0);
            Console.WriteLine(filtered);
        }

        /// Create and print an anonymous type containing CustomerId and the count of their orders
        static void Exercise27()
        {
            var customers = DataLoader.LoadCustomers();
            var orders = from customer in customers
                         select new
                         {
                             customer.CustomerID,
                             orderCount = customer.Orders.Count()
                         };

            foreach (var count in orders)
                Console.WriteLine($"{count.CustomerID} - {count.orderCount}");
        }

        /// Print a distinct list of product categories and the count of the products they contain
        static void Exercise28()
        {
            var categories = DataLoader.LoadProducts().GroupBy(p => p.Category);

            foreach (var group in categories)
                Console.WriteLine("{0,-15} - {1,3}", group.Key, group.Count());
        }

        /// Print a distinct list of product categories and the total units in stock
        static void Exercise29()
        {
            var categories = DataLoader.LoadProducts().GroupBy(p => p.Category);

            foreach (var group in categories)
            {
                int count = 0;
                foreach (var product in group)
                {
                    count += product.UnitsInStock;
                }
                Console.WriteLine("{0,-15} - {1,3}",group.Key,count);
            }
        }

        /// Print a distinct list of product categories and the lowest priced product in that category
        static void Exercise30()
        {
            var categories = DataLoader.LoadProducts().GroupBy(p => p.Category);

            foreach (var group in categories)
            {
                foreach (var product in group.OrderBy(p => p.UnitPrice).Take(1))
                    Console.WriteLine("{0,-15} - {1,6:c}",group.Key,product.UnitPrice);
            }
        }

        /// Print the top 3 categories by the average unit price of their products
        static void Exercise31()
        {
            var categories = DataLoader.LoadProducts().GroupBy(c => c.Category).Select(g => new {Category = g.Key,AverageUnitPrice = g.Average(p => p.UnitPrice)}).OrderByDescending(o => o.AverageUnitPrice).Take(3);

            foreach (var group in categories)
                Console.WriteLine("{0,-15} - {1,6:c}",group.Category,group.AverageUnitPrice);
        }
    }
}
