using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TWN.CustomerApi.Entities.Customer;

namespace TWN.CustomerApi.Service.Controllers
{
    /// <summary>
    /// Customer Controller
    /// </summary>
    [ApiVersionNeutral]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Principal Constructor
        /// </summary>
        public CustomerController()
        {

        }

        /// <summary>
        /// Get Method which returns all Customer Entities in DataBase.
        /// </summary>
        /// <returns>Action Result with CustomerEntity list</returns>
        [HttpGet]
        public ActionResult<List<CustomerEntity>> GetAll()
        {
            var result = new List<CustomerEntity>();

            return result;
        }

        /// <summary>
        /// Get Method which returns a concrete Customer Entities in DataBase.
        /// </summary>
        /// <returns>Action Result with CustomerEntity</returns>
        [HttpGet("{customerId}")]
        public CustomerEntity GetById(int CustomerId)
        {
            var result = new CustomerEntity();

            return result;
        }

        /// <summary>
        /// Post Method which insert a new Customer into DataBase.
        /// </summary>
        /// <param name="customerEntity">Customer Entity Parameter</param>
        /// <returns>Customer Entity stored in DataBase</returns>
        [HttpPost]
        public ActionResult<CustomerEntity> Create(CustomerEntity customerEntity)
        {
            var result = new CustomerEntity { CountryId = 1, FullName = "Test Full Name", LastAccess = "1 minute ago" };

            return result;
        }

        /// <summary>
        /// Put Method which update an already created stored Customer into DataBase.
        /// </summary>
        /// <param name="customerId">CustomerId of the Entity we want to modify</param>
        /// <param name="customerEntity">Customer Entity Parameter</param>
        /// <returns>Customer Entity stored in DataBase with the changes</returns>
        [HttpPut("{customerId}")]
        public ActionResult<CustomerEntity> Update(int customerId, CustomerEntity customerEntity)
        {
            var result = new CustomerEntity { CountryId = 1, FullName = "Test Full Name", LastAccess = "1 minute ago" };

            return result;
        }

        /// <summary>
        /// Delete Method which insert an already created Customer into DataBase.
        /// </summary>
        /// <param name="customerId">Customer Entity Parameter</param>
        /// <returns>Customer Entity stored in DataBase</returns>
        [HttpDelete("{customerId}")]
        public async Task<IActionResult> Delete(int customerId)
        {
            var result = NoContent();

            return result;
        }
    }
}
