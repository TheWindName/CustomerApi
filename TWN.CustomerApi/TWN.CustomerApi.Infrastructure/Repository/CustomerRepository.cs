using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWN.CustomerApi.Infrastructure.Models;
using TWN.CustomerApi.Infrastructure.ObjectDataContext;

namespace TWN.CustomerApi.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        #region Private Properties

        private readonly TestDb _contextDb;

        private readonly ICountryRepository _countryRepository;

        #endregion Private Properties

        #region Constructors

        public CustomerRepository(ICountryRepository countryRepository, TestDb contextDb)
        {
            _countryRepository = countryRepository;
            this._contextDb = contextDb;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Method that add a new customer into Data Base.
        /// </summary>
        /// <param name="customer">New Customer to add into Data Base</param>
        public void AddCustomer(Customer customer)
        {
            // First we need to check the countryid
            var countryResponse = _countryRepository.GetCountryById(customer.CountryId);

            if (countryResponse != null)
            {
                // Second Add a new Customer
                _contextDb.Customer.Add(customer);

                _contextDb.SaveChanges();
            }
        }

        #endregion Public Methods
    }
}
