using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
        public int ClientCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<OrderItem> Items { get; set; }
        public DateTime Date { get; set; }
    }

}
