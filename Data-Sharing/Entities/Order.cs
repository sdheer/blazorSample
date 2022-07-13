using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Sharing.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedTime { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();
        public int StoreID { get; set; }

        public decimal GetTotalPrice() => Items.Sum(p => p.Price);

        public string GetFormattedTotalPrice() => GetTotalPrice().ToString("0.00");
    }
}
