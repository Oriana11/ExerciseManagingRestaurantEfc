// See https://aka.ms/new-console-template for more information
using ManagingRestaurantAppEfc.Context;
using ManagingRestaurantAppEfc.Data;
using ManagingRestaurantAppEfc.Models;

// put the argum,ent in RerstaurntContext
using (var dbContext = new RestaurantContext())
{
    // Create an instance of DataAccess and pass the dbContext to its constructor
    var dataAccess = new DataAccess(dbContext);
    PrepDb.PrepPopulation(dbContext);

    // Create a menu item
    var menuItem1 = new MenuItem
    {
        Name = "Pizza",
        Category = "Main Course",
        Price = 12.99m,

    };
    var menuItem2 = new MenuItem
    {
        Name = "Pasta",
        Category = "Main Course",
        Price = 9.99m,

    };
    var menuItem3 = new MenuItem
    {
        Name = "Salad",
        Category = "Appetizer",
        Price = 5.99m,

    };
    var menuItem4 = new MenuItem
    {
        Name = "Burger",
        Category = "Main Course",
        Price = 8.99m,

    };

    var createAMenuItem1 = dataAccess.AddMenuItem(menuItem1);
    var createAMenuItem2 = dataAccess.AddMenuItem(menuItem2);
    var createAMenuItem3 = dataAccess.AddMenuItem(menuItem3);
    var createAMenuItem4 = dataAccess.AddMenuItem(menuItem4);
    Console.WriteLine($"Menu item created: {menuItem1}");
    Console.WriteLine($"Menu item created: {menuItem2}");
    Console.WriteLine($"Menu item created: {menuItem3}");
    Console.WriteLine($"Menu item created: {menuItem4}");

    // Get menu items by category
    var menuItemsByCategory = await dataAccess.GetMenuItemsByCategory("Main Course");

    foreach (var menuItem in menuItemsByCategory)
    {
        Console.WriteLine($"Menu item: {menuItem.Name}");
    }

    // Add an order
    var order = new Order
    {
        TableNumber = 1,
        TimeStamp = DateTime.Now,
        TotalAmount = 12.99m,
        MenuItem = menuItem1
    };
    Console.WriteLine($"Menu item: {order}");

    var order4 = new Order
    {
        TableNumber = 4,
        TimeStamp = DateTime.Now,
        TotalAmount = 8.99m,
        MenuItem = menuItem4
    };
    Console.WriteLine($"Menu item: {order4}");

    // Get Orders By table
    var ordersByTable = await dataAccess.GetOrdersByTable(4);

    if (ordersByTable.Any())
    {
        foreach (var orderinTable in ordersByTable)
        {
            Console.WriteLine(orderinTable.ToString());
        }
    }
    else
    {
        Console.WriteLine("No orders found for the specified table number.");
    }
}



