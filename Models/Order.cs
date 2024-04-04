using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingRestaurantAppEfc.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int? TableNumber { get; set; }
        public DateTime TimeStamp { get; set; }
        public decimal TotalAmount { get; set; }
        public MenuItem? MenuItem { get; set; }
        

        public override string ToString()
        {
            return $"Id: {Id}, TableNumber: {TableNumber}, TimeStamp: {TimeStamp}, TotalAmount: {TotalAmount}";
        }
    }
}


