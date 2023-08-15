using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemAPI.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public decimal? SellingPrice { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime ShipDate { get; set; } = DateTime.Now.AddDays(3);


    }
}
