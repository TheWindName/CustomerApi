using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWN.CustomerApi.Infrastructure.Models
{
    /// <summary>
    /// Order Model
    /// </summary>
    public class Order
    {

        public int OrderId { get; set; }

        public string OrderName { get; set; }

        public int CustomerId { get; set; }
    }
}
