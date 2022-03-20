using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWN.CustomerApi.Infrastructure.Models
{
    /// <summary>
    /// Customer Model
    /// </summary>
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FullName  { get; set; }
        public int CountryId { get; set; }
        public string LastAccess { get; set; }
    }
}
