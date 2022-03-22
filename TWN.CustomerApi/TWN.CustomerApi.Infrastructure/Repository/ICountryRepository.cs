using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWN.CustomerApi.Entities.Country;
using TWN.CustomerApi.Infrastructure.Models;
using TWN.CustomerApi.Infrastructure.ObjectDataContext;

namespace TWN.CustomerApi.Infrastructure.Repository
{
    /// <summary>
    /// Interface Country Repository
    /// </summary>
    public interface ICountryRepository
    {
        public Country GetCountryById(int countryId);

        public List<Country> GetAllCountry();

        public Country AddCountry(CountryEntity country);
    }
}
