using ManagingRestaurantAppEfc.Context;
using ManagingRestaurantAppEfc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingRestaurantAppEfc.Data
{
    public class PrepDb
    {
        public static void PrepPopulation(RestaurantContext context)
        {
            SeedData(context);
        }

        private static void SeedData(RestaurantContext context)
        {
            if (!context.Orders.Any())
            {
                Console.WriteLine("Adding data - seeding...");
                context.MenuItems.AddRange(
                    new MenuItem()
                    {
                        Name = "Pizza",
                        Category = "Main Course",
                        Price = 12.50M,
                        Orders = new List<Order>()
                        {
                            new Order()
                            {
                                TableNumber = 1,
                                TimeStamp = DateTime.Now,
                                TotalAmount = 12.50M
                            }
                            
                        }
                    },
                    new MenuItem()
                    {
                        Name = "Burger",
                        Category = "Main Course",
                        Price = 8.99M,
                        Orders = new List<Order>()
                        {
                            new Order()
                            {
                                TableNumber = 2,
                                TimeStamp = DateTime.Now,
                                TotalAmount = 8.99M
                            }
                        }
                    },
                     new MenuItem()
                     {
                         Name = "Salad",
                         Category = "Appetizers",
                         Price = 6.99M,
                         Orders = new List<Order>()
                        {
                            new Order()
                            {
                                TableNumber = 3,
                                TimeStamp = DateTime.Now,
                                TotalAmount = 6.99M
                            }
                        }
                     },
                    new MenuItem()
                    {
                        Name = "Salad",
                        Category = "Appetizers",
                        Price = 6.99M,
                        Orders = new List<Order>()
                        {
                            new Order()
                            {
                                TableNumber = 4,
                                TimeStamp = DateTime.Now,
                                TotalAmount = 6.99M
                            }
                        }
                    });

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Already have data - not seeding");
            }
        }
    }
}
