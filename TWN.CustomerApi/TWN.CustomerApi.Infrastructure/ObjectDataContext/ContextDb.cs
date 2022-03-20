using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWN.CustomerApi.Infrastructure.Models;

namespace TWN.CustomerApi.Infrastructure.ObjectDataContext
{
    /// <summary>
    /// 
    /// </summary>
    public class ContextDb : DbContext
    {
        #region Properties
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Order> Order { get; set; }
        #endregion Properties

        #region Constructors
        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {

        }
        #endregion Constructors
    }
}
