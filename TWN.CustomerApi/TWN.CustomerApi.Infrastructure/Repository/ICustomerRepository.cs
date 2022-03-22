using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWN.CustomerApi.Infrastructure.Models;

namespace TWN.CustomerApi.Infrastructure.Repository
{
    public interface ICustomerRepository
    {

        public void AddCustomer(Customer customer);

    }
}
