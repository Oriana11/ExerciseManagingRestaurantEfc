using ManagingRestaurantAppEfc.Context;
using ManagingRestaurantAppEfc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingRestaurantAppEfc.Data
{
    public class DataAccess
    {
        private readonly RestaurantContext _context;

        public DataAccess(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<MenuItem> AddMenuItem(MenuItem menuItem)
        {
            await _context.AddAsync(menuItem);
            await _context.SaveChangesAsync();
            return menuItem;
        }

        public async Task<IEnumerable<MenuItem>> GetMenuItemsByCategory(string category)
        {
            var menuItems = await _context.MenuItems
                 .Where(m => m.Category == category)
                 .ToListAsync();
            return menuItems;
        }

        public async Task<Order> AddOrder(Order order)
        {

            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order object is null");
            }
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
          
        }
        public async Task<List<Order>> GetOrdersByTable(int tableNumber)
        {
            var orders = await _context.Orders
               .Where(order => order.TableNumber.Value.ToString() == tableNumber.ToString())
               .ToListAsync();

            return orders;
        }

    }
}
